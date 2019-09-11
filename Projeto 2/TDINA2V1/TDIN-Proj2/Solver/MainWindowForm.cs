using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

using Solver.NotificationService;
using Solver.TicketsService;
using Common;

namespace Solver
{
    public partial class MainWindowForm : Form
    {
        private Guid userId;
        public NotificationServiceClient notificationServiceClient;
        private InstanceContext instanceContext;
        public Common.Solver solver;
        public TicketsServiceClient ticketService;
        public List<TicketForm> openWindows = new List<TicketForm>();

        public MainWindowForm(Common.Solver solver)
        {

            InitializeComponent();

            this.solver = solver;
            ticketService = new TicketsServiceClient();
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
            UI_Init();
        }



        public void CloseWindow()
        {
            if (notificationServiceClient != null)
            {
                try
                {
                    if (notificationServiceClient.State != CommunicationState.Faulted)
                    {
                        notificationServiceClient.Unsubscribe(userId);
                        notificationServiceClient.Close();
                    }
                }
                catch
                {
                    notificationServiceClient.Abort();
                }
            }
        }

        private void Form1_Close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            for (int i = 0; i < openWindows.Count; i++)
                openWindows[i].Dispose();
        }

        public void TestNotificar(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                try
                {
                    if (notificationServiceClient.State == CommunicationState.Faulted)
                    {
                        notificationServiceClient.Abort();
                        notificationServiceClient = new NotificationServiceClient(instanceContext);
                    }
                    //notificationServiceClient.SendMessage(userId, message);
                    Console.WriteLine("--------Enviei uma msg nova--------");
                }
                catch
                { }

            }
        }


        private void UserNotified_Handler(EventOperation op)
        {
            if (op == EventOperation.NEW_TICKET_ADDED || op == EventOperation.UPDATE_UNASSIGNED)
            {
                UI_UpdateUnassignedTickets();
            }
            if (op == EventOperation.QUESTION_ANSWERED)
            {
                for (int i = 0; i < openWindows.Count; i++)
                {
                    openWindows[i].UI_UpdateQuestionTables();
                }
                UI_UpdateAssignedTickets();
            }
        }

        void UI_UpdateSelectedUnassignedTicketInfo(int id, string title, string description)
        {
            SelectedUTicketTitle.Text = "#" + id + " - " + title;
            SelectedUTicketDescription.Text = description;
        }

        void UI_ResetSelectedUTicketInfo()
        {
            SelectedUTicketTitle.Text = "";
            SelectedUTicketDescription.Text = "";
        }

        public void UI_UpdateAssignedTickets()
        {
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => UI_UpdateAssignedTickets()));
            else
            {
                Ticket[] uTickets = ticketService.GetAssignedTickets(solver.id);
                AssignedTicketsBinding.Clear();
                if (uTickets != null)
                {
                    for (int i = 0; i < uTickets.Length; i++)
                    {
                        AssignedTicketsBinding.Add(uTickets[i]);
                    }
                }
            }

        }

        void UI_UpdateUnassignedTickets()
        {
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => UI_UpdateUnassignedTickets()));
            else
            {
                Ticket[] uTickets = ticketService.GetUnassignedTickets();
                UnassignedTicketsBinding.Clear();
                if ( uTickets != null)
                {
                    Console.WriteLine("oiiiiiii " + uTickets.Length);
                    for (int i = 0; i < uTickets.Length; i++)
                    {
                        UnassignedTicketsBinding.Add(uTickets[i]);
                    }

                }
            }
               
        }

        void UI_Init()
        {
            UI_UpdateUnassignedTickets();
            UI_UpdateAssignedTickets();
            UI_ResetSelectedUTicketInfo();
            label2.Text = solver.username + " - " + solver.name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestNotificar("txt teste 1");
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void UnassignedTicketsBinding_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void UnassignedTicketsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             var senderGrid = (DataGridView)sender;

            //BOTAO DE DAR ASSIGN
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name == "UAssignButtonColumn")
            {
                int ticketId = Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (ticketService.AssignTicketToSolver(ticketId, this.solver.id))
                {
                    notificationServiceClient.SendMessage(EventOperation.UPDATE_UNASSIGNED, new Guid(), "hey");
                    UI_UpdateAssignedTickets();
                }
            }

        }

        private void UnassignedTicketsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //BOTAO DE DAR ASSIGN
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name == "UAssignButtonColumn")
            {

            }
            else if (e.RowIndex >= 0 ) //COLUNA NORMAL
            {
                int ticketId = Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                string ticketTitle = senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                string ticketDescription = senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                UI_UpdateSelectedUnassignedTicketInfo(ticketId, ticketTitle, ticketDescription);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            //BOTAO DE VIEW
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
               e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name == "AViewButtonColumn")
            {
                int ticketId = Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                TicketForm ticketForm = new TicketForm(this, ticketId);
                ticketForm.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }








    public delegate void UserNotifiedEventHandler(EventOperation op);


    public class NotificationServiceCallback : INotificationServiceCallback
    {
        public event UserNotifiedEventHandler UserNotifiedEvent;

        public void HandleMessage(EventOperation operation)
        {

            if (UserNotifiedEvent != null)
                UserNotifiedEvent(operation);
        }

    }
}
