using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Transaction
{
    using System.Data;

    public class T12236 : CommonDAL
    {
        public CommonDAL _commonDal = new CommonDAL();

        public DataTable GetUnitNo(string T_UNIT_FROM, string T_UNIT_TO, string LANG)
        {
            return Query($"SELECT DISTINCT T12019.T_UNIT_NO,T12004.T_ABO_CODE,T12004.T_LANG{LANG}_NAME AS T_ABO_NAME FROM T12019, "
                         + $"T12004 WHERE T_UNIT_NO BETWEEN '{T_UNIT_FROM}' AND '{T_UNIT_TO}' AND "
                         + $"(T12019.T_ABO_CODE IS NOT NULL OR T12019.T_BLOOD_BAG_GROUP IS NOT NULL)"
                         + $" AND T12019.T_ABO_CODE = T12004.T_ABO_CODE "
                         + $"AND T_VERIFY = '1' AND T_SEG_ABO IS NULL ORDER BY T12019.T_UNIT_NO");
        }
        public DataTable GetBloodGroupList(string LANG)
        {
            return Query($"SELECT T_ABO_CODE,T_LANG{LANG}_NAME AS T_ABO_NAME FROM T12004 ORDER BY T_LANG{LANG}_NAME");
        }
        public DataTable CheckABOCode(string T_ABO_CODE,string T_UNIT_NO)
        {
            return Query($"SELECT DISTINCT T_UNIT_NO,T_ABO_CODE FROM T12019 WHERE T_ABO_CODE = '{T_ABO_CODE}' AND T_UNIT_NO = '{T_UNIT_NO}'");
        }
        public bool updateT12019(string T_ABO_CODE, string T_UNIT_NO)
        {
            return Command($"UPDATE T12019 SET T_SEG_ABO = '{T_ABO_CODE}' WHERE T_UNIT_NO = '{T_UNIT_NO}'");
        }
        public bool updateT12075(string T_UNIT_NO, string T_CONFIRM_VERIFY_BY)
        {
            return Command($"UPDATE T12075 SET T_CONFIRM_VERIFY = '1',T_CONFIRM_VERIFY_BY = '{T_CONFIRM_VERIFY_BY}',"
                           + $"T_CONFIRM_VERIFY_DATE = TRUNC(SYSDATE),T_BLOOD_GROUP_MATCH_YN = '1'"
                           + $" WHERE T_UNIT_NO = {T_UNIT_NO}");
        }

    }
}