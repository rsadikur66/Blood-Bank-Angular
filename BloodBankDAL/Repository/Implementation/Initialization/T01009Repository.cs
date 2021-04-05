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
    public class T01009Repository:IT01009
    {
        private readonly T01009 obj = new T01009();
        public T01009Repository(T01009 _obj) : base()
        {
            obj = _obj;
        }

        public DataTable GetAllUserData(string siteCode)
        {
            //var obj = this.obj.GetAllUserData(siteCode);
            //return obj;

            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetAllUserData(siteCode);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
        }
    }
}