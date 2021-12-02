using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer;


namespace BOLayer {
    public class CreditCard {
        private String m_CreditCardNumber;
        private String m_CreditCardOwnerName;
        private String m_MerchantName;
        private DateTime m_ExpDate;
        private String m_AddressLine1;
        private String m_AddressLine2;
        private String m_City;
        private String m_State;
        private String m_ZipCode;
        private String m_Country;
        private decimal m_CreditCardLimit;
        private decimal m_CreditCardBalance;
        private bool m_ActivationStatus;

        public CreditCard() {
            m_CreditCardNumber = "";
            m_CreditCardOwnerName = "";
            m_MerchantName = "";
            m_ExpDate = new DateTime().Date;
            m_AddressLine1 = "";
            m_AddressLine2 = "";
            m_City = "";
            m_State = "";
            m_ZipCode = "";
            m_Country = "";
            m_CreditCardBalance = 0.0M;
            m_CreditCardLimit = 0.0M;
            m_ActivationStatus = true;
        }

        public CreditCard(string mCreditCardNumber, string mCreditCardOwnerName, string mMerchantName, DateTime mExpDate, string mAddressLine1, string mAddressLine2, string mCity, string mState, string mZipCode, string mCountry, decimal mCreditCardLimit, decimal mCreditCardBalance) {
            CreditCardNumber = mCreditCardNumber;
            CreditCardOwnerName = mCreditCardOwnerName;
            MerchantName = mMerchantName;
            ExpDate = mExpDate;
            AddressLine1 = mAddressLine1;
            AddressLine2 = mAddressLine2;
            City = mCity;
            State = mState;
            ZipCode = mZipCode;
            Country = mCountry;
            CreditCardLimit = mCreditCardLimit;
            CreditCardBalance = mCreditCardBalance;
            m_ActivationStatus = true;
        }

        ~CreditCard() {
        }

        public string CreditCardNumber {
            get => m_CreditCardNumber;
            set => m_CreditCardNumber = value;
        }

        public string CreditCardOwnerName {
            get => m_CreditCardOwnerName;
            set => m_CreditCardOwnerName = value;
        }

        public string MerchantName {
            get => m_MerchantName;
            set => m_MerchantName = value;
        }

        public DateTime ExpDate {
            get => m_ExpDate;
            set => m_ExpDate = value;
        }

        public string AddressLine1 {
            get => m_AddressLine1;
            set => m_AddressLine1 = value;
        }

        public string AddressLine2 {
            get => m_AddressLine2;
            set => m_AddressLine2 = value;
        }

        public string City {
            get => m_City;
            set => m_City = value;
        }

        public string State {
            get => m_State;
            set => m_State = value;
        }

        public string ZipCode {
            get => m_ZipCode;
            set => m_ZipCode = value;
        }

        public string Country {
            get => m_Country;
            set => m_Country = value;
        }

        public decimal CreditCardLimit {
            get => m_CreditCardLimit;
            set => m_CreditCardLimit = value;
        }

        public decimal CreditCardBalance {
            get => m_CreditCardBalance;
            set => m_CreditCardBalance = value;
        }

        public bool ActivationStatus {
            get => m_ActivationStatus;
        }


        public void Print() {
            var data = $"{nameof(CreditCardNumber)} = {CreditCardNumber}\n{nameof(CreditCardOwnerName)} = {CreditCardOwnerName}\n{nameof(MerchantName)} = {MerchantName}\n{nameof(ExpDate)} = {ExpDate}\n{nameof(AddressLine1)} = {AddressLine1}\n{nameof(AddressLine2)} = {AddressLine2}\n{nameof(City)} = {City}\n{nameof(State)} = {State}\n{nameof(ZipCode)} = {ZipCode}\n{nameof(Country)} = {Country}\n{nameof(CreditCardLimit)} = {CreditCardLimit}\n{nameof(CreditCardBalance)} = {CreditCardBalance}\n{nameof(ActivationStatus)} = {ActivationStatus}";

            try {
                using (StreamWriter sw = File.AppendText("Network_Printer.txt")) {
                    sw.WriteLine(data);
                    sw.Close();
                }


            }
            catch (Exception) {
                throw new FileNotFoundException("Unable to open or locate file");
            }


        }

        public bool Activate() {
            m_ActivationStatus = true;
            return m_ActivationStatus;
        }

        public bool Deactivate() {
            m_ActivationStatus = false;
            return m_ActivationStatus;
        }

