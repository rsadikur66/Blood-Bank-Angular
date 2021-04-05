using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    using BloodBankDAL.Model;

    public interface IT12232
    {
        DataTable GetVirusList();
        DataTable GetDonationDate(string unitNo);
        DataTable ValidateUnitNo(string unitNo);
        DataTable GetAllData (string T_UNIT_NO, string T_LANG,string empCode);
        DataTable CheckDoctorUser(string T_EMP_CODE, string T_LANG);
        string UpdateT12034(List<M12034> M12034, string T_POS1_VERIFIED_BY);

        DataTable CheckT12022(string T_UNIT_NO);

        DataTable CheckT12075(string T_UNIT_NO);
        DataTable CheckT12019(string T_UNIT_NO);
        DataTable CheckT12075_T_VIROLOGY_RESULT(string T_UNIT_NO);
        DataTable CheckT12075_T_UNIT_DISCARD(string T_UNIT_NO);
        DataTable CheckT12034_T_POS1_VERIFY(string T_UNIT_NO, string T_VIRUS_CODE);
    } 
}
