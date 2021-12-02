using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DALayer;

namespace ClientApp {
    public partial class frmCreditCardDelete : Form {
        public frmCreditCardDelete() {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            String input = textBox1.Text;

            if (input.Length > 0)
            {
                CreditCardDAO cc = new CreditCardDAO();
                bool status = cc.Delete(input);
                if (status)
                {
                    MessageBox.Show("Successfully removed the credit card", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Either the credit card number doesn't exist or I ran into some issues while trying to delete the card", "Something went wrong",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill out the form before trying to submit it", "Form not complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