        public bool Load(String key) {
            return DALayer_Load(key);
        }
        public bool Insert() {
            return DALayer_Insert();
        }
        public bool InsertCreditCardOfACustomer(int CustKey) {
            return DALayer_InsertCreditCardOfACustomer(CustKey);
        }

        public bool Update() {

            return DALayer_Update();
        }

        public bool Delete(String key) {
            DALayer_Delete(key);
            return Load(key);
        }

        public static List<CreditCard> GetAllCreditCards() {
            return DALayer_GetAllCreditCards();
        }

        protected bool DALayer_Load(String key) {
            try {
                DALObjectFactoryBase objSQLDAOFactory =
DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);
                CreditCardDAO objCreditCardDAO = objSQLDAOFactory.GetCreditCardDAO();
                CreditCardDTO objCreditCardDTO = objCreditCardDAO.GetRecordByID(key);
                if (objCreditCardDTO != null) {
                    this.CreditCardNumber = objCreditCardDTO.CreditCardNumber;
                    this.CreditCardOwnerName = objCreditCardDTO.CreditCardOwnerName;
                    this.MerchantName = objCreditCardDTO.MerchantName;
                    this.ExpDate = objCreditCardDTO.ExpDate;
                    this.AddressLine1 = objCreditCardDTO.AddressLine1;
                    this.AddressLine2 = objCreditCardDTO.AddressLine2;
                    this.City = objCreditCardDTO.City;
                    this.State = objCreditCardDTO.State;
                    this.ZipCode = objCreditCardDTO.ZipCode;
                    this.Country = objCreditCardDTO.Country;
                    this.CreditCardLimit = objCreditCardDTO.CreditCardLimit;
                    this.CreditCardBalance = objCreditCardDTO.CreditCardBalance;

                    if (objCreditCardDTO.ActivationStatus == true)
                        this.Activate();
                    else
                        this.Deactivate();

                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception objE) {
                throw new Exception("Unexpected Error in DALayer_Load(key) Method: {0} " + objE.Message);
            }
        }

        protected bool DALayer_Insert() {
            try {
                DALObjectFactoryBase objSQLDAOFactory =
    DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);
                CreditCardDAO objCreditCardDAO = objSQLDAOFactory.GetCreditCardDAO();
                CreditCardDTO objCreditCardDTO = new CreditCardDTO();
                objCreditCardDTO.CreditCardNumber = this.CreditCardNumber;
                objCreditCardDTO.CreditCardOwnerName = this.CreditCardOwnerName;
                objCreditCardDTO.MerchantName = this.MerchantName;
                objCreditCardDTO.ExpDate = this.ExpDate;
                objCreditCardDTO.AddressLine1 = this.AddressLine1;
                objCreditCardDTO.AddressLine2 = this.AddressLine2;
                objCreditCardDTO.City = this.City;
                objCreditCardDTO.State = this.State;
                objCreditCardDTO.ZipCode = this.ZipCode;
                objCreditCardDTO.Country = this.Country;
                objCreditCardDTO.CreditCardLimit = this.CreditCardLimit;
                objCreditCardDTO.CreditCardBalance = this.CreditCardBalance;
                objCreditCardDTO.ActivationStatus = this.ActivationStatus;
               bool inserted = objCreditCardDAO.Insert(objCreditCardDTO);
   
         
                if (inserted == true) {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception objE) {
                throw new Exception("Unexpected Error in DALayer_Insert() Method: {0} " + objE.Message);
            }

        }
        protected bool DALayer_InsertCreditCardOfACustomer(int parentKey) {
            try {
                DALObjectFactoryBase objSQLDAOFactory =
DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);
                CreditCardDAO objCreditCardDAO = objSQLDAOFactory.GetCreditCardDAO();
                CreditCardDTO objCreditCardDTO = new CreditCardDTO();
                objCreditCardDTO.CreditCardNumber = this.CreditCardNumber;
                objCreditCardDTO.CreditCardOwnerName = this.CreditCardOwnerName;
                objCreditCardDTO.MerchantName = this.MerchantName;
                objCreditCardDTO.ExpDate = this.ExpDate;
                objCreditCardDTO.AddressLine1 = this.AddressLine1;
                objCreditCardDTO.AddressLine2 = this.AddressLine2;
                objCreditCardDTO.City = this.City;
                objCreditCardDTO.State = this.State;
                objCreditCardDTO.ZipCode = this.ZipCode;
                objCreditCardDTO.Country = this.Country;
                objCreditCardDTO.CreditCardLimit = this.CreditCardLimit;
                objCreditCardDTO.CreditCardBalance = this.CreditCardBalance;
                objCreditCardDTO.ActivationStatus = this.ActivationStatus;
                bool inserted = objCreditCardDAO.InsertChildObjectOfAParent(parentKey, objCreditCardDTO);
                if (inserted == true) {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception objE) {
                throw new Exception("Unexpected Error in DALayer_InsertCreditCardOfACustomer () Method: {0}" + objE.Message);
            }
        }
        protected bool DALayer_Update() {
            try {
                DALObjectFactoryBase objSQLDAOFactory =
    DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);
                CreditCardDAO objCreditCardDAO = objSQLDAOFactory.GetCreditCardDAO();
                CreditCardDTO objCreditCardDTO = new CreditCardDTO();
                objCreditCardDTO.CreditCardNumber = this.CreditCardNumber;
                objCreditCardDTO.CreditCardOwnerName = this.CreditCardOwnerName;
                objCreditCardDTO.MerchantName = this.MerchantName;
                objCreditCardDTO.ExpDate = this.ExpDate;
                objCreditCardDTO.AddressLine1 = this.AddressLine1;
                objCreditCardDTO.AddressLine2 = this.AddressLine2;
                objCreditCardDTO.City = this.City;
                objCreditCardDTO.State = this.State;
                objCreditCardDTO.ZipCode = this.ZipCode;
                objCreditCardDTO.Country = this.Country;
                objCreditCardDTO.CreditCardLimit = this.CreditCardLimit;
                objCreditCardDTO.CreditCardBalance = this.CreditCardBalance;
                objCreditCardDTO.ActivationStatus = this.ActivationStatus;
                bool updated = objCreditCardDAO.Update(objCreditCardDTO);
                if (updated == true) {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception objE) {
                throw new Exception("Unexpected Error in DALayer_Update() Method: {0} " + objE.Message);
            }

        }

