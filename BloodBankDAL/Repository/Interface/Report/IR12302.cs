using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Report
{
    public interface IR12302
    {
        DataTable GetReport(string siteCode);
        DataTable GetPatInf();
        DataTable GetSite(string siteCode);

        DataTable getPatInfo(string patno);
        DataTable geHistoryData(string patno,string siteCode);
        DataTable getR12065_Report(string patno);
        DataTable getR12036A_Report(string patno);
        DataTable getR12012_Report(string reqno, string site, string lang);
    }
}
