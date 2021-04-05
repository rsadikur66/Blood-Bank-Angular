using BloodBankDAL.Repository.Interface.Transaction;
using BloodBankDAL.Repository.Query.Transaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    public class T12266Repository : IT12266
    {
        private readonly T12266 obj = new T12266();
        public T12266Repository(T12266 _obj) : base()
        {
            obj = _obj;
        }
        public DataTable GetDeliveryManData(string site)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetDeliveryManData(site);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
        }
        public DataTable GetReqDetails(string bldReq, string site, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetReqDetails(bldReq, site, lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
        }
        public DataTable GetuserDetails(string lang, string user)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetuserDetails(lang, user);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
        }
        public string Save(string delCode, string requestNo, string siteCode, string user, string time)
        {
            string data = "";
            try
            {
                data = obj.Save(delCode,requestNo, siteCode, user, time);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return data;
        }
    }
}