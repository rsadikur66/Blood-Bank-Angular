using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Repository.Interface.Transaction;
using BloodBankDAL.Repository.Query.Transaction;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    public class T13054Repository:IT13054
    {
        private readonly T13054 obj = new T13054();
        public T13054Repository(T13054 _obj) : base()
        {
            obj = _obj;
        }
        public DataTable test()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.test();

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.test();
            //return obj;
        }

        public DataTable GetModelData(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetModelData(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetModelData(lang);
            //return obj;
        }
    }
}