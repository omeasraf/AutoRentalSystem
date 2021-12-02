using DALayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp {
    public partial class frmCreditCardUpdate : Form {
        public frmCreditCardUpdate() {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            String input = txtBoxSearch.Text;
            Console.WriteLine(input);
            CreditCardDAO cc = new CreditCardDAO();
            var allRecords = cc.GetAllRecords();
            CreditCardDTO card = null;
            allRecords.ForEach(record => {
                if (record.CreditCardNumber.ToString() == input) {
                    card = record;
                }
            });

            if (card != null) {
                textBox1.Text = card.CreditCardNumber;
                textBox2.Text = card.CreditCardOwnerName;
                textBox3.Text = card.MerchantName;
                dateTimePicker1.Value = card.ExpDate;
                textBox5.Text = card.AddressLine1;
                textBox6.Text = card.AddressLine2;
                textBox7.Text = card.City;
                textBox8.Text = card.State;
                textBox9.Text = card.ZipCode;
                textBox10.Text = card.Country;
                textBox11.Text = card.CreditCardLimit.ToString();
                textBox12.Text = card.CreditCardBalance.ToString();
                textBox13.Text = card.ActivationStatus == true ? "Active" : "Inactive";
            }
            else {
                MessageBox.Show("Please enter a valid credit card number", "Card not found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApply_Click(object sender, EventArgs e) {
            CreditCardDTO card = new CreditCardDTO();
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
                textBox12.Text.Length > 0) {

                card.CreditCardNumber = textBox1.Text;
                card.CreditCardOwnerName = textBox2.Text;
                card.MerchantName = textBox3.Text;
                card.ExpDate = dateTimePicker1.Value;
                card.AddressLine1 = textBox5.Text;
                card.AddressLine2 = textBox6.Text;
                card.City = textBox7.Text;
                card.State = textBox8.Text;
                card.ZipCode = textBox9.Text;
                card.Country = textBox10.Text;
                card.CreditCardLimit = decimal.Parse(textBox11.Text);
                card.CreditCardBalance = decimal.Parse(textBox12.Text);
                card.ActivationStatus = true;

                CreditCardDAO cc = new CreditCardDAO();
                cc.Update(card);
                MessageBox.Show("Successfully sent the data to the Database", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {

                MessageBox.Show("Please fill out the form before trying to submit it", "Form not complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
