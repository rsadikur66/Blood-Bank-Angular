using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Report
{
    public interface IR12304
    {
        DataTable getR12046_Report(string reqno, string site, string lang);
        DataTable GetSite(string siteCode);

    }
}
