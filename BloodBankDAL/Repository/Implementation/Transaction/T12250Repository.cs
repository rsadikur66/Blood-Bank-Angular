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
    public class T12250Repository : IT12250
    {
        private readonly T12250 obj = new T12250();
        public T12250Repository(T12250 _obj) : base()
        {
            obj = _obj;
        }

        public DataTable CheckDonor(string P_PAT_NO, string P_NTNLTY_ID, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.checkDonor(P_PAT_NO, P_NTNLTY_ID, lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.checkDonor(P_PAT_NO, P_NTNLTY_ID, lang);
            //return Data;
        }
        public DataTable GetReasonList(int age, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetReasonList(age, lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;

            //var Data = obj.GetReasonList(age, lang);
            //return Data;
        }
        public DataTable GetSingleReason(int age, string reasonCode, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetSingleReason(age, lang, reasonCode);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetSingleReason(age, lang, reasonCode);
            //return Data;
        }

        public DataTable GetPatientData(string lang, string searchValue)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetPatientData(lang, searchValue);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetPatientData(lang, searchValue);
            //return obj;
        }
        public string insert(CommonModel t12017, string user)
        {
            string msg = "";
            // DataTable dt = new DataTable();
            try
            {
                string time = DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes.ToString();
                msg = obj.insert(user, t12017.T_PAT_NO, t12017.T_DONOR_NTNLTY_ID, t12017.T_DOTN_RSN_CODE,
                    t12017.T_REF_PAT_NO, t12017.T_OTHER_PAT_NAME, t12017.T_GENDER, time, t12017.T_SITE_CODE);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return msg;
            
            //string time = DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes.ToString();
            //msg = obj.insert(user, t12017.T_PAT_NO, t12017.T_DONOR_NTNLTY_ID, t12017.T_DOTN_RSN_CODE,
            //    t12017.T_REF_PAT_NO, t12017.T_OTHER_PAT_NAME, t12017.T_GENDER,time,t12017. T_SITE_CODE);
            //return msg;
        }

        public string GetArabicName(string patNo)
        {
           // DataTable dt = new DataTable();
            string dt = "";
            try
            {
                dt = this.obj.GetArabicName(patNo);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetArabicName(patNo);
            //return obj;
        }
    }
}