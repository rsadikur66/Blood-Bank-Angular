using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    public interface IT12349
    {
        DataTable getBagType(string lang);
        DataTable getUnitList(string T_SITE_CODE, string T_UNIT_NO, string DATEFROM, string DATETO);
        DataTable validateWeight(string T_UNIT_WEIGHT, string T_BAG_TYPE);
        string insert(List<CommonModel> modelList, string lang, string user);

    }
}