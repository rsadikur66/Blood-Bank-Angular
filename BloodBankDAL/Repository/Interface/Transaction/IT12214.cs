using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    using System.Data;

    using BloodBankDAL.Model;

    public interface IT12214
    {
        DataTable GetTitle(string lang);

        DataTable GetAllNationality(string lang);

        DataTable GetAllReligion(string lang);

        DataTable GetAllGender(string lang);

        DataTable GetAllMrtlStatus(string lang);

        DataTable GetAllRelation(string lang);
        DataTable GetAllERRelation(string lang);

        DataTable GetArabicName(string englishName);

        DataTable GetEnglishName(string arabicName);

        string insert(T03001 t03001, string T_EMP_CODE);

        DataTable GetExistingPat(string pat, string nat, string fisName, string fathName, string graName, string famName,string gendr, string natnl, string regn, string mrists,string year);

        DataTable CheckNationalityCode(string T_NTNLTY_ID);

        String GetPatNo();

        string GetUserMsg(string T_MSG_CODE, string LANG);
    }
}
