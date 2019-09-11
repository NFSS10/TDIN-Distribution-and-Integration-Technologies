using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Remote;

namespace Client
{
    public partial class QuotaPopUp : Form
    {
        bool isSell;
        int userId;
        IUserService userService;
        public QuotaPopUp(bool isSell, int userId, IUserService userService)
        {
            this.userId = userId;
            this.isSell = isSell;
            this.userService = userService;
            InitializeComponent();
        }

        private void QuotaPopUp_Load(object sender, EventArgs e)
        {
            if (isSell)
            {
                label2.Text = "Your Sell order is pending, choose a new Quota.";
            }
            else
            {
                label2.Text = "Your Purchase order is pending, choose a new Quota.";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (this.isSell) // se for sellOrder
                {
                    if (Decimal.Parse(textBox1.Text) < userService.GetCurrentQuote() && Decimal.Parse(textBox1.Text) > 0)
                    {
                        userService.SetNewQuota(Decimal.Parse(textBox1.Text), isSell, userId);
                        this.Close();
                    }
                    else if (Decimal.Parse(textBox1.Text) == userService.GetCurrentQuote() && Decimal.Parse(textBox1.Text) > 0)
                    {
                        this.Close();
                    }
                    else
                    {
                        textBox2.Text = "Please choose a value between 0 and the current Quota";
                    }
                }
                else
                {
                    if (Decimal.Parse(textBox1.Text) > userService.GetCurrentQuote() && Decimal.Parse(textBox1.Text) > 0)
                    {
                        userService.SetNewQuota(Decimal.Parse(textBox1.Text), isSell, userId);
                        this.Close();
                    }
                    else if (Decimal.Parse(textBox1.Text) == userService.GetCurrentQuote() && Decimal.Parse(textBox1.Text) > 0)
                    {
                        this.Close();
                    }
                    else
                    {
                        textBox2.Text = "Please choose a value higher than the current Quota";
                    }
                }
            }
            
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal coma
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
