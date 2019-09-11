using Common;
using Solver.TicketsService;
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
    public partial class LoginForm : Form
    {
        private TicketsServiceClient ticketService;
        public LoginForm()
        {
            InitializeComponent();
            ticketService = new TicketsServiceClient();

            //ticketService.ClearServerDatabase(); //TODO  remover, é de debug :p
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Common.Solver solver = ticketService.Login(LoginUsernameTextBox.Text, LoginPasswordTextBox.Text);
                if (solver != null)
                {
                    WelcomeWindowHelpLabel.Text = "Login sucessful!";
                    this.Hide();
                    MainWindowForm mainWindowForm = new MainWindowForm(solver);
                    mainWindowForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    WelcomeWindowHelpLabel.Text = "Wrong credentials!";
                }
            }
            catch
            {
                WelcomeWindowHelpLabel.Text = "Error connecting with the service!";
            }
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (RegisterNameTextBox.Text == "")
                WelcomeWindowHelpLabel.Text = "Introduza um Nome válido";
            else if (RegisterUsernameTextBox.Text == "")
                WelcomeWindowHelpLabel.Text = "Introduza um Username válido";
            else if (RegisterPasswordTextBox.Text == "")
                WelcomeWindowHelpLabel.Text = "Introduza uma Password válida";
            else if (RegisterPasswordTextBox.Text != RegisterConfPasswordTextBox.Text)
                WelcomeWindowHelpLabel.Text = "Password e Confirm Password não são iguais";
            else
            {
                if (ticketService.Register(RegisterNameTextBox.Text, RegisterUsernameTextBox.Text, RegisterPasswordTextBox.Text))
                {
                    WelcomeWindowHelpLabel.Text = "Registo feito com sucesso !";
                    this.tabControl1.SelectTab(1); //Muda para a tab de login
                }
                else
                {
                    WelcomeWindowHelpLabel.Text = "User já existe!";
                }
            }
        }
    }
}
