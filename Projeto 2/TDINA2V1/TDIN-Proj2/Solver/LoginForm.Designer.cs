namespace Solver
{
    partial class LoginForm
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
            this.WelcomeWindowHelpLabel = new System.Windows.Forms.Label();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.LoginTab.SuspendLayout();
            this.RegisterTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.LoginTab);
            this.tabControl1.Controls.Add(this.RegisterTab);
            this.tabControl1.Location = new System.Drawing.Point(31, 151);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 325);
            this.tabControl1.TabIndex = 1;
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
            this.LoginTab.Location = new System.Drawing.Point(4, 25);
            this.LoginTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoginTab.Name = "LoginTab";
            this.LoginTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoginTab.Size = new System.Drawing.Size(376, 296);
            this.LoginTab.TabIndex = 0;
            this.LoginTab.Text = "Login";
            this.LoginTab.UseVisualStyleBackColor = true;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(61, 158);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(260, 43);
            this.LoginBtn.TabIndex = 9;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // LoginPasswordTextBox
            // 
            this.LoginPasswordTextBox.Location = new System.Drawing.Point(136, 80);
            this.LoginPasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoginPasswordTextBox.MaxLength = 32;
            this.LoginPasswordTextBox.Name = "LoginPasswordTextBox";
            this.LoginPasswordTextBox.PasswordChar = '*';
            this.LoginPasswordTextBox.Size = new System.Drawing.Size(164, 23);
            this.LoginPasswordTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // LoginUsernameTextBox
            // 
            this.LoginUsernameTextBox.Location = new System.Drawing.Point(136, 43);
            this.LoginUsernameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoginUsernameTextBox.MaxLength = 32;
            this.LoginUsernameTextBox.Name = "LoginUsernameTextBox";
            this.LoginUsernameTextBox.Size = new System.Drawing.Size(164, 23);
            this.LoginUsernameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
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
            this.RegisterTab.Location = new System.Drawing.Point(4, 25);
            this.RegisterTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterTab.Name = "RegisterTab";
            this.RegisterTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterTab.Size = new System.Drawing.Size(376, 296);
            this.RegisterTab.TabIndex = 1;
            this.RegisterTab.Text = "Register";
            this.RegisterTab.UseVisualStyleBackColor = true;
            // 
            // RegisterBtn
            // 
            this.RegisterBtn.Location = new System.Drawing.Point(59, 202);
            this.RegisterBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterBtn.Name = "RegisterBtn";
            this.RegisterBtn.Size = new System.Drawing.Size(260, 43);
            this.RegisterBtn.TabIndex = 13;
            this.RegisterBtn.Text = "Register";
            this.RegisterBtn.UseVisualStyleBackColor = true;
            this.RegisterBtn.Click += new System.EventHandler(this.RegisterBtn_Click);
            // 
            // RegisterNameTextBox
            // 
            this.RegisterNameTextBox.Location = new System.Drawing.Point(148, 34);
            this.RegisterNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterNameTextBox.MaxLength = 100;
            this.RegisterNameTextBox.Name = "RegisterNameTextBox";
            this.RegisterNameTextBox.Size = new System.Drawing.Size(164, 22);
            this.RegisterNameTextBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Name";
            // 
            // RegisterConfPasswordTextBox
            // 
            this.RegisterConfPasswordTextBox.Location = new System.Drawing.Point(148, 135);
            this.RegisterConfPasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterConfPasswordTextBox.MaxLength = 32;
            this.RegisterConfPasswordTextBox.Name = "RegisterConfPasswordTextBox";
            this.RegisterConfPasswordTextBox.PasswordChar = '*';
            this.RegisterConfPasswordTextBox.Size = new System.Drawing.Size(164, 22);
            this.RegisterConfPasswordTextBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 139);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Confirm Password";
            // 
            // RegisterPasswordTextBox
            // 
            this.RegisterPasswordTextBox.Location = new System.Drawing.Point(148, 103);
            this.RegisterPasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterPasswordTextBox.MaxLength = 32;
            this.RegisterPasswordTextBox.Name = "RegisterPasswordTextBox";
            this.RegisterPasswordTextBox.PasswordChar = '*';
            this.RegisterPasswordTextBox.Size = new System.Drawing.Size(164, 22);
            this.RegisterPasswordTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // RegisterUsernameTextBox
            // 
            this.RegisterUsernameTextBox.Location = new System.Drawing.Point(148, 66);
            this.RegisterUsernameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterUsernameTextBox.MaxLength = 32;
            this.RegisterUsernameTextBox.Name = "RegisterUsernameTextBox";
            this.RegisterUsernameTextBox.Size = new System.Drawing.Size(164, 22);
            this.RegisterUsernameTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Username";
            // 
            // WelcomeWindowHelpLabel
            // 
            this.WelcomeWindowHelpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeWindowHelpLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.WelcomeWindowHelpLabel.Location = new System.Drawing.Point(32, 66);
            this.WelcomeWindowHelpLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WelcomeWindowHelpLabel.Name = "WelcomeWindowHelpLabel";
            this.WelcomeWindowHelpLabel.Size = new System.Drawing.Size(379, 81);
            this.WelcomeWindowHelpLabel.TabIndex = 3;
            this.WelcomeWindowHelpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeLabel.Location = new System.Drawing.Point(131, 11);
            this.WelcomeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(166, 39);
            this.WelcomeLabel.TabIndex = 4;
            this.WelcomeLabel.Text = "Welcome";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 491);
            this.Controls.Add(this.WelcomeLabel);
            this.Controls.Add(this.WelcomeWindowHelpLabel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LoginForm";
            this.Text = "Login";
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
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.TextBox LoginPasswordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LoginUsernameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage RegisterTab;
        private System.Windows.Forms.Button RegisterBtn;
        private System.Windows.Forms.TextBox RegisterNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox RegisterConfPasswordTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox RegisterPasswordTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RegisterUsernameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label WelcomeWindowHelpLabel;
        private System.Windows.Forms.Label WelcomeLabel;
    }
}