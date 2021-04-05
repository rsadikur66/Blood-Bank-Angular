using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Repository.Interface.Transaction;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    using System.Data;

    using BloodBankDAL.Model;
    using BloodBankDAL.Repository.Query.Transaction;

    public class T12301Repository : IT12301
    {
        private readonly T12301 obj = new T12301();

        CommonDAL _CommonData = new CommonDAL();

        private String nationalityMessage = "";
        public T12301Repository(T12301 _obj) : base()
        {
            obj = _obj;
        }

        public DataTable GetPatInfo(string T_REQUEST_NO, string T_LANG, string T_SITE_CODE)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetPatInfo(T_REQUEST_NO, T_LANG, T_SITE_CODE);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetPatInfo(T_REQUEST_NO, T_LANG, T_SITE_CODE);
            //return obj;
        }
        public DataTable GetRequestNoPopUp(string T_SITE_CODE)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetRequestNoPopUp(T_SITE_CODE);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetRequestNoPopUp(T_SITE_CODE);
            //return obj;

        }
        public DataTable GetUserList(string T_SITE_CODE,string T_EMP_CODE)
        {
            DataTable dt = new DataTable();
            try
            {
                dt =  this.obj.GetUserList(T_SITE_CODE, T_EMP_CODE);
                

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetUserList(T_SITE_CODE, T_EMP_CODE);
            //return obj;
        }

        public DataTable GetUserListByCode(string T_SITE_CODE, string T_EMP_CODE)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetUserListByCode(T_SITE_CODE, T_EMP_CODE);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetUserListByCode(T_SITE_CODE,T_EMP_CODE);
            //return obj;
        }

        public DataTable GetCurrentUser(string T_EMP_CODE)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetCurrentUser(T_EMP_CODE);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetCurrentUser(T_EMP_CODE);
            //return obj;
        }


        public string updateT12012(string T_REQUEST_NO, string T_BLOOD_BRING, string T_LAB_NO, string T_REQ_REC_DATE, string T_REQ_REC_TIME, string T_UPD_USER,string T_SITE_CODE)
        {
            string msg = "";
            bool isUpdate = false;

            try
            {
                obj.BeginTransaction();
                if (this.obj.updateT12012(T_REQUEST_NO, T_BLOOD_BRING, T_LAB_NO, T_REQ_REC_DATE, T_REQ_REC_TIME, T_UPD_USER, T_SITE_CODE))
                {
                    isUpdate = true;
                }
                if (isUpdate)
                {
                    msg = "Data save successfully";
                    obj.CommitTransaction();
                }
                else
                {
                    msg = "Save failed";
                    obj.RollbackTransaction();
                }

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return msg;
            //obj.BeginTransaction();
            //if (this.obj.updateT12012(T_REQUEST_NO, T_BLOOD_BRING, T_LAB_NO, T_REQ_REC_DATE,T_REQ_REC_TIME, T_UPD_USER, T_SITE_CODE))
            //{
            //    isUpdate = true;
            //}
            //if (isUpdate)
            //{
            //    msg = "Data save successfully";
            //    obj.CommitTransaction();
            //}
            //else
            //{
            //    msg = "Save failed";
            //    obj.RollbackTransaction();
            //}
            //return msg;

        }
    }
}