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
    public class R12304Repository : IR12304
    {
        readonly R12302 _r12302 = new R12302();

        public R12304Repository(R12302 r12302)
        {
            _r12302 = r12302;
        }

        public DataTable GetSite(string siteCode)
        {
            //var data = _r12302.GetSite(siteCode);
            //return data;

            var data = new DataTable();

            try
            {
                data = _r12302.GetSite(siteCode);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                _r12302.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable getR12046_Report(string reqno, string site, string lang)
        {
            //var data = _r12302.getR12012_Report(reqno, site, lang);
            //return data;

            var data = new DataTable();

            try
            {
                data = _r12302.getR12012_Report(reqno, site, lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                _r12302.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

    }
}