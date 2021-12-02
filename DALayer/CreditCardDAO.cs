using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer {
    public class CreditCardDAO : ICreditCardDAO {
        public bool Delete(string key) {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
            try {
                objConn.Open();
                string strSQL = "DELETE FROM CreditCard WHERE CreditCardNumber = @CreditCardNumber;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;
                objCmd.Parameters.Add("@CreditCardNumber", SqlDbType.VarChar).Value = key;
                int intRecordsAffected = objCmd.ExecuteNonQuery();
                if (intRecordsAffected == 1) {
                    return true;
                }
                objCmd.Dispose();
                objCmd = null;
                return false;
            }
            catch (Exception objE) {
                throw new Exception("Unexpected Error in CreditCardADO Delete(key) Method:{0} " + objE.Message);
            }
            finally {
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }

        }

        public List<string> GetAllChildKeysOwnedByParent(int parentKey) {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
            try {
                objConn.Open();
                string strSQL;
                strSQL = "SELECT CreditCard.CreditCardCardNumber";
                strSQL = strSQL + " FROM CreditCard, Customer_CreditCard";
                strSQL = strSQL + " WHERE CreditCard.CreditCardNumber = Customer_CreditCard.CreditCardNumber";
                strSQL = strSQL + " AND Customer_CreditCard.CustomerID = @CustomerID;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;
                objCmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = parentKey;
                SqlDataReader objDR = objCmd.ExecuteReader();
                if (objDR.HasRows) {
                    List<string> colKeyList = new List<string>();
                    while (objDR.Read()) {
                        colKeyList.Add(objDR.GetString(0));
                    }
                    return colKeyList;
                }
                else {
                    objDR.Close();
                    objDR = null;
                    objCmd.Dispose();
                    objCmd = null;
                    return null;

                }
            }
            catch (Exception objE) {
                throw new Exception("Unexpected Error in CreditCardADO GetAllChildKeysOwnedByParent() Method:{0} " + objE.Message);
            }
            finally {
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }

        public List<CreditCardDTO> GetAllChildRecordsOwnedByParent(int parentKey) {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
            try {
                objConn.Open();
                string strSQL;
                strSQL = "SELECT CreditCard.CreditCardNumber,CreditCard.OwnerName,";
                strSQL = strSQL + "CreditCard.MerchantName,CreditCard.ExpDate,";
                strSQL = strSQL + "CreditCard.AddressLine1,AddressLine2, CreditCard.City,CreditCard.State,";
                strSQL = strSQL + "CreditCard.ZipCode,CreditCard.Country,";
                strSQL = strSQL + "CreditCard.CreditCardLimit,CreditCard.CreditCardBalance,)";
                strSQL = strSQL + "CreditCard.ActivationStatus)";
                strSQL = strSQL + " FROM CreditCard, Customer_CreditCard";
                strSQL = strSQL + " WHERE CreditCard.CreditCardNumber = Customer_CreditCard.CreditCardNumber";
                strSQL = strSQL + " AND Customer_CreditCard.CustomerID = @CustomerID;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;
                objCmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = parentKey;
                SqlDataReader objDR = objCmd.ExecuteReader();
                if (objDR.HasRows) {
                    List<CreditCardDTO> colRecordList = new List<CreditCardDTO>();
                    while (objDR.Read()) {
                        CreditCardDTO objDTO = new CreditCardDTO();
                        objDTO.CreditCardNumber = objDR.GetString(0);
                        objDTO.CreditCardOwnerName = objDR.GetString(1);
                        objDTO.MerchantName = objDR.GetString(2);
                        objDTO.ExpDate = objDR.GetDateTime(3);
                        objDTO.AddressLine1 = objDR.GetString(4);
                        objDTO.AddressLine2 = objDR.GetString(5);
                        objDTO.City = objDR.GetString(6);
                        objDTO.State = objDR.GetString(7);
                        objDTO.ZipCode = objDR.GetString(8);
                        objDTO.Country = objDR.GetString(9);
                        objDTO.CreditCardLimit = objDR.GetDecimal(10);
                        objDTO.CreditCardBalance = objDR.GetDecimal(11);
                        try {
                            objDTO.ActivationStatus = objDR.GetBoolean(12);
                        }
                        catch (Exception) {
                            objDTO.ActivationStatus = objDR.GetString(12).ToLower() == "true" ? true : false;
                        }
                        colRecordList.Add(objDTO);
                    }
                    return colRecordList;
                }
                else {
                    objDR.Close();
                    objDR = null;
                    objCmd.Dispose();
                    objCmd = null;
                    return null;

                }
            }
            catch (Exception objE) {
                throw new Exception("Unexpected Error in CreditCardADO GetAllChildKeysOwnedByParent() Method:{0} " + objE.Message);
            }
            finally {
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }

        public List<string> GetAllKeys() {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
            try {
                objConn.Open();
                string strSQL = "SELECT CreditCardNumber FROM CreditCard;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;
                SqlDataReader objDR = objCmd.ExecuteReader();
                if (objDR.HasRows) {
                    List<string> colKeyList = new List<string>();
                    while (objDR.Read()) {
                        colKeyList.Add(objDR.GetString(0));
                    }
                    return colKeyList;
                }
                else {
                    objDR.Close();
                    objDR = null;
                    objCmd.Dispose();
                    objCmd = null;
                    return null;

                }
            }
            catch (Exception objE) {
                throw new Exception("Unexpected Error in CreditCardADO GetAllKeys() Method:{0} " + objE.Message);
            }
            finally {
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }

        }

        public List<CreditCardDTO> GetAllRecords() {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
            try {
                objConn.Open();
                string strSQL = "SELECT * FROM CreditCard;";

                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;
                SqlDataReader objDR = objCmd.ExecuteReader();
                if (objDR.HasRows) {
                    List<CreditCardDTO> colRecordList = new List<CreditCardDTO>();
                    while (objDR.Read()) {
                        CreditCardDTO objDTO = new CreditCardDTO();
                        objDTO.CreditCardNumber = objDR.GetString(0);
                        objDTO.CreditCardOwnerName = objDR.GetString(1);
                        objDTO.MerchantName = objDR.GetString(2);
                        objDTO.ExpDate = objDR.GetDateTime(3);
                        objDTO.AddressLine1 = objDR.GetString(4);
                        objDTO.AddressLine2 = objDR.GetString(5);
                        objDTO.City = objDR.GetString(6);
                        objDTO.State = objDR.GetString(7);
                        objDTO.ZipCode = objDR.GetString(8);
                        objDTO.Country = objDR.GetString(9);
                        objDTO.CreditCardLimit = objDR.GetDecimal(10);
                        objDTO.CreditCardBalance = objDR.GetDecimal(11);
                        try
                        {
                            objDTO.ActivationStatus = objDR.GetBoolean(12);
                        }
                        catch (Exception)
                        {
                            objDTO.ActivationStatus = objDR.GetString(12).ToLower() == "true" ? true : false;
                        }
                        colRecordList.Add(objDTO);
                    }
                    return colRecordList;
                }
                else {
                    objDR.Close();
                    objDR = null;
                    objCmd.Dispose();
                    objCmd = null;
                    return null;

                }
            }
            catch (Exception objE) {
                throw new Exception("Unexpected Error in CreditCardADO GetAllRecords() Method:{0} " + objE.Message);
            }
            finally {
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }

        public CreditCardDTO GetRecordByID(string key) {

            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try {
                objConn.Open();
                string strSQL = "SELECT * FROM CreditCard WHERE CreditCardNumber = @CreditCardNumber;";
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;
                objCmd.Parameters.Add("@CreditCardNumber", SqlDbType.VarChar).Value = key;
                SqlDataReader objDR = objCmd.ExecuteReader();
                if (objDR.HasRows) {
                    CreditCardDTO objDto = new CreditCardDTO();
                    objDR.Read();
                    objDto.CreditCardNumber = objDR.GetString(0);
                    objDto.CreditCardOwnerName = objDR.GetString(1);
                    objDto.MerchantName = objDR.GetString(2);
                    objDto.ExpDate = objDR.GetDateTime(3);
                    objDto.AddressLine1 = objDR.GetString(4);
                    objDto.AddressLine2 = objDR.GetString(5);
                    objDto.City = objDR.GetString(6);
                    objDto.State = objDR.GetString(7);
                    objDto.ZipCode = objDR.GetString(8);
                    objDto.Country = objDR.GetString(9);
                    objDto.CreditCardLimit = objDR.GetDecimal(10);
                    objDto.CreditCardBalance = objDR.GetDecimal(11);
                    try {
                        objDto.ActivationStatus = objDR.GetBoolean(12);
                    }
                    catch (Exception) {
                        objDto.ActivationStatus = objDR.GetString(12).ToLower() == "true" ? true : false;
                    }

                    return objDto;
                }

                objDR.Close();
                objDR = null;
                objCmd.Dispose();
                objCmd = null;
                return null;
            }

            catch (Exception objE) {

                throw new Exception("Unexpected Error in CreditCardADO GetRecordByID(key) Method:{0} " + objE.Message);
            }
            finally {

                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
        }

        public bool Insert(CreditCardDTO objDto) {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());
            try {
                objConn.Open();
                string strSQL;
                strSQL = "INSERT INTO CreditCard (CreditCardNumber,OwnerName,MerchantName,ExpDate,";
                strSQL = strSQL + "AddressLine1,AddressLine2,City,State,ZipCode,Country,";
                strSQL = strSQL + "CreditCardBalance,CreditCardLimit,ActivationStatus)";
                strSQL = strSQL + "VALUES(@CreditCardNumber,@OwnerName,@MerchantName,@ExpDate,";
                strSQL = strSQL + "@AddressLine1,@AddressLine2,@City,@State,@ZipCode,@Country,";
                strSQL = strSQL + "@CreditCardLimit,@CreditCardBalance,@ActivationStatus);";
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;
                objCmd.Parameters.Add("@CreditCardNumber", SqlDbType.VarChar).Value = objDto.CreditCardNumber;
                objCmd.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = objDto.CreditCardOwnerName;
                objCmd.Parameters.Add("@MerchantName", SqlDbType.VarChar).Value = objDto.MerchantName;
                objCmd.Parameters.Add("@ExpDate", SqlDbType.VarChar).Value = objDto.ExpDate;
                objCmd.Parameters.Add("@AddressLine1", SqlDbType.VarChar).Value = objDto.AddressLine1;
                objCmd.Parameters.Add("@AddressLine2", SqlDbType.VarChar).Value = objDto.AddressLine2;
                objCmd.Parameters.Add("@City", SqlDbType.VarChar).Value = objDto.City;
                objCmd.Parameters.Add("@State", SqlDbType.Char).Value = objDto.State.ToCharArray();
                objCmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = objDto.ZipCode;
                objCmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = objDto.Country;
                objCmd.Parameters.Add("@CreditCardLimit", SqlDbType.Decimal).Value = objDto.CreditCardLimit;
                objCmd.Parameters.Add("@CreditCardBalance", SqlDbType.Decimal).Value = objDto.CreditCardBalance;
                objCmd.Parameters.Add("@ActivationStatus", SqlDbType.Bit).Value = objDto.ActivationStatus;
                var intRecordsAffected = objCmd.ExecuteNonQuery();
                if (intRecordsAffected == 1) {
                    return true;
                }
                objCmd.Dispose();
                objCmd = null;
                return false;
            }

            catch (Exception objE) {
                throw new Exception("Unexpected Error in CreditCardADO Insert(CreditCardDTO objDto) Method:{0} " + objE.Message);
            }
            finally {
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }

        }

        public bool InsertChildObjectOfAParent(int parentKey, CreditCardDTO objDto) {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try {

                objConn.Open();
                string strSQL;

                strSQL = "INSERT INTO CreditCard (CreditCardNumber,OwnerName,MerchantName,ExpDate,";
                strSQL = strSQL + "AddressLine1,AddressLine2,City,State,ZipCode,Country,";
                strSQL = strSQL + "CreditCardBalance,CreditCardLimit,ActivationStatus)";
                strSQL = strSQL + "VALUES(@CreditCardNumber,@OwnerName,@MerchantName,@ExpDate,";
                strSQL = strSQL + "@AddressLine1,@AddressLine2,@City,@State,@ZipCode,@Country,";
                strSQL = strSQL + "@CreditCardLimit,@CreditCardBalance,@ActivationStatus);";
                strSQL = strSQL + " INSERT INTO Customer_CreditCard (CustomerID,CreditCardNumber)";
                strSQL = strSQL + "VALUES (@CustomerID,@CreditCardNumber);";
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;


                objCmd.Parameters.Add("@CreditCardNumber", SqlDbType.VarChar).Value = objDto.CreditCardNumber;
                objCmd.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = objDto.CreditCardOwnerName;
                objCmd.Parameters.Add("@MerchantName", SqlDbType.VarChar).Value = objDto.MerchantName;
                objCmd.Parameters.Add("@ExpDate", SqlDbType.VarChar).Value = objDto.ExpDate;
                objCmd.Parameters.Add("@AddressLine1", SqlDbType.VarChar).Value = objDto.AddressLine1;
                objCmd.Parameters.Add("@AddressLine2", SqlDbType.VarChar).Value = objDto.AddressLine2;
                objCmd.Parameters.Add("@City", SqlDbType.VarChar).Value = objDto.City;
                objCmd.Parameters.Add("@State", SqlDbType.Char).Value = objDto.State.ToCharArray();
                objCmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = objDto.ZipCode;
                objCmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = objDto.Country;
                objCmd.Parameters.Add("@CreditCardLimit", SqlDbType.Decimal).Value = objDto.CreditCardLimit;
                objCmd.Parameters.Add("@CreditCardBalance", SqlDbType.Decimal).Value = objDto.CreditCardBalance;
                objCmd.Parameters.Add("@ActivationStatus", SqlDbType.Bit).Value = objDto.ActivationStatus;
                objCmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = parentKey;
                int intRecordsAffected = objCmd.ExecuteNonQuery();

                if (intRecordsAffected == 2) {

                    return true;
                }

                objCmd.Dispose();
                objCmd = null;

                return false;
            }

            catch (Exception objE) {

                throw new Exception("Unexpected Error in CreditCardADO InsertChildObjectOfAParent (Key, CreditCardDTO objDto) Method: {0}" + objE.Message);
            }
            finally {

                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }

        }

        public bool Update(CreditCardDTO objDto) {
            SqlConnection objConn = new SqlConnection(SQLServerFactory.ConnectionString());

            try {

                objConn.Open();

                string strSQL;
                strSQL = "UPDATE CreditCard";
                strSQL = strSQL + " SET OwnerName=@OwnerName,";
                strSQL = strSQL + "MerchantName=@MerchantName,";
                strSQL = strSQL + "ExpDate=@ExpDate,";
                strSQL = strSQL + "AddressLine1=@AddressLine1,";
                strSQL = strSQL + "AddressLine2=@AddressLine2,";
                strSQL = strSQL + "City=@City,";
                strSQL = strSQL + "State=@State,";
                strSQL = strSQL + "ZipCode=@ZipCode,";
                strSQL = strSQL + "Country=@Country,";
                strSQL = strSQL + "CreditCardLimit=@CreditCardLimit,";
                strSQL = strSQL + "CreditCardBalance=@CreditCardBalance,";
                strSQL = strSQL + "ActivationStatus=@ActivationStatus";
                strSQL = strSQL + " WHERE CreditCardNumber=@CreditCardNumber;";
                SqlCommand objCmd = new SqlCommand(strSQL, objConn);
                objCmd.CommandType = CommandType.Text;

                objCmd.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = objDto.CreditCardOwnerName;
                objCmd.Parameters.Add("@MerchantName", SqlDbType.VarChar).Value = objDto.MerchantName;
                objCmd.Parameters.Add("@ExpDate", SqlDbType.VarChar).Value = objDto.ExpDate;
                objCmd.Parameters.Add("@AddressLine1", SqlDbType.VarChar).Value = objDto.AddressLine1;
                objCmd.Parameters.Add("@AddressLine2", SqlDbType.VarChar).Value = objDto.AddressLine2;
                objCmd.Parameters.Add("@City", SqlDbType.VarChar).Value = objDto.City;
                objCmd.Parameters.Add("@State", SqlDbType.Char).Value = objDto.State.ToCharArray();
                objCmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = objDto.ZipCode;
                objCmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = objDto.Country;
                objCmd.Parameters.Add("@CreditCardLimit", SqlDbType.Decimal).Value = objDto.CreditCardLimit;
                objCmd.Parameters.Add("@CreditCardBalance", SqlDbType.Decimal).Value = objDto.CreditCardBalance;
                objCmd.Parameters.Add("@ActivationStatus", SqlDbType.Bit).Value = objDto.ActivationStatus;
                objCmd.Parameters.Add("@CreditCardNumber", SqlDbType.VarChar).Value = objDto.CreditCardNumber;
                int intRecordsAffected = objCmd.ExecuteNonQuery();

                if (intRecordsAffected == 1) {

                    return true;
                }

                objCmd.Dispose();
                objCmd = null;

                return false;
            }

            catch (Exception objE) {

                throw new Exception("Unexpected Error in CreditCardADO Update(CreditCardDTO objDto) Method:{0} " + objE.Message);
            }
            finally {

                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }

        }
    }
}
