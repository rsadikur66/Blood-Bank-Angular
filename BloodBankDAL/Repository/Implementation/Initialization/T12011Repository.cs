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
    public class T12011Repository:IT12011
    {
        private readonly T12011 obj = new T12011();
        public T12011Repository(T12011 _obj)
        {
            obj = _obj;
        }
        public T12011Repository()
        {

        }
        public DataTable GetGridData(string lang)
        {
            //var obj = this.obj.GetGridData(lang);
            //return obj;

            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetGridData(lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;

        }

        public string Insert_T12011(t12011 t12011, string user)
        {
            //var Data = obj.Insert_T12011(t12011, user);
            //return Data;

            var data = "";
            try
            {
                data = obj.Insert_T12011(t12011, user);
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