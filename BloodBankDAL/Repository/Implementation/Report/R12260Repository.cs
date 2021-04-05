using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Repository.Interface.Report;
using BloodBankDAL.Repository.Query.Report;

namespace BloodBankDAL.Repository.Implementation.Report
{
    public class R12260Repository: IR12260
    {
        private readonly R12260 obj = new R12260();
        public DataTable GetInforData(string site, string lang)
        {
            var data = obj.GetInforData(site, lang);
            return data;
        }

     public   DataTable getDate(string site, string f, string t)
        {
            var data = obj.getDate(site, f, t);
            return data;
        }
        public DataTable GetDetails(string site, string fromDate, string toDate)
        {
            var data = obj.GetDetails( site,  fromDate,  toDate);
            return data;
        }

       public DataTable showReport(string site, string f, string t)
        {
            var data = obj.showReport(site, f,t);
            return data;
        }

     public DataTable getTimeData(string site, string f, string t)
        {
            var data = obj.getTimeData(site, f, t);
            return data;
        }
    }
}