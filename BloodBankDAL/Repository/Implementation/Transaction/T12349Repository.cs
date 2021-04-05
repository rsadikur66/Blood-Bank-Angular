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
    public class T12349Repository : IT12349
    {
        private readonly T12349 obj = new T12349();

        public T12349Repository(T12349 _obj) : base()
        {
            obj = _obj;
        }
        public T12349Repository()
        {
        }
        public DataTable getBagType(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.getBagType(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.getBagType(lang);
            //return Data;
        }
        public DataTable getUnitList(string T_SITE_CODE, string T_UNIT_NO, string DATEFROM, string DATETO)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.getUnitList(T_SITE_CODE, T_UNIT_NO, DATEFROM, DATETO);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.getUnitList(T_SITE_CODE, T_UNIT_NO, DATEFROM, DATETO);
            //return Data;
        }
        public DataTable validateWeight(string T_UNIT_WEIGHT, string T_BAG_TYPE)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.validateWeight(T_UNIT_WEIGHT, T_BAG_TYPE);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.validateWeight(T_UNIT_WEIGHT, T_BAG_TYPE);
            //return Data;
        }
        public string insert(List<CommonModel> modelList, string lang, string user)
        {
            string dt = "";
           // DataTable dt = new DataTable();
            try
            {
                dt = obj.insert(modelList, lang, user);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.insert(modelList, lang, user);
            //return Data;
        }
    }
}