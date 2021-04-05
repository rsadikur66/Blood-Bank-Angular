using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface.Initialization;
using BloodBankDAL.Repository.Query.Initialization;

namespace BloodBankDAL.Repository.Implementation.Initialization
{
    public class T12281Repository : IT12281
    {
        private readonly T12281 obj = new T12281();
        public T12281Repository(T12281 _obj) : base()
        {
            obj = _obj;
        }
        public DataTable GetAllData(string lang)
        {
            //var Data = obj.GetAllData(lang);
            //return Data;

            var data = new DataTable();

            try
            {
                data = obj.GetAllData(lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetAllUnitData(string lang)
        {
            //var Data = obj.GetAllUnitData(lang);
            //return Data;

            var data = new DataTable();

            try
            {
                data = obj.GetAllUnitData(lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public string SaveData(M12281 t12281, string lang, string user)
        {
            //var Data = obj.SaveData(t12281, user,lang);
            //return Data;

            var data = "";

            try
            {
                data = obj.SaveData(t12281, user, lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;



            //string msg = "";
            //obj.BeginTransaction();
            //if (obj.InsertT12281(t12281, user))
            //{
            //    obj.CommitTransaction();
            //    msg = obj.GetUserMsg("N0040", "LANG" + lang);
            //}
            //return msg;
        }
    }
}