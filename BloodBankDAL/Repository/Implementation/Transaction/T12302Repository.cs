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
    public class T12302Repository : IT12302
    {
        private readonly T12302 obj = new T12302();
        public T12302Repository(T12302 _obj) : base()
        {
            obj = _obj;
        }
        public T12302Repository()
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
        }
        public DataTable reqDet(string lang, string site, string req)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.reqDet(lang, site, req);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var Data = obj.reqDet(lang, site, req);
            //return Data;
        }
        public DataTable bgList(string lang, string code)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.bgList(lang, code);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var Data = obj.bgList(lang, code);
            //return Data;
        }
        public DataTable techList(string site, string code)
        {
            //var Data = obj.techList(site, code);
            //return Data;
            DataTable dt = new DataTable();
            try
            {
                dt = obj.techList(site, code);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
        }

        public DataTable antTypAutoList(string lang, string code, string type)
        {
            //var Data = obj.antTypAutoList(lang, code, type);
            //return Data;
            DataTable dt = new DataTable();
            try
            {
                dt = obj.antTypAutoList(lang, code, type);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
        }
        public DataTable antTypFinalList(string lang, string code, string type)
        {
            //var Data = obj.antTypFinalList(lang, code, type);
            //return Data;
            DataTable dt = new DataTable();
            try
            {
                dt = obj.antTypFinalList(lang, code, type);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
        }
        public DataTable antiList()
        {
            //var Data = obj.antiList();
            //return Data;
            DataTable dt = new DataTable();
            try
            {
                dt = obj.antiList();
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
        }
        public DataTable dctList(string lang)
        {
            //var Data = obj.dctList(lang);
            //return Data;
            DataTable dt = new DataTable();
            try
            {
                dt = obj.dctList(lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
        }
        public DataTable getbgByControl(string lang, string P_ANTI_A, string P_ANTI_B, string P_ANTI_D, string P_CONTROL)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.getbgByControl(lang, P_ANTI_A, P_ANTI_B, P_ANTI_D, P_CONTROL);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var Data = obj.getbgByControl(lang, P_ANTI_A, P_ANTI_B, P_ANTI_D, P_CONTROL);
            //return Data;
        }
        public DataTable checkBg(string P_PAT_NO, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.checkBg(P_PAT_NO, lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var Data = obj.checkBg(P_PAT_NO, lang);
            //return Data;
        }
        public DataTable checkT_SC(string P_PAT_NO, string site)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.checkT_SC(P_PAT_NO, site);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var Data = obj.checkT_SC(P_PAT_NO, site);
            //return Data;
        }
        public DataTable getbgByControl6(string lang, string P_ANTI_A, string P_ANTI_B, string P_ANTI_D, string P_CONTROL, string P_ACELL, string P_BCELL)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.getbgByControl6(lang, P_ANTI_A, P_ANTI_B, P_ANTI_D, P_CONTROL, P_ACELL, P_BCELL);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var Data = obj.getbgByControl6(lang, P_ANTI_A, P_ANTI_B, P_ANTI_D, P_CONTROL, P_ACELL, P_BCELL);
            //return Data;
        }
        public int chkDoctor(string P_EMP_CODE, string P_SITE_CODE)
        {
            int dt = new int() ;
            try
            {
                dt = obj.chkDoctor(P_EMP_CODE, P_SITE_CODE);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var Data = obj.chkDoctor(P_EMP_CODE, P_SITE_CODE);
            //return Data;
        }
        public DataTable unitList(string P_PAT_NO, string P_SITE_CODE, string P_PHENO, string P_REQUISITION, string P_ABO_CODE, string P_UNIT_NO, string P_REQUEST_NO, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.unitList(P_PAT_NO, P_SITE_CODE, P_PHENO, P_REQUISITION, P_ABO_CODE, P_UNIT_NO, P_REQUEST_NO, lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var Data = obj.unitList(P_PAT_NO, P_SITE_CODE, P_PHENO, P_REQUISITION, P_ABO_CODE, P_UNIT_NO, P_REQUEST_NO, lang);
            //return Data;
        }
        public string insert(T12013 t12013, List<T12256> t12256)
        {
            string dt = "";
            try
            {
                dt = obj.insert(t12013, t12256);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var Data = obj.insert(t12013, t12256);
            //return Data;
        }

       public DataTable getUserId(string site, string emp,string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.getUserId(site, emp,lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
        }

        public DataTable checkBlood(string patId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.checkBlood(patId);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
        }
    }

}