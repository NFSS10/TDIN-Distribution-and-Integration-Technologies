using Remote;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class WelcomeWindowForm : Form
    {
        IUserService userService;


        public WelcomeWindowForm(bool logout)
        {
            InitializeComponent();
            if(!logout)
                RemotingConfiguration.Configure("Client.exe.config", false);

            userService = (IUserService)Activator.GetObject(typeof(IUserService), "tcp://localhost:9000/Server/remuri");
        }





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void WelcomeWindowForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginBtnClick(object sender, EventArgs e)
        {
            if (LoginUsernameTextBox.Text == "" || LoginPasswordTextBox.Text == "")
                WelcomeWindowHelpLabel.Text = "Introduza informação de Login válida";
            else
            {
                Login loginUser =  userService.Login(LoginUsernameTextBox.Text, LoginPasswordTextBox.Text);

                switch (loginUser.opLogin)
                {
                    case OpLogin.lOGIN_SUCCESS:
                        WelcomeWindowHelpLabel.Text = "Login feito com sucesso !";
                        this.Hide();
                        MainWindow mainWindowForm = new MainWindow(loginUser.user, userService);
                        mainWindowForm.ShowDialog();
                        this.Close();
                        break;
                    case OpLogin.USER_DOESNT_EXIST:
                        WelcomeWindowHelpLabel.Text = "User não existe";
                        break;
                    case OpLogin.INVALID_USERNAME:
                        WelcomeWindowHelpLabel.Text = "Username inválido";
                        break;
                    case OpLogin.INVALID_PASSWORD:
                        WelcomeWindowHelpLabel.Text = "Password inválida";
                        break;
                    case OpLogin.ERROR:
                        WelcomeWindowHelpLabel.Text = "ERRO: Login";
                        break;
                    default:
                        WelcomeWindowHelpLabel.Text = "ERRO: Login";
                        break;
                }

            }



        }

        private void RegisterBtnClick(object sender, EventArgs e)
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
                switch (userService.RegisterUser(RegisterNameTextBox.Text, RegisterUsernameTextBox.Text, RegisterPasswordTextBox.Text))
                {
                    case OpRegister.REGISTER_SUCCESS:
                        WelcomeWindowHelpLabel.Text = "Registo feito com sucesso !";
                        this.tabControl1.SelectTab(1); //Muda para a tab de login
                        break;
                    case OpRegister.USER_ALREADY_EXISTS:
                        WelcomeWindowHelpLabel.Text = "User já existe existe";
                        break;
                    case OpRegister.INVALID_REGISTER_INFORMATION:
                        WelcomeWindowHelpLabel.Text = "Informação de Registo inválida";
                        break;
                    case OpRegister.ERROR:
                        WelcomeWindowHelpLabel.Text = "ERRO: Registo";
                        break;
                    default:
                        WelcomeWindowHelpLabel.Text = "ERRO: Registo";
                        break;
                }

            }

        }
    }
}
