namespace Solver
{
    partial class MainWindowForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AViewButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AssignedTicketsBinding = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.SelectedUTicketTitle = new System.Windows.Forms.TextBox();
            this.SelectedUTicketDescription = new System.Windows.Forms.TextBox();
            this.UnassignedTicketsGrid = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UAssignButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.UnassignedTicketsBinding = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssignedTicketsBinding)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnassignedTicketsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnassignedTicketsBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 68);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(691, 476);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(683, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Your Tickets";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.titleDataGridViewTextBoxColumn1,
            this.descriptionDataGridViewTextBoxColumn1,
            this.dateDataGridViewTextBoxColumn1,
            this.stateDataGridViewTextBoxColumn,
            this.AViewButtonColumn});
            this.dataGridView1.DataSource = this.AssignedTicketsBinding;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(677, 444);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idDataGridViewTextBoxColumn1.Width = 50;
            // 
            // titleDataGridViewTextBoxColumn1
            // 
            this.titleDataGridViewTextBoxColumn1.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn1.HeaderText = "title";
            this.titleDataGridViewTextBoxColumn1.Name = "titleDataGridViewTextBoxColumn1";
            this.titleDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn1
            // 
            this.descriptionDataGridViewTextBoxColumn1.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn1.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn1.Name = "descriptionDataGridViewTextBoxColumn1";
            this.descriptionDataGridViewTextBoxColumn1.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn1.Width = 190;
            // 
            // dateDataGridViewTextBoxColumn1
            // 
            this.dateDataGridViewTextBoxColumn1.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn1.HeaderText = "date";
            this.dateDataGridViewTextBoxColumn1.Name = "dateDataGridViewTextBoxColumn1";
            this.dateDataGridViewTextBoxColumn1.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn1.Width = 150;
            // 
            // stateDataGridViewTextBoxColumn
            // 
            this.stateDataGridViewTextBoxColumn.DataPropertyName = "state";
            this.stateDataGridViewTextBoxColumn.HeaderText = "state";
            this.stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            this.stateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // AViewButtonColumn
            // 
            this.AViewButtonColumn.DataPropertyName = "id";
            this.AViewButtonColumn.HeaderText = "";
            this.AViewButtonColumn.Name = "AViewButtonColumn";
            this.AViewButtonColumn.ReadOnly = true;
            this.AViewButtonColumn.Text = "View";
            this.AViewButtonColumn.UseColumnTextForButtonValue = true;
            this.AViewButtonColumn.Width = 83;
            // 
            // AssignedTicketsBinding
            // 
            this.AssignedTicketsBinding.DataSource = typeof(Common.Ticket);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.SelectedUTicketTitle);
            this.tabPage2.Controls.Add(this.SelectedUTicketDescription);
            this.tabPage2.Controls.Add(this.UnassignedTicketsGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(683, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Unassigned Tickets";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ticket:";
            // 
            // SelectedUTicketTitle
            // 
            this.SelectedUTicketTitle.Location = new System.Drawing.Point(49, 307);
            this.SelectedUTicketTitle.Name = "SelectedUTicketTitle";
            this.SelectedUTicketTitle.ReadOnly = true;
            this.SelectedUTicketTitle.Size = new System.Drawing.Size(625, 20);
            this.SelectedUTicketTitle.TabIndex = 2;
            // 
            // SelectedUTicketDescription
            // 
            this.SelectedUTicketDescription.Location = new System.Drawing.Point(3, 333);
            this.SelectedUTicketDescription.Multiline = true;
            this.SelectedUTicketDescription.Name = "SelectedUTicketDescription";
            this.SelectedUTicketDescription.ReadOnly = true;
            this.SelectedUTicketDescription.Size = new System.Drawing.Size(671, 111);
            this.SelectedUTicketDescription.TabIndex = 1;
            // 
            // UnassignedTicketsGrid
            // 
            this.UnassignedTicketsGrid.AutoGenerateColumns = false;
            this.UnassignedTicketsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UnassignedTicketsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.UAssignButtonColumn});
            this.UnassignedTicketsGrid.DataSource = this.UnassignedTicketsBinding;
            this.UnassignedTicketsGrid.Location = new System.Drawing.Point(3, 3);
            this.UnassignedTicketsGrid.Name = "UnassignedTicketsGrid";
            this.UnassignedTicketsGrid.RowHeadersVisible = false;
            this.UnassignedTicketsGrid.Size = new System.Drawing.Size(677, 298);
            this.UnassignedTicketsGrid.TabIndex = 0;
            this.UnassignedTicketsGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UnassignedTicketsGrid_CellClick);
            this.UnassignedTicketsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UnassignedTicketsGrid_CellContentClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 50;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 290;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.Width = 150;
            // 
            // UAssignButtonColumn
            // 
            this.UAssignButtonColumn.HeaderText = "";
            this.UAssignButtonColumn.Name = "UAssignButtonColumn";
            this.UAssignButtonColumn.Text = "Assign";
            this.UAssignButtonColumn.UseColumnTextForButtonValue = true;
            this.UAssignButtonColumn.Width = 83;
            // 
            // UnassignedTicketsBinding
            // 
            this.UnassignedTicketsBinding.DataSource = typeof(Common.Ticket);
            this.UnassignedTicketsBinding.CurrentChanged += new System.EventHandler(this.UnassignedTicketsBinding_CurrentChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 569);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainWindowForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Close);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssignedTicketsBinding)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnassignedTicketsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnassignedTicketsBinding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView UnassignedTicketsGrid;
        private System.Windows.Forms.BindingSource UnassignedTicketsBinding;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource AssignedTicketsBinding;
        private System.Windows.Forms.TextBox SelectedUTicketTitle;
        private System.Windows.Forms.TextBox SelectedUTicketDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn AViewButtonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn UAssignButtonColumn;
    }
}

