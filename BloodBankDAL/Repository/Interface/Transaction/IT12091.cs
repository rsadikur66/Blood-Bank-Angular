using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    public interface IT12091
    {
        DataTable GetDeliveryManData();
        DataTable GetReqDetails(string bldReq, string site,string lang);
        DataTable GetuserDetails(string lang, string user);
        string Save(string requestNo, string siteCode, string user, string time);
    }
}