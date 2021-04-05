using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Transaction
{
  public interface IT12300
    {
        DataTable GetPatDetailsData(string lang, string patNo);
        DataTable GetDoctor(string lang);
        DataTable GetABO(string lang);
        DataTable Getsergeon(string lang);
        DataTable GetProductData(string lang);
        DataTable GethospitalData(string lang);
        DataTable GetCheckData(string lang);
        DataTable GetWardData(string lang, string siteCode);
        DataTable GetNurseData(string lang, string siteCode);
        string SaveData(M12300 t12300,string lang,string user,string sitCode);
        DataTable GeAllData(string patNo, string lang);
        DataTable GetVirusData(string lang);
    }
}
