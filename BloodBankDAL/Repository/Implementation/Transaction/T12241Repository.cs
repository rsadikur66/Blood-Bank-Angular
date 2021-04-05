using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    using BloodBankDAL.Repository.Interface.Transaction;
    using BloodBankDAL.Repository.Query.Transaction;

    public class T12241Repository: IT12241
    {
        private readonly T12241 obj = new T12241();
        public T12241Repository(T12241 _obj) : base()
        {
            obj = _obj;
        }

        public DataTable GridResultVirology(string UnitNoFrom, string UnitNoTo,string lang,string siteCode)
        {
            DataTable dt = new DataTable();
            try
            {
                if (lang == "2")
                {
                    lang = "";
                }
                else
                {
                    lang = "2";
                }
                dt = obj.GridResultVirology(UnitNoFrom, UnitNoTo, lang, siteCode);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //if (lang == "2")
            //{
            //    lang = "";
            //}
            //else
            //{
            //    lang = "2";
            //}
            //var data = obj.GridResultVirology(UnitNoFrom, UnitNoTo,lang,siteCode);
            //return data;
        }

        public DataTable DocEmpCode(string usercode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.DocEmpCode(usercode);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var data = obj.DocEmpCode(usercode);
            //return data;
        }
        
        public DataTable GetUnitPopUpData()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetUnitPopUpData();

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var data = obj.GetUnitPopUpData();
            //return data;
        }

        public bool updateVirologyResults(string unitNo,string siteCode)
        {
            string user = HttpContext.Current.Session["T_EMP_CODE"].ToString();
            string msg = "";
          
            try
            {
                obj.BeginTransaction();
                if (obj.updateVirologyResults(user, unitNo, siteCode))
                {
                    obj.CommitTransaction();
                    msg = "Data updated Successfully";
                }
                else
                {
                    obj.RollbackTransaction();
                    msg = "Data Not Saved";
                }

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return true;
           
            //obj.BeginTransaction();
            //if (obj.updateVirologyResults(user,unitNo, siteCode))
            //{
            //    obj.CommitTransaction();
            //    msg = "Data updated Successfully";
            //}
            //else
            //{
            //    obj.RollbackTransaction();
            //    msg = "Data Not Saved";
            //}
            //return true;
        }

        public bool InsertT12223(string unitNo, string sitecode)
        {
            string user = HttpContext.Current.Session["T_EMP_CODE"].ToString();
            string msg = "";
          
            try
            {
                obj.BeginTransaction();
                if (obj.InsertT12223(user, sitecode, unitNo))
                {
                    obj.CommitTransaction();
                    msg = "Data Insert Successfully into t12223";
                }
                else
                {
                    obj.RollbackTransaction();
                    msg = "Data Not Saved";
                }

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return true;
            //obj.BeginTransaction();
            //if (obj.InsertT12223(user,sitecode, unitNo))
            //{
            //    obj.CommitTransaction();
            //    msg = "Data Insert Successfully into t12223";
            //}
            //else
            //{
            //    obj.RollbackTransaction();
            //    msg = "Data Not Saved";
            //}
           // return true;
        }
    }
}