using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12349:CommonDAL
    {
        public DataTable getBagType(string lang)
        {
            return Query($"SELECT T_UNIT_TYPE,T_LANG{lang}_NAME NAME FROM T12073 ORDER BY T_UNIT_TYPE");
        }
        public DataTable getUnitList(string T_SITE_CODE, string T_UNIT_NO, string DATEFROM, string DATETO)
        {
            string con = string.IsNullOrEmpty(DATEFROM) && string.IsNullOrEmpty(DATETO) ? "OR" : "AND";
            return Query($"SELECT T12022.T_DONATION_DATE,T12022.T_UNIT_NO,'' T_UNIT_WEIGHT,'' T_RECEIVED_USER FROM T12022 INNER JOIN T12075 ON T12022.T_UNIT_NO = T12075.T_UNIT_NO INNER JOIN T12017 ON T12017.T_REQUEST_ID = T12022.T_REQUEST_ID WHERE T12017.T_SITE_CODE = '{T_SITE_CODE}' AND(('{T_UNIT_NO}' IS NULL OR T12022.T_UNIT_NO = '{T_UNIT_NO}') {con} (TO_DATE(T12022.T_DONATION_DATE) BETWEEN '{DATEFROM}' AND '{DATETO}')) AND T12022.T_APHERESIS IS NULL AND T12022.T_UNIT_NO NOT IN (SELECT T12019.T_UNIT_NO FROM T12135 INNER JOIN T12019 ON T12135.T_UNIT_NO=T12019.T_UNIT_NO) AND T12022.T_RECEIVED IS NOT NULL AND T12017.T_HAMLA_STTS IS NOT NULL ORDER BY TO_DATE(T12022.T_DONATION_DATE) DESC");
        }
        public DataTable validateWeight(string T_UNIT_WEIGHT, string T_BAG_TYPE)
        {
            return Query($"SELECT T_WEIGHT_CODE FROM T12081 WHERE '{T_UNIT_WEIGHT}' BETWEEN T_WEIGHT_GM AND T_WEIGHT_GMT AND '{T_BAG_TYPE}' = T_ACTION");
        }
        public string insert(List<CommonModel> modelList, string lang, string user)
        {
            int count = 0;
            BeginTransaction();
            foreach (var m in modelList)
            {
                string[] arr = new string[] { "PRBC", "PLT", "FFP" };
                string[] arrH = new string[] { "PRBC", "FFP" };
                int arrLength = 0;
                string T_PRODUCT_CODE = "";
                string T_REASON = "";
                string T_UNIT_STATUS = "";
                string T_EXPIRY_DATE = "";
                string wt = m.T_WEIGHT_CODE;
                if (wt == "01")
                {
                    T_REASON = "02";
                    T_UNIT_STATUS = "10";
                    T_PRODUCT_CODE = "NSFS";
                    T_EXPIRY_DATE = "";
                    arrLength = 1;
                }
                else if (wt == "02")
                {
                    T_PRODUCT_CODE = "PRBC";
                    T_REASON = "";
                    T_EXPIRY_DATE = Query($"SELECT TO_CHAR(T_DONATION_DATE+T_EXPIRY_DAYS) EXPIRY_DATE FROM T12022,T12011 WHERE T_UNIT_NO='{m.T_UNIT_NO}' AND T_PRODUCT_CODE='{T_PRODUCT_CODE}'").Rows[0]["EXPIRY_DATE"].ToString();
                    T_UNIT_STATUS = "";
                    arrLength = 1;
                }
                else if (wt == "04")
                {
                    T_REASON = "01";
                    T_UNIT_STATUS = "10";
                    T_PRODUCT_CODE = "NSFS";
                    T_EXPIRY_DATE = "";
                    arrLength = 1;

                }
                else if (wt == "03")
                {
                    arrLength = m.T_BAG_TYPE == "01" || m.T_BAG_TYPE == "02" ? arr.Length : arrH.Length;
                    T_REASON = "";
                    T_UNIT_STATUS = "";
                    
                }

                int a = 0;
                int i = 0;
                for ( i = 0; i < arrLength; i++)
                {
                    if (arrLength == 2)
                    {
                        T_PRODUCT_CODE = arrH[i];
                        T_EXPIRY_DATE = Query($"SELECT TO_CHAR(T_DONATION_DATE+T_EXPIRY_DAYS) EXPIRY_DATE FROM T12022,T12011 WHERE T_UNIT_NO='{m.T_UNIT_NO}' AND T_PRODUCT_CODE='{T_PRODUCT_CODE}'").Rows[0]["EXPIRY_DATE"].ToString();
                    }
                    else if (arrLength == 3)
                    {
                        T_PRODUCT_CODE = arr[i];
                        T_EXPIRY_DATE =Query($"SELECT TO_CHAR(T_DONATION_DATE+T_EXPIRY_DAYS) EXPIRY_DATE FROM T12022,T12011 WHERE T_UNIT_NO='{m.T_UNIT_NO}' AND T_PRODUCT_CODE='{T_PRODUCT_CODE}'")
                                .Rows[0]["EXPIRY_DATE"].ToString();
                    }

                    bool insert35 = Command($"INSERT INTO T12135 (T_UNIT_NO,T_CENTRIFUGE_MACHINE_CODE,T_PROGRAM_CODE, T_PROD_CODE,T_PROCESS_ID,T_PROD_EXPIRY_DATE,T_DONATION_DATE,T_ENTRY_USER, T_ENTRY_DATE, T_SEPARATION_TIME, T_REASON) VALUES ('{m.T_UNIT_NO}', '0001', '1', '{T_PRODUCT_CODE}', '', '{T_EXPIRY_DATE}','{m.T_DONATION_DATE.ToString("dd-MMM-yyyy")}','{user}', TRUNC(SYSDATE), TO_CHAR(SYSDATE, 'HH24MI'), '{T_REASON}')");
                        bool insert19 = Command($"INSERT INTO T12019(T_ENTRY_DATE,T_ENTRY_USER,T_DESTROY_FLAG,T_DONATION_DATE, T_EXPIRY_DATE,T_PRODUCT_CODE,T_REJECT_FLAG,T_UNIT_NO,T_UNIT_SEPERATION_DATE, T_UNIT_STATUS)VALUES(TRUNC(SYSDATE),'{user}', '2','{m.T_DONATION_DATE.ToString("dd-MMM-yyyy")}', '{T_EXPIRY_DATE}', '{T_PRODUCT_CODE}', '2','{m.T_UNIT_NO}', TRUNC(SYSDATE), '{T_UNIT_STATUS}')");
                    a = insert35 && insert19 ? a + 1 : a;
                }

                count = a == i && a > 0 ? count+1 : count;
            }
            string code = "";
            if (count==modelList.Count)
            {
                CommitTransaction();
                code = "N0040";
            }
            else
            {
                RollbackTransaction();
                code = "N0071";
            }

            string msg = GetUserMsg(code, "LANG"+lang);
            return msg;
        }
    }
}