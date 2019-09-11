namespace Client
{
    partial class MainWindow
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SellOrdersGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nDiginotesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suspendedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Confirm = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Withdraw = new System.Windows.Forms.DataGridViewButtonColumn();
            this.sellOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sNameLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UsernameLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BalanceLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MyDiginotesdataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diginoteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.QuotaValueLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diginoteIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trasQuotaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.AddToBalanceTextBox = new System.Windows.Forms.TextBox();
            this.AddDiginoteBtn = new System.Windows.Forms.Button();
            this.AddToBalanceBtn = new System.Windows.Forms.Button();
            this.AddSellOrderBtn = new System.Windows.Forms.Button();
            this.SellOrderDiginoteAmmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.BuyOrderDiginoteAmmount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.NdiginotesLbl = new System.Windows.Forms.Label();
            this.BuyOrdersdataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ConfirmBuyOrderTable = new System.Windows.Forms.DataGridViewButtonColumn();
            this.WithdrawBuyOrderTable = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buyOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.newPriceOfferTxt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SellOrdersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyDiginotesdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diginoteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuyOrdersdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buyOrderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SellOrdersGridView
            // 
            this.SellOrdersGridView.AllowUserToAddRows = false;
            this.SellOrdersGridView.AllowUserToDeleteRows = false;
            this.SellOrdersGridView.AutoGenerateColumns = false;
            this.SellOrdersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SellOrdersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nDiginotesDataGridViewTextBoxColumn,
            this.suspendedDataGridViewCheckBoxColumn,
            this.Confirm,
            this.Withdraw});
            this.SellOrdersGridView.DataSource = this.sellOrderBindingSource;
            this.SellOrdersGridView.Location = new System.Drawing.Point(16, 316);
            this.SellOrdersGridView.Name = "SellOrdersGridView";
            this.SellOrdersGridView.ReadOnly = true;
            this.SellOrdersGridView.Size = new System.Drawing.Size(380, 122);
            this.SellOrdersGridView.TabIndex = 1;
            this.SellOrdersGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SellOrderTableColumnClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.idDataGridViewTextBoxColumn.Width = 20;
            // 
            // nDiginotesDataGridViewTextBoxColumn
            // 
            this.nDiginotesDataGridViewTextBoxColumn.DataPropertyName = "nDiginotes";
            this.nDiginotesDataGridViewTextBoxColumn.HeaderText = "nDiginotes";
            this.nDiginotesDataGridViewTextBoxColumn.Name = "nDiginotesDataGridViewTextBoxColumn";
            this.nDiginotesDataGridViewTextBoxColumn.ReadOnly = true;
            this.nDiginotesDataGridViewTextBoxColumn.Width = 60;
            // 
            // suspendedDataGridViewCheckBoxColumn
            // 
            this.suspendedDataGridViewCheckBoxColumn.DataPropertyName = "suspended";
            this.suspendedDataGridViewCheckBoxColumn.HeaderText = "suspended";
            this.suspendedDataGridViewCheckBoxColumn.Name = "suspendedDataGridViewCheckBoxColumn";
            this.suspendedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.suspendedDataGridViewCheckBoxColumn.Width = 70;
            // 
            // Confirm
            // 
            this.Confirm.HeaderText = "Confirm";
            this.Confirm.Name = "Confirm";
            this.Confirm.ReadOnly = true;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseColumnTextForButtonValue = true;
            this.Confirm.Width = 70;
            // 
            // Withdraw
            // 
            this.Withdraw.HeaderText = "Withdraw";
            this.Withdraw.Name = "Withdraw";
            this.Withdraw.ReadOnly = true;
            this.Withdraw.Text = "Withdraw";
            this.Withdraw.UseColumnTextForButtonValue = true;
            this.Withdraw.Width = 70;
            // 
            // sellOrderBindingSource
            // 
            this.sellOrderBindingSource.DataSource = typeof(Remote.SellOrder);
            // 
            // sNameLbl
            // 
            this.sNameLbl.AutoSize = true;
            this.sNameLbl.Location = new System.Drawing.Point(7, 9);
            this.sNameLbl.Name = "sNameLbl";
            this.sNameLbl.Size = new System.Drawing.Size(35, 13);
            this.sNameLbl.TabIndex = 3;
            this.sNameLbl.Text = "Name";
            this.sNameLbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Location = new System.Drawing.Point(48, 9);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(22, 13);
            this.NameLbl.TabIndex = 4;
            this.NameLbl.Text = "     ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username";
            // 
            // UsernameLbl
            // 
            this.UsernameLbl.AutoSize = true;
            this.UsernameLbl.Location = new System.Drawing.Point(68, 28);
            this.UsernameLbl.Name = "UsernameLbl";
            this.UsernameLbl.Size = new System.Drawing.Size(22, 13);
            this.UsernameLbl.TabIndex = 6;
            this.UsernameLbl.Text = "     ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "MyDiginotes";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Balance €:";
            // 
            // BalanceLbl
            // 
            this.BalanceLbl.AutoSize = true;
            this.BalanceLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BalanceLbl.ForeColor = System.Drawing.Color.SeaGreen;
            this.BalanceLbl.Location = new System.Drawing.Point(94, 72);
            this.BalanceLbl.Name = "BalanceLbl";
            this.BalanceLbl.Size = new System.Drawing.Size(23, 16);
            this.BalanceLbl.TabIndex = 9;
            this.BalanceLbl.Text = "     ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "SellOrders";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 447);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "BuyOrders";
            // 
            // MyDiginotesdataGridView
            // 
            this.MyDiginotesdataGridView.AllowUserToAddRows = false;
            this.MyDiginotesdataGridView.AllowUserToDeleteRows = false;
            this.MyDiginotesdataGridView.AutoGenerateColumns = false;
            this.MyDiginotesdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MyDiginotesdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1});
            this.MyDiginotesdataGridView.DataSource = this.diginoteBindingSource;
            this.MyDiginotesdataGridView.Location = new System.Drawing.Point(227, 21);
            this.MyDiginotesdataGridView.Name = "MyDiginotesdataGridView";
            this.MyDiginotesdataGridView.ReadOnly = true;
            this.MyDiginotesdataGridView.Size = new System.Drawing.Size(78, 116);
            this.MyDiginotesdataGridView.TabIndex = 12;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idDataGridViewTextBoxColumn1.Width = 20;
            // 
            // diginoteBindingSource
            // 
            this.diginoteBindingSource.DataSource = typeof(Remote.Diginote);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(317, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Quota Value:";
            // 
            // QuotaValueLbl
            // 
            this.QuotaValueLbl.AutoSize = true;
            this.QuotaValueLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuotaValueLbl.ForeColor = System.Drawing.Color.SteelBlue;
            this.QuotaValueLbl.Location = new System.Drawing.Point(431, 9);
            this.QuotaValueLbl.Name = "QuotaValueLbl";
            this.QuotaValueLbl.Size = new System.Drawing.Size(19, 20);
            this.QuotaValueLbl.TabIndex = 14;
            this.QuotaValueLbl.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Transactions";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn2,
            this.fromIDDataGridViewTextBoxColumn,
            this.toIDDataGridViewTextBoxColumn,
            this.diginoteIDDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.trasQuotaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.transactionBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(16, 174);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(486, 116);
            this.dataGridView1.TabIndex = 17;
            // 
            // idDataGridViewTextBoxColumn2
            // 
            this.idDataGridViewTextBoxColumn2.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn2.HeaderText = "id";
            this.idDataGridViewTextBoxColumn2.Name = "idDataGridViewTextBoxColumn2";
            this.idDataGridViewTextBoxColumn2.ReadOnly = true;
            this.idDataGridViewTextBoxColumn2.Width = 25;
            // 
            // fromIDDataGridViewTextBoxColumn
            // 
            this.fromIDDataGridViewTextBoxColumn.DataPropertyName = "fromID";
            this.fromIDDataGridViewTextBoxColumn.HeaderText = "fromID";
            this.fromIDDataGridViewTextBoxColumn.Name = "fromIDDataGridViewTextBoxColumn";
            this.fromIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.fromIDDataGridViewTextBoxColumn.Width = 40;
            // 
            // toIDDataGridViewTextBoxColumn
            // 
            this.toIDDataGridViewTextBoxColumn.DataPropertyName = "toID";
            this.toIDDataGridViewTextBoxColumn.HeaderText = "toID";
            this.toIDDataGridViewTextBoxColumn.Name = "toIDDataGridViewTextBoxColumn";
            this.toIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.toIDDataGridViewTextBoxColumn.Width = 40;
            // 
            // diginoteIDDataGridViewTextBoxColumn
            // 
            this.diginoteIDDataGridViewTextBoxColumn.DataPropertyName = "diginoteID";
            this.diginoteIDDataGridViewTextBoxColumn.HeaderText = "diginoteID";
            this.diginoteIDDataGridViewTextBoxColumn.Name = "diginoteIDDataGridViewTextBoxColumn";
            this.diginoteIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.diginoteIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.Width = 200;
            // 
            // trasQuotaDataGridViewTextBoxColumn
            // 
            this.trasQuotaDataGridViewTextBoxColumn.DataPropertyName = "trasQuota";
            this.trasQuotaDataGridViewTextBoxColumn.HeaderText = "Quota";
            this.trasQuotaDataGridViewTextBoxColumn.Name = "trasQuotaDataGridViewTextBoxColumn";
            this.trasQuotaDataGridViewTextBoxColumn.ReadOnly = true;
            this.trasQuotaDataGridViewTextBoxColumn.Width = 50;
            // 
            // transactionBindingSource
            // 
            this.transactionBindingSource.DataSource = typeof(Remote.Transaction);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(424, 313);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "DEBUG:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(425, 343);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Add 1 Diginote";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Add to Balance:";
            // 
            // AddToBalanceTextBox
            // 
            this.AddToBalanceTextBox.Location = new System.Drawing.Point(96, 99);
            this.AddToBalanceTextBox.Name = "AddToBalanceTextBox";
            this.AddToBalanceTextBox.Size = new System.Drawing.Size(66, 20);
            this.AddToBalanceTextBox.TabIndex = 21;
            // 
            // AddDiginoteBtn
            // 
            this.AddDiginoteBtn.Location = new System.Drawing.Point(446, 359);
            this.AddDiginoteBtn.Name = "AddDiginoteBtn";
            this.AddDiginoteBtn.Size = new System.Drawing.Size(39, 23);
            this.AddDiginoteBtn.TabIndex = 22;
            this.AddDiginoteBtn.Text = "Add";
            this.AddDiginoteBtn.UseVisualStyleBackColor = true;
            this.AddDiginoteBtn.Click += new System.EventHandler(this.AddDiginoteBtnClick);
            // 
            // AddToBalanceBtn
            // 
            this.AddToBalanceBtn.Location = new System.Drawing.Point(168, 97);
            this.AddToBalanceBtn.Name = "AddToBalanceBtn";
            this.AddToBalanceBtn.Size = new System.Drawing.Size(39, 23);
            this.AddToBalanceBtn.TabIndex = 23;
            this.AddToBalanceBtn.Text = "Add";
            this.AddToBalanceBtn.UseVisualStyleBackColor = true;
            this.AddToBalanceBtn.Click += new System.EventHandler(this.AddToBalanceBtnClick);
            // 
            // AddSellOrderBtn
            // 
            this.AddSellOrderBtn.Location = new System.Drawing.Point(451, 83);
            this.AddSellOrderBtn.Name = "AddSellOrderBtn";
            this.AddSellOrderBtn.Size = new System.Drawing.Size(39, 23);
            this.AddSellOrderBtn.TabIndex = 26;
            this.AddSellOrderBtn.Text = "Add";
            this.AddSellOrderBtn.UseVisualStyleBackColor = true;
            this.AddSellOrderBtn.Click += new System.EventHandler(this.AddSellOrderBtnClick);
            // 
            // SellOrderDiginoteAmmount
            // 
            this.SellOrderDiginoteAmmount.Location = new System.Drawing.Point(396, 86);
            this.SellOrderDiginoteAmmount.Name = "SellOrderDiginoteAmmount";
            this.SellOrderDiginoteAmmount.Size = new System.Drawing.Size(49, 20);
            this.SellOrderDiginoteAmmount.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(320, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Add Sell Order";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(451, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.AddBuyOrderBtnClick);
            // 
            // BuyOrderDiginoteAmmount
            // 
            this.BuyOrderDiginoteAmmount.Location = new System.Drawing.Point(396, 123);
            this.BuyOrderDiginoteAmmount.Name = "BuyOrderDiginoteAmmount";
            this.BuyOrderDiginoteAmmount.Size = new System.Drawing.Size(49, 20);
            this.BuyOrderDiginoteAmmount.TabIndex = 28;
            this.BuyOrderDiginoteAmmount.Click += new System.EventHandler(this.BuyOrderAdd);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(320, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Add Buy Order";
            // 
            // NdiginotesLbl
            // 
            this.NdiginotesLbl.AutoSize = true;
            this.NdiginotesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NdiginotesLbl.Location = new System.Drawing.Point(264, 138);
            this.NdiginotesLbl.Name = "NdiginotesLbl";
            this.NdiginotesLbl.Size = new System.Drawing.Size(15, 15);
            this.NdiginotesLbl.TabIndex = 30;
            this.NdiginotesLbl.Text = "0";
            // 
            // BuyOrdersdataGridView
            // 
            this.BuyOrdersdataGridView.AllowUserToAddRows = false;
            this.BuyOrdersdataGridView.AllowUserToDeleteRows = false;
            this.BuyOrdersdataGridView.AutoGenerateColumns = false;
            this.BuyOrdersdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BuyOrdersdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewCheckBoxColumn1,
            this.ConfirmBuyOrderTable,
            this.WithdrawBuyOrderTable});
            this.BuyOrdersdataGridView.DataSource = this.buyOrderBindingSource;
            this.BuyOrdersdataGridView.Location = new System.Drawing.Point(15, 463);
            this.BuyOrdersdataGridView.Name = "BuyOrdersdataGridView";
            this.BuyOrdersdataGridView.ReadOnly = true;
            this.BuyOrdersdataGridView.Size = new System.Drawing.Size(380, 122);
            this.BuyOrdersdataGridView.TabIndex = 31;
            this.BuyOrdersdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BuyOrderTableColumnClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 20;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "nDiginotes";
            this.dataGridViewTextBoxColumn2.HeaderText = "nDiginotes";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "suspended";
            this.dataGridViewCheckBoxColumn1.HeaderText = "suspended";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 70;
            // 
            // ConfirmBuyOrderTable
            // 
            this.ConfirmBuyOrderTable.HeaderText = "Confirm";
            this.ConfirmBuyOrderTable.Name = "ConfirmBuyOrderTable";
            this.ConfirmBuyOrderTable.ReadOnly = true;
            this.ConfirmBuyOrderTable.Text = "Confirm";
            this.ConfirmBuyOrderTable.UseColumnTextForButtonValue = true;
            this.ConfirmBuyOrderTable.Width = 70;
            // 
            // WithdrawBuyOrderTable
            // 
            this.WithdrawBuyOrderTable.HeaderText = "Withdraw";
            this.WithdrawBuyOrderTable.Name = "WithdrawBuyOrderTable";
            this.WithdrawBuyOrderTable.ReadOnly = true;
            this.WithdrawBuyOrderTable.Text = "Withdraw";
            this.WithdrawBuyOrderTable.UseColumnTextForButtonValue = true;
            this.WithdrawBuyOrderTable.Width = 70;
            // 
            // buyOrderBindingSource
            // 
            this.buyOrderBindingSource.DataSource = typeof(Remote.BuyOrder);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(224, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 15);
            this.label13.TabIndex = 32;
            this.label13.Text = "Total:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(449, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Change";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ChangePriceOfferClick);
            // 
            // newPriceOfferTxt
            // 
            this.newPriceOfferTxt.Location = new System.Drawing.Point(397, 39);
            this.newPriceOfferTxt.Name = "newPriceOfferTxt";
            this.newPriceOfferTxt.Size = new System.Drawing.Size(49, 20);
            this.newPriceOfferTxt.TabIndex = 34;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(316, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "New Price Offer";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 36;
            this.button3.Text = "Logout";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 594);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.newPriceOfferTxt);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.BuyOrdersdataGridView);
            this.Controls.Add(this.NdiginotesLbl);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BuyOrderDiginoteAmmount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.AddSellOrderBtn);
            this.Controls.Add(this.SellOrderDiginoteAmmount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.AddToBalanceBtn);
            this.Controls.Add(this.AddDiginoteBtn);
            this.Controls.Add(this.AddToBalanceTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.QuotaValueLbl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MyDiginotesdataGridView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BalanceLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UsernameLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.sNameLbl);
            this.Controls.Add(this.SellOrdersGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.Text = "Diginotes Trader";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SellOrdersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyDiginotesdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diginoteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuyOrdersdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buyOrderBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView SellOrdersGridView;
        private System.Windows.Forms.Label sNameLbl;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label UsernameLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label BalanceLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView MyDiginotesdataGridView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label QuotaValueLbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox AddToBalanceTextBox;
        private System.Windows.Forms.Button AddDiginoteBtn;
        private System.Windows.Forms.Button AddToBalanceBtn;
        private System.Windows.Forms.Button AddSellOrderBtn;
        private System.Windows.Forms.TextBox SellOrderDiginoteAmmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox BuyOrderDiginoteAmmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label NdiginotesLbl;
        private System.Windows.Forms.BindingSource sellOrderBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDiginotesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn suspendedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Confirm;
        private System.Windows.Forms.DataGridViewButtonColumn Withdraw;
        private System.Windows.Forms.DataGridView BuyOrdersdataGridView;
        private System.Windows.Forms.BindingSource buyOrderBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource diginoteBindingSource;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diginoteIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trasQuotaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource transactionBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox newPriceOfferTxt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn ConfirmBuyOrderTable;
        private System.Windows.Forms.DataGridViewButtonColumn WithdrawBuyOrderTable;
        private System.Windows.Forms.Button button3;
    }
}

