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
    public class T12325Repository : IT12325
    {
        private readonly T12325 obj = new T12325();
        public T12325Repository(T12325 _obj) : base()
        {
            obj = _obj;
        }

        public DataTable GetVirus(string lang, string user)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetVirus(lang, user);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetVirus(lang, user);
            //return Data;

        }

        public DataTable GetResulDes(string lang, string value)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetResulDes(lang, value);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetResulDes(lang, value);
            //return Data;
        }

        public DataTable CheckUnitNo(string unit)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.CheckUnitNo(unit);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.CheckUnitNo(unit);
            //return Data;
        }

        //public string SaveData(string un, T12325 vairusList)
        // {
        //     string msg = "";
        //    // bool isInsert = false;
        //     obj.BeginTransaction();
        //     if (obj.SaveData(un, vairusList))
        //     {
        //         obj.CommitTransaction();
        //         msg = "Save Successfully";
        //     }
        //    // var Data = obj.SaveData(un,vairusList);
        //     return msg;
        // }

        public string SaveData(string un, List<M12325> vairusList, string T_EMP_CODE, string lang)
        {
            var Data = "";
            try
            {
                 Data = obj.SaveData(un, vairusList, T_EMP_CODE, lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
           // var Data = obj.SaveData(un, vairusList, T_EMP_CODE, lang);
            return Data;
        }

        public DataTable GetUnitNo()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetUnitNo();

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetUnitNo();
            //return Data;
        }

        public DataTable GerVirusResult(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GerVirusResult(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GerVirusResult(lang);
            //return Data;
        }

        public DataTable GetAllData(string lang, string unitNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetAllData(lang, unitNo);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetAllData(lang,unitNo);
            //return Data;
        }
    }
}