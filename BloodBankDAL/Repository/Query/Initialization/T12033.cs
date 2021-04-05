using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Initialization
{
    public class T12033:CommonDAL
    {
        public DataTable GetGridData()
        {
            return Query($"SELECT T_VIRUS_CODE,T_LANG2_NAME,T_LANG1_NAME,T_ACTIVE,T_PN FROM T12033 ORDER BY T_VIRUS_CODE");
        }

        public string Insert_T12033(t12033 t12033, string user)
        {
            string msg = "";
            int count = Query($"SELECT T_VIRUS_CODE FROM T12033 WHERE T_VIRUS_CODE  = '{t12033.T_VIRUS_CODE}'").Rows.Count;
            var max = Query($"select lpad((MAX(T_VIRUS_CODE)+1),2,'0') T_VIRUS_CODE FROM T12033");
            var maxviruscode = max.Rows[0]["T_VIRUS_CODE"];
            BeginTransaction();

            if (count == 0)
            {
                if (Command($"INSERT INTO T12033 (T_ENTRY_USER,T_ENTRY_DATE,T_VIRUS_CODE,T_LANG2_NAME,T_LANG1_NAME,T_PN,T_ACTIVE) VALUES ('{user}', TRUNC(SYSDATE), '{maxviruscode}', '{t12033.T_LANG2_NAME}', '{t12033.T_LANG1_NAME}', '{t12033.T_PN}','{t12033.T_ACTIVE}')"))
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
                    $"UPDATE T12033 SET T_UPD_USER='{user}',T_UPD_DATE=TRUNC(SYSDATE),T_LANG2_NAME='{t12033.T_LANG2_NAME}',T_LANG1_NAME='{t12033.T_LANG1_NAME}',T_PN='{t12033.T_PN}',T_ACTIVE='{t12033.T_ACTIVE}' WHERE T_VIRUS_CODE='{t12033.T_VIRUS_CODE}' "))
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
            return msg;
        }
    }
}