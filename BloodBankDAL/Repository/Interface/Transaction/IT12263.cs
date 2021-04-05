using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    public interface IT12263
    {
        DataTable GetSiteList(string siteCode, string refCode, string lang);
        DataTable GetRequestedData(string siteCode, string requestNo);
        DataTable GetRequestList(string siteCode, string refCode);
        DataTable GetGridData(string bldGrp, string proCode, string empCode, string userName);
        DataTable CrossmatchCheck(string reqNo, string bldGrp, string proCode);
        string T12263insert(List<M12263> t12263, string user, string siteCode);
        DataTable GetCourierServiceData(string siteCode, string lang);
        DataTable GetdeliveryByData(string siteCode, string lang);
        DataTable GetDeliveryManLocation(string siteCode, string lang);
    }
}
