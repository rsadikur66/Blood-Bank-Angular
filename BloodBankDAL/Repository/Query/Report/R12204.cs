using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Report
{
    public class R12204 :CommonDAL
    {
        public DataTable GetReport(string pat, string ept)
        {
            return Query($"SELECT T_DONATION_DATE,  T12022.T_PAT_NO,  T_FIRST_LANG2_NAME  ||' '  ||T_FATHER_LANG2_NAME  ||' '  || T_GFATHER_LANG2_NAME  ||' '  ||T_FAMILY_LANG2_NAME Pat_Name, t01.T_GENDER, t06.T_LANG2_NAME GENDER, t01.T_NTNLTY_ID, t01.T_NTNLTY_CODE,   t03.T_LANG2_NAME NATIONALITY,  T12022.T_UNIT_NO,  T12022.T_SEGMENT_NO,  '='||t12022.t_unit_no||T_UNIT_CHAR||T_UNIT_DIG T_BAG_BARCODE, T_DONATION_TIME  FROM T12022 INNER JOIN T03001 t01 ON T12022.T_PAT_NO = t01.T_PAT_NO LEFT JOIN T02003 t03 ON t01.T_NTNLTY_CODE = t03.T_NTNLTY_CODE LEFT JOIN T02006 t06 ON t01.T_GENDER = t06.T_SEX_CODE WHERE T12022.T_PAT_NO   = '{pat}' AND T_EPISODE_NO = '{ept}'");
        }
    }
}