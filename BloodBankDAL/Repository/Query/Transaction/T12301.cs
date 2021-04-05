using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Transaction
{
    using System.Data;

    public class T12301 : CommonDAL
    {
        public DataTable GetPatInfo(string T_REQUEST_NO, string T_LANG, string T_SITE_CODE)
        {
            return Query(
                $"SELECT T12012.T_REQUEST_NO,T12012.T_REQUEST_DATE,T12012.T_REQUEST_TIME,T12012.T_PAT_NO,T12012.T_REQ_STATUS,"
                + $"T03001.T_FIRST_LANG{T_LANG}_NAME || ' ' || T03001.T_FATHER_LANG{T_LANG}_NAME || ' ' || "
                + $"T03001.T_GFATHER_LANG{T_LANG}_NAME || ' ' || T03001.T_MOTHER_LANG{T_LANG}_NAME || ' ' || "
                + $"T03001.T_FAMILY_LANG{T_LANG}_NAME T_PAT_NAME,T02003.T_LANG{T_LANG}_NAME T_NATIONALITY,"
                + $"T02006.T_LANG{T_LANG}_NAME T_GENDER,T02007.T_LANG{T_LANG}_NAME T_MARITIAL_STATUS,T12012.T_LOCATION_CODE,"
                + $"T02042.T_LANG{T_LANG}_NAME T_LOCATION_NAME,"
                + $"TRUNC(MONTHS_BETWEEN(SYSDATE, T03001.T_BIRTH_DATE) / 12, 0) YRS,"
                + $"TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T03001.T_BIRTH_DATE), 12), 0) MOS "
                + $"FROM T12012, T03001, T02003, T02006, T02007, T02042"
                + $" WHERE T_REQUEST_NO = '{T_REQUEST_NO}' AND T03001.T_PAT_NO = T12012.T_PAT_NO AND "
                + $"T03001.T_NTNLTY_CODE = T02003.T_NTNLTY_CODE AND T02006.T_SEX_CODE = T03001.T_GENDER "
                + $"AND T02007.T_MRTL_STATUS_CODE = T03001.T_MRTL_STATUS"
                + $" AND T02042.T_LOC_CODE = T12012.T_LOCATION_CODE "
                + $"AND T12012.T_SITE_CODE = '{T_SITE_CODE}'");
        }


        //public DataTable GetPatInfo(string T_REQUEST_NO, string T_LANG, string T_SITE_CODE)
        //{
        //    return Query(
        //        $"SELECT T12012.T_REQUEST_NO,T12012.T_REQUEST_DATE,T12012.T_REQUEST_TIME,T12012.T_PAT_NO,T12012.T_REQ_STATUS,"
        //        + $"T03001.T_FIRST_LANG{T_LANG}_NAME || ' ' || T03001.T_FATHER_LANG{T_LANG}_NAME || ' ' || "
        //        + $"T03001.T_GFATHER_LANG{T_LANG}_NAME || ' ' || T03001.T_MOTHER_LANG{T_LANG}_NAME || ' ' || "
        //        + $"T03001.T_FAMILY_LANG{T_LANG}_NAME T_PAT_NAME,T02003.T_LANG{T_LANG}_NAME T_NATIONALITY,"
        //        + $"T02006.T_LANG{T_LANG}_NAME T_GENDER,T02007.T_LANG{T_LANG}_NAME T_MARITIAL_STATUS,T12012.T_LOCATION_CODE,"
        //        + $"T02042.T_LANG{T_LANG}_NAME T_LOCATION_NAME,"
        //        + $"TRUNC(MONTHS_BETWEEN(SYSDATE, T03001.T_BIRTH_DATE) / 12, 0) YRS,"
        //        + $"TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T03001.T_BIRTH_DATE), 12), 0) MOS "
        //        + $"FROM T12012, T03001, T02003, T02006, T02007, T02042"
        //        + $" WHERE T_REQUEST_NO = '{T_REQUEST_NO}' AND T03001.T_PAT_NO = T12012.T_PAT_NO AND "
        //        + $"T03001.T_NTNLTY_CODE = T02003.T_NTNLTY_CODE AND T02006.T_SEX_CODE = T03001.T_GENDER "
        //        + $"AND T02007.T_MRTL_STATUS_CODE = T03001.T_MRTL_STATUS"
        //        + $" AND T02042.T_LOC_CODE = T12012.T_LOCATION_CODE "
        //        + $"AND T12012.T_SITE_CODE = '{T_SITE_CODE}'"
        //        + $"AND T12012.T_REQ_REC_DATE IS NULL AND T12012.T_REQ_REC_TIME IS NULL");
        //}

        public DataTable GetRequestNoPopUp(string T_SITE_CODE)
        {
            return Query($"SELECT T12012.T_REQUEST_NO, T12012.T_PAT_NO, to_char(to_date(T12012.T_REQUEST_DATE, 'DD-MON-YY'), 'DD/MM/YYYY') T_REQUEST_DATE, T12012.T_ABO_CODE FROM T12012 WHERE T_SITE_CODE = '{T_SITE_CODE}' AND T_REQ_STATUS IS NULL AND T_REQ_REC_DATE IS NULL AND T_REQ_REC_TIME IS NULL ORDER BY T12012.T_REQUEST_NO");
        }
        public DataTable GetUserList(string T_SITE_CODE,string P_EMP_CODE)
        {
            return Query($"SELECT T_USER_NAME,T_EMP_CODE FROM T01009 WHERE T_SITE_CODE = '{T_SITE_CODE}' AND T_ROLE_CODE = '0012' AND T_ACTIVE_FLAG = '1' AND ('{P_EMP_CODE}' IS NULL OR T_EMP_CODE='{P_EMP_CODE}') ORDER BY 1");
        }

        public DataTable GetUserListByCode(string T_SITE_CODE,string T_EMP_CODE)
        {
            return Query($"SELECT T_USER_NAME,T_EMP_CODE FROM T01009 WHERE T_SITE_CODE = '{T_SITE_CODE}' AND T_EMP_CODE = '{T_EMP_CODE}' AND T_ROLE_CODE = '0012' AND T_ACTIVE_FLAG = '1' ORDER BY 1");
        }

        public DataTable GetCurrentUser(string T_EMP_CODE)
        {
            return Query($"SELECT T_USER_NAME,  T_EMP_CODE FROM T01009 WHERE T_EMP_CODE = '{T_EMP_CODE}'");
        }

        public bool updateT12012(string T_REQUEST_NO, string T_BLOOD_BRING, string T_LAB_NO,string T_REQ_REC_DATE, string T_REQ_REC_TIME, string T_UPD_USER,string T_SITE_CODE)
        {
            return Command($"UPDATE T12012 SET T_REQ_STATUS = '1',T_REQ_REC_DATE = '{T_REQ_REC_DATE}',"
                           + $"T_BLOOD_BRING = '{T_BLOOD_BRING}',T_LAB_NO = '{T_LAB_NO}',"
                           + $"T_REQ_RECEIVER = '{T_UPD_USER}',T_REQ_REC_TIME = '{T_REQ_REC_TIME}',"
                           + $"T_UPD_DATE = TRUNC(SYSDATE),T_UPD_USER = '{T_UPD_USER}'"
                           + $" WHERE T_REQUEST_NO = '{T_REQUEST_NO}' AND T_SITE_CODE = '{T_SITE_CODE}'");
        }
    }
}