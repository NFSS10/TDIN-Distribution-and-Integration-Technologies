using System;
using System.Windows.Forms;

using Remote;
using System.Runtime.Remoting;
using System.Collections.Generic;

namespace Client
{
    public partial class MainWindow : Form
    {
        User user;
        AlterationsEvent evRepeater;
        IUserService userService;

        public MainWindow(User user, IUserService userService)
        {
            InitializeComponent();

            this.user = user;
            this.userService = userService;

            evRepeater = new AlterationsEvent();
            evRepeater.AlterationsEvents += new AlterationDelegate(DoAlterations);

            userService.AlterationEvent += new AlterationDelegate(evRepeater.LocallyHandleMessageArrived);


            UI_Init();


            //Testes(userService);

        }

        public void DoAlterations(EventOperation op, int userID)
        {
            switch (op)
            {
                case EventOperation.QUOTA_CHANGED:
                    UI_UpdateQuotaValue(userService.GetCurrentQuote());
                    UI_UpdateSellOrdersTable(userService.GetUserSellOrdersList(user.id));
                    UI_UpdateBuyOrdersTable(userService.GetUserBuyOrdersList(user.id));
                    UI_UpdateTransacionsTable(userService.GetMyTransactions(user.id));
                    break;
                case EventOperation.TRANSACTION:
                    if(userID == user.id)
                    { 
                        UI_UpdateSellOrdersTable(userService.GetUserSellOrdersList(user.id));
                        UI_UpdateBuyOrdersTable(userService.GetUserBuyOrdersList(user.id));
                        UI_UpdateTransacionsTable(userService.GetMyTransactions(user.id));
                        UI_UpdateTotalDiginotesNumber(userService.GetDiginotesNumber(user.id));
                        UI_UpdateMyDigicoinsTable(userService.GetMyDiginotesIDList(user.id));
                        UI_UpdateBalance(userService.GetUserBalance(user.id));
                    }
                    break;
                case EventOperation.UNSUSPEND:
                    UI_UpdateSellOrdersTable(userService.GetUserSellOrdersList(user.id));
                    UI_UpdateBuyOrdersTable(userService.GetUserBuyOrdersList(user.id));
                    UI_UpdateTransacionsTable(userService.GetMyTransactions(user.id));
                    break;
                case EventOperation.UPDATE_ALL:
                    UI_UpdateBalance(userService.GetUserBalance(user.id));
                    UI_UpdateTotalDiginotesNumber(userService.GetDiginotesNumber(user.id));
                    UI_UpdateQuotaValue(userService.GetCurrentQuote());

                    UI_UpdateTransacionsTable(userService.GetMyTransactions(user.id));
                    UI_UpdateMyDigicoinsTable(userService.GetMyDiginotesIDList(user.id));
                    UI_UpdateSellOrdersTable(userService.GetUserSellOrdersList(user.id));
                    UI_UpdateBuyOrdersTable(userService.GetUserBuyOrdersList(user.id));
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }


        void UI_Init()
        {
            NameLbl.Text = user.name;
            UsernameLbl.Text = user.username;

            UI_UpdateBalance(userService.GetUserBalance(user.id));
            UI_UpdateTotalDiginotesNumber(userService.GetDiginotesNumber(user.id));
            UI_UpdateQuotaValue(userService.GetCurrentQuote());

            UI_UpdateTransacionsTable(userService.GetMyTransactions(user.id));
            UI_UpdateMyDigicoinsTable(userService.GetMyDiginotesIDList(user.id));
            UI_UpdateSellOrdersTable(userService.GetUserSellOrdersList(user.id));
            UI_UpdateBuyOrdersTable(userService.GetUserBuyOrdersList(user.id));
        }




        //Refreshes the user balance
        void UI_UpdateBalance(decimal balance)
        {
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => UI_UpdateBalance(balance)));
            else
                BalanceLbl.Text = balance.ToString();
        }

