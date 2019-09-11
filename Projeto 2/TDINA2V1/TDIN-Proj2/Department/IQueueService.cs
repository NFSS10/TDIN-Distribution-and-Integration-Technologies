using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Department
{
    [ServiceContract]
    public interface IQueueService
    {
        [OperationContract(IsOneWay = true)]
        void ProcessQuestion(string title, string question, int questionID, int ticketID);
    }



}
