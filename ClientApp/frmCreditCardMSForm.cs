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
    public partial class frmCreditCardMSForm : Form {
        public frmCreditCardMSForm() {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            frmCreditCardSearch objERP = new frmCreditCardSearch();
            this.Hide();

            objERP.ShowDialog();
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnRegistration_Click(object sender, EventArgs e) {
            frmCreditCardRegistration objERP = new frmCreditCardRegistration();
            this.Hide();

            objERP.ShowDialog();
            this.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            frmCreditCardUpdate objERP = new frmCreditCardUpdate();
            this.Hide();

            objERP.ShowDialog();
            this.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            frmCreditCardDelete objERP = new frmCreditCardDelete();
            this.Hide();

            objERP.ShowDialog();
            this.Show();
        }
    }
}
