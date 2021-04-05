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
    public class T12246Repository : IT12246
    {
        private readonly T12246 obj = new T12246();

        public T12246Repository(T12246 _obj) : base()
        {
            obj = _obj;
        }

        public T12246Repository()
        {
        }

        //For Blood Data
        public DataTable GetBloodData(string language)
        {
            //var obj = this.obj.GetBloodData(language);
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetBloodData(language);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        //For product Data
        public DataTable GetProductData(string language)
        {
            //var obj = this.obj.GetProductData(language);
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetProductData(language);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetGridData(string language, string productCode, string bloodGroup)
        {
            //var obj = this.obj.GetGridData(language, productCode,bloodGroup);
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetGridData(language, productCode, bloodGroup);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }
       
        public string Insert_T12211(List<t12246> t12246, string p, string b, string user)
        {
            //var Data = obj.Insert_T12211(t12246, p, b, user);
            //return Data;

            var data = "";

            try
            {
                data = obj.Insert_T12211(t12246, p, b, user);
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