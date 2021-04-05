using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Repository.Interface.Initialization;
using BloodBankDAL.Repository.Query.Initialization;

namespace BloodBankDAL.Repository.Implementation.Initialization
{
    public class T12132Repository: IT12132
    {
        private readonly T12132 obj = new T12132();
        public T12132Repository(T12132 _obj)
        {
            obj = _obj;
        }
        public T12132Repository()
        {
        }

        public DataTable GetGridData()
        {
            //var obj = this.obj.GetGridData();
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetGridData();
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetAllFormCodeData()
        {
            //var Data = obj.GetAllFormCodeData();
            //return Data;

            var data = new DataTable();

            try
            {
                data = obj.GetAllFormCodeData();
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public string SaveData(M12132 t12132, string lang, string user)
        {
            //var data = obj.SaveData(t12132, user, lang);
            //return data;

            var data = "";

            try
            {
                data = obj.SaveData(t12132, user, lang);
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