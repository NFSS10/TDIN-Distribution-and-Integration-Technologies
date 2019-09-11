using System;
using System.Runtime.Remoting;
using System.Configuration;
using System.Data.SqlClient;
using Remote;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Server
{
    class Server
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("Server.exe.config", false);
            Console.WriteLine("Server iniciado...");
            Console.ReadLine();
        }
    }






    public class RemoteObj : MarshalByRefObject, IUserService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.DatabaseConnectionString"].ConnectionString;
        public event AlterationDelegate AlterationEvent;

        ServerHandler serverHandler = new ServerHandler(ConfigurationManager.ConnectionStrings["Server.Properties.Settings.DatabaseConnectionString"].ConnectionString);
        


        //Register a new user
        public OpRegister RegisterUser(string name, string username, string password)
        {
            if (username == "" || password == "" || name == "")
                return OpRegister.INVALID_REGISTER_INFORMATION;

            if (serverHandler.IsUserRegisted(username))
                return OpRegister.USER_ALREADY_EXISTS;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("RegisterUserTransaction");
                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "INSERT INTO [User] values (@username, @password, @name, @balance)";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@balance", 0);
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    serverHandler.log.SaveMessage("Register: New user created - Username:"+username + " Name:"+name);
                    return OpRegister.REGISTER_SUCCESS;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    serverHandler.log.SaveMessage("ERROR: RegisterUser - Inserting into database");
                    return OpRegister.ERROR;
                }
            }            
        }

        //Verifies if the login is correct
        public Login Login(string username, string password)
        {
            Login loginRes;
            loginRes.user = null;

            if (username == "")
            {
                loginRes.opLogin = OpLogin.INVALID_USERNAME;
                return loginRes;
            }
            if (password == "")
            {
                loginRes.opLogin = OpLogin.INVALID_PASSWORD;
                return loginRes;
            }
            if (!serverHandler.IsUserRegisted(username))
            {
                loginRes.opLogin = OpLogin.USER_DOESNT_EXIST;
                return loginRes;
            }


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [User] WHERE Username = @user";
                command.Parameters.Add(new SqlParameter("@user", username));

                try
                {
                    loginRes.opLogin  = OpLogin.lOGIN_SUCCESS;

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    if (reader["Username"].ToString() != username)
                    {
                        loginRes.opLogin = OpLogin.INVALID_USERNAME;
                        reader.Close();
                        return loginRes;
                    }
                    if (reader["Password"].ToString() != password)
                    {
                        loginRes.opLogin = OpLogin.INVALID_PASSWORD;
                        reader.Close();
                        return loginRes;
                    }

                    loginRes.user = new User(reader["Name"].ToString(), reader["Username"].ToString(), (int)reader["Id"], (decimal)reader["Balance"]);
                    reader.Close();
                    serverHandler.log.SaveMessage("Login: "+username);
                    return loginRes;
                }
                catch (SqlException e)
                {
                    serverHandler.log.SaveMessage("ERROR: Login - Reading from database");
                    loginRes.opLogin = OpLogin.ERROR;
                    return loginRes;
                }
            }
        }

        //TODO
        public bool Logout()
        {
            return true;
        }


        public bool CreateNewDiginote(int userID)
        {
            return serverHandler.CreateNewDiginote(userID);
        }

        //Adds money to the user specified by his ID
        public bool AddMoney(int userID, decimal ammount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("AddMoneyTransaction");
                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "UPDATE [User] SET Balance = Balance + @newbalance WHERE Id = @id";
                command.Parameters.AddWithValue("@newbalance", ammount);
                command.Parameters.AddWithValue("@id", userID);
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    serverHandler.log.SaveMessage("Money: Added "+ammount + " to user with ID: " + userID);
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    serverHandler.log.SaveMessage("ERROR: AddMoney[user id:"+userID+"] - Inserting into database");
                    return false;
                }
            }

        }

        //Gets the number of diginotes the user has
        public int GetDiginotesNumber(int userID)
        {
            return serverHandler.GetDiginotesNumber(userID);
        }
        public List<Diginote> GetMyDiginotesIDList(int userID)
        {
            return serverHandler.GetMyDiginotesIDList(userID);
        }



        //Gets the current quota value
        public decimal GetCurrentQuote()
        {
            return serverHandler.GetCurrentQuote();
        }
        //Gets the current user balance
        public decimal GetUserBalance(int userID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Balance FROM [User] WHERE Id = @id";
                command.Parameters.Add(new SqlParameter("@id", userID));

                try
                {
                    return (decimal)command.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    serverHandler.log.SaveMessage("ERROR: Getting user ("+userID+") balance");
                    return -1;
                }
            }
        }



        //Changes the to a new quota
        public bool SetNewQuota(decimal newQuotaValue, bool isSell, int userID)
        {
            if (newQuotaValue == GetCurrentQuote())
            {
                NotifyClients(EventOperation.QUOTA_CHANGED, -1);
                return true;
            }


            if (isSell)
            {
                //Logica sell
                if (newQuotaValue > GetCurrentQuote())
                    return false;
                else
                {
                    if (SuspendOrders(60000, serverHandler.GetALLsellOrdersIDsList(), true)) //Se suspende
                    {
                        List<SellOrder> orders = GetUserSellOrdersList(userID); //Tira suspend da ultima order
                        if (orders != null)
                        {
                            List<int> order = new List<int>();
                            order.Add(orders[orders.Count - 1].id);
                            UnsuspendSellOrders(0, order, false);
                        }
                    }
                    serverHandler.ChangeQuota(newQuotaValue);
                    NotifyClients(EventOperation.QUOTA_CHANGED, -1);
                    return true;
                }

            }
            else
            {
                //Logica purchase
                if (newQuotaValue < GetCurrentQuote())
                    return false;
                else
                {
                    if (SuspendOrders(60000, serverHandler.GetALLbuyOrdersIDsList(), false))
                    {
                        List<BuyOrder> orders = GetUserBuyOrdersList(userID);
                        if (orders != null)
                        {
                            List<int> order = new List<int>();
                            order.Add(orders[orders.Count - 1].id);
                            UnsuspendBuyOrders(0, order, false);
                        }
                    }
                    serverHandler.ChangeQuota(newQuotaValue);
                    NotifyClients(EventOperation.QUOTA_CHANGED, -1);
                    return true;
                }
            }

        }




        //Emmits a sell order (should change quota with result = PARTIAL)
        public TransationResult EmmitSellOrder(int diginotesAmmount, int userId)
        {
            decimal pendingDiginotes = 0;
            List<SellOrder> userSellOrders = serverHandler.GetUserSellOrders(userId);
            if (userSellOrders != null)
            {
                for (int j = 0; j < userSellOrders.Count; j++)
                {
                    pendingDiginotes += userSellOrders[i].nDiginotes;
                }
            }
            if (diginotesAmmount > (GetDiginotesNumber(userId) - pendingDiginotes)  || diginotesAmmount < 1)
                return TransationResult.DIGINOTES_ERROR;


            //Create sell order
            int sellOrderId = serverHandler.AddSellOrder(diginotesAmmount, userId, false);
            if (sellOrderId == -1)
                return TransationResult.ERROR;



            //Is there buyers that can buy?
            List<BuyOrder> buyingOrdersIDsList = serverHandler.GetBuyingOrdersList();
            if (buyingOrdersIDsList == null)
                return TransationResult.PARTIAL;
            

            //For each buy order, see if it can fulfill atleast part, when you get full, it means I sold everything
            for (int i = 0; i < buyingOrdersIDsList.Count; i++)
            {
                if (!buyingOrdersIDsList[i].suspended)
                {
                    TransationResult transactionRes = serverHandler.MakeSellTransaction(sellOrderId, buyingOrdersIDsList[i].id);
                    NotifyClients(EventOperation.TRANSACTION, buyingOrdersIDsList[i].userID);
                    if (transactionRes == TransationResult.FULL)
                        return TransationResult.FULL;
                }
            }
            //Sold nothing
            return TransationResult.PARTIAL; 
        }





        public TransationResult EmmitPurchaseOrder(int diginotesAmmount, int userId)
        {
            //ve se tem salto suficiente para comprar
            decimal currentQuote = GetCurrentQuote();
            decimal pendingMoney = 0;
            List<BuyOrder> userBuyOrders = serverHandler.GetUserBuyOrders(userId);
            if (userBuyOrders != null)
            {
                for (int j = 0; j < userBuyOrders.Count; j++)
                {
                    pendingMoney += userBuyOrders[i].nDiginotes * currentQuote;
                }
            }
            if ((currentQuote * diginotesAmmount > (serverHandler.GetUserBalance(userId) - pendingMoney)) || (diginotesAmmount < 1))
                return TransationResult.DIGINOTES_ERROR;


            //Create sell order
            int buyOrderId = serverHandler.AddBuyOrder(diginotesAmmount, userId, false);
            if (buyOrderId == -1)
                return TransationResult.ERROR;



            //Is there buyers that can buy?
            List<SellOrder> sellingOrdersIDsList = serverHandler.GetSellingOrdersList();
            if (sellingOrdersIDsList == null)
                return TransationResult.PARTIAL;


            //For each buy order, see if it can fulfill atleast part, when you get full, it means I sold everything
            for (int i = 0; i < sellingOrdersIDsList.Count; i++)
            {
                if (!sellingOrdersIDsList[i].suspended)
                {
                    TransationResult transactionRes = serverHandler.MakeBuyTransaction(sellingOrdersIDsList[i].id, buyOrderId);
                    NotifyClients(EventOperation.TRANSACTION, sellingOrdersIDsList[i].userID);
                    if (transactionRes == TransationResult.FULL)
                        return TransationResult.FULL;
                }
            }
            //Sold nothing
            return TransationResult.PARTIAL;
        }





        public List<BuyOrder> GetUserBuyOrdersList(int userID)
        {
            return serverHandler.GetUserBuyOrders(userID);
        }
        public List<SellOrder> GetUserSellOrdersList(int userID)
        {
            return serverHandler.GetUserSellOrders(userID);
        }
        public List<Transaction> GetMyTransactions(int userID)
        {
            return serverHandler.GetMyTransactions(userID);
        }




        //Confirms the order
        public bool ConfirmPriceOfOrder(int orderID, bool isSellOrder)
        {
            List<int> orderList = new List<int>();
            orderList.Add(orderID);
            if(isSellOrder)
                return UnsuspendSellOrders(0, orderList, false); 
            else
                return UnsuspendBuyOrders(0, orderList, false);
        }

        public bool Withdraw(int orderID, bool isSellOrder)
        {
            if (isSellOrder)
                return serverHandler.RemoveSellingOrder(orderID);
            else
                return serverHandler.RemoveBuyingOrder(orderID);
        }













        //Suspend all the specified orders for time(in ms): delayMs
        bool SuspendOrders(int delayMS, List<int> ordersIDlist, bool isSellOrders)
        {
            if (ordersIDlist == null)
                return false;
            if (ordersIDlist.Count < 1)
                return false;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlTransaction transaction;
                if (isSellOrders)
                    transaction = connection.BeginTransaction("Supend_SellOrders_Transaction");
                else
                    transaction = connection.BeginTransaction("Supend_BuyOrders_Transaction");


                List<SqlCommand> commands = new List<SqlCommand>();
                if (isSellOrders)
                {
                    for (int i = 0; i < ordersIDlist.Count; i++)
                        commands.Add(serverHandler.CreateChangeSuspendState_SellOrderCommand(ordersIDlist[i], true, connection, transaction));
                }
                else
                {
                    for (int i = 0; i < ordersIDlist.Count; i++)
                        commands.Add(serverHandler.CreateChangeSuspendState_BuyOrderCommand(ordersIDlist[i], true, connection, transaction));
                }


                try
                {
                    foreach (SqlCommand command in commands)
                        command.ExecuteNonQuery();

                    transaction.Commit();
                    serverHandler.log.SaveMessage("Suspended Orders: Orders suspended for " + delayMS + "ms");
                    StartUnsuspendOrdersTask(delayMS, ordersIDlist, isSellOrders);
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    serverHandler.log.SaveMessage("ERROR: SuspendOrders - Updating the orders suspended state");
                    return false;
                }
            }
        }

        //Start a task of unsuspending orders after time(in ms): delayMs
        void StartUnsuspendOrdersTask(int delayMS, List<int> ordersIDlist, bool isSellOrders)
        {
            if (isSellOrders)
            {
                Thread oThread = new Thread(new ThreadStart(() => { UnsuspendSellOrders(delayMS, ordersIDlist, true); }));
                oThread.Start();
            }
            else
            {
                Thread oThread = new Thread(new ThreadStart(() => { UnsuspendBuyOrders(delayMS, ordersIDlist, true); }));
                oThread.Start();
            }
        }

        public bool UnsuspendSellOrders(int delayMS, List<int> ordersIDlis, bool useDelay)
        {
            if(useDelay)
                Thread.Sleep(delayMS);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction("Unsupend_SellOrders_Transaction");

                List<SqlCommand> commands = new List<SqlCommand>();
                for (int i = 0; i < ordersIDlis.Count; i++)
                    commands.Add(serverHandler.CreateChangeSuspendState_SellOrderCommand(ordersIDlis[i], false, connection, transaction));

                try
                {
                    foreach (SqlCommand command in commands)
                        command.ExecuteNonQuery();

                    transaction.Commit();
                    serverHandler.log.SaveMessage("Unsuspended Orders: Sell Orders unsuspended");
                    NotifyClients(EventOperation.UNSUSPEND, -5);
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    serverHandler.log.SaveMessage("ERROR: UnsuspendSellOrders - Updating the orders suspended state");
                    return false;
                }
            }
        }
        public bool UnsuspendBuyOrders(int delayMS, List<int> ordersIDlis, bool useDelay)
        {
            if (useDelay)
                Thread.Sleep(delayMS);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction("Unsupend_BuyOrders_Transaction");

                List<SqlCommand> commands = new List<SqlCommand>();
                for (int i = 0; i < ordersIDlis.Count; i++)
                    commands.Add(serverHandler.CreateChangeSuspendState_BuyOrderCommand(ordersIDlis[i], false, connection, transaction));

                try
                {
                    foreach (SqlCommand command in commands)
                        command.ExecuteNonQuery();

                    transaction.Commit();
                    serverHandler.log.SaveMessage("Unsuspended Orders: Buy Orders unsuspended");
                    NotifyClients(EventOperation.UNSUSPEND, -5);
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    serverHandler.log.SaveMessage("ERROR: UnsuspendBuyOrders - Updating the orders suspended state");
                    return false;
                }
            }
        }






        //Notifies clients of an alteration
        private void NotifyClients(EventOperation op, int userID)
        {
            if (AlterationEvent != null)
            {
                Delegate[] invkList = AlterationEvent.GetInvocationList();

                foreach (AlterationDelegate handler in invkList)
                {
                    try
                    {
                        handler(op, userID);
                        serverHandler.log.SaveMessage("NotifyClients: Invoking event handler: "+op + " - user: "+userID);
                    }
                    catch (Exception)
                    {
                        AlterationEvent -= handler;
                        serverHandler.log.SaveMessage("Exception: Removed an event handler");
                    }
                }
            }
        }





        //DEBUG: Testes
        int i = 0;
        public void TesteFunc()
        {
            serverHandler.log.SaveMessage("TestFunc chamada com sucesso !!!! ");
            i++;

            serverHandler.TestesTransaction();

            //serverHandler.log.SaveMessage("new log test");
            //serverHandler.StartUnsuspendOrdersTask(1000, null, true);
            //serverHandler.StartUnsuspendOrdersTask(5000, null, false);
            //serverHandler.StartUnsuspendOrdersTask(2000, null, true);

            //NotifyClients(i, "(" + i + ")");
        }
        public void TestQuotaval(decimal val)
        {
            serverHandler.ChangeQuota(val);
        }


    }











}
