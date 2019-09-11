namespace Solver
{
    partial class TicketForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.closeTicketBtn = new System.Windows.Forms.Button();
            this.finalAnswer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.sendQuestionTitle = new System.Windows.Forms.TextBox();
            this.sendQuestionBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.sendQuestionDescription = new System.Windows.Forms.TextBox();
            this.answeredList = new System.Windows.Forms.ListBox();
            this.AquestionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.selectedQuestionAnswer = new System.Windows.Forms.TextBox();
            this.selectedQuestionQuestion = new System.Windows.Forms.TextBox();
            this.selectedQuestionTitle = new System.Windows.Forms.TextBox();
            this.pendingList = new System.Windows.Forms.ListBox();
            this.PquestionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.ticketInfoLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AquestionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PquestionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(17, 44);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(917, 523);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.closeTicketBtn);
            this.tabPage1.Controls.Add(this.finalAnswer);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.descriptionBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.titleBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.emailBox);
            this.tabPage1.Controls.Add(this.nameBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(909, 494);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Overview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(461, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Final Answer:";
            // 
            // closeTicketBtn
            // 
            this.closeTicketBtn.Enabled = false;
            this.closeTicketBtn.Location = new System.Drawing.Point(465, 441);
            this.closeTicketBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closeTicketBtn.Name = "closeTicketBtn";
            this.closeTicketBtn.Size = new System.Drawing.Size(428, 43);
            this.closeTicketBtn.TabIndex = 9;
            this.closeTicketBtn.Text = "CLOSE TICKET";
            this.closeTicketBtn.UseVisualStyleBackColor = true;
            this.closeTicketBtn.Click += new System.EventHandler(this.closeTicketBtn_Click);
            // 
            // finalAnswer
            // 
            this.finalAnswer.Location = new System.Drawing.Point(465, 37);
            this.finalAnswer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.finalAnswer.Multiline = true;
            this.finalAnswer.Name = "finalAnswer";
            this.finalAnswer.Size = new System.Drawing.Size(427, 395);
            this.finalAnswer.TabIndex = 8;
            this.finalAnswer.TextChanged += new System.EventHandler(this.finalAnswer_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 193);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Description:";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(8, 213);
            this.descriptionBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.ReadOnly = true;
            this.descriptionBox.Size = new System.Drawing.Size(417, 270);
            this.descriptionBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Title:";
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(8, 151);
            this.titleBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.titleBox.Name = "titleBox";
            this.titleBox.ReadOnly = true;
            this.titleBox.Size = new System.Drawing.Size(417, 22);
            this.titleBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Author Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Author Name:";
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(8, 92);
            this.emailBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.emailBox.Name = "emailBox";
            this.emailBox.ReadOnly = true;
            this.emailBox.Size = new System.Drawing.Size(417, 22);
            this.emailBox.TabIndex = 1;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(8, 37);
            this.nameBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(417, 22);
            this.nameBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.sendQuestionTitle);
            this.tabPage2.Controls.Add(this.sendQuestionBtn);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.sendQuestionDescription);
            this.tabPage2.Controls.Add(this.answeredList);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.selectedQuestionAnswer);
            this.tabPage2.Controls.Add(this.selectedQuestionQuestion);
            this.tabPage2.Controls.Add(this.selectedQuestionTitle);
            this.tabPage2.Controls.Add(this.pendingList);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(909, 494);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Questions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(265, 17);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 17);
            this.label12.TabIndex = 16;
            this.label12.Text = "Answered:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 17);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "Pending:";
            // 
            // sendQuestionTitle
            // 
            this.sendQuestionTitle.Location = new System.Drawing.Point(543, 37);
            this.sendQuestionTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendQuestionTitle.Name = "sendQuestionTitle";
            this.sendQuestionTitle.Size = new System.Drawing.Size(331, 22);
            this.sendQuestionTitle.TabIndex = 14;
            this.sendQuestionTitle.TextChanged += new System.EventHandler(this.Question_TextChanged);
            // 
            // sendQuestionBtn
            // 
            this.sendQuestionBtn.Enabled = false;
            this.sendQuestionBtn.Location = new System.Drawing.Point(543, 432);
            this.sendQuestionBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendQuestionBtn.Name = "sendQuestionBtn";
            this.sendQuestionBtn.Size = new System.Drawing.Size(332, 50);
            this.sendQuestionBtn.TabIndex = 13;
            this.sendQuestionBtn.Text = "SEND";
            this.sendQuestionBtn.UseVisualStyleBackColor = true;
            this.sendQuestionBtn.Click += new System.EventHandler(this.sendQuestionBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(539, 17);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 17);
            this.label9.TabIndex = 12;
            this.label9.Text = "Send Question:";
            // 
            // sendQuestionDescription
            // 
            this.sendQuestionDescription.Location = new System.Drawing.Point(543, 69);
            this.sendQuestionDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendQuestionDescription.Multiline = true;
            this.sendQuestionDescription.Name = "sendQuestionDescription";
            this.sendQuestionDescription.Size = new System.Drawing.Size(331, 355);
            this.sendQuestionDescription.TabIndex = 11;
            this.sendQuestionDescription.TextChanged += new System.EventHandler(this.Question_TextChanged);
            // 
            // answeredList
            // 
            this.answeredList.DataSource = this.AquestionBindingSource;
            this.answeredList.DisplayMember = "title";
            this.answeredList.FormattingEnabled = true;
            this.answeredList.ItemHeight = 16;
            this.answeredList.Location = new System.Drawing.Point(269, 37);
            this.answeredList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.answeredList.Name = "answeredList";
            this.answeredList.Size = new System.Drawing.Size(247, 116);
            this.answeredList.TabIndex = 10;
            this.answeredList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.answeredList_Selected);
            // 
            // AquestionBindingSource
            // 
            this.AquestionBindingSource.DataSource = typeof(Common.Question);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 354);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Answer:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 172);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Question:";
            // 
            // selectedQuestionAnswer
            // 
            this.selectedQuestionAnswer.Location = new System.Drawing.Point(9, 374);
            this.selectedQuestionAnswer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectedQuestionAnswer.Multiline = true;
            this.selectedQuestionAnswer.Name = "selectedQuestionAnswer";
            this.selectedQuestionAnswer.ReadOnly = true;
            this.selectedQuestionAnswer.Size = new System.Drawing.Size(503, 109);
            this.selectedQuestionAnswer.TabIndex = 6;
            // 
            // selectedQuestionQuestion
            // 
            this.selectedQuestionQuestion.Location = new System.Drawing.Point(9, 224);
            this.selectedQuestionQuestion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectedQuestionQuestion.Multiline = true;
            this.selectedQuestionQuestion.Name = "selectedQuestionQuestion";
            this.selectedQuestionQuestion.ReadOnly = true;
            this.selectedQuestionQuestion.Size = new System.Drawing.Size(503, 109);
            this.selectedQuestionQuestion.TabIndex = 5;
            // 
            // selectedQuestionTitle
            // 
            this.selectedQuestionTitle.Location = new System.Drawing.Point(9, 192);
            this.selectedQuestionTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectedQuestionTitle.Name = "selectedQuestionTitle";
            this.selectedQuestionTitle.ReadOnly = true;
            this.selectedQuestionTitle.Size = new System.Drawing.Size(503, 22);
            this.selectedQuestionTitle.TabIndex = 4;
            // 
            // pendingList
            // 
            this.pendingList.DataSource = this.PquestionBindingSource;
            this.pendingList.DisplayMember = "title";
            this.pendingList.FormattingEnabled = true;
            this.pendingList.ItemHeight = 16;
            this.pendingList.Location = new System.Drawing.Point(9, 37);
            this.pendingList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pendingList.Name = "pendingList";
            this.pendingList.Size = new System.Drawing.Size(247, 116);
            this.pendingList.TabIndex = 0;
            this.pendingList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pendingList_Selected);
            // 
            // PquestionBindingSource
            // 
            this.PquestionBindingSource.DataSource = typeof(Common.Question);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 11);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "Ticket:";
            // 
            // ticketInfoLabel
            // 
            this.ticketInfoLabel.AutoSize = true;
            this.ticketInfoLabel.Location = new System.Drawing.Point(77, 11);
            this.ticketInfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ticketInfoLabel.Name = "ticketInfoLabel";
            this.ticketInfoLabel.Size = new System.Drawing.Size(99, 17);
            this.ticketInfoLabel.TabIndex = 15;
            this.ticketInfoLabel.Text = "ticketInfoLabel";
            // 
            // TicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 582);
            this.Controls.Add(this.ticketInfoLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TicketForm";
            this.Text = "Ticket Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_Close);
            this.Load += new System.EventHandler(this.TicketForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AquestionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PquestionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button closeTicketBtn;
        private System.Windows.Forms.TextBox finalAnswer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button sendQuestionBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox sendQuestionDescription;
        private System.Windows.Forms.ListBox answeredList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox selectedQuestionAnswer;
        private System.Windows.Forms.TextBox selectedQuestionQuestion;
        private System.Windows.Forms.TextBox selectedQuestionTitle;
        private System.Windows.Forms.ListBox pendingList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label ticketInfoLabel;
        private System.Windows.Forms.TextBox sendQuestionTitle;
        private System.Windows.Forms.BindingSource PquestionBindingSource;
        private System.Windows.Forms.BindingSource AquestionBindingSource;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}