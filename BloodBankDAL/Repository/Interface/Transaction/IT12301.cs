using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    using System.Data;

    using BloodBankDAL.Model;

    public interface IT12301
    {
        DataTable GetPatInfo(string T_REQUEST_NO, string T_LANG, string T_SITE_CODE);

        DataTable GetRequestNoPopUp(string T_SITE_CODE);

        string updateT12012(string T_REQUEST_NO, string T_BLOOD_BRING, string T_LAB_NO, string T_REQ_REC_DATE, string T_REQ_REC_TIME, string T_UPD_USER,string T_SITE_CODE);

        DataTable GetUserList(string T_SITE_CODE,string T_EMP_CODE=null);

        DataTable GetUserListByCode(string T_SITE_CODE, string T_EMP_CODE);

        DataTable GetCurrentUser(string T_EMP_CODE);
    }
}
