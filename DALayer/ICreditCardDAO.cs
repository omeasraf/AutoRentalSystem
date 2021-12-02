using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer {
    public interface ICreditCardDAO
    {
        CreditCardDTO GetRecordByID(String key);
        bool Insert(CreditCardDTO objDto);
        bool InsertChildObjectOfAParent(int parentKey, CreditCardDTO objDto);
        bool Update(CreditCardDTO objDto);
        bool Delete(String key);
        List<CreditCardDTO> GetAllRecords();
        List<String> GetAllKeys();
        List<CreditCardDTO> GetAllChildRecordsOwnedByParent(int parentKey);
        List<String> GetAllChildKeysOwnedByParent(int parentKey);
    }
}