        protected bool DALayer_Delete(String key) {
            try {
                DALObjectFactoryBase objSQLDAOFactory =
    DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);
                CreditCardDAO objCreditCardDAO = objSQLDAOFactory.GetCreditCardDAO();
                bool deleted = objCreditCardDAO.Delete(key);
                if (deleted == true) {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception objE) {
                throw new Exception("Unexpected Error in DALayer_Update() Method: {0} " + objE.Message);
            }
        }

        protected static List<CreditCard> DALayer_GetAllCreditCards() {
            try {
                DALObjectFactoryBase objSQLDAOFactory =
    DALObjectFactoryBase.GetDataSourceDAOFactory(DALObjectFactoryBase.SQLSERVER);
                CreditCardDAO objCreditCardDAO = objSQLDAOFactory.GetCreditCardDAO();
                List<CreditCardDTO> objCreditCardDTOList = objCreditCardDAO.GetAllRecords();
                if (objCreditCardDTOList != null) {
                    List<CreditCard> objCreditCardList = new List<CreditCard>();
                    foreach (CreditCardDTO objDTO in objCreditCardDTOList) {
                        CreditCard objCreditCard = new CreditCard();
                        objCreditCard.CreditCardNumber = objDTO.CreditCardNumber;
                        objCreditCard.CreditCardOwnerName = objDTO.CreditCardOwnerName;
                        objCreditCard.MerchantName = objDTO.MerchantName;
                        objCreditCard.ExpDate = objDTO.ExpDate;
                        objCreditCard.AddressLine1 = objDTO.AddressLine1;
                        objCreditCard.AddressLine2 = objDTO.AddressLine2;
                        objCreditCard.City = objDTO.City;
                        objCreditCard.State = objDTO.State;
                        objCreditCard.ZipCode = objDTO.ZipCode;
                        objCreditCard.Country = objDTO.Country;
                        objCreditCard.CreditCardBalance = objDTO.CreditCardBalance;
                        objCreditCard.CreditCardLimit = objDTO.CreditCardLimit;

                        if (objDTO.ActivationStatus == true)
                            objCreditCard.Activate();
                        else
                            objCreditCard.Deactivate();

                        objCreditCardList.Add(objCreditCard);
                    }
                    return objCreditCardList;
                }
                else {
                    return null;
                }
            }
            catch (Exception objE) {
                throw new Exception("Unexpected Error in DALayer_GetAllCreditCards(key) Method: {0} " +
                    objE.Message);
            }
        }

    }
}
