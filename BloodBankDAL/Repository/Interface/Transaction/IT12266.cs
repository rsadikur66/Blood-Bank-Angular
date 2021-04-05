using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    public interface IT12266
    {
        DataTable GetDeliveryManData(string site);
        DataTable GetReqDetails(string bldReq, string site, string lang);
        DataTable GetuserDetails(string lang, string user);
        string Save(string delCode, string requestNo, string siteCode, string user, string time);
    }
}