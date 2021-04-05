using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Transaction
{
    using BloodBankDAL.Model;

    public class T12232 : CommonDAL
    {
        public DataTable GetVirusList()
        {
            return Query($"SELECT T_VIRUS_CODE CODE, T_LANG2_NAME NAME FROM T12033");
        }

        public DataTable GetDonationDate(string unitNo)
        {
            return Query($"SELECT T_DONATION_DATE FROM T12022 WHERE T_UNIT_NO='{unitNo}'");
        }
        public DataTable ValidateUnitNo(string unitNo)
        {
            return Query($"SELECT t_close_flag from t12075 where t_unit_no='{unitNo}'  and t_virology_result='1'");
        }

        public DataTable GetAllData(string T_UNIT_NO, string T_LANG,string empCode)
        {
            return Query($"SELECT T12033.T_VIRUS_CODE,T12033.T_LANG2_NAME T_VIRUS_NAME,T12034.T_ENTRY_USER,T01009.T_USER_NAME{T_LANG} "
                         + $"T_USER_NAME, T12034.T_POS1_VERIFY,T12034.T_POS1_VERIFIED_BY,  (SELECT T_USER_NAME{T_LANG} FROM T01009 WHERE T_EMP_CODE = '{empCode}' )VERIFIED_NAME,  T12034.T_POS1_VERIFIED_DATE FROM T12033, T12034, T01009 WHERE T12034.T_UNIT_NO = '{T_UNIT_NO}' AND T12034.T_POS = '1' "
                         + $"AND T12033.T_VIRUS_CODE = T12034.T_VIRUS_CODE AND T12034.T_ENTRY_USER = T01009.T_EMP_CODE");
        }
        public DataTable CheckDoctorUser(string T_EMP_CODE, string T_LANG)
        {
            return Query($"SELECT t12031.T_EMP_CODE, t01009.T_USER_NAME{T_LANG} T_USER_NAME FROM t12031 JOIN t01009 ON t12031.t_emp_code = t01009.t_emp_code WHERE t12031.t_emp_code = '{T_EMP_CODE}'");
        }

        public bool updateT12034(string T_UNIT_NO, string T_POS1_VERIFIED_BY, string T_VIRUS_CODE)
        {
            return Command(
                 $"UPDATE T12034 SET T_POS1_VERIFY = '1',T_POS1_VERIFIED_BY = '{T_POS1_VERIFIED_BY}',"
                 + $" T_POS1_VERIFIED_DATE = TRUNC(SYSDATE) WHERE T_UNIT_NO = '{T_UNIT_NO}' AND T_VIRUS_CODE = '{T_VIRUS_CODE}'");
        }

        public bool updateT12019(string T_UNIT_NO, string T_VIROLOGY_BY)
        {
            return Command($"UPDATE T12019 SET T_CLOSE_FLAG = '1', T_VIOROLOGY_RESULT = '2', "
                           + $"T_VIROLOGY_BY = '{T_VIROLOGY_BY}',T_VIRO_TIME = TO_CHAR(SYSDATE, 'HH24MI'),"
                           + $"T_VIRO_DATE = TRUNC(SYSDATE) WHERE T_UNIT_NO = '{T_UNIT_NO}'");
        }

        public bool updateT12075(string T_UNIT_NO, string T_VIROLOGY_BY)
        {
            return Command($"UPDATE T12075 SET T_VIROLOGY_RESULT = '2', T_UNIT_DISCARD = '1',T_VIROLOGY_RESULT_BY = '{T_VIROLOGY_BY}',"
                           + $"T_VIROLOGY_RESULT_DATE = TRUNC(SYSDATE),T_DISCARD_REASON_CODE = '',"
                           + $"T_DISCARD_BY = '{T_VIROLOGY_BY}',T_DISCARD_DATE = TRUNC(SYSDATE),"
                           + $"T_DISCARD_TIME = TO_CHAR(SYSDATE, 'HHMI') WHERE T_UNIT_NO = '{T_UNIT_NO}'");
        }
        public DataTable CheckT12022(string T_UNIT_NO)
        {
            return Query($"SELECT DISTINCT T12019.T_UNIT_NO FROM T12022, T12019, T12075 WHERE T12022.T_UNIT_NO = '{T_UNIT_NO}' AND T12022.T_UNIT_NO = T12019.T_UNIT_NO AND T12075.T_UNIT_NO = T12019.T_UNIT_NO AND T12075.T_UNIT_NO = T12022.T_UNIT_NO");
        }
        public DataTable CheckT12075(string T_UNIT_NO)
        {
            return Query($"SELECT T_CLOSE_FLAG FROM T12075 WHERE T_UNIT_NO = '{T_UNIT_NO}' AND T_VIROLOGY_RESULT = '1'");
        }
        public DataTable CheckT12019(string T_UNIT_NO)
        {
            return Query($"SELECT * FROM T12019 WHERE T_UNIT_NO = '{T_UNIT_NO}'");
        }
        public DataTable CheckT12075_T_VIROLOGY_RESULT(string T_UNIT_NO)
        {
            return Query($"SELECT T_VIROLOGY_RESULT FROM T12075 WHERE T_UNIT_NO = '{T_UNIT_NO}' AND T_VIROLOGY_RESULT = '1'");
        }
        public DataTable CheckT12075_T_UNIT_DISCARD(string T_UNIT_NO)
        {
            return Query($"SELECT T_UNIT_DISCARD FROM T12075 WHERE T_UNIT_NO = '{T_UNIT_NO}' AND T_UNIT_DISCARD = '1' AND T_VIROLOGY_RESULT IS NULL");
        }
        public DataTable CheckT12034_T_POS1_VERIFY(string T_UNIT_NO,string T_VIRUS_CODE)
        {
            return Query($"SELECT T_POS1_VERIFY FROM T12034 WHERE T_UNIT_NO = '{T_UNIT_NO}' AND T_VIRUS_CODE = '{T_VIRUS_CODE}'");
        }

    }
}