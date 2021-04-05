using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Query
{
    public interface IQ12025
    {
        DataTable GetSiteData(string lang);
        DataTable GetBloodGroupData(string lang);
        DataTable GetProductData(string lang);
        DataTable GetStocktData(string lang, string donTiFrom, string donTiTo, string siteCode, string bloodGrp, string product);
    }
}
