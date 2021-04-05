using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Initialization
{
    public interface IT12337
    {
        DataTable GetZoneList(string lang);
        DataTable GetBankTypeList(string lang);
        DataTable GetSiteList(string lang);
        DataTable GetGridListData();
        

        string InsertToT12337(M12337 t12337, string user,string siteCode);
        //string UpdateToT12337(M12337 t12337, string user,string siteCode);
    }
}
