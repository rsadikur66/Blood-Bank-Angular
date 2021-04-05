using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    public interface IT12262
    {
        DataTable GetDataBySiteCode(string siteCode, string lang);
        DataTable GetDataRequestNo(string siteCode, string refCode, string lang);
        DataTable GetRequestDetails(string requestNo, string siteCode, string lang);
        DataTable GetRequestDetails(string siteCode, string lang);
        DataTable GetuserDetails(string lang, string user);
        string Save(string requestNo, string siteCode,string user,string time);
    }
}