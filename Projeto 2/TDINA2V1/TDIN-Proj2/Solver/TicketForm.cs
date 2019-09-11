using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solver
{
    public partial class TicketForm : Form
    {
        MainWindowForm mainForm;
        int ticketId;
        string authorEmail;
        string ticketTitle;
        bool canSendFinalAnswer = false;
        public TicketForm(MainWindowForm form, int ticketId)
        {
            this.mainForm = form;
            this.ticketId = ticketId;
            mainForm.openWindows.Add(this);
            InitializeComponent();
            UI_Init();
        }

        public void UI_Init()
        {
            UI_FillTicketInfo();
            UI_UpdateQuestionTables();
        }

        public void UI_UpdateQuestionTables()
        {
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => UI_FillTicketInfo()));
            else
            {
                Question[] ticketQuestions;
                PquestionBindingSource.Clear();
                AquestionBindingSource.Clear();
                
                if ((ticketQuestions = mainForm.ticketService.GetTicketQuestions(this.ticketId)) != null)
                {
                    int pendingIndex = 0;
                    int answeredIndex = 0;
                    
                    for (int i = 0; i < ticketQuestions.Length; i++)
                    {
                        if (ticketQuestions[i].isAnswered)
                        {
                            AquestionBindingSource.Insert(answeredIndex, ticketQuestions[i]);
                            answeredIndex++;
                        }
                        else
                        {
                            PquestionBindingSource.Insert(pendingIndex, ticketQuestions[i]);
                            pendingIndex++;
                        }
                    }
                    mainForm.UI_UpdateAssignedTickets();
                }
                if (mainForm.ticketService.CanCloseTicket(this.ticketId))
                {
                    canSendFinalAnswer = true;
                    if (!mainForm.ticketService.UpdateTicketState(this.ticketId, TicketState.ASSIGNED))
                        return;
                }
                else
                {
                    canSendFinalAnswer = false;
                    if (!mainForm.ticketService.UpdateTicketState(this.ticketId, TicketState.WAITING_FOR_ANSWERS))
                        return;
                }
            }
        }

        private void UI_FillTicketInfo()
        {
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => UI_FillTicketInfo()));
            else
            {
                Ticket selectedTicket;
                if ((selectedTicket = mainForm.ticketService.GetTicket(this.ticketId)) != null)
                {
                    Worker ticketAuthor;
                    if ((ticketAuthor = mainForm.ticketService.GetAuthorInfo(selectedTicket.workerId)) != null)
                    {
                        nameBox.Text = ticketAuthor.name;
                        emailBox.Text = ticketAuthor.email;
                        titleBox.Text = selectedTicket.title;
                        descriptionBox.Text = selectedTicket.description;
                        ticketInfoLabel.Text = "#" + ticketId + " - " + selectedTicket.title;
                        this.authorEmail = ticketAuthor.email;
                        this.ticketTitle = selectedTicket.title;
                    }
                    else
                    {
                        Console.WriteLine("Error getting ticket author");
                        this.Dispose();
                    }
                }
                else
                {
                    Console.WriteLine("Error getting ticket with the id: " + this.ticketId);
                    this.Dispose();
                }
            }
        }

        private void Form2_Close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainForm.openWindows.Remove(this);
        }



        private void closeTicketBtn_Click(object sender, EventArgs e)
        {
            if (mainForm.ticketService.CanCloseTicket(this.ticketId))
            {
                
                if (mainForm.ticketService.SolveTicket(this.ticketId, mainForm.solver.name, this.ticketTitle, finalAnswer.Text, this.authorEmail))
                { 
                    mainForm.UI_UpdateAssignedTickets();
                    this.Dispose();
                }
                else
                {
                    Console.WriteLine("Error closing ticket");
                }
            }
        }

        private void sendQuestionBtn_Click(object sender, EventArgs e)
        {
            answeredList.ClearSelected();
            pendingList.ClearSelected();
            selectedQuestionAnswer.Text = "";
            selectedQuestionQuestion.Text = "";
            selectedQuestionTitle.Text = "";
            if (sendQuestionDescription.Text != "" && sendQuestionTitle.Text != "")
            {
                int questionId;
                if ((questionId = mainForm.ticketService.AddQuestion(sendQuestionTitle.Text, sendQuestionDescription.Text, 1, this.ticketId)) != -1)
                {
                    mainForm.ticketService.SendQuestionToDepartment(sendQuestionTitle.Text, sendQuestionDescription.Text, questionId, this.ticketId);
                    UI_UpdateQuestionTables();
                }
            }
        }

        private void Question_TextChanged(object sender, EventArgs e)
        {
            if (sendQuestionTitle.Text != "" && sendQuestionDescription.Text != "")
            {
                sendQuestionBtn.Enabled = true;
            }
            else
            {
                sendQuestionBtn.Enabled = false;
            }
        }

        private void finalAnswer_TextChanged(object sender, EventArgs e)
        {
            if (finalAnswer.Text != "" && canSendFinalAnswer)
            {
                closeTicketBtn.Enabled = true;
            }
            else
            {
                closeTicketBtn.Enabled = false;
            }
        }
        
    

        private void pendingList_Selected(object sender, MouseEventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (list.SelectedItems.Count == 0)
                return;
            Question selectedQuestion = (Question)PquestionBindingSource[list.SelectedIndex];
            selectedQuestionTitle.Text = selectedQuestion.title;
            selectedQuestionQuestion.Text = selectedQuestion.description;
            selectedQuestionAnswer.Text = "Not answered yet.";
            answeredList.ClearSelected();
        }

        private void answeredList_Selected(object sender, MouseEventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (list.SelectedItems.Count == 0)
                return;
            Question selectedQuestion = (Question)AquestionBindingSource[list.SelectedIndex];
            selectedQuestionTitle.Text = selectedQuestion.title;
            selectedQuestionQuestion.Text = selectedQuestion.description;
            selectedQuestionAnswer.Text = selectedQuestion.answer;
            pendingList.ClearSelected();
        }

        private void TicketForm_Load(object sender, EventArgs e)
        {

        }
    }
}
