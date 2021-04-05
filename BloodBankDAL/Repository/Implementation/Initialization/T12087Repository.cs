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
    public class T12087Repository : IT12087
    {
        private readonly T12087 obj = new T12087();
        public T12087Repository(T12087 _obj) : base()
        {
            obj = _obj;
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

        public DataTable GetGridDataChild(string viralCode, string lang)
        {
            //var obj = this.obj.GetGridDataChild(viralCode,lang);
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetGridDataChild(viralCode, lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public string Update_T12087(List<t12087> t12087, List<M12087> M12087, string user, string lang)
        {
            //var Data = obj.Update_T12087(t12087, M12087, user,lang);
            //return Data;

            var data = "";

            try
            {
                data = this.obj.Update_T12087(t12087, M12087, user, lang);
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