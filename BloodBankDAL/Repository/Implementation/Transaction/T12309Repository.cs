using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Repository.Interface.Transaction;
using BloodBankDAL.Repository.Query.Transaction;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    public class T12309Repository: IT12309
    {
        private readonly T12309 obj = new T12309();

        public T12309Repository(T12309 _obj) : base()
        {
            obj = _obj;
        }
        public  DataTable GetUnitData()
        {
            var data = obj.GetUnitData();
            return data;
        }

        public DataTable GetProductDetails(string unitNo, string prodCode, string lang)
        {
            var data = obj.GetProductDetails( unitNo, prodCode, lang);
            return data;
        }

       public string SaveData(M12309 t12309, string user, string siteCode)
       {
           var data = obj.SaveData(t12309, user, siteCode);
           return data;
       }
    }
}