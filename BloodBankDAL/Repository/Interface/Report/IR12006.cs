using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Report
{
    public interface IR12006
    {
        DataTable getReport(string l, string nationalId);
        DataTable GetR12006Site(string code);
        DataTable GetR12006PatProfile(string lang,string patNo);
        DataTable GetR12006Agreement(string l,string patNo);
        DataTable GetR12006Confirmation(string lang);
        DataTable GetR12215Summery(string entryDate, int siteCode, string donationDate);
        DataTable GetR12215SiteCode(int siteCode, string lang);
        DataTable GetR12215CollectedUnit(int siteCode, string donationDate);
        DataTable GetTechList(string site);
        DataTable GetReasonList(string lang);
        DataTable getCollector(string lang, string fdate);
        DataTable getCollection(string lang, string fdate);
        DataTable getCountTime(string lang, string fdate);
    }
}
