using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface.Initialization;
using BloodBankDAL.Repository.Query.Initialization;
using BloodBankDAL.Repository.Query.Transaction;

namespace BloodBankDAL.Repository.Implementation.Initialization
{
    public class T12033Repository:IT12033
    {
        private readonly T12033 obj = new T12033();
        public T12033Repository(T12033 _obj) : base()
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

        public string Insert_T12033(t12033 t12033, string user)
        {
            //var Data = obj.Insert_T12033(t12033, user);
            //return Data;

            var data = "";

            try
            {
                data = obj.Insert_T12033(t12033, user);
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