using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace webServer
{
    [ServiceContract(CallbackContract = typeof(INotificationServiceCallBack))]
    public interface INotificationService
    {
        [OperationContract]
        Guid Subscribe();


        [OperationContract(IsOneWay = true)]
        void Unsubscribe(Guid clientId);


        [OperationContract(IsOneWay = true)]
        void KeepConnection();


        [OperationContract]
        void SendMessage(EventOperation operation, Guid clientId, string message);
    }



    public interface INotificationServiceCallBack
    {
        [OperationContract(IsOneWay = true)]
        void HandleMessage(EventOperation operation);
    }




}
