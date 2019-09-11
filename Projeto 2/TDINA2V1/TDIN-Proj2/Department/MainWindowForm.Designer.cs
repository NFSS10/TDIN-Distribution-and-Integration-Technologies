namespace Departments
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
            this.answerTxt = new System.Windows.Forms.TextBox();
            this.answerBtn = new System.Windows.Forms.Button();
            this.questionTitleTxt = new System.Windows.Forms.TextBox();
            this.questionDetailsTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.questionsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // answerTxt
            // 
            this.answerTxt.Location = new System.Drawing.Point(349, 348);
            this.answerTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.answerTxt.Multiline = true;
            this.answerTxt.Name = "answerTxt";
            this.answerTxt.Size = new System.Drawing.Size(913, 179);
            this.answerTxt.TabIndex = 3;
            this.answerTxt.TextChanged += new System.EventHandler(this.OnAnswerTxt_TextChanged);
            // 
            // answerBtn
            // 
            this.answerBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.answerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerBtn.Location = new System.Drawing.Point(349, 535);
            this.answerBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.answerBtn.Name = "answerBtn";
            this.answerBtn.Size = new System.Drawing.Size(915, 57);
            this.answerBtn.TabIndex = 4;
            this.answerBtn.Text = "Answer";
            this.answerBtn.UseVisualStyleBackColor = false;
            this.answerBtn.Click += new System.EventHandler(this.AnswerBtnClick);
            // 
            // questionTitleTxt
            // 
            this.questionTitleTxt.BackColor = System.Drawing.SystemColors.Control;
            this.questionTitleTxt.Location = new System.Drawing.Point(349, 50);
            this.questionTitleTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.questionTitleTxt.Name = "questionTitleTxt";
            this.questionTitleTxt.ReadOnly = true;
            this.questionTitleTxt.Size = new System.Drawing.Size(913, 22);
            this.questionTitleTxt.TabIndex = 5;
            // 
            // questionDetailsTxt
            // 
            this.questionDetailsTxt.BackColor = System.Drawing.SystemColors.Control;
            this.questionDetailsTxt.Location = new System.Drawing.Point(349, 105);
            this.questionDetailsTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.questionDetailsTxt.Multiline = true;
            this.questionDetailsTxt.Name = "questionDetailsTxt";
            this.questionDetailsTxt.ReadOnly = true;
            this.questionDetailsTxt.Size = new System.Drawing.Size(913, 205);
            this.questionDetailsTxt.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Questions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Question Details";
            // 
            // questionsListBox
            // 
            this.questionsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionsListBox.FormattingEnabled = true;
            this.questionsListBox.ItemHeight = 20;
            this.questionsListBox.Location = new System.Drawing.Point(16, 34);
            this.questionsListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.questionsListBox.Name = "questionsListBox";
            this.questionsListBox.Size = new System.Drawing.Size(320, 544);
            this.questionsListBox.TabIndex = 10;
            this.questionsListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SelectQuestionsListItem);
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 607);
            this.Controls.Add(this.questionsListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.questionDetailsTxt);
            this.Controls.Add(this.questionTitleTxt);
            this.Controls.Add(this.answerBtn);
            this.Controls.Add(this.answerTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainWindowForm";
            this.Text = "Department";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox answerTxt;
        private System.Windows.Forms.Button answerBtn;
        private System.Windows.Forms.TextBox questionTitleTxt;
        private System.Windows.Forms.TextBox questionDetailsTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox questionsListBox;
    }
}

