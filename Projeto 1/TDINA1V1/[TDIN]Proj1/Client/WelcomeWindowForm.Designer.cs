namespace Client
{
    partial class WelcomeWindowForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.LoginTab = new System.Windows.Forms.TabPage();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.LoginPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginUsernameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RegisterTab = new System.Windows.Forms.TabPage();
            this.RegisterBtn = new System.Windows.Forms.Button();
            this.RegisterNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RegisterConfPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RegisterPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RegisterUsernameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.WelcomeWindowHelpLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.LoginTab.SuspendLayout();
            this.RegisterTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.LoginTab);
            this.tabControl1.Controls.Add(this.RegisterTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 185);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(288, 264);
            this.tabControl1.TabIndex = 0;
            // 
            // LoginTab
            // 
            this.LoginTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LoginTab.Controls.Add(this.LoginBtn);
            this.LoginTab.Controls.Add(this.LoginPasswordTextBox);
            this.LoginTab.Controls.Add(this.label2);
            this.LoginTab.Controls.Add(this.LoginUsernameTextBox);
            this.LoginTab.Controls.Add(this.label1);
            this.LoginTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginTab.Location = new System.Drawing.Point(4, 22);
            this.LoginTab.Name = "LoginTab";
            this.LoginTab.Padding = new System.Windows.Forms.Padding(3);
            this.LoginTab.Size = new System.Drawing.Size(280, 238);
            this.LoginTab.TabIndex = 0;
            this.LoginTab.Text = "Login";
            this.LoginTab.UseVisualStyleBackColor = true;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(46, 128);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(195, 35);
            this.LoginBtn.TabIndex = 9;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtnClick);
            // 
            // LoginPasswordTextBox
            // 
            this.LoginPasswordTextBox.Location = new System.Drawing.Point(102, 65);
            this.LoginPasswordTextBox.MaxLength = 32;
            this.LoginPasswordTextBox.Name = "LoginPasswordTextBox";
            this.LoginPasswordTextBox.PasswordChar = '*';
            this.LoginPasswordTextBox.Size = new System.Drawing.Size(124, 20);
            this.LoginPasswordTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // LoginUsernameTextBox
            // 
            this.LoginUsernameTextBox.Location = new System.Drawing.Point(102, 35);
            this.LoginUsernameTextBox.MaxLength = 32;
            this.LoginUsernameTextBox.Name = "LoginUsernameTextBox";
            this.LoginUsernameTextBox.Size = new System.Drawing.Size(124, 20);
            this.LoginUsernameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // RegisterTab
            // 
            this.RegisterTab.Controls.Add(this.RegisterBtn);
            this.RegisterTab.Controls.Add(this.RegisterNameTextBox);
            this.RegisterTab.Controls.Add(this.label6);
            this.RegisterTab.Controls.Add(this.RegisterConfPasswordTextBox);
            this.RegisterTab.Controls.Add(this.label5);
            this.RegisterTab.Controls.Add(this.RegisterPasswordTextBox);
            this.RegisterTab.Controls.Add(this.label3);
            this.RegisterTab.Controls.Add(this.RegisterUsernameTextBox);
            this.RegisterTab.Controls.Add(this.label4);
            this.RegisterTab.Location = new System.Drawing.Point(4, 22);
            this.RegisterTab.Name = "RegisterTab";
            this.RegisterTab.Padding = new System.Windows.Forms.Padding(3);
            this.RegisterTab.Size = new System.Drawing.Size(280, 238);
            this.RegisterTab.TabIndex = 1;
            this.RegisterTab.Text = "Register";
            this.RegisterTab.UseVisualStyleBackColor = true;
            // 
            // RegisterBtn
            // 
            this.RegisterBtn.Location = new System.Drawing.Point(44, 164);
            this.RegisterBtn.Name = "RegisterBtn";
            this.RegisterBtn.Size = new System.Drawing.Size(195, 35);
            this.RegisterBtn.TabIndex = 13;
            this.RegisterBtn.Text = "Register";
            this.RegisterBtn.UseVisualStyleBackColor = true;
            this.RegisterBtn.Click += new System.EventHandler(this.RegisterBtnClick);
            // 
            // RegisterNameTextBox
            // 
            this.RegisterNameTextBox.Location = new System.Drawing.Point(111, 28);
            this.RegisterNameTextBox.MaxLength = 100;
            this.RegisterNameTextBox.Name = "RegisterNameTextBox";
            this.RegisterNameTextBox.Size = new System.Drawing.Size(124, 20);
            this.RegisterNameTextBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Name";
            // 
            // RegisterConfPasswordTextBox
            // 
            this.RegisterConfPasswordTextBox.Location = new System.Drawing.Point(111, 110);
            this.RegisterConfPasswordTextBox.MaxLength = 32;
            this.RegisterConfPasswordTextBox.Name = "RegisterConfPasswordTextBox";
            this.RegisterConfPasswordTextBox.PasswordChar = '*';
            this.RegisterConfPasswordTextBox.Size = new System.Drawing.Size(124, 20);
            this.RegisterConfPasswordTextBox.TabIndex = 10;
            this.RegisterConfPasswordTextBox.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Confirm Password";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // RegisterPasswordTextBox
            // 
            this.RegisterPasswordTextBox.Location = new System.Drawing.Point(111, 84);
            this.RegisterPasswordTextBox.MaxLength = 32;
            this.RegisterPasswordTextBox.Name = "RegisterPasswordTextBox";
            this.RegisterPasswordTextBox.PasswordChar = '*';
            this.RegisterPasswordTextBox.Size = new System.Drawing.Size(124, 20);
            this.RegisterPasswordTextBox.TabIndex = 7;
            this.RegisterPasswordTextBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // RegisterUsernameTextBox
            // 
            this.RegisterUsernameTextBox.Location = new System.Drawing.Point(111, 54);
            this.RegisterUsernameTextBox.MaxLength = 32;
            this.RegisterUsernameTextBox.Name = "RegisterUsernameTextBox";
            this.RegisterUsernameTextBox.Size = new System.Drawing.Size(124, 20);
            this.RegisterUsernameTextBox.TabIndex = 5;
            this.RegisterUsernameTextBox.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Username";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeLabel.Location = new System.Drawing.Point(81, 9);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(133, 31);
            this.WelcomeLabel.TabIndex = 1;
            this.WelcomeLabel.Text = "Welcome";
            // 
            // WelcomeWindowHelpLabel
            // 
            this.WelcomeWindowHelpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeWindowHelpLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.WelcomeWindowHelpLabel.Location = new System.Drawing.Point(16, 87);
            this.WelcomeWindowHelpLabel.Name = "WelcomeWindowHelpLabel";
            this.WelcomeWindowHelpLabel.Size = new System.Drawing.Size(280, 66);
            this.WelcomeWindowHelpLabel.TabIndex = 2;
            this.WelcomeWindowHelpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WelcomeWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 453);
            this.Controls.Add(this.WelcomeWindowHelpLabel);
            this.Controls.Add(this.WelcomeLabel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "WelcomeWindowForm";
            this.Text = "WelcomeWindowForm";
            this.Load += new System.EventHandler(this.WelcomeWindowForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.LoginTab.ResumeLayout(false);
            this.LoginTab.PerformLayout();
            this.RegisterTab.ResumeLayout(false);
            this.RegisterTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage LoginTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage RegisterTab;
        private System.Windows.Forms.TextBox LoginPasswordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LoginUsernameTextBox;
        private System.Windows.Forms.TextBox RegisterPasswordTextBox;
        private System.Windows.Forms.TextBox RegisterUsernameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox RegisterConfPasswordTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button RegisterBtn;
        private System.Windows.Forms.TextBox RegisterNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.Label WelcomeWindowHelpLabel;
    }
}