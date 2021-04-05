using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Initialization
{
    public class T12246 : CommonDAL
    {
        //For Blood Group popup Data
        public DataTable GetBloodData(string language)
        {
            return Query($"SELECT T_ABO_CODE T_BLOOD_GROUP,T_LANG{language}_NAME T_LANG_NAME FROM T12004 ORDER BY T_ABO_CODE");
        }

        //For Product popup Data
        public DataTable GetProductData(string language)
        {
            return Query($"SELECT  T_PRODUCT_CODE,T_LANG{language}_NAME T_NAME FROM T12011 ORDER BY T_PRODUCT_CODE");
        }

        public DataTable GetGridData(string language,string productCode,string bloodGroup)
        {
            return Query($"SELECT DISTINCT T12211.T_PRODUCT_CODE,T12004.T_ABO_CODE T_BLOOD_GROUP,T12004.T_LANG{language}_NAME T_LANG_NAME,T12211.T_TECH FROM T12004 LEFT OUTER JOIN T12211 ON T12004.T_ABO_CODE = T12211.T_BLOOD_GROUP AND ('{productCode}' IS NULL OR T12211.T_PRODUCT_CODE='{productCode}') AND  ('{bloodGroup}' IS NULL OR T12211.T_PAT_BLOOD_GROUP='{bloodGroup}') ORDER BY T_ABO_CODE ");
        }

        public string Insert_T12211(List<t12246> t12246, string p, string b, string user)
        {
            string msg = "";
            foreach (var list in t12246)
            {
                int count = Query($"SELECT T_PRODUCT_CODE,T_BLOOD_GROUP,T_PAT_BLOOD_GROUP FROM T12211 WHERE T_PRODUCT_CODE  = '{p}' AND T_PAT_BLOOD_GROUP = '{b}' AND T_BLOOD_GROUP = '{list.T_BLOOD_GROUP}'").Rows.Count;
                BeginTransaction();

                if (count == 0)
                {

                    if (Command($"INSERT INTO T12211 (T_ENTRY_USER,T_ENTRY_DATE,T_PRODUCT_CODE,T_PAT_BLOOD_GROUP,T_BLOOD_GROUP, T_TECH ) VALUES ('{user}', TRUNC(SYSDATE), '{p}', '{b}', '{list.T_BLOOD_GROUP}', '{list.T_TECH}')"))
                    {
                        CommitTransaction();
                        msg = "N0040";
                    }
                    else
                    {
                        RollbackTransaction();
                        msg = "N0071";
                    }

                }
                else
                {
                    if (Command(
                        $"UPDATE T12211 SET T_UPD_USER='{user}',T_UPD_DATE=TRUNC(SYSDATE),T_TECH='{list.T_TECH}' WHERE T_BLOOD_GROUP='{list.T_BLOOD_GROUP}' "))
                    {
                        CommitTransaction();
                        msg = "N0041";
                    }
                    else
                    {
                        RollbackTransaction();
                        msg = "N0072";
                    }

                }
            }
            
            return msg;
        }
    }
}



