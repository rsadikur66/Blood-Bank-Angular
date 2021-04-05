using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Repository.Interface.Transaction;
using BloodBankDAL.Repository.Query.Transaction;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    public class T12262Repository : IT12262
    {
        private readonly T12262 obj = new T12262();
        public T12262Repository(T12262 _obj) : base()
        {
            obj = _obj;
        }
        public DataTable GetDataBySiteCode(string siteCode, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetDataBySiteCode(siteCode, lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
        }
        public DataTable GetDataRequestNo(string siteCode, string refCode, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetDataRequestNo(siteCode, refCode, lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
        }
        public DataTable GetRequestDetails(string requestNo, string siteCode, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetRequestDetails(requestNo, siteCode, lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
        }
        public DataTable GetRequestDetails(string siteCode, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetRequestDetails(siteCode, lang);
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
        public string Save(string requestNo, string siteCode, string user, string time)
        {
            string data = "";
            try
            {
                data = obj.Save(requestNo, siteCode, user, time);
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