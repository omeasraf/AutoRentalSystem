using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer {
    public class SQLServerFactory: DALObjectFactoryBase
    {
        public static string ConnectionString() {
            return "Data Source =.\\SQLExpress; Initial Catalog = EZRentalDB; Integrated Security = True";
        }


        override
        public CreditCardDAO GetCreditCardDAO()
        {
            return new CreditCardDAO();
        }

    }
}
