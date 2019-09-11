using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.NotificationService;

using Common;
using System.Net.Mail;

namespace WebSite
{
    public partial class Webpage : System.Web.UI.Page
    {
        TicketsService.TicketsServiceClient ticketsService;
        private NotificationServiceClient notificationServiceClient;
        private InstanceContext instanceContext;
        Guid userId;

        List<Worker> workersList = null;
        List<Ticket> ticketsList = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            ticketsService = new TicketsService.TicketsServiceClient();

            NotificationServiceCallback notificationServiceCallback = new NotificationServiceCallback();
            notificationServiceCallback.UserNotifiedEvent += UserNotified_Handler;


            instanceContext = new InstanceContext(notificationServiceCallback);
            notificationServiceClient = new NotificationServiceClient(instanceContext);

            try
            {
                userId = notificationServiceClient.Subscribe();
            }
            catch
            {
                Console.WriteLine("ERROR: notificationServiceClient.Subscribe()");
            }

            LoadWorkers();


            if (!Page.IsPostBack)
            {
                UpdateWorkersList();
            }

            if(workersList!=null)
            {
                if(workersList.Count >0)
                    UpdateQuestionsListBox(workersList[workersDropDownList.SelectedIndex].id);


            }

            //TODO remover, Isto é para DEBUG 
            //DebugLabel.Text = ticketsService.DebugTests();

        }

        void LoadWorkers()
        {
            Worker[] workers = ticketsService.GetAllWorkers();
            if (workers == null)
                return;

            workersList = workers.ToList<Worker>();
        }
        void LoadWorkerTickets(int workerID)
        {
            Ticket[] tickets = ticketsService.GetWorkerTroubleTickets(workerID);

            if (tickets == null)
                return;

            ticketsList = tickets.ToList<Ticket>();
        }

        void UpdateWorkersList()
        {
            if (workersList != null)
            {
                workersDropDownList.Items.Clear();

                for(int i=0; i< workersList.Count; i++)
                    workersDropDownList.Items.Add(workersList[i].ToString());
            }
        }

        void UpdateQuestionsListBox(int workerID)
        {
            LoadWorkerTickets(workerID);

            if (ticketsList != null)
            {
                workersQuestionsListBox.Items.Clear();

                for (int i = 0; i < ticketsList.Count; i++)
                    workersQuestionsListBox.Items.Add(ticketsList[i].ToString());
            }

        }




        public bool IsEmailValid(string emailaddress)
        {
            if (emailaddress == "")
                return false;

            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException e)
            {
                return false;
            }
        }

        protected void SendTicket(object sender, EventArgs e)
        {
            warningLabel.Text = "";
            string errorMsg = "";


            if (nameTextBox.Text == "")
                errorMsg+= "| Invalid Name |";

            if (!IsEmailValid(emailTextBox.Text))
                errorMsg += "| Invalid Email |";

            if (TitleText.Text == "")
                errorMsg += "| Invalid Problem Title |";

            if (DescriptionText.Text == "")
                errorMsg += "| Invalid Problem Description |";

            if (errorMsg == "")
            {
                int workerID = ticketsService.AddWorker(nameTextBox.Text, emailTextBox.Text);
                if (workerID == -1)
                {
                    warningLabel.Text = "ERROR: Ticket not sent...";
                    return;
                }
                else
                {
                    LoadWorkers();
                    UpdateWorkersList();
                }



                if (ticketsService.AddTicket(TitleText.Text, DescriptionText.Text, workerID))
                {
                    warningLabel.Text = "SUCCESS: " + nameTextBox.Text + " sent a new ticket !";
                    //UpdateQuestionsListBox(workerID); //Nao esta a fazer update do direito nao sei pk...s
                    if(workersList != null)
                    {
                        if(workersList.Count>0)
                            UpdateQuestionsListBox(workersList[0].id);
                    }
                    //UpdateQuestionsListBox(workerID); //Nao esta a fazer update do direito nao sei pk...s
                    notificationServiceClient.SendMessage(EventOperation.NEW_TICKET_ADDED, new Guid(), "");
                }
                else
                    warningLabel.Text = "Ticket not sent! An Error has occurred...";
            }
            else
                warningLabel.Text = errorMsg;
        }
        
        protected void UserNotified_Handler(EventOperation operation)
        {
            /*
            LoadWorkers();
            if (workersDropDownList.SelectedIndex >= 0)
            {
                int selectedWorkerID = workersList[workersDropDownList.SelectedIndex].id;
                LoadWorkerTickets(selectedWorkerID);
                UpdateQuestionsListBox(selectedWorkerID);
            }
            //ClientScript.RegisterStartupScript(GetType(), "hwa", "reload();", true);
            warningLabel.Text = "call back";
            */
        }

        public delegate void UserNotifiedEventHandler(EventOperation operation);

        public class NotificationServiceCallback : INotificationServiceCallback
        {
            public event UserNotifiedEventHandler UserNotifiedEvent;

            public void HandleMessage(EventOperation operation)
            {
                if (UserNotifiedEvent != null)
                    UserNotifiedEvent(operation);
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }



        protected void workersDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int workerID = -1;
            if (workersList == null)
                return;

            if (workersDropDownList.SelectedIndex >= 0 && workersDropDownList.SelectedIndex < workersList.Count)
                workerID = workersList[workersDropDownList.SelectedIndex].id;


            if (workerID == -1)
                return;
            else
                UpdateQuestionsListBox(workerID);
        }


        /*
void UpdateSelectedUserTicketInfo(int ticketID)
{
Ticket ticket = ticketsService.GetTicket(ticketID);

if(ticket == null)
{
workerSelectedQuestionTitleTxtBox.Text = "ERROR LOADING";
workerSelectedQuestionInfoTxtBox.Text = "ERROR LOADING";
}
else
{
workerSelectedQuestionTitleTxtBox.Text = ticket.title;
workerSelectedQuestionInfoTxtBox.Text = ticket.description;
}
}*/

        /*
        protected void workersQuestionsListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            int ticketID = -1;
            if (ticketsList == null)
                return;

            if (workersQuestionsListBox.SelectedIndex >= 0 && workersQuestionsListBox.SelectedIndex < ticketsList.Count)
                ticketID = ticketsList[workersQuestionsListBox.SelectedIndex].id;

            if (ticketID == -1)
                return;
            else
                UpdateSelectedUserTicketInfo(ticketID);
        }
        */


        protected void ReloadBtn_Click(object sender, EventArgs e)
        {

        }
    }
}