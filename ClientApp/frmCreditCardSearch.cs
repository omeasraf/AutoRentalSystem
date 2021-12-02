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
    public partial class frmCreditCardSearch : Form {
        public frmCreditCardSearch() {
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
            allRecords.ForEach(record =>
            {
                if (record.CreditCardNumber.ToString() == input)
                {
                    card = record;
                }
            });

            if (card != null)
            {
                textBox1.Text = card.CreditCardNumber;
                textBox2.Text = card.CreditCardOwnerName;
                textBox3.Text = card.MerchantName;
                textBox4.Text = card.ExpDate.ToShortDateString();
                textBox5.Text = card.AddressLine1;
                textBox6.Text = card.AddressLine2;
                textBox7.Text = card.City;
                textBox8.Text = card.State;
                textBox9.Text = card.ZipCode;
                textBox10.Text = card.Country;
                textBox11.Text = card.CreditCardLimit.ToString();
                textBox12.Text = card.CreditCardBalance.ToString();
                textBox13.Text = card.ActivationStatus == true ? "Active": "Inactive";
            }
            else
            {
                MessageBox.Show("Please enter a valid credit card number and make sure the database server is online", "Card not found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
