using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Initialization
{
    public class T12332:CommonDAL
    {
        public DataTable GetGridData(string unittype, string english, string local, string bag)
        {
            return Query($"SELECT DISTINCT T_UNIT_TYPE,T_LANG2_NAME,T_LANG1_NAME,T_NO_OF_BAG FROM T12073 WHERE ('{unittype}'IS NULL OR T_UNIT_TYPE='{unittype}') AND ('{english}'IS NULL OR T_LANG2_NAME='{english}') AND ('{local}'IS NULL OR T_LANG1_NAME='{local}') AND ('{bag}'IS NULL OR T_NO_OF_BAG='{bag}') ORDER BY T_UNIT_TYPE");
        }

        public string Insert_T12332(t12073 t12073,string user)
        {
            string msg = "";
            
                int count = Query($"SELECT T_UNIT_TYPE FROM T12073 WHERE T_UNIT_TYPE  = '{t12073.T_UNIT_TYPE}'").Rows.Count;
                var max = Query($"select lpad((MAX(T_UNIT_TYPE)+1),2,'0') T_UNIT_TYPE FROM T12073");
                var maxUnittype = max.Rows[0]["T_UNIT_TYPE"];
                BeginTransaction();

                if (count == 0)
                {

                    if (Command($"INSERT INTO T12073 (T_ENTRY_USER,T_ENTRY_DATE,T_UNIT_TYPE,T_LANG2_NAME,T_LANG1_NAME, T_NO_OF_BAG ) VALUES ('{user}', TRUNC(SYSDATE), '{maxUnittype}', '{t12073.T_LANG2_NAME}', '{t12073.T_LANG1_NAME}', '{t12073.T_NO_OF_BAG}')"))
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
                        $"UPDATE T12073 SET T_UPD_USER='{user}',T_UPD_DATE=TRUNC(SYSDATE),T_LANG2_NAME='{t12073.T_LANG2_NAME}',T_LANG1_NAME='{t12073.T_LANG1_NAME}',T_NO_OF_BAG='{t12073.T_NO_OF_BAG}' WHERE T_UNIT_TYPE='{t12073.T_UNIT_TYPE}' "))
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