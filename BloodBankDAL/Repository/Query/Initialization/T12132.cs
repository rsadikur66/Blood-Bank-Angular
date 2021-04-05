using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Initialization
{
    public class T12132 : CommonDAL
    {
        public CommonDAL _commonDal = new CommonDAL();

        //public DataTable GetGridData(string controlname, string local,string english)
        //{
        //    return Query($"SELECT DISTINCT T_CONTROL_NAME,T_CONTROL_TEXT_LANG1,T_CONTROL_TEXT_LANG2 FROM T12132 WHERE ('{controlname}'IS NULL OR T_CONTROL_NAME='{controlname}') AND ('{local}'IS NULL OR T_CONTROL_TEXT_LANG1='{local}') AND ('{english}'IS NULL OR T_CONTROL_TEXT_LANG2='{english}') ORDER BY T_ENTRY_USER");
        //}


        public DataTable GetGridData()
        {
            return Query($"SELECT T_FORM_NAME, T_CONTROL_NAME, T_CONTROL_TEXT_LANG1, T_CONTROL_TEXT_LANG2, T_LABEL_ID FROM T12132");
        }

        public DataTable GetAllFormCodeData()
        {
            return Query($"SELECT T_LINK_TEXT FROM T12199 WHERE T_LINK_TEXT IS NOT NULL");
        }

        //public DataTable GetAllFormCodeData()
        //{
        //    return Query($"SELECT T_FORM_NAME FROM T12132 WHERE T_FORM_NAME IS NOT NULL");
        //}

        public DataTable getForm()
        {
            return Query($"SELECT T_LINK_TEXT FROM T12199 WHERE T_INACTIVE_FLAG IS NULL GROUP BY T_LINK_TEXT ORDER BY T_LINK_TEXT DESC");
        }

        public DataTable getAllData()
        {
            return Query($"");
        }

        public string SaveData(M12132 t12132, string user, string lang)
        {
            string msg = "";
            int count = 0;
            var max = Query($"select MAX(T_LABEL_ID*1)+1 T_LABEL_ID FROM T12132");
            var maxId = max.Rows[0]["T_LABEL_ID"];
            var collection = Query($"SELECT (SELECT MAX(CASE WHEN T_FORM_NAME = '{t12132.T_FORM_NAME}' AND T_CONTROL_NAME ='{t12132.T_CONTROL_NAME}' THEN '1' ELSE '0' END) FROM T12132)COLLECTION from dual").Rows[0]["COLLECTION"].ToString();
            BeginTransaction();
            if (collection == "0")
            {
                Command("INSERT INTO T12132(T_ENTRY_DATE,T_ENTRY_USER, T_FORM_NAME, T_CONTROL_NAME,T_CONTROL_TEXT_LANG1,T_CONTROL_TEXT_LANG2,T_LABEL_ID)"
                        + $" VALUES (SYSDATE, '{user}', '{t12132.T_FORM_NAME}','{t12132.T_CONTROL_NAME}','{t12132.T_CONTROL_TEXT_LANG1}','{t12132.T_CONTROL_TEXT_LANG2}','{maxId}')");
                // CommitTransaction();
                count = 1;
                msg = GetUserMsg("N0040", "LANG" + lang);
            }
            else
            {
                Command($"UPDATE T12132  SET T_UPD_DATE=SYSDATE,T_UPD_USER='{user}',T_FORM_NAME = '{t12132.T_FORM_NAME}',T_CONTROL_NAME='{t12132.T_CONTROL_NAME}',T_CONTROL_TEXT_LANG1='{t12132.T_CONTROL_TEXT_LANG1}',T_CONTROL_TEXT_LANG2 ='{t12132.T_CONTROL_TEXT_LANG2}'" +
                        $" WHERE T_LABEL_ID='{t12132.T_LABEL_ID}'");
                // CommitTransaction();
                count = 1;
                msg = GetUserMsg("N0041", "LANG" + lang);
            }
            if (count == 1)
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