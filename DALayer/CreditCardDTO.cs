using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer {
    public class CreditCardDTO {
        public string CreditCardNumber {
            get; set;
        }
        public string CreditCardOwnerName {
            get; set;
        }
        public string MerchantName {
            get; set;
        }
        public DateTime ExpDate {
            get; set;
        }
        public string AddressLine1 {
            get; set;
        }
        public string AddressLine2 {
            get; set;
        }
        public string City {
            get; set;
        }
        public string State {
            get; set;
        }
        public string ZipCode {
            get; set;
        }
        public string Country {
            get; set;
        }
        public decimal CreditCardLimit {
            get; set;
        }
        public decimal CreditCardBalance {
            get; set;
        }
        public bool ActivationStatus {
            get; set;
        }
    }
}
