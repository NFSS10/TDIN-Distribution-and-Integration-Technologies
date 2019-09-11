using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Department
{


    public class QueueService : IQueueService
    {
        [OperationBehavior]
        public void ProcessQuestion(string title, string question, int questionID, int ticketID)
        {
            if(DepartmentDatabaseHandler.AddQuestion(title, question, questionID, ticketID))
            { 
                try
                {
                    UpdateUI handler = UI_Updater;
                    if (handler != null)
                    {
                        handler();
                    }
                }
                catch
                {}
            }
            else throw new Exception("ERROR trying do add new question to department :(");

        }
        public delegate void UpdateUI();

        public static UpdateUI UI_Updater { get; set; }



    }










}
