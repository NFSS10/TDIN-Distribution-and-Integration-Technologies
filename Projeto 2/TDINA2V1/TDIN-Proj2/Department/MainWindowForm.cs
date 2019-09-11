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
using Department.TicketService;
using Department;
using Common;
using Department.NotificationService;

namespace Departments
{
    public partial class MainWindowForm : Form
    {
        private TicketsServiceClient ticketService;

        private Guid userId;
        private NotificationServiceClient notificationServiceClient;
        private InstanceContext instanceContext;


        DepartmentQuestion activeQuestion = null;


        public MainWindowForm()
        {
            InitializeComponent();


            QueueService.UI_Updater = UI_UpdateList; //Calls UI_UpdateList When new question is received

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

            ServiceHost host = new ServiceHost(typeof(QueueService));
            host.Open();




            UI_LBOX();

            //TODO remover
            //DebugTestes();
        }


        void UI_LBOX()
        {
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => UI_LBOX()));
            else
            {

                questionsListBox.Items.Clear();
                List<DepartmentQuestion> questionsList = DepartmentDatabaseHandler.GetAllQuestions();
                if (questionsList != null)
                {
                    for (int i = 0; i < questionsList.Count; i++)
                        questionsListBox.Items.Add(questionsList[i]);
                }
            }
        }

        //######################## UI updates ########################
        //Updates questions list
        void UI_UpdateList()
        {
            //Caso seja invocado por outro thread
            Invoke((MethodInvoker)delegate 
            {
                questionsListBox.Items.Clear();
                List<DepartmentQuestion> questionsList = DepartmentDatabaseHandler.GetAllQuestions();
                if(questionsList !=null)
                {
                    for(int i=0; i< questionsList.Count; i++)
                        questionsListBox.Items.Add(questionsList[i]);
                }
            });
        }

        //Updates questions info
        void UI_UpdateQuestionInfo(DepartmentQuestion question)
        {
            Invoke((MethodInvoker)delegate
            {
                activeQuestion = question;
                questionTitleTxt.Text = question.title;
                questionDetailsTxt.Text = question.question;
                answerTxt.Text = "";
            });
        }




        //######################## UI events ########################

        void SelectQuestionsListItem(object sender, MouseEventArgs e)
        {
            if (questionsListBox.SelectedItems.Count == 0)
                return;

            DepartmentQuestion question;
            question = (DepartmentQuestion)questionsListBox.SelectedItems[0];
            if (question == null)
            {
                activeQuestion = null;
                UI_UpdateList();
                return;
            }

            question = DepartmentDatabaseHandler.GetQuestion(question.id);
            if(question == null)
            {
                activeQuestion = null;
                UI_UpdateList();
                return;
            }

            UI_UpdateQuestionInfo(question);
        }

        void OnAnswerTxt_TextChanged(object sender, EventArgs e)
        {
            if(activeQuestion == null || string.IsNullOrWhiteSpace(answerTxt.Text))
                answerBtn.Enabled = false;
            else
                answerBtn.Enabled = true;
        }

        void AnswerBtnClick(object sender, EventArgs e)
        {
            if (activeQuestion == null || answerTxt.Text == "")
                return;

            if(ticketService.AnswerQuestion(activeQuestion.serverQuestionId, answerTxt.Text))
            { 
                DepartmentDatabaseHandler.RemoveQuestion(activeQuestion.id);
                activeQuestion = null;
                answerBtn.Enabled = false;
                questionTitleTxt.Text = "";
                questionDetailsTxt.Text = "";
                notificationServiceClient.SendMessage(EventOperation.QUESTION_ANSWERED, userId, "");
                UI_UpdateList();
            }
        }







        void DebugTestes()
        {
            string msg = "\n\n\n------------------ Debug: ------------------\n";


            msg += "\n##################  Questions  ##################\n";
            if (DepartmentDatabaseHandler.AddQuestion("T1", "quest1", 1, 3))
                msg += "1: OK\n";
            else
                msg += "1: ERROR\n";

            if (DepartmentDatabaseHandler.AddQuestion("T2", "quest2", 1, 3))
                msg += "2: OK\n";
            else
                msg += "2: ERROR\n";

            if (DepartmentDatabaseHandler.GetQuestion(1).title == "T1"
                && DepartmentDatabaseHandler.GetQuestion(1).question == "quest1"
                && DepartmentDatabaseHandler.GetQuestion(1).serverQuestionId == 1
                && DepartmentDatabaseHandler.GetQuestion(1).ticketId == 3)
                msg += "3: OK\n";
            else
                msg += "3: ERROR\n";


            if (DepartmentDatabaseHandler.GetAllQuestions(3).Count == 2)
                msg += "4: OK\n";
            else
                msg += "4: ERROR\n";

            if (DepartmentDatabaseHandler.RemoveQuestion(1))
                msg += "5: OK\n";
            else
                msg += "5: ERROR\n";

            if (DepartmentDatabaseHandler.GetAllQuestions(3).Count == 1)
                msg += "6: OK\n";
            else
                msg += "6: ERROR\n";

            if (!DepartmentDatabaseHandler.IsAllQuestionsAnswered(3))
                msg += "7: OK\n";
            else
                msg += "7: ERROR\n";

            if (DepartmentDatabaseHandler.RemoveQuestion(2))
                msg += "8: OK\n";
            else
                msg += "8: ERROR\n";


            if (DepartmentDatabaseHandler.GetAllQuestions(3) == null)
                msg += "9: OK\n";
            else
                msg += "9: ERROR\n";

            if (DepartmentDatabaseHandler.IsAllQuestionsAnswered(3))
                msg += "10: OK\n";
            else
                msg += "10: ERROR\n";


            Console.WriteLine("\n\n\n" + msg);
        }

        private void UserNotified_Handler(EventOperation op)
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
