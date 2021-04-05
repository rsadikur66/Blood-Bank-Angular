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
    public class R12025Repository: IR12025
    {
        private readonly R12025 obj = new R12025();
        public R12025Repository(R12025 _obj) : base()
        {
            obj = _obj;
        }
        public  DataTable GetReport(string lang, string donTiFrom, string donTiTo, string siteCode, string bloodGrp, string product)
        {
            //var Data = obj.GetReport(lang, donTiFrom,donTiTo,siteCode,bloodGrp,product);
            //return Data;

            var data = new DataTable();

            try
            {
                data = obj.GetReport(lang, donTiFrom, donTiTo, siteCode, bloodGrp, product);
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