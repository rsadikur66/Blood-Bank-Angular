using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Transaction
{
   public interface IT12201
    {
        DataTable CheckDonor(string P_PAT_NO, string P_NTNLTY_ID, string lang);
        DataTable GetReasonList(int age,string lang);
        DataTable GetSingleReason(int age, string reasonCode, string lang);
        DataTable GetPatientData(string lang, string searchValue);
        string insert(CommonModel t12017, string user);

        string GetArabicName(string patNo);
        DataTable ChekApheresis(string patNo, string epsot);
    }
}
