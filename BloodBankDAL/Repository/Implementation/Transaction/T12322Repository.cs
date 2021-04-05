using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface.Transaction;
using BloodBankDAL.Repository.Query.Transaction;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    public class T12322Repository:IT12322
    {
        private readonly T12322 obj = new T12322();
        public T12322Repository(T12322 _obj) : base()
        {
            obj = _obj;
        }
      

        public DataTable GetProductList()
        {
            DataTable dt = new DataTable();
            dt = obj.GetProductList();
            return dt;

        }
        public DataTable GetReasonList(string lang)
        {
            DataTable dt = new DataTable();
            dt = obj.GetReasonList(lang);
            return dt;
            
        }
        public DataTable GetSingleUnit(string unit, string lang)
        {
            DataTable dt = new DataTable();
            dt = obj.GetSingleUnit(unit, lang);
            return dt;
            
        }
        public string saveList(List<T12320> t23List, string user, string lang)
        {
            return obj.saveList(t23List,  user,  lang);
            
        }
    }
}