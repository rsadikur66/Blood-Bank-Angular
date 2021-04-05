using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Query.Transaction;

namespace BloodBankDAL.Repository.Implementation
{
   public class T12244Repository:IT12244
    {
        private readonly T12244 obj = new T12244();

        public T12244Repository(T12244 _obj) : base()
        {           
            obj = _obj;
        }
        public T12244Repository()
        {
        }
        public DataTable getPatNo(string P_PAT_NO, string T_SITE_CODE)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.getPatNo(P_PAT_NO, T_SITE_CODE);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.getPatNo(P_PAT_NO, T_SITE_CODE);
            //return Data;
        }
        public DataTable getQuestions(int type, string P_SEX, string P_PAT_NO)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.getQuestions(type, P_SEX, P_PAT_NO);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.getQuestions(type,  P_SEX,P_PAT_NO);
            //return Data;
        }  public DataTable getConsent(int type)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.getConsent(type);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.getConsent(type);
            //return Data;
        }
        public string insert(CommonModel t12017)
        {
            string dt = "";
          
            try
            {
                dt = obj.insert(t12017);
               

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //string user = u;
            //string msg = "";
            //string time = DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes.ToString();
            ////bool isInsert = false;
            //obj.BeginTransaction();
            //if (obj.update17(user, t12017.T_BLOOD_DONATION_STATUS, t12017.T_RESEARCH_STTS, t12017.T_REQUEST_ID))
            //{
            //    obj.CommitTransaction();

            //    foreach (CommonModel t71 in t12071)
            //    {
            //        obj.BeginTransaction();
            //        t71.T_REQUEST_ID = t12017.T_REQUEST_ID;
            //        if (obj.insert71(user, time, t71.T_DONOR_ID, t71.T_DONOR_PATNO, t71.T_DONOR_EPISODE, t71.T_QNO, t71.T_QNO_ANS, t71.T_QHEAD_NO, t71.T_DISP_SEQ, t71.T_DIFFERAL_DAY, t71.T_REQUEST_ID))
            //        {obj.CommitTransaction();}
            //        else{obj.RollbackTransaction();}

            //    }
            //    msg = "s";
            //}
            //else
            //{ obj.RollbackTransaction(); msg = "f"; }

            //return msg;





            
        }

        public string singleInsert(CommonModel t71)
        {
            
            string sms = "";
            try
            {
                sms = obj.singleInsert(t71);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return sms;
            //var Data = obj.singleInsert(t71);
            //return Data;
        }
        public DataTable testPrint()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.testPrint();

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.testPrint();
            //return Data;
        }
    }
}
