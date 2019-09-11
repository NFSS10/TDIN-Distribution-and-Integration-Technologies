using System;
using System.Collections.Generic;

namespace Remote
{
    public delegate void AlterationDelegate(EventOperation op, int id);
    public enum EventOperation { SELL_SUCCESS, SELL_PARTIAL, QUOTA_CHANGED, UPDATE_ALL, TRANSACTION, UNSUSPEND }


    public enum OpRegister { REGISTER_SUCCESS, INVALID_REGISTER_INFORMATION, USER_ALREADY_EXISTS, ERROR};
    public enum OpLogin { lOGIN_SUCCESS, INVALID_USERNAME, INVALID_PASSWORD, USER_DOESNT_EXIST, ERROR};
    public enum TransationResult { ERROR, PARTIAL, FULL, DIGINOTES_ERROR };




    //Communication between Client and Servers is done through this interface
    public interface IUserService
    {
        event AlterationDelegate AlterationEvent;


        OpRegister RegisterUser(string name, string username, string password);
        Login Login(string username, string password);
        bool Logout();

        bool CreateNewDiginote(int userID);
        bool AddMoney(int userID, decimal ammount);
        int GetDiginotesNumber(int userID);
        List<Diginote> GetMyDiginotesIDList(int userID);
        decimal GetUserBalance(int userID);


        decimal GetCurrentQuote();
        bool SetNewQuota(decimal newQuotaValue, bool isSell, int userID);


        TransationResult EmmitSellOrder(int diginotesAmmount, int userID);
        TransationResult EmmitPurchaseOrder(int diginotesAmmount, int userID);



        
        List<BuyOrder> GetUserBuyOrdersList(int userID);
        List<SellOrder> GetUserSellOrdersList(int userID);
        List<Transaction> GetMyTransactions(int userID);




        bool ConfirmPriceOfOrder(int orderID, bool isSellOrder);

        bool Withdraw(int orderID, bool isSellOrder);




        //DEBUG
        void TesteFunc();
        void TestQuotaval(decimal val);
    }




    [Serializable]
    public struct Login
    {
        public User user;
        public OpLogin opLogin;
    }




    [Serializable]
    public class User
    {
        public int id { get;}
        public string name { get; }
        public string username { get; }
        public decimal balance {get; set;}

        public User(string name, string username, int id, decimal balance)
        {
            this.name = name;
            this.username = username;
            this.id = id;
            this.balance = balance;
        }

    }



    [Serializable]
    public class SellOrder
    {
        public int id { get; }
        public int userID { get; }
        public int nDiginotes { get; }
        public bool suspended { get; }


        public SellOrder(int id, int userID, int nDiginotes, bool suspended)
        {
            this.id = id;
            this.userID = userID;
            this.nDiginotes = nDiginotes;
            this.suspended = suspended;
        }
    }


    [Serializable]
    public class BuyOrder
    {
        public int id { get; }
        public int userID { get; }
        public int nDiginotes { get; }
        public bool suspended { get; }


        public BuyOrder(int id, int userID, int nDiginotes, bool suspended)
        {
            this.id = id;
            this.userID = userID;
            this.nDiginotes = nDiginotes;
            this.suspended = suspended;
        }
    }


    [Serializable]
    public class Diginote
    {
        public int id { get; }
        public int OwnerUserID { get; }

        public Diginote(int id, int ownerUserID)
        {
            this.id = id;
            this.OwnerUserID = ownerUserID;
        }
    }

    [Serializable]
    public class Transaction
    {
        public int id { get; }
        public int fromID { get; }
        public int toID { get; }
        public int diginoteID { get; }
        public string date { get; }
        public decimal trasQuota { get; }


        public Transaction(int id, int fromID, int toID, int diginoteID, string date, decimal trasQuota)
        {
            this.id = id;
            this.fromID = fromID;
            this.toID = toID;
            this.diginoteID = diginoteID;
            this.date = date;
            this.trasQuota = trasQuota;
        }
    }




    //For events
    public class AlterationsEvent : MarshalByRefObject
    {
        public event AlterationDelegate AlterationsEvents;

        public override object InitializeLifetimeService()
        {
            return null;
        }
        
        public void LocallyHandleMessageArrived(EventOperation op, int userID)
        {
            if (AlterationsEvents != null)
                AlterationsEvents(op, userID);
        }
    }



}


