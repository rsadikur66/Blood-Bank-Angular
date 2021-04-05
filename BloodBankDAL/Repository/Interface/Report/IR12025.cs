using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Report
{
   public interface IR12025
   {
       DataTable GetReport(string lang, string donTiFrom, string donTiTo, string siteCode, string bloodGrp, string product);
   }
}
