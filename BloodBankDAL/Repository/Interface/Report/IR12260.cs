using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Report
{
   public interface IR12260
    {
        DataTable GetInforData(string site, string lang);
        DataTable GetDetails(string site, string fromDate, string toDate);
        DataTable getDate(string site, string f, string t);
        DataTable showReport(string site, string f, string t);
        DataTable getTimeData(string site, string f, string t);
    }
}
