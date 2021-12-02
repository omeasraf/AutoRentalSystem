using BOLayer;
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
    public partial class MainWelcomeForm : Form {
        public MainWelcomeForm() {
            InitializeComponent();
        }


        private void btnERP_Click(object sender, EventArgs e) {
            frmERPSystemForm objERP = new frmERPSystemForm();
            this.Hide();

            objERP.ShowDialog();
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnPOS_Click(object sender, EventArgs e) {
            Console.WriteLine("Hasn't been implemented yet");
        }
    }
}
