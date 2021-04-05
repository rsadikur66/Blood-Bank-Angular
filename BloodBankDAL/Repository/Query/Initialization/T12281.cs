using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Initialization
{
    public class T12281:CommonDAL
    {
        public DataTable GetAllData(object lang)
        {
            return Query($"select T12081.T_ACTION,T12081.T_LANG{lang}_NAME T_WEIGHT_NAME,T12081.T_WEIGHT_CODE,T12081.T_WEIGHT_FR,T12081.T_WEIGHT_TO,T12081.T_DISCARD_REASON_CODE,T12081.T_WEIGHT_GM,T12081.T_WEIGHT_GMT,T12073.T_LANG{lang}_NAME UNIT_NAME from T12081 JOIN T12073 ON T12081.T_ACTION =T12073.T_UNIT_TYPE ORDER BY T12081.T_WEIGHT_CODE ASC");
        }

        public DataTable GetAllUnitData(string lang)
        {
            return Query($"SELECT T_UNIT_TYPE,T_LANG{lang}_NAME T_UNIT_NAME FROM T12073");
        }

        public string SaveData(M12281 t12281, string user,string lang)
        {
            string msg = "";
            int count = 0;
            var collection =Query($"SELECT (SELECT MAX(CASE WHEN T_WEIGHT_CODE = '{t12281.T_WEIGHT_CODE}' AND T_ACTION ='{t12281.T_ACTION}' THEN '1' ELSE '0' END) FROM t12081)COLLECTION from dual").Rows[0]["COLLECTION"].ToString();
            BeginTransaction();
            if (collection == "0")
            {
                Command("INSERT INTO T12081(T_ENTRY_DATE,T_ENTRY_USER, T_WEIGHT_CODE, T_LANG2_NAME,T_WEIGHT_FR,T_WEIGHT_TO,T_WEIGHT_GM,T_WEIGHT_GMT,T_DISCARD_REASON_CODE,T_ACTION)"
                               + $" VALUES (SYSDATE, '{user}', '{t12281.T_WEIGHT_CODE}','{t12281.T_WEIGHT_NAME}','{t12281.T_WEIGHT_FR}','{t12281.T_WEIGHT_TO}','{t12281.T_WEIGHT_GM}','{t12281.T_WEIGHT_GMT}','{t12281.T_DISCARD_REASON_CODE}','{t12281.T_ACTION}')");
                // CommitTransaction();
                count = 1;
                 msg = GetUserMsg("N0040", "LANG" + lang);
            }
            else
            {
                Command($"UPDATE T12081  SET T_UPD_DATE=SYSDATE,T_UPD_USER='{user}',T_LANG2_NAME = '{t12281.T_WEIGHT_NAME}',T_WEIGHT_FR='{t12281.T_WEIGHT_FR}',T_WEIGHT_TO='{t12281.T_WEIGHT_TO}',T_WEIGHT_GM ='{t12281.T_WEIGHT_GMT}',T_WEIGHT_GMT='{t12281.T_WEIGHT_GMT}'," +
                        $"T_DISCARD_REASON_CODE='{t12281.T_DISCARD_REASON_CODE}' WHERE T_ACTION='{t12281.T_ACTION}' AND T_WEIGHT_CODE = '{t12281.T_WEIGHT_CODE}'");
                // CommitTransaction();
                count = 1;
                msg = GetUserMsg("N0041", "LANG" + lang);
            }
            if (count==1)
            {
                CommitTransaction();
            }
            else
            {
                RollbackTransaction();
            }

            return msg;
            // Command($"INSERT INTO T12075(T_ENTRY_DATE, T_UNIT_NO, T_SEGMENT_NO,T_BLD_STORE_ID,T_DONATION_DATE)"
            //      + $" VALUES (SYSDATE, '{t12022.T_UNIT_NO}', '{t12022.T_SEGMENT_NO}','{storeId}',SYSDATE)");

            //  Command($"UPDATE T12035  SET T_SEQ_NO = '{t12022.T_SEQ_NO}' WHERE T_HOSPITAL ='1' AND T_WS_CODE = '12'");
        }
    }
}