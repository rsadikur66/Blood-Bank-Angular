using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Initialization
{
    public class T12011:CommonDAL
    {
        public CommonDAL _CommonDal = new CommonDAL();

        public DataTable GetGridData(string lang)
        {
            return Query($"SELECT T_PRODUCT_CODE,T_LANG{lang}_NAME T_NAME,T_EXPIRY_DAYS,T_STORE_AT,T_ACTIVE,T_PROD_PRIORITY FROM T12011");
        }
        
        public string Insert_T12011(t12011 t12011, string user)
        {
            string msg = "";
            int count = Query($"SELECT T_PRODUCT_CODE FROM T12011 WHERE T_PRODUCT_CODE  = '{t12011.T_PRODUCT_CODE}'").Rows.Count;
            BeginTransaction();
            if (count == 0)
            {
                if (Command($"INSERT INTO T12011 (T_ENTRY_USER,T_ENTRY_DATE,T_PRODUCT_CODE,T_LANG2_NAME,T_LANG1_NAME, T_EXPIRY_DAYS,T_PROD_PRIORITY,T_STORE_AT, T_ACTIVE) VALUES ('{user}', TRUNC(SYSDATE), '{t12011.T_PRODUCT_CODE}', '{t12011.T_LANG2_NAME}', '{t12011.T_LANG1_NAME}', '{t12011.T_EXPIRY_DAYS}', '{t12011.T_PROD_PRIORITY}','{t12011.T_STORE_AT}', '{t12011.T_ACTIVE}')"))
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
                    $"UPDATE T12011 SET T_UPD_USER='{user}',T_UPD_DATE=TRUNC(SYSDATE),T_LANG2_NAME='{t12011.T_LANG2_NAME}',T_LANG1_NAME='{t12011.T_LANG1_NAME}',T_EXPIRY_DAYS='{t12011.T_EXPIRY_DAYS}',T_PROD_PRIORITY='{t12011.T_PROD_PRIORITY}',T_STORE_AT='{t12011.T_STORE_AT}',T_ACTIVE='{t12011.T_ACTIVE}' WHERE T_PRODUCT_CODE='{t12011.T_PRODUCT_CODE}'"))
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