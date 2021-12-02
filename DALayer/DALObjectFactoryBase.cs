using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer {
    public abstract class DALObjectFactoryBase {
        public const int SQLSERVER = 1;
        public const int ORACLE = 2;
        public const int MYSQL = 3;

        public static DALObjectFactoryBase GetDataSourceDAOFactory(int targetDataSource) {
            switch (targetDataSource) {
                case 1:

                    return new SQLServerFactory();
                case 2:

                    throw new NotImplementedException();
                case 3: 
                    throw new NotImplementedException();
                default: 
                    return null;
            }//End of switch

        }//End of method
        public abstract CreditCardDAO GetCreditCardDAO();

    }

}
