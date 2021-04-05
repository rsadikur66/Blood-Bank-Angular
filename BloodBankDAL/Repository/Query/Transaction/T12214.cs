using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Transaction
{
    using System.Data;

    public class T12214 : CommonDAL
    {
        public CommonDAL _commonDal = new CommonDAL();
        public DataTable GetTitle(string language)
        {
            DataTable dt = Query($"SELECT T_TITLE_CODE,T_LANG{language}_NAME T_TITLE_NAME FROM T02061 ORDER BY T_TITLE_CODE");
            return WithBlankRow(dt);
        }

        public DataTable GetRelation(string language)
        {
            DataTable dt = Query($"SELECT T_RLTN_CODE,T_LANG{language}_NAME AS T_RLTN_NAME FROM t02004 ORDER BY 1");
            return WithBlankRow(dt);
        }
        public DataTable GetERRelation(string language)
        {
            DataTable dt = Query($"SELECT T_RLTN_CODE AS T_ER_RLTN_CODE,T_LANG{language}_NAME AS T_ERRLTN_NAME FROM t02004 ORDER BY 1");
            return WithBlankRow(dt);
        }

        public DataTable GetAllNationality(string language)
        {
            DataTable dt = _commonDal.GetAllNationality(language);
            return WithBlankRow(dt);
        }

        public DataTable GetAllReligion(string language)
        {
            DataTable dt = _commonDal.GetAllReligion(language);
            return WithBlankRow(dt);
        }
        public DataTable GetAllGender(string language)
        {
            DataTable dt = _commonDal.GetAllGender(language);
            return WithBlankRow(dt);
        }
        public DataTable GetAllMrtlStatus(string language)
        {
            DataTable dt = _commonDal.GetAllMrtlStatus(language);
            return WithBlankRow(dt);
        }

        public DataTable GetArabicName(string englishName)
        {
            return Query($"SELECT T_NAME_ARB FROM T02009 WHERE T_NAME = '{englishName}'");
        }
        public DataTable GetEnglishName(string arabicName)
        {
            return Query($"SELECT T_NAME FROM T02009 WHERE T_NAME_ARB = '{arabicName}'");
        }
        public bool insert03001(string T_ENTRY_USER, string maxId, string T_BIRTH_DATE, string T_PAT_NO, string T_FAMILY_LANG1_NAME,
            string T_FAMILY_LANG2_NAME, string T_FATHER_LANG1_NAME, string T_FATHER_LANG2_NAME, string T_GFATHER_LANG1_NAME,
            string T_GFATHER_LANG2_NAME, string T_FIRST_LANG1_NAME, string T_FIRST_LANG2_NAME,
            string T_MOTHER_LANG1_NAME, string T_MOTHER_LANG2_NAME, string T_NTNLTY_CODE, string T_NTNLTY_ID, string T_ADDRESS1
            , string T_ADDRESS2, string T_RLGN_CODE, string T_RLTN_CODE, string T_GENDER, string T_MOBILE_NO, string T_POSTAL_CODE,
            string T_POBOX_NO, string T_EMAIL_ID, string T_ER_RLTN_CODE, string T_ER_MOBILE, string T_PAT_TITLE, string T_MRTL_STATUS)
        {
            return Command($"INSERT INTO T03001 (T_ENTRY_DATE,ID,T_ENTRY_USER, T_BIRTH_DATE, T_PAT_NO, T_FAMILY_LANG1_NAME, T_FAMILY_LANG2_NAME, T_FATHER_LANG1_NAME, T_FATHER_LANG2_NAME, T_GFATHER_LANG1_NAME, T_GFATHER_LANG2_NAME, T_FIRST_LANG1_NAME, T_FIRST_LANG2_NAME, T_MOTHER_LANG1_NAME, T_MOTHER_LANG2_NAME, T_NTNLTY_CODE, T_NTNLTY_ID, T_ADDRESS1, T_ADDRESS2, T_RLGN_CODE, T_RLTN_CODE, T_GENDER, T_MOBILE_NO, T_POSTAL_CODE, T_POBOX_NO, T_EMAIL_ID, T_ER_RLTN_CODE, T_PAT_TITLE, T_ER_MOBILE,T_MRTL_STATUS)"
                           + $" VALUES (TRUNC(SYSDATE),{maxId},'{T_ENTRY_USER}', '{T_BIRTH_DATE}', '{T_PAT_NO}', '{T_FAMILY_LANG1_NAME}', UPPER('{T_FAMILY_LANG2_NAME}'), '{T_FATHER_LANG1_NAME}', UPPER('{T_FATHER_LANG2_NAME}'), '{T_GFATHER_LANG1_NAME}', UPPER('{T_GFATHER_LANG2_NAME}'), '{T_FIRST_LANG1_NAME}', UPPER('{T_FIRST_LANG2_NAME}'), '{T_MOTHER_LANG1_NAME}', UPPER('{T_MOTHER_LANG2_NAME}'), '{T_NTNLTY_CODE}', '{T_NTNLTY_ID}', '{T_ADDRESS1 }', '{T_ADDRESS2 }', '{T_RLGN_CODE}', '{T_RLTN_CODE}', '{T_GENDER}', '{T_MOBILE_NO}', '{T_POSTAL_CODE}', '{T_POBOX_NO}', '{T_EMAIL_ID}', '{T_ER_RLTN_CODE}', '{T_PAT_TITLE}', '{T_ER_MOBILE}','{T_MRTL_STATUS}')");
        }
        public bool update03001(string T_UPD_USER, string T_BIRTH_DATE, string T_PAT_NO, string T_FAMILY_LANG1_NAME,
            string T_FAMILY_LANG2_NAME, string T_FATHER_LANG1_NAME, string T_FATHER_LANG2_NAME, string T_GFATHER_LANG1_NAME,
            string T_GFATHER_LANG2_NAME, string T_FIRST_LANG1_NAME, string T_FIRST_LANG2_NAME,
            string T_MOTHER_LANG1_NAME, string T_MOTHER_LANG2_NAME, string T_NTNLTY_CODE, string T_NTNLTY_ID, string T_ADDRESS1
            , string T_ADDRESS2, string T_RLGN_CODE, string T_RLTN_CODE, string T_GENDER, string T_MOBILE_NO, string T_POSTAL_CODE,
            string T_POBOX_NO, string T_EMAIL_ID, string T_ER_RLTN_CODE, string T_ER_MOBILE, string T_PAT_TITLE, string T_MRTL_STATUS)
        {
            return Command($"UPDATE T03001 SET T_UPD_USER = '{T_UPD_USER}', T_UPD_DATE = TRUNC(SYSDATE), T_BIRTH_DATE = '{T_BIRTH_DATE}', "
                           + $"T_FAMILY_LANG1_NAME = '{T_FAMILY_LANG1_NAME}', T_FAMILY_LANG2_NAME = UPPER('{T_FAMILY_LANG2_NAME}'),"
                           + $" T_FATHER_LANG1_NAME = '{T_FATHER_LANG1_NAME}', T_FATHER_LANG2_NAME = UPPER('{T_FATHER_LANG2_NAME}'),"
                           + $" T_GFATHER_LANG1_NAME = '{T_GFATHER_LANG1_NAME}', T_GFATHER_LANG2_NAME = UPPER('{T_GFATHER_LANG2_NAME}'),"
                           + $" T_FIRST_LANG1_NAME = '{T_FIRST_LANG1_NAME}', T_FIRST_LANG2_NAME = UPPER('{T_FIRST_LANG2_NAME}'), "
                           + $"T_MOTHER_LANG1_NAME = '{T_MOTHER_LANG1_NAME}', T_MOTHER_LANG2_NAME = UPPER('{T_MOTHER_LANG2_NAME}'),"
                           + $" T_NTNLTY_ID = '{T_NTNLTY_ID}', T_ADDRESS1 = '{T_ADDRESS1}',"
                           + $" T_ADDRESS2 = '{T_ADDRESS2}', T_RLGN_CODE = '{T_RLGN_CODE}', T_RLTN_CODE = '{T_RLTN_CODE}',"
                           + $" T_GENDER = '{T_GENDER}', T_MOBILE_NO = '{T_MOBILE_NO}', T_POSTAL_CODE = '{T_POSTAL_CODE}',"
                           + $" T_POBOX_NO = '{T_POBOX_NO}', T_EMAIL_ID = '{T_EMAIL_ID}', T_ER_RLTN_CODE = '{T_ER_RLTN_CODE}',"
                           + $" T_PAT_TITLE = '{T_PAT_TITLE}', T_ER_MOBILE = '{T_ER_MOBILE}',T_MRTL_STATUS='{T_MRTL_STATUS}',"
                           + $"T_NTNLTY_CODE ='{T_NTNLTY_CODE}' WHERE T_PAT_NO = '{T_PAT_NO}' AND T_NTNLTY_ID = '{T_NTNLTY_ID}'");
        }

        public DataTable GetMaxPatNo()
        {
            return Query("SELECT MAX(TO_NUMBER(regexp_replace(T_PAT_NO, '[^0-9]', '')))+1 T_MAX_PAT_NO FROM T03001");
        }
        public String GetPatNo()
        {
            return Query("SELECT MAX(TO_NUMBER(regexp_replace(T_PAT_NO, '[^0-9]', ''))) T_MAX_PAT_NO FROM T03001").Rows[0]["T_MAX_PAT_NO"].ToString();
        }

        public String GetMaxId()
        {
            return Query("SELECT MAX(ID+1) T_MAX_ID FROM T03001").Rows[0]["T_MAX_ID"].ToString();
        }


        public DataTable GetExistingPat(string pat, string nat, string fisName, string fathName, string graName, string famName, string gendr, string natnl, string regn, string mrists,string year, string LANG)
        {
            //return Query($"SELECT T03001.*, T02061.T_LANG{LANG}_NAME T_PAT_TITLE_NAME, T02006.T_LANG{LANG}_NAME T_GENDER_NAME, "
            //             + $"T02007.T_LANG{LANG}_NAME T_MRTL_STATUS_NAME, T02003.T_LANG{LANG}_NAME T_NTNLTY_NAME, T02005.T_LANG{LANG}_NAME T_RLGN_NAME, "
            //             + $"(SELECT T_LANG{LANG}_NAME FROM T02004 WHERE T02004.T_RLTN_CODE = T03001.T_RLTN_CODE) T_RLTN_NAME, "
            //             + $"(SELECT T_LANG{LANG}_NAME FROM T02004 WHERE T02004.T_RLTN_CODE = T03001.T_ER_RLTN_CODE) T_ERRLTN_NAME,"
            //             + $"(SELECT T_USER_NAME FROM T01009 WHERE T01009.T_EMP_CODE = T03001.T_ENTRY_USER) T_ENTRY_USER_NAME,"
            //             + $"(SELECT T_USER_NAME FROM T01009 WHERE T01009.T_EMP_CODE = T03001.T_UPD_USER) T_UPDATE_USER_NAME,"
            //             + $"TRUNC(MONTHS_BETWEEN(SYSDATE,T03001.T_BIRTH_DATE) / 12, 0) YRS, "
            //             + $"TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T03001.T_BIRTH_DATE), 12), 0) MOS "
            //             + $"FROM T03001, T02003, T02004, T02005, T02006, T02007, T02061 WHERE (T_PAT_NO = NVL('{pat}', T_PAT_NO)AND T_NTNLTY_ID= NVL('{nat}', T_NTNLTY_ID)AND T_FIRST_LANG2_NAME= NVL('{fisName}', T_FIRST_LANG2_NAME)AND T_FATHER_LANG2_NAME= NVL('{fathName}', T_FATHER_LANG2_NAME)AND T_GFATHER_LANG2_NAME= NVL('{graName}', T_GFATHER_LANG2_NAME)AND T_FAMILY_LANG2_NAME= NVL('{famName}', T_FAMILY_LANG2_NAME)AND T_GENDER = NVL('{gendr}', T_GENDER) AND T03001.T_NTNLTY_CODE = NVL('{natnl}', T03001.T_NTNLTY_CODE) AND T03001.T_RLGN_CODE = NVL('{regn}', T03001.T_RLGN_CODE) AND T_MRTL_STATUS = NVL('{mrists}', T_MRTL_STATUS)AND TRUNC(MONTHS_BETWEEN(SYSDATE,T03001.T_BIRTH_DATE) / 12, 0)   = NVL('{year}', TRUNC(MONTHS_BETWEEN(SYSDATE,T03001.T_BIRTH_DATE) / 12, 0)) )"
            //             + $" AND T03001.T_GENDER = T02006.T_SEX_CODE (+) AND T03001.T_MRTL_STATUS = T02007.T_MRTL_STATUS_CODE (+) "
            //             + $"AND T03001.T_NTNLTY_CODE = T02003.T_NTNLTY_CODE (+) AND T03001.T_RLGN_CODE = T02005.T_RLGN_CODE (+) "
            //             + $"AND T03001.T_RLTN_CODE = T02004.T_RLTN_CODE (+) AND T03001.T_PAT_TITLE = T02061.T_TITLE_CODE (+)"
            //             + $"AND T03001.T_ER_RLTN_CODE = T02004.T_RLTN_CODE (+) AND ROWNUM <= 500 order by ROWNUM ASC");
            return Query($"SELECT T03001.*, T02061.T_LANG2_NAME T_PAT_TITLE_NAME, T02006.T_LANG2_NAME T_GENDER_NAME, T02007.T_LANG2_NAME T_MRTL_STATUS_NAME, T02003.T_LANG2_NAME T_NTNLTY_NAME, T02005.T_LANG2_NAME T_RLGN_NAME, (SELECT T_LANG2_NAME FROM T02004 WHERE T02004.T_RLTN_CODE = T03001.T_RLTN_CODE ) T_RLTN_NAME, (SELECT T_LANG2_NAME FROM T02004 WHERE T02004.T_RLTN_CODE = T03001.T_ER_RLTN_CODE ) T_ERRLTN_NAME, (SELECT T_USER_NAME FROM T01009 WHERE T01009.T_EMP_CODE = T03001.T_ENTRY_USER ) T_ENTRY_USER_NAME, (SELECT T_USER_NAME FROM T01009 WHERE T01009.T_EMP_CODE = T03001.T_UPD_USER ) T_UPDATE_USER_NAME, TRUNC(MONTHS_BETWEEN(SYSDATE,T03001.T_BIRTH_DATE) / 12, 0) YRS, TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T03001.T_BIRTH_DATE), 12), 0) MOS FROM T03001, T02003, T02004, T02005, T02006, T02007, T02061 WHERE (T_PAT_NO = NVL('{pat}', T_PAT_NO) AND T_NTNLTY_ID = NVL('{nat}', T_NTNLTY_ID) AND NVL(T_FIRST_LANG2_NAME,0) =NVL(NVL('{fisName}', T_FIRST_LANG2_NAME),0) AND NVL(T_FATHER_LANG2_NAME,0) = NVL(NVL('{fathName}', T_FATHER_LANG2_NAME),0) AND NVL(T_GFATHER_LANG2_NAME,0) = NVL(NVL('{graName}', T_GFATHER_LANG2_NAME),0) AND NVL(T_FAMILY_LANG2_NAME,0) = NVL(NVL('{famName}', T_FAMILY_LANG2_NAME),0) AND NVL(T_GENDER,0) =NVL(NVL('{gendr}', T_GENDER),0) AND NVL(T03001.T_NTNLTY_CODE,0) = NVL(NVL('{natnl}', T03001.T_NTNLTY_CODE),0) AND NVL(T03001.T_RLGN_CODE,0) = NVL(NVL('{regn}', T03001.T_RLGN_CODE),0) AND NVL(T_MRTL_STATUS,0) = NVL(NVL('{mrists}', T_MRTL_STATUS),0) AND TRUNC(MONTHS_BETWEEN(SYSDATE,T03001.T_BIRTH_DATE) / 12, 0) = NVL('{year}', TRUNC(MONTHS_BETWEEN(SYSDATE,T03001.T_BIRTH_DATE) / 12, 0)) ) AND T03001.T_GENDER = T02006.T_SEX_CODE (+) AND T03001.T_MRTL_STATUS = T02007.T_MRTL_STATUS_CODE (+) AND T03001.T_NTNLTY_CODE = T02003.T_NTNLTY_CODE (+) AND T03001.T_RLGN_CODE = T02005.T_RLGN_CODE (+) AND T03001.T_RLTN_CODE = T02004.T_RLTN_CODE (+) AND T03001.T_PAT_TITLE = T02061.T_TITLE_CODE (+) AND T03001.T_ER_RLTN_CODE = T02004.T_RLTN_CODE (+) AND ROWNUM <= 500 ORDER BY ROWNUM ASC");
        }

        public DataTable CheckExtistingPatient(string T_PAT_NO)
        {
            return Query($"SELECT T_PAT_NO,T_NTNLTY_ID FROM T03001 WHERE T_PAT_NO = '{T_PAT_NO}'");
        }

        public DataTable CheckNationalityCode(string T_NTNLTY_ID)
        {
            return Query($"SELECT T_NTNLTY_ID FROM T03001 WHERE T_NTNLTY_ID = '{T_NTNLTY_ID}'");
        }

        public string GetUserMsg(string T_MSG_CODE, string LANG)
        {
            return _commonDal.GetUserMsg(T_MSG_CODE, "LANG" + LANG);
        }
    }
}