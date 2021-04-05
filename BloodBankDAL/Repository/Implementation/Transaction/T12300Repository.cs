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
    public class T12300Repository: IT12300
    {
        private readonly T12300 obj = new T12300();
        public T12300Repository(T12300 _obj) : base()
        {
            obj = _obj;
        }
        public DataTable GetPatDetailsData(string lang, string patNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetPatDetailsData(lang, patNo);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetPatDetailsData(lang, patNo);
            //return Data;
        }

       public DataTable GetDoctor(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetDoctor(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetDoctor(lang);
            //return Data;
        }

       public DataTable GetABO(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetABO(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetABO(lang);
            //return Data;
        }

      public  DataTable Getsergeon(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.Getsergeon(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.Getsergeon(lang);
            //return Data;
        }

        public DataTable GetProductData(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetProductData(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetProductData(lang);
            //return Data;
        }

        public DataTable GethospitalData(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GethospitalData(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GethospitalData(lang);
            //return Data;
        }

        public DataTable GetCheckData(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetCheckData(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetCheckData(lang);
            //return Data;
        }

        public DataTable GetWardData(string lang,string siteCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetWardData(lang, siteCode);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetWardData(lang, siteCode);
            //return Data;
        }

        public DataTable GetNurseData(string lang, string siteCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetNurseData(lang, siteCode);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetNurseData(lang, siteCode);
            //return Data;
        }

       public string SaveData(M12300 t12300, string lang, string user, string sitCode)
       {
           string dt = "";
            try
            {
                dt = obj.SaveData(t12300, lang, user, sitCode);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.SaveData(t12300,lang,user, sitCode);
            //return Data;
        }

       public DataTable GeAllData(string patNo, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GeAllData(patNo, lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GeAllData(patNo, lang);
            //return Data;
        }

      public DataTable GetVirusData(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetVirusData(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetVirusData(lang);
            //return Data;
        }
    }
}