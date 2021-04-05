using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Repository.Interface.Report;
using BloodBankDAL.Repository.Query.Report;

namespace BloodBankDAL.Repository.Implementation.Report
{
    public class R12204Repository : RI12204
    {
        private readonly R12204 obj = new R12204();
        public R12204Repository(R12204 _obj) : base()
        {
            obj = _obj;
        }

        public DataTable GetReport(string pat, string ept)
        {
            //var Data = obj.GetReport(pat,ept);
            //return Data;

            var data = new DataTable();

            try
            {
                data = obj.GetReport(pat, ept);
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