        //Refreshes the quota value
        void UI_UpdateQuotaValue(decimal newQuotaValue)
        {
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => UI_UpdateQuotaValue(newQuotaValue)));
            else
                QuotaValueLbl.Text = newQuotaValue.ToString();
        }

        //Refreshes total digicoins value
        void UI_UpdateTotalDiginotesNumber(int digiAmmount)
        {
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => UI_UpdateTotalDiginotesNumber(digiAmmount)));
            else
                NdiginotesLbl.Text = digiAmmount.ToString();
        }




        //Refreshes the client SellOrder table
        void UI_UpdateMyDigicoinsTable(List<Diginote> diginotesList)
        {
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => UI_UpdateMyDigicoinsTable(diginotesList)));
            else
            {
                diginoteBindingSource.Clear();
                if (diginotesList != null)
                {
                    for (int i = 0; i < diginotesList.Count; i++)
                        diginoteBindingSource.Add(diginotesList[i]);
                }
            }
        }

        //Refreshes the client SellOrder table
        void UI_UpdateSellOrdersTable(List<SellOrder> sellOrdersList)
        {
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => UI_UpdateSellOrdersTable(sellOrdersList)));
            else
            {
                sellOrderBindingSource.Clear();
                if(sellOrdersList!=null)
                { 
                    for (int i = 0; i < sellOrdersList.Count; i++)
                        sellOrderBindingSource.Add(sellOrdersList[i]);
                }
            }
        }

        //Refreshes the client SellOrder table
        void UI_UpdateBuyOrdersTable(List<BuyOrder> buyOrdersList)
        {
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => UI_UpdateBuyOrdersTable(buyOrdersList)));
            else
            {
                buyOrderBindingSource.Clear();
                if (buyOrdersList != null)
                {
                    for (int i = 0; i < buyOrdersList.Count; i++)
                        buyOrderBindingSource.Add(buyOrdersList[i]);
                }
            }
        }

        ///Refreshes the client SellOrder table
        void UI_UpdateTransacionsTable(List<Transaction> transactionsList)
        {
           if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => UI_UpdateTransacionsTable(transactionsList)));
            else
            {
                transactionBindingSource.Clear();
                if (transactionsList != null)
                {
                    for (int i = 0; i < transactionsList.Count; i++)
                        transactionBindingSource.Add(transactionsList[i]);
                }
            }
        }





        private void AddBuyOrderBtnClick(object sender, EventArgs e)
        {
            int diginotesAmmount;
            if (!int.TryParse(BuyOrderDiginoteAmmount.Text, out diginotesAmmount))
            {
                MessageBox.Show("Valor inválido");
                return;
            }

            //Se chega aqui é pk o Valor é valido
            switch (userService.EmmitPurchaseOrder(diginotesAmmount, user.id))
            {
                case TransationResult.DIGINOTES_ERROR:
                    MessageBox.Show("Número de diginotes não permitido");
                    break;
                case TransationResult.FULL:
                    UI_UpdateBuyOrdersTable(userService.GetUserBuyOrdersList(user.id));
                    UI_UpdateTransacionsTable(userService.GetMyTransactions(user.id));
                    UI_UpdateTotalDiginotesNumber(userService.GetDiginotesNumber(user.id));
                    UI_UpdateMyDigicoinsTable(userService.GetMyDiginotesIDList(user.id));
                    UI_UpdateBalance(userService.GetUserBalance(user.id));
                    break;
                case TransationResult.PARTIAL:
                    UI_UpdateBuyOrdersTable(userService.GetUserBuyOrdersList(user.id));
                    UI_UpdateTransacionsTable(userService.GetMyTransactions(user.id));
                    UI_UpdateTotalDiginotesNumber(userService.GetDiginotesNumber(user.id));
                    UI_UpdateMyDigicoinsTable(userService.GetMyDiginotesIDList(user.id));
                    UI_UpdateBalance(userService.GetUserBalance(user.id));

                    QuotaPopUp quotaPopUp = new QuotaPopUp(false, this.user.id, this.userService);
                    quotaPopUp.ShowDialog();
                    break;
                default:
                    MessageBox.Show("ERRO: Emmit Purchase");
                    break;
            }
        }

        private void AddSellOrderBtnClick(object sender, EventArgs e)
        {
            int diginotesAmmount;
            if (!int.TryParse(SellOrderDiginoteAmmount.Text, out diginotesAmmount))
            {
                MessageBox.Show("Valor inválido");
                return;
            }

            //Se chega aqui é pk o Valor é valido
            switch (userService.EmmitSellOrder(diginotesAmmount, user.id))
            {
                case TransationResult.DIGINOTES_ERROR:
                    MessageBox.Show("Número de diginotes não permitido");
                    break;
                case TransationResult.FULL:
                    UI_UpdateSellOrdersTable(userService.GetUserSellOrdersList(user.id));
                    UI_UpdateTransacionsTable(userService.GetMyTransactions(user.id));
                    UI_UpdateTotalDiginotesNumber(userService.GetDiginotesNumber(user.id));
                    UI_UpdateMyDigicoinsTable(userService.GetMyDiginotesIDList(user.id));
                    break;
                case TransationResult.PARTIAL:
                    UI_UpdateSellOrdersTable(userService.GetUserSellOrdersList(user.id));
                    UI_UpdateTransacionsTable(userService.GetMyTransactions(user.id));
                    UI_UpdateTotalDiginotesNumber(userService.GetDiginotesNumber(user.id));
                    UI_UpdateMyDigicoinsTable(userService.GetMyDiginotesIDList(user.id));
                    UI_UpdateBalance(userService.GetUserBalance(user.id));

                    QuotaPopUp quotaPopUp = new QuotaPopUp(true, this.user.id, this.userService);
                    quotaPopUp.ShowDialog();
                    break;
                default:
                    MessageBox.Show("ERRO: Emmit sale");
                    break;
            }
        }








        void Testes(IUserService userService)
        {
            userService.TesteFunc();


            //ChangeTestTextbox(""+userService.GetCurrentQuote());

            //ChangeTestTextbox("" + userService.GetDiginotesNumber(2));

            //ChangeTestTextbox(""+userService.EmmitSellOrder(2, 2));

            //userService.TestQuotaval(5);
            //ChangeTestTextbox(textBox1.Text+"         deve ser 5->" + userService.GetCurrentQuote());


            //userService.TestQuotaval(2);
            //ChangeTestTextbox(textBox1.Text + "         deve ser 2->" + userService.GetCurrentQuote());

            /*
                        //teste rapido, usei o doalterations para nao ter de fazer uma funcao de novo :p
                        DoAlterations(0, "     ");



                        if(userService.Login("NFSS10", "aaaa").opLogin == OpLogin.INVALID_PASSWORD)
                            DoAlterations(0, "PassInvalida: OK     ");
                        else
                            DoAlterations(0, "PassInvalida: TesteErro     ");
                        if (userService.Login("", "").opLogin == OpLogin.INVALID_USERNAME)
                            DoAlterations(0, "User/Pass Invalida: OK     ");
                        else
                            DoAlterations(0, "User/Pass Invalida: TesteErro     ");
                        if (userService.Login("UsernameTeste", "pass123").opLogin == OpLogin.USER_DOESNT_EXIST)
                            DoAlterations(0, "User nao existe: OK     ");
                        else
                            DoAlterations(0, "User nao existe: TesteErro     ");
                        if (userService.Login("NFSS10", "pass123").opLogin == OpLogin.lOGIN_SUCCESS)
                            DoAlterations(0, "LoginSucesso: OK     ");
                        else
                            DoAlterations(0, "LoginSucesso: TesteErro     ");


                        DoAlterations(0, "          [registo]   ");
                        if(userService.RegisterUser("Nuno","NFSS10","pppp") == OpRegister.USER_ALREADY_EXISTS)
                            DoAlterations(0, "UserJaExiste: OK     ");
                        else
                            DoAlterations(0, "UserJaExiste: TesteErro     ");
                        if (userService.RegisterUser("", "", "") == OpRegister.INVALID_REGISTER_INFORMATION)
                            DoAlterations(0, "ParametrosInvalidos: OK     ");
                        else
                            DoAlterations(0, "ParametrosInvalidos: TesteErro     ");
                        if (userService.RegisterUser("NomeTeste", "TesteUser", "ppppp") == OpRegister.REGISTER_SUCCESS)
                            DoAlterations(0, "RegistoSucesso: OK     ");
                        else
                            DoAlterations(0, "RegistoSucesso: TesteErro     ");



                        DoAlterations(0, "          [Diginote]   ");
                        if (userService.GetDiginotesNumber(2)==3)
                            DoAlterations(0, "User 2 DininotesAmmount: OK     ");
                        else
                            DoAlterations(0, "User 2 DininotesAmmount: TesteErro     ");``/
            */
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void AddDiginoteBtnClick(object sender, EventArgs e)
        {
            if(userService.CreateNewDiginote(user.id))
            {
                UI_UpdateTotalDiginotesNumber(userService.GetDiginotesNumber(user.id));
                UI_UpdateMyDigicoinsTable(userService.GetMyDiginotesIDList(user.id));
            }
        }

        private void AddToBalanceBtnClick(object sender, EventArgs e)
        {
            int moneyAmmount;
            if (!int.TryParse(AddToBalanceTextBox.Text, out moneyAmmount))
            {
                MessageBox.Show("Valor inválido");
                return;
            }

            if (userService.AddMoney(user.id, moneyAmmount))
                UI_UpdateBalance(userService.GetUserBalance(user.id));
        }



        private void BuyOrderAdd(object sender, EventArgs e)
        {

        }



        private void SellOrderTableColumnClick(object sender, DataGridViewCellEventArgs e)
        {
            if(SellOrdersGridView.Columns[e.ColumnIndex].Name == "Confirm")
            {
                if ((bool)SellOrdersGridView.Rows[e.RowIndex].Cells[2].Value) //Is suspended?
                {
                    if (MessageBox.Show("Confirmar Sell Order ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int orderID = (int)SellOrdersGridView.Rows[e.RowIndex].Cells[0].Value;
                        if (userService.ConfirmPriceOfOrder(orderID, true))
                            UI_UpdateSellOrdersTable(userService.GetUserSellOrdersList(user.id));
                    }
                }
                else
                    MessageBox.Show("Esta Sell Order não está suspensa !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (SellOrdersGridView.Columns[e.ColumnIndex].Name == "Withdraw")
            {
                if (MessageBox.Show("Withdraw Sell Order ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int orderID = (int)SellOrdersGridView.Rows[e.RowIndex].Cells[0].Value;
                    if (userService.Withdraw(orderID, true))
                        UI_UpdateSellOrdersTable(userService.GetUserSellOrdersList(user.id));
                }
            }
        }



        private void BuyOrderTableColumnClick(object sender, DataGridViewCellEventArgs e)
        {
            if (BuyOrdersdataGridView.Columns[e.ColumnIndex].Name == "ConfirmBuyOrderTable")
            {
                if ((bool)BuyOrdersdataGridView.Rows[e.RowIndex].Cells[2].Value) //Is suspended?
                {
                    if (MessageBox.Show("Confirmar Buy Order ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int orderID = (int)BuyOrdersdataGridView.Rows[e.RowIndex].Cells[0].Value;
                        if(userService.ConfirmPriceOfOrder(orderID, false))
                            UI_UpdateBuyOrdersTable(userService.GetUserBuyOrdersList(user.id));
                    }
                }
                else
                    MessageBox.Show("Esta Buy Order não está suspensa !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (BuyOrdersdataGridView.Columns[e.ColumnIndex].Name == "WithdrawBuyOrderTable")
            {
                if (MessageBox.Show("Withdraw BuyOrder?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int orderID = (int)BuyOrdersdataGridView.Rows[e.RowIndex].Cells[0].Value;
                    if(userService.Withdraw(orderID, false))
                        UI_UpdateBuyOrdersTable(userService.GetUserBuyOrdersList(user.id));
                }
            }
        }

        private void ChangePriceOfferClick(object sender, EventArgs e)
        {
            decimal newQuota;
            if (!decimal.TryParse(newPriceOfferTxt.Text, out newQuota))
            {
                MessageBox.Show("Valor inválido, tenha cuidado com as virgulas");
                return;
            }


            if(userService.GetUserBuyOrdersList(user.id) != null && userService.GetUserSellOrdersList(user.id) != null) //Tanto pode para cima como para baixo
            {
                if (newQuota >= userService.GetCurrentQuote())
                {
                    if (userService.SetNewQuota(newQuota, false, user.id))
                        MessageBox.Show("Quota mudada");
                    else
                        MessageBox.Show("Tente um valor diferente");
                }
                else
                {
                    if (userService.SetNewQuota(newQuota, true, user.id))
                        MessageBox.Show("Quota mudada");
                    else
                        MessageBox.Show("Tente um valor diferente");
                }
            }
            else if(userService.GetUserBuyOrdersList(user.id)!= null) //para poder mudar
            {
                if (newQuota >= userService.GetCurrentQuote()) //valor superior pode
                {
                    if (userService.SetNewQuota(newQuota, false, user.id))
                        MessageBox.Show("Quota mudada");
                    else
                        MessageBox.Show("Tente um valor diferente");
                }
                else
                    MessageBox.Show("Tente um valor diferente");
            }
            else if (userService.GetUserSellOrdersList(user.id) != null) //para poder mudar
            {
                if (newQuota <= userService.GetCurrentQuote()) //valor inferior pode
                {
                    if (userService.SetNewQuota(newQuota, true, user.id))
                        MessageBox.Show("Quota mudada");
                    else
                        MessageBox.Show("Tente um valor diferente");
                }
                else
                    MessageBox.Show("Tente um valor diferente");
            }
            else
                MessageBox.Show("Não pode mudar a Quota");

            UI_UpdateQuotaValue(userService.GetCurrentQuote());
            UI_UpdateTransacionsTable(userService.GetMyTransactions(user.id));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            WelcomeWindowForm welcomeWindowForm = new WelcomeWindowForm(true);
            welcomeWindowForm.ShowDialog();
            this.Close();
        }
    }
}
