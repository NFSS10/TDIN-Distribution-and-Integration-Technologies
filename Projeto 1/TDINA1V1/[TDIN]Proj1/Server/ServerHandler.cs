using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Remote;


namespace Server
{
    class ServerHandler
    {
        public Log log { get; }
        string connectionString;

        public ServerHandler(string connectionString)
        {
            this.connectionString = connectionString;
            log = new Log();
        }




        //Verifies if User is already registed (search by username)
        public bool IsUserRegisted(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [User] WHERE Username = @user";
                command.Parameters.Add(new SqlParameter("@user", username));

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        reader.Close();
                        return true;
                    }
                    else return false;
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: Verifying User existence - Reading from database");
                    return true;
                }
            }
        }
        //Verifies if User is already registed (search by id)
        public bool IsUserRegisted(int userID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [User] WHERE Id = @uId";
                command.Parameters.Add(new SqlParameter("@uId", userID));

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        reader.Close();
                        return true;
                    }
                    else return false;
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: Verifying User existence - Reading from database");
                    return true;
                }
            }
        }



        //Creates new diginote and adds it to the user specified
        public bool CreateNewDiginote(int userId)
        {
            if (!IsUserRegisted(userId))
                return false;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("CreateNewDiginoteTransaction");
                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "INSERT INTO [Diginote] values (@OwnerUser)";
                command.Parameters.AddWithValue("@OwnerUser", userId);
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    log.SaveMessage("Diginote: Added new diginote" + " to user with ID: " + userId);
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    log.SaveMessage("ERROR: CreateNewDiginote - Inserting into database");
                    return false;
                }
            }
        }


        //Changes te quota value in the DB
        public bool ChangeQuota(decimal newQuotaValue)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("QuotaChangeTransaction");
                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "UPDATE [Quota] SET Value = @newQuotaValue WHERE Id = @id";
                command.Parameters.AddWithValue("@newQuotaValue", newQuotaValue);
                command.Parameters.AddWithValue("@id", 1);
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    log.SaveMessage("Quota: Quota value changed to " + newQuotaValue);
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    log.SaveMessage("ERROR: Changing quota value");
                    return false;
                }
            }
        }






        //Adds a new SellOrder to the DB
        public int AddSellOrder(int nDiginotes, int userId, bool suspended)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction = connection.BeginTransaction("AddSellOrderTransaction");

                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "INSERT INTO [SellingOrders] OUTPUT INSERTED.Id values (@UserID, @NumberDiginotes, @Suspended)";
                command.Parameters.AddWithValue("@UserID", userId);
                command.Parameters.AddWithValue("@NumberDiginotes", nDiginotes);
                command.Parameters.AddWithValue("@Suspended", suspended);


                try
                {
                    Int32 orderID = (Int32)command.ExecuteScalar();
                    transaction.Commit();
                    log.SaveMessage("Sell Order: New pending sellOrder created - UserId:" + userId + " nDiginotes:" + nDiginotes + " SellorderID:" + orderID);
                    return orderID;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    log.SaveMessage("ERROR: AddSellOrder - Inserting into database");
                    return -1;
                }
            }
        }

        //Adds a new BuyOrder to the DB
        public int AddBuyOrder(int nDiginotes, int userId, bool suspended)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction = connection.BeginTransaction("AddBuyOrderTransaction");

                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "INSERT INTO [BuyingOrders] OUTPUT INSERTED.Id values (@UserID, @NumberDiginotes, @Suspended)";
                command.Parameters.AddWithValue("@UserID", userId);
                command.Parameters.AddWithValue("@NumberDiginotes", nDiginotes);
                command.Parameters.AddWithValue("@Suspended", suspended);


                try
                {
                    Int32 orderID = (Int32)command.ExecuteScalar();
                    transaction.Commit();
                    log.SaveMessage("Buy Order: New pending BuyOrder created - UserId:" + userId + " nDiginotes:" + nDiginotes + " BuyorderID:" + orderID);
                    return orderID;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    log.SaveMessage("ERROR: AddBuyOrder - Inserting into database");
                    return -1;
                }
            }
        }

        //Removes a SellOrder from the DB
        public bool RemoveBuyingOrder(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("RemoveBuyingOrderTransaction");
                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "DELETE FROM [BuyingOrders] WHERE Id = @orderId";
                command.Parameters.AddWithValue("@orderId", orderId);
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    log.SaveMessage("Buying Order: BuyingOrder deleted");
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    log.SaveMessage("ERROR: RemoveBuyingOrder - Deleting from database");
                    return false;
                }
            }
        }
        //Removes a BuyOrder from the DB
        public bool RemoveSellingOrder(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("RemoveSellingOrderTransaction");
                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "DELETE FROM [SellingOrders] WHERE Id = @orderId";
                command.Parameters.AddWithValue("@orderId", orderId);
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    log.SaveMessage("Selling Order: SellingOrder deleted");
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    log.SaveMessage("ERROR: RemoveSellingOrder - Deleting from database");
                    return false;
                }
            }
        }

        //Decreases a SellOrder from the DB
        public bool DecreaseBuyingOrderAmount(int orderId, int amount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("DecreaseBuyingAmountTransaction");
                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "UPDATE [BuyingOrders] SET NumberDiginotes = NumberDiginotes - @amount WHERE Id = @id";
                command.Parameters.AddWithValue("@amount", amount);
                command.Parameters.AddWithValue("@id", orderId);
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    log.SaveMessage("BuyingOrder: Removed " + amount + " to BuyingOrder with ID: " + orderId);
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    log.SaveMessage("ERROR: DecreaseBuyingOrderAmount - Removing " + amount + "to BuyingOrder with ID: " + orderId);
                    return false;
                }
            }
        }
        //Decreases a BuyOrder from the DB
        public bool DecreaseSellingOrderAmount(int orderId, int amount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("DecreaseSellingAmountTransaction");
                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "UPDATE [SellingOrders] SET NumberDiginotes = NumberDiginotes - @amount WHERE Id = @id";
                command.Parameters.AddWithValue("@amount", amount);
                command.Parameters.AddWithValue("@id", orderId);
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    log.SaveMessage("SellingOrder: Removed " + amount + " to SellingOrder with ID: " + orderId);
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    log.SaveMessage("ERROR: DecreaseSellingOrderAmount - Removing " + amount + "to SellingOrder with ID: " + orderId);
                    return false;
                }
            }
        }

        public decimal GetCurrentQuote()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Value FROM [Quota] WHERE Id = @id";
                command.Parameters.Add(new SqlParameter("@id", 1));

                try
                {
                    return (decimal)command.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: Getting current quota");
                    return -1;
                }
            }
        }




        public TransationResult MakeSellTransaction(int sellOrderId, int buyOrderId)
        {
            SellOrder sellOrder = GetSellingOrder(sellOrderId);
            BuyOrder buyOrder = GetBuyingOrder(buyOrderId);
            decimal currentQuote = GetCurrentQuote();

            if (sellOrder != null && buyOrder != null && currentQuote != -1)
            {
                if (sellOrder.userID == buyOrder.userID) //cant trade with yourself
                    return TransationResult.PARTIAL;


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction("SellTransaction");
                    List<SqlCommand> commands = new List<SqlCommand>();
                    List<Diginote> sellerDiginotes = GetMyDiginotesIDList(sellOrder.userID);
                    if (sellOrder.nDiginotes == buyOrder.nDiginotes) //sellOrder == buyIOrder 
                    {   
                        for (int i = 0; i < sellOrder.nDiginotes; i++)
                        {
                            commands.Add(CreateAddTransactionCommand(sellOrder.userID, buyOrder.userID, sellerDiginotes[i].id, currentQuote, connection, transaction));
                        }
                        commands.Add(CreateTransferCommand(buyOrder.userID, sellOrder.userID, buyOrder.nDiginotes, connection, transaction));
                        commands.Add(CreateDepositMoneyCommand(sellOrder.userID, sellOrder.nDiginotes * currentQuote, connection, transaction));
                        commands.Add(CreateWithdrawMoneyCommand(buyOrder.userID, sellOrder.nDiginotes * currentQuote, connection, transaction));
                        commands.Add(CreateRevomeSellOrderCommand(sellOrderId, connection, transaction));
                        commands.Add(CreateRevomeBuyOrderCommand(buyOrderId, connection, transaction));

                        try
                        {
                            foreach (SqlCommand command in commands)
                                command.ExecuteNonQuery();

                            transaction.Commit();
                            log.SaveMessage("SellTransaction: Transfered " + buyOrder.nDiginotes + " from (" + sellOrder.userID + ") to (" + buyOrder.userID + ")");
                            return TransationResult.FULL;
                        }
                        catch (SqlException e)
                        {
                            transaction.Rollback();
                            log.SaveMessage("ERROR: SellOrder - Making a sell - sellDiginotes == buyDiginotes");
                            return TransationResult.ERROR;
                        }
                    }
                    else //one order bigger than the other
                    {

                        if (sellOrder.nDiginotes < buyOrder.nDiginotes) //sellOrder < buyOrder
                        {
                            for (int i = 0; i < sellOrder.nDiginotes; i++)
                            {
                                commands.Add(CreateAddTransactionCommand(sellOrder.userID, buyOrder.userID, sellerDiginotes[i].id, currentQuote, connection, transaction));
                            }
                            commands.Add(CreateTransferCommand(buyOrder.userID, sellOrder.userID, sellOrder.nDiginotes, connection, transaction));
                            commands.Add(CreateDepositMoneyCommand(sellOrder.userID, sellOrder.nDiginotes * currentQuote, connection, transaction));
                            commands.Add(CreateWithdrawMoneyCommand(buyOrder.userID, sellOrder.nDiginotes * currentQuote, connection, transaction));
                            commands.Add(CreateDecreaseBuyOrderCommand(buyOrderId, sellOrder.nDiginotes, connection, transaction));
                            commands.Add(CreateRevomeSellOrderCommand(sellOrderId, connection, transaction));
                            try
                            {
                                foreach (SqlCommand command in commands)
                                    command.ExecuteNonQuery();

                                transaction.Commit();
                                log.SaveMessage("SellTransaction: Transfered " + sellOrder.nDiginotes + " from (" + sellOrder.userID + ") to (" + buyOrder.userID + ")");
                                return TransationResult.FULL;
                            }
                            catch (SqlException e)
                            {
                                transaction.Rollback();
                                log.SaveMessage("ERROR: SellOrder - Making a sell - sellDiginotes < buyDiginotes");
                                return TransationResult.ERROR;
                            }
                        }
                        else  //sellOrder > buyOrder
                        {
                            for (int i = 0; i < buyOrder.nDiginotes; i++)
                            {
                                commands.Add(CreateAddTransactionCommand(sellOrder.userID, buyOrder.userID, sellerDiginotes[i].id, currentQuote, connection, transaction));
                            }
                            commands.Add(CreateTransferCommand(buyOrder.userID, sellOrder.userID, buyOrder.nDiginotes, connection, transaction));
                            commands.Add(CreateDepositMoneyCommand(sellOrder.userID, buyOrder.nDiginotes * currentQuote, connection, transaction));
                            commands.Add(CreateWithdrawMoneyCommand(buyOrder.userID, buyOrder.nDiginotes * currentQuote, connection, transaction));
                            commands.Add(CreateDecreaseSellOrderCommand(sellOrderId, buyOrder.nDiginotes, connection, transaction));
                            commands.Add(CreateRevomeBuyOrderCommand(buyOrderId, connection, transaction));
                            try
                            {
                                foreach (SqlCommand command in commands)
                                    command.ExecuteNonQuery();

                                transaction.Commit();
                                return TransationResult.PARTIAL;
                            }
                            catch (SqlException e)
                            {
                                transaction.Rollback();
                                log.SaveMessage("ERROR: SellOrder - Making a sell - sellDiginotes > buyDiginotes");
                                return TransationResult.ERROR;
                            }
                        }
                    }
                }
            }
            else
            {
                log.SaveMessage("ERROR: SellOrder - Making a sell > nulls");
                return TransationResult.ERROR;
            }
        }


        //Gets a list of all the BuyingOrders
        public List<BuyOrder> GetBuyingOrdersList()
        {
            List<BuyOrder> buyingOrders = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [BuyingOrders]";

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (buyingOrders == null)
                            buyingOrders = new List<BuyOrder>();
                        buyingOrders.Add(new BuyOrder((int)reader["Id"], (int)reader["UserID"], (int)reader["NumberDiginotes"], (bool)reader["Suspended"]));
                    }
                    reader.Close();
                    return buyingOrders;
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: GetBuyingOrdersList - Reading from database");
                    return null;
                }
            }
        }

        public List<SellOrder> GetSellingOrdersList()
        {
            List<SellOrder> sellingOrders = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [SellingOrders]";

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (sellingOrders == null)
                            sellingOrders = new List<SellOrder>();
                        sellingOrders.Add(new SellOrder((int)reader["Id"], (int)reader["UserID"], (int)reader["NumberDiginotes"], (bool)reader["Suspended"]));
                    }
                    reader.Close();
                    return sellingOrders;
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: GetSellingOrdersList - Reading from database");
                    return null;
                }
            }
        }





        public List<BuyOrder> GetUserBuyOrders(int userId)
        {
            List<BuyOrder> buyingOrders = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [BuyingOrders] WHERE UserId = @userId";
                command.Parameters.AddWithValue("@userId", userId);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (buyingOrders == null)
                            buyingOrders = new List<BuyOrder>();
                        buyingOrders.Add(new BuyOrder((int)reader["Id"], (int)reader["UserID"], (int)reader["NumberDiginotes"], (bool)reader["Suspended"]));
                    }
                    reader.Close();
                    return buyingOrders;
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: GetBuyingOrdersList - Reading from database");
                    return null;
                }
            }
        }

        public List<SellOrder> GetUserSellOrders(int userId)
        {
            List<SellOrder> sellOrders = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [SellingOrders] WHERE UserId = @userId";
                command.Parameters.AddWithValue("@userId", userId);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (sellOrders == null)
                            sellOrders = new List<SellOrder>();
                        sellOrders.Add(new SellOrder((int)reader["Id"], (int)reader["UserID"], (int)reader["NumberDiginotes"], (bool)reader["Suspended"]));
                    }
                    reader.Close();
                    return sellOrders;
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: GetSellingOrdersList - Reading from database");
                    return null;
                }
            }
        }
       


        public TransationResult MakeBuyTransaction(int sellOrderId, int buyOrderId)
        {
            SellOrder sellOrder = GetSellingOrder(sellOrderId);
            BuyOrder buyOrder = GetBuyingOrder(buyOrderId);
            decimal currentQuote = GetCurrentQuote();

            if (sellOrder != null && buyOrder != null && currentQuote != -1)
            {
                if (sellOrder.userID == buyOrder.userID) //cant trade with yourself
                    return TransationResult.PARTIAL;


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction("SellTransaction");
                    List<SqlCommand> commands = new List<SqlCommand>();
                    List<Diginote> sellerDiginotes = GetMyDiginotesIDList(sellOrder.userID);

                    if (sellOrder.nDiginotes == buyOrder.nDiginotes) //sellOrder == buyIOrder 
                    {
                        for (int i = 0; i < sellOrder.nDiginotes; i++)
                        {
                            commands.Add(CreateAddTransactionCommand(sellOrder.userID, buyOrder.userID, sellerDiginotes[i].id, currentQuote, connection, transaction));
                        }
                        commands.Add(CreateTransferCommand(buyOrder.userID, sellOrder.userID, buyOrder.nDiginotes, connection, transaction));
                        commands.Add(CreateDepositMoneyCommand(sellOrder.userID, buyOrder.nDiginotes * currentQuote, connection, transaction));
                        commands.Add(CreateWithdrawMoneyCommand(buyOrder.userID, buyOrder.nDiginotes * currentQuote, connection, transaction));
                        commands.Add(CreateRevomeSellOrderCommand(sellOrderId, connection, transaction));
                        commands.Add(CreateRevomeBuyOrderCommand(buyOrderId, connection, transaction));

                        try
                        {
                            foreach (SqlCommand command in commands)
                                command.ExecuteNonQuery();

                            transaction.Commit();
                            log.SaveMessage("BuyTransaction: Transfered " + buyOrder.nDiginotes + " from (" + sellOrder.userID + ") to (" + buyOrder.userID + ")");
                            return TransationResult.FULL;
                        }
                        catch (SqlException e)
                        {
                            transaction.Rollback();
                            log.SaveMessage("ERROR: BuyOrder - Making a buy - sellDiginotes == buyDiginotes");
                            return TransationResult.ERROR;
                        }
                    }
                    else //one order bigger than the other
                    {

                        if (buyOrder.nDiginotes < sellOrder.nDiginotes) //buyOrder < sellOrder
                        {
                            for (int i = 0; i < buyOrder.nDiginotes; i++)
                            {
                                commands.Add(CreateAddTransactionCommand(sellOrder.userID, buyOrder.userID, sellerDiginotes[i].id, currentQuote, connection, transaction));
                            }
                            commands.Add(CreateTransferCommand(buyOrder.userID, sellOrder.userID, buyOrder.nDiginotes, connection, transaction));
                            commands.Add(CreateDepositMoneyCommand(sellOrder.userID, buyOrder.nDiginotes * currentQuote, connection, transaction));
                            commands.Add(CreateWithdrawMoneyCommand(buyOrder.userID, buyOrder.nDiginotes * currentQuote, connection, transaction));
                            commands.Add(CreateDecreaseSellOrderCommand(sellOrderId, buyOrder.nDiginotes, connection, transaction));
                            commands.Add(CreateRevomeBuyOrderCommand(buyOrderId, connection, transaction));
                            try
                            {
                                foreach (SqlCommand command in commands)
                                    command.ExecuteNonQuery();

                                transaction.Commit();
                                log.SaveMessage("BuyTransaction: Transfered " + buyOrder.nDiginotes + " from (" + sellOrder.userID + ") to (" + buyOrder.userID + ")");
                                return TransationResult.FULL;
                            }
                            catch (SqlException e)
                            {
                                transaction.Rollback();
                                log.SaveMessage("ERROR: BuyOrder - Making a buy - sellDiginotes < buyDiginotes");
                                return TransationResult.ERROR;
                            }
                        }
                        else  //buyOrder > sellOrder
                        {
                            for (int i = 0; i < sellOrder.nDiginotes; i++)
                            {
                                commands.Add(CreateAddTransactionCommand(sellOrder.userID, buyOrder.userID, sellerDiginotes[i].id, currentQuote, connection, transaction));
                            }
                            commands.Add(CreateTransferCommand(buyOrder.userID, sellOrder.userID, sellOrder.nDiginotes, connection, transaction));
                            commands.Add(CreateDepositMoneyCommand(sellOrder.userID, sellOrder.nDiginotes * currentQuote, connection, transaction));
                            commands.Add(CreateWithdrawMoneyCommand(buyOrder.userID, sellOrder.nDiginotes * currentQuote, connection, transaction));
                            commands.Add(CreateDecreaseBuyOrderCommand(buyOrderId, sellOrder.nDiginotes, connection, transaction));
                            commands.Add(CreateRevomeSellOrderCommand(sellOrderId, connection, transaction));
                            try
                            {
                                foreach (SqlCommand command in commands)
                                    command.ExecuteNonQuery();

                                transaction.Commit();
                                return TransationResult.PARTIAL;
                            }
                            catch (SqlException e)
                            {
                                transaction.Rollback();
                                log.SaveMessage("ERROR: BuyOrder - Making a sell - sellDiginotes > buyDiginotes");
                                return TransationResult.ERROR;
                            }
                        }
                    }
                }
            }
            else
            {
                log.SaveMessage("ERROR: BuyOrder - Making a buy > nulls");
                return TransationResult.ERROR;
            }
        }

        public decimal GetUserBalance(int userId)
        {
            decimal balance = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Balance FROM [User] WHERE Id= @id";
                command.Parameters.AddWithValue("@id", userId);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                        balance = (decimal)reader["Balance"];
                    reader.Close();

                    return balance;
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: GetBuyingOrder - Reading from database");
                    return -1;
                }
            }
        }
        public SqlCommand CreateWithdrawMoneyCommand(int userToWithdraw, decimal amount, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.Transaction = transaction;
            command.CommandText = "UPDATE [User] SET Balance = Balance - @newbalance WHERE Id = @id";
            command.Parameters.AddWithValue("@id", userToWithdraw);
            command.Parameters.AddWithValue("@newbalance", amount);
            return command;
        }
        public SqlCommand CreateDepositMoneyCommand(int userToDeposit, decimal amount, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.Transaction = transaction;
            command.CommandText = "UPDATE [User] SET Balance = Balance + @newbalance WHERE Id = @id";
            command.Parameters.AddWithValue("@id", userToDeposit);
            command.Parameters.AddWithValue("@newbalance", amount);
            return command;
        }
        //Gets information about BuyingOrder of the specified ID
        public BuyOrder GetBuyingOrder(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [BuyingOrders] WHERE Id= @id";
                command.Parameters.AddWithValue("@id", orderId);

                BuyOrder buyOrder = null;
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                        buyOrder = new BuyOrder((int)reader["Id"], (int)reader["UserID"], (int)reader["NumberDiginotes"], (bool)reader["Suspended"]);
                    reader.Close();

                    return buyOrder;
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: GetBuyingOrder - Reading from database");
                    return null;
                }
            }
        }

        //Gets information about SellOrder of the specified ID
        public SellOrder GetSellingOrder(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [SellingOrders] WHERE Id= @id";
                command.Parameters.AddWithValue("@id", orderId);

                SellOrder sellOrder = null;
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                        sellOrder = new SellOrder((int)reader["Id"], (int)reader["UserID"], (int)reader["NumberDiginotes"], (bool)reader["Suspended"]);
                    reader.Close();

                    return sellOrder;
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: GetSellingOrder - Reading from database");
                    return null;
                }
            }
        }
        //Gets a list of all the SellOrders
        public List<SellOrder> GetSellOrdersList()
        {
            List<SellOrder> sellOrders = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [SellingOrders]";

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (sellOrders == null)
                            sellOrders = new List<SellOrder>();
                        sellOrders.Add(new SellOrder((int)reader["Id"], (int)reader["UserID"], (int)reader["NumberDiginotes"], (bool)reader["Suspended"]));
                    }
                    reader.Close();
                    return sellOrders;
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: GetSellOrdersList - Reading from database");
                    return null;
                }
            }
        }

        public int GetDiginotesNumber(int userID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(Id) FROM [Diginote] WHERE OwnerUser = @userID";
                command.Parameters.Add(new SqlParameter("@userID", userID));

                try
                {
                    return (Int32)command.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: Getting Diginotes ammount of user: " + userID);
                    return -1;
                }

            }
        }

        public int GetNDiginotesTransactions()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(Id) FROM [Trasactions]";

                try
                {
                    return (Int32)command.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: Getting Transfers ammount");
                    return -1;
                }

            }

        }

        public List<Diginote> GetMyDiginotesIDList(int userID)
        {
            List<Diginote> diginotesIDs = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [Diginote] WHERE OwnerUser = @userID";
                command.Parameters.Add(new SqlParameter("@userID", userID));

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (diginotesIDs == null)
                            diginotesIDs = new List<Diginote>();
                        diginotesIDs.Add(new Diginote((int)reader["Id"], (int)reader["OwnerUser"]));
                    }
                    reader.Close();
                    return diginotesIDs;
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: GetMyDiginotesIDList of user: " + userID);
                    return null;
                }

            }
        }


        public List<Transaction> GetMyTransactions(int userID)
        {
            List<Transaction> transactionsList = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [Trasactions] WHERE FromID = @userID OR ToID = @userID";
                command.Parameters.Add(new SqlParameter("@userID", userID));

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (transactionsList == null)
                            transactionsList = new List<Transaction>();
                        transactionsList.Add(new Transaction((int)reader["Id"], (int)reader["FromID"], (int)reader["ToID"], (int)reader["DiginoteID"], ((DateTime)(reader["Date"])).ToString("yyyy/MM/dd HH:mm:ss:FFF"), (decimal)reader["TransactionQuota"]));
                    }
                    reader.Close();
                    return transactionsList;
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: GetMyTransactions of user: " + userID);
                    return null;
                }

            }
        }




        public List<int> GetALLsellOrdersIDsList()
        {
            List<int> sellOrders = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [SellingOrders]";

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (sellOrders == null)
                            sellOrders = new List<int>();
                        sellOrders.Add((int)reader["Id"]);
                    }
                    reader.Close();
                    return sellOrders;
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: GetALLsellOrdersIDsList - Reading from database");
                    return null;
                }
            }
        }

        public List<int> GetALLbuyOrdersIDsList()
        {
            List<int> buyingOrders = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [BuyingOrders]";

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (buyingOrders == null)
                            buyingOrders = new List<int>();
                        buyingOrders.Add((int)reader["Id"]);
                    }
                    reader.Close();
                    return buyingOrders;
                }
                catch (SqlException e)
                {
                    log.SaveMessage("ERROR: GetALLbuyOrdersIDsList - Reading from database");
                    return null;
                }
            }
        }


        SqlCommand CreateDecreaseBuyOrderCommand(int buyOrderId, object amount, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand commandTransfer = connection.CreateCommand();
            commandTransfer.Connection = connection;
            commandTransfer.Transaction = transaction;
            commandTransfer.CommandText = "UPDATE [BuyingOrders] set NumberDiginotes = NumberDiginotes - @amount WHERE Id = @buyOrderId";
            commandTransfer.Parameters.AddWithValue("@amount", amount);
            commandTransfer.Parameters.AddWithValue("@buyOrderId", buyOrderId);
            return commandTransfer;
        }
        SqlCommand CreateDecreaseSellOrderCommand(int sellOrderId, object amount, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand commandTransfer = connection.CreateCommand();
            commandTransfer.Connection = connection;
            commandTransfer.Transaction = transaction;
            commandTransfer.CommandText = "UPDATE [SellingOrders] set NumberDiginotes = NumberDiginotes - @amount WHERE Id = @sellOrderId";
            commandTransfer.Parameters.AddWithValue("@amount", amount);
            commandTransfer.Parameters.AddWithValue("@sellOrderId", sellOrderId);
            return commandTransfer;
        }

        SqlCommand CreateTransferCommand(int buyerId, int sellerId, int amount, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand commandTransfer = connection.CreateCommand();
            commandTransfer.Connection = connection;
            commandTransfer.Transaction = transaction;
            commandTransfer.CommandText = "UPDATE TOP (@nDiginotes) [Diginote] set OwnerUser = @buyerId WHERE OwnerUser = @sellerId";
            commandTransfer.Parameters.AddWithValue("@buyerId", buyerId);
            commandTransfer.Parameters.AddWithValue("@sellerId", sellerId);
            commandTransfer.Parameters.AddWithValue("@nDiginotes", amount);
            return commandTransfer;
        }

        SqlCommand CreateAddTransactionCommand(int sellerId, int buyerId, int diginoteId, decimal transactionQuota, SqlConnection connection, SqlTransaction transaction)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            SqlCommand commandTransaction = connection.CreateCommand();
            commandTransaction.Connection = connection;
            commandTransaction.Transaction = transaction;
            commandTransaction.CommandText = "INSERT INTO[Trasactions] values(@FromId,@ToId,@DiginoteId,@Date,@TransactionQuota)";
            commandTransaction.Parameters.AddWithValue("@FromId", sellerId);
            commandTransaction.Parameters.AddWithValue("@ToId", buyerId);
            commandTransaction.Parameters.AddWithValue("@DiginoteId", diginoteId);
            commandTransaction.Parameters.AddWithValue("@Date", sqlFormattedDate);
            commandTransaction.Parameters.AddWithValue("@TransactionQuota", transactionQuota);
            return commandTransaction;
        }

        SqlCommand CreateRevomeSellOrderCommand(int sellOrderId, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand commandTransfer = connection.CreateCommand();
            commandTransfer.Connection = connection;
            commandTransfer.Transaction = transaction;
            commandTransfer.CommandText = "DELETE FROM [SellingOrders] WHERE Id = @orderId";
            commandTransfer.Parameters.AddWithValue("@orderId", sellOrderId);
            return commandTransfer;
        }
        SqlCommand CreateRevomeBuyOrderCommand(int buyOrderId, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand commandTransfer = connection.CreateCommand();
            commandTransfer.Connection = connection;
            commandTransfer.Transaction = transaction;
            commandTransfer.CommandText = "DELETE FROM [BuyingOrders] WHERE Id = @orderId";
            commandTransfer.Parameters.AddWithValue("@orderId", buyOrderId);
            return commandTransfer;
        }


        public SqlCommand CreateChangeSuspendState_BuyOrderCommand(int buyOrderId, bool suspendedState, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand commandTransfer = connection.CreateCommand();
            commandTransfer.Connection = connection;
            commandTransfer.Transaction = transaction;
            commandTransfer.CommandText = "UPDATE [BuyingOrders] set Suspended = @state WHERE Id = @buyOrderId";
            commandTransfer.Parameters.AddWithValue("@state", suspendedState);
            commandTransfer.Parameters.AddWithValue("@buyOrderId", buyOrderId);
            return commandTransfer;
        }
        public SqlCommand CreateChangeSuspendState_SellOrderCommand(int sellOrderId, bool suspendedState, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand commandTransfer = connection.CreateCommand();
            commandTransfer.Connection = connection;
            commandTransfer.Transaction = transaction;
            commandTransfer.CommandText = "UPDATE [SellingOrders] set Suspended = @state WHERE Id = @sellOrderId";
            commandTransfer.Parameters.AddWithValue("@state", suspendedState);
            commandTransfer.Parameters.AddWithValue("@sellOrderId", sellOrderId);
            return commandTransfer;
        }

    



        //DEBUG: Testes
        public void TestesTransaction()
        {
            Console.WriteLine("\n\nSell Order tests"); //Buy order tests
            //Adicionar sellorders
            if (GetSellingOrder(1) == null)
                Console.WriteLine("Teste 1: OK");
            else
                Console.WriteLine("Teste 1: ERROR");

            AddSellOrder(2, 2, false);
            if (GetSellingOrder(1) == null)
                Console.WriteLine("Teste 2: ERROR");
            else
                Console.WriteLine("Teste 2: OK");

            //Modificar sell orders
            if(GetSellingOrder(1).nDiginotes == 2)
                Console.WriteLine("Teste 3: OK");
            else
                Console.WriteLine("Teste 3: ERROR");

            DecreaseSellingOrderAmount(1, 1);
            if (GetSellingOrder(1).nDiginotes == 1)
                Console.WriteLine("Teste 4: OK");
            else
                Console.WriteLine("Teste 4: ERROR");

            //Remover sellorders
            RemoveSellingOrder(1);
            if (GetSellingOrder(1) == null)
                Console.WriteLine("Teste 5: OK");
            else
                Console.WriteLine("Teste 5: ERROR");



            Console.WriteLine("\n\nBuy Order tests"); //Buy order tests
            //Adicionar buyorders
            if (GetBuyingOrder(1) == null)
                Console.WriteLine("Teste 6: OK");
            else
                Console.WriteLine("Teste 6: ERROR");

            AddBuyOrder(2, 2, false);
            if (GetBuyingOrder(1) == null)
                Console.WriteLine("Teste 7: ERROR");
            else
                Console.WriteLine("Teste 7: OK");

            //Modificar buy orders
            if (GetBuyingOrder(1).nDiginotes == 2)
                Console.WriteLine("Teste 8: OK");
            else
                Console.WriteLine("Teste 8: ERROR");

            DecreaseBuyingOrderAmount(1, 1);
            if (GetBuyingOrder(1).nDiginotes == 1)
                Console.WriteLine("Teste 9: OK");
            else
                Console.WriteLine("Teste 9: ERROR");

            //Remover buy orders
            RemoveBuyingOrder(1);
            if (GetBuyingOrder(1) == null)
                Console.WriteLine("Teste 10: OK");
            else
                Console.WriteLine("Teste 10: ERROR");


            //Criar diginotes / adiciona 100 diginotes a PAULAO E NFSS10
            for (int j = 0; j< 100; j++)
            {
                CreateNewDiginote(5);
                CreateNewDiginote(2);
            }
            Console.WriteLine("\n\nSell Transaction tests"); //Sell transaction test
            //Full sell == buy
            AddBuyOrder(10, 2, false); //NFSS10 quer comprar 10
            AddSellOrder(10, 5, false); //PAULAO quer vender 10
            if ((MakeSellTransaction(2, 2) == TransationResult.FULL) && (GetBuyingOrder(2) == null) && (GetSellingOrder(2) == null) && GetNDiginotesTransactions() == 10) //vende tudo
                Console.WriteLine("Teste 11: OK");
            else
                Console.WriteLine("Teste 11: ERROR");

            //Partial sell < buy
            AddBuyOrder(10, 2, false); //NFSS10 quer comprar 10
            AddSellOrder(5, 5, false); //PAULAO quer vender 5
            if ((MakeSellTransaction(3, 3) == TransationResult.FULL) && (GetBuyingOrder(3).nDiginotes == 5) && (GetSellingOrder(3) == null && GetNDiginotesTransactions() == 15)) //vende tudo
                Console.WriteLine("Teste 12: OK");
            else
                Console.WriteLine("Teste 12: ERROR");
            RemoveBuyingOrder(3);//limpa teste

            //Partial sell > buy
            AddBuyOrder(5, 2, false); //NFSS10 quer comprar 5
            AddSellOrder(10, 5, false); //PAULAO quer vender 10
            if ((MakeSellTransaction(4, 4) == TransationResult.PARTIAL) && (GetBuyingOrder(4) == null) && (GetSellingOrder(4).nDiginotes == 5 && GetNDiginotesTransactions() == 20)) //vende parcialmente
                Console.WriteLine("Teste 13: OK");
            else
                Console.WriteLine("Teste 13: ERROR");
            RemoveSellingOrder(4);//limpa teste


            /*
             * Mudado funcoes de ServerHandler para Server
             * 
            Console.WriteLine("\n\nSuspend Orders tests");
            AddBuyOrder(10, 2, false); //NFSS10 quer comprar 10
            AddBuyOrder(10, 2, false); //NFSS10 quer comprar 10
            AddSellOrder(10, 5, false); //PAULAO quer vender 10
            AddSellOrder(10, 5, false); //PAULAO quer vender 10
            List<int> BuyordersList = new List<int>();
            BuyordersList.Add(5);
            BuyordersList.Add(6);
            List<int> SellordersList = new List<int>();
            SellordersList.Add(5);
            SellordersList.Add(6);
            if (GetBuyingOrder(5).suspended == false && GetBuyingOrder(6).suspended == false && GetSellingOrder(5).suspended == false && GetSellingOrder(6).suspended == false)
                Console.WriteLine("Teste 14: OK");
            else
                Console.WriteLine("Teste 14: ERROR");

            SuspendOrders(0, SellordersList, true);
            SuspendOrders(0, SellordersList, false);
            if (GetBuyingOrder(5).suspended == true && GetBuyingOrder(6).suspended == true && GetSellingOrder(5).suspended == true && GetSellingOrder(6).suspended == true)
                Console.WriteLine("Teste 15: OK");
            else
                Console.WriteLine("Teste 15: ERROR");
                
             */


            //Transfer diginotes with full
            AddBuyOrder(3, 5, false); //PAULAO quer comprar 3
            AddSellOrder(3, 2, false); //NFSS10 quer vender 3
            if ((MakeSellTransaction(7, 7) == TransationResult.FULL) && (GetDiginotesNumber(5) == 83)) //ve se paulao ficou com 3 diginotes
                Console.WriteLine("Teste 16: OK");
            else
                Console.WriteLine("Teste 16: ERROR");


            //Balance check after full sell < buy
            AddBuyOrder(3, 5, false); //PAULAO quer comprar 3
            AddSellOrder(2, 2, false); //NFSS10 quer vender 2
            if ((MakeSellTransaction(8, 8) == TransationResult.FULL) && (GetUserBalance(2) == 85)) //ve se NFSS10 ficou com 82 de balance
                Console.WriteLine("Teste 17: OK");
            else
                Console.WriteLine("Teste 17: ERROR");
            RemoveBuyingOrder(7);

            //Balance check after Partial sell > buy
            AddBuyOrder(1, 2, false); //NFSS10 quer comprar 1
            AddSellOrder(2, 5, false); //PAULAO quer vender 2
            if ((MakeSellTransaction(9, 9) == TransationResult.PARTIAL) && (GetUserBalance(2) == 84)) //ve se NFSS10 ficou com 81 de balance
                Console.WriteLine("Teste 18: OK");
            else
                Console.WriteLine("Teste 18: ERROR");
            RemoveSellingOrder(7);

            //Full buy == sell
            AddBuyOrder(10, 2, false); //NFSS10 quer comprar 10
            AddSellOrder(10, 5, false); //PAULAO quer vender 10
            if ((MakeBuyTransaction(10, 10) == TransationResult.FULL) && (GetBuyingOrder(10) == null) && (GetSellingOrder(10) == null)) //compra tudo
                Console.WriteLine("Teste 19: OK");
            else
                Console.WriteLine("Teste 19: ERROR");

            //Partial sell < buy
            AddBuyOrder(10, 2, false); //NFSS10 quer comprar 10
            AddSellOrder(5, 5, false); //PAULAO quer vender 5
            if ((MakeBuyTransaction(11, 11) == TransationResult.PARTIAL) && (GetBuyingOrder(11).nDiginotes == 5) && (GetSellingOrder(11) == null)) //vende tudo
                Console.WriteLine("Teste 20: OK");
            else
                Console.WriteLine("Teste 20: ERROR");
            RemoveBuyingOrder(10);//limpa teste



            //Partial sell > buy
            AddBuyOrder(5, 2, false); //NFSS10 quer comprar 5
            AddSellOrder(10, 5, false); //PAULAO quer vender 10
            if ((MakeBuyTransaction(12, 12) == TransationResult.FULL) && (GetBuyingOrder(12) == null) && (GetSellingOrder(12).nDiginotes == 5)) //vende parcialmente
                Console.WriteLine("Teste 21: OK");
            else
                Console.WriteLine("Teste 21: ERROR");
            RemoveSellingOrder(11);//limpa teste
        }






    }

}
