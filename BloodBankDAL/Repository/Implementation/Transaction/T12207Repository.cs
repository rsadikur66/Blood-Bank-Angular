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
    public class T12207Repository : IT12207
    {
        private readonly T12207 obj = new T12207();
        public T12207Repository(T12207 _obj) : base()
        {
            obj = _obj;
        }

        public DataTable GetRefHospital(string siteCode, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetRefHospital(siteCode, lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var obj = this.obj.GetRefHospital(siteCode, lang);
            //return obj;
        }

        public DataTable GetBlood(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetBlood(lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var obj = this.obj.GetBlood(lang);
            //return obj;
        }

        public DataTable GetProduct(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetProduct(lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var obj = this.obj.GetProduct(lang);
            //return obj;
        }
        public DataTable GetGridDataForTransfusion(string siteCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetGridDataForTransfusion(siteCode);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var obj = this.obj.GetProduct(lang);
            //return obj;
        }

        public string Insert_T12207(t12207 t12207, string user, string siteCode)
        {
            var data = "";
            try
            {
                data = obj.Insert_T12207(t12207, user, siteCode);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
            
            //var data = obj.Insert_T12207(t12207, user, siteCode);
            //return data;
        }
        public string BloodReceiveFromTransfusion(string del, string blNo, string user,string siteCode)
        {
            string data = "";
            try
            {
                data = obj.BloodReceiveFromTransfusion(del, blNo, user,siteCode);

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