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
    public partial class frmCreditCardRegistration : Form {
        public frmCreditCardRegistration() {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e) {
            if (textBox1.Text.Length > 0 &&
                textBox2.Text.Length > 0 &&
                textBox3.Text.Length > 0 &&
                
                textBox5.Text.Length > 0 &&
                textBox6.Text.Length > 0 &&
                textBox7.Text.Length > 0 &&
                textBox8.Text.Length > 0 &&
                textBox9.Text.Length > 0 &&
                textBox10.Text.Length > 0 &&
                textBox11.Text.Length > 0 &&
                textBox12.Text.Length > 0)
            {
                CreditCardDAO cc = new CreditCardDAO();
                CreditCardDTO dto = new CreditCardDTO();
                dto.CreditCardNumber = textBox1.Text;
                dto.CreditCardOwnerName = textBox2.Text;
                dto.MerchantName = textBox3.Text;
                dto.ExpDate = dateTimePicker1.Value;
                dto.AddressLine1 = textBox5.Text;
                dto.AddressLine2 = textBox6.Text;
                dto.City = textBox7.Text;
                dto.State = textBox8.Text;
                dto.ZipCode = textBox9.Text;
                dto.Country = textBox10.Text;
                dto.CreditCardLimit = decimal.Parse(textBox11.Text);
                dto.CreditCardBalance = decimal.Parse(textBox12.Text);
                dto.ActivationStatus = true;
                cc.Insert(dto);
                textBox12.Text = "Active";

                MessageBox.Show("Successfully sent the data to the Database", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please fill out the form before trying to submit it", "Form not complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
