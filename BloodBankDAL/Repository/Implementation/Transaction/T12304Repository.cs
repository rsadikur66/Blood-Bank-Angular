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
    public class T12304Repository : IT12304
    {
        private readonly T12304 obj = new T12304();
        public T12304Repository(T12304 _obj) : base()
        {
            obj = _obj;
        }
        public T12304Repository()
        {
        }
        public DataTable reqList(string lang, string site, string req)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.reqList(lang, site, req);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var data = obj.reqList(lang, site, req);
            //return data;
        }

        public DataTable GetReqNoList(string site)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetReqNoList(site);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var data = obj.GetReqNoList(site);
            //return data;
        }

        public DataTable Griddatalist(string reqNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.Griddatalist(reqNo);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var data = obj.Griddatalist(reqNo);
            //return data;
        }

        public DataTable get_Issuedbyname(string lang, string empCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.get_Issuedby_name(lang, empCode);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var data = obj.get_Issuedby_name(lang, empCode);
            //return data;
        }

        

        public string Insert(string user,List<t12304>  t12304,string lang)
        {
            string dt = "";
            try
            {
                obj.BeginTransaction();
                if (obj.Insert(user, t12304))
                {
                    obj.CommitTransaction();
                    dt = obj.GetUserMsg("N0040", "LANG" + lang);
                }
                else
                {
                    obj.RollbackTransaction();
                    dt = obj.GetUserMsg("N0071", "LANG" + lang);
                }
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //string msg = "";
            //obj.BeginTransaction();
            //if (obj.Insert(user, t12304))
            //{
            //    obj.CommitTransaction();
            //    msg = "Data Saved Successfully";
            //}
            //else
            //{
            //    obj.RollbackTransaction();
            //    msg = "Data Not Saved";
            //}
            //return msg;
        }
        //------------------------------------Report----------------------------
        public DataTable GetSite(string siteCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetSite(siteCode);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var data = obj.GetSite(siteCode);
            //return data;
        }
        public DataTable getR12046_xMatch(string reqno, string site, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.getR12046_xMatch(reqno, site, lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var data = obj.getR12046_xMatch(reqno, site, lang);
            //return data;
        }
        public DataTable getR12046_Issue(string reqno, string site, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.getR12046_Issue(reqno, site, lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var data = obj.getR12046_Issue(reqno, site, lang);
            //return data;
        }

        public DataTable RequestNoList(string siteCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetReqNoList(siteCode);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var data = obj.GetReqNoList(siteCode);
            //return data;
        }
    }
}