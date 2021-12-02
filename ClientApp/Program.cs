using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOLayer;
namespace ClientApp {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           TestCreditCard();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWelcomeForm());

            
        }

        static void TestCreditCard()
        {
            // Testing CreditCard class
            
            CreditCard cc = new CreditCard();
            cc.CreditCardNumber = "5555555555555555";
            cc.CreditCardOwnerName = "Ami Asraf";
            cc.MerchantName = "BOFA";
            cc.ExpDate = new DateTime(2022, 02, 10);
            cc.AddressLine1 = "1276 Union Road";
            cc.AddressLine2 = "Unknown Plaza";
            cc.City = "Brooklyn";
            cc.State = "NY";
            cc.ZipCode = "10001";
            cc.Country = "US";
            cc.CreditCardBalance = 250;
            cc.CreditCardLimit = 5000;


            if (!cc.Load(cc.CreditCardNumber))
            {
                cc.Insert();
            }
            
            cc.Print();
            
        }
    }
}
