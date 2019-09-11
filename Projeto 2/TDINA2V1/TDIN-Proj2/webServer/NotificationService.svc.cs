using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace webServer
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class NotificationService : INotificationService
    {
        private readonly Dictionary<Guid, INotificationServiceCallBack> clients = new Dictionary<Guid, INotificationServiceCallBack>();

        public Guid Subscribe()
        {
            INotificationServiceCallBack callback = OperationContext.Current.GetCallbackChannel<INotificationServiceCallBack>();
            Guid clientId = Guid.NewGuid();

            if (callback != null)
            {
                lock (clients)
                {
                    clients.Add(clientId, callback);
                }
            }

            return clientId;
        }


        public void Unsubscribe(Guid clientId)
        {
            lock (clients)
            {
                if (clients.ContainsKey(clientId))
                {
                    clients.Remove(clientId);
                }
            }
        }



        public void KeepConnection()
        {
            throw new NotImplementedException();
        }

        public void SendMessage(EventOperation operation, Guid clientId, string message)
        {
            BroadcastMessage(operation, clientId, message);
        }

        private void BroadcastMessage(EventOperation operation, Guid clientId, string message)
        {
            ThreadPool.QueueUserWorkItem(
                delegate
                {
                    lock (clients)
                    {
                        List<Guid> disconnectedClientGuids = new List<Guid>();

                        foreach (KeyValuePair<Guid, INotificationServiceCallBack> client in clients)
                        {
                            try
                            {
                                client.Value.HandleMessage(operation);
                            }
                            catch (Exception)
                            {
                                disconnectedClientGuids.Add(client.Key);
                            }
                        }


                        foreach (Guid clientGuid in disconnectedClientGuids)
                        {
                            clients.Remove(clientGuid);
                        }
                    }
                });
        }


    }




}
