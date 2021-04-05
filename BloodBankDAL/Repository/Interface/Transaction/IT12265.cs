using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    public interface IT12265
    {
        DataTable GetRequestListData(string empCode);
        DataTable GetHandOverDataFromCenter(string empCode);
        DataTable GetLocationDeliveryMan(string bldReqNo);
        DataTable GetAllDeliveryManLocation(string bldReqNo);
        string updateT12091(string acpt, string reqId, string user);
        string updateT12091ForReceived(string reqNo, string user);
        string updateT91T92ForDrop(string reqNo, string user);
        string insertT91(string reqId,string reqNo, string devMan, string estDelDis, string estDelTime, string entryuser, string siteCode, string canReason);
        string updT65unassign(string reqId, string reqNo, string siteCode,string empCode);
        string UpdateActiveStatus(string entryuser);
    }
}
