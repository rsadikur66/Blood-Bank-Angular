using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Initialization
{
    public class T12338 : CommonDAL
    {
        public DataTable GetCentralBankList(string lang)
        {
            return Query(
                $"SELECT T37.T_BANK_CODE CODE, T37.T_LANG{lang}_NAME NAME FROM T12337 T37 WHERE T_BANK_TYPE='1'");
        }

        public DataTable CheckExistOrNot(M12338 t12338)
        {
            return Query($"SELECT * FROM T12338 WHERE T_CENTRAL_BANK_CODE='{t12338.T_CENTRAL_BANK_CODE}' AND T_BANK_CODE='{t12338.T_BANK_CODE}'");
        }
        public DataTable GetTransfusionsList(string bankCode)
        {
            return Query(
                $"SELECT T37.T_BANK_CODE, T37.T_LANG2_NAME,T37.T_LANG1_NAME,T38.T_BANK_ACTIVE FROM T12337 T37 LEFT JOIN T12338 T38 ON T37.T_BANK_CODE = T38.T_BANK_CODE and T_CENTRAL_BANK_CODE='{bankCode}' WHERE T_BANK_TYPE = '3' order by 1");
        }

        public bool InsertToT12338(M12338 t12338, string user)
        {
            Command($"INSERT INTO T12338 (T_ENTRY_USER,T_ENTRY_DATE,T_CENTRAL_BANK_CODE,T_BANK_CODE,T_LANG2_NAME,T_LANG1_NAME,T_BANK_ACTIVE) VALUES ('{user}',TRUNC(SYSDATE),'{t12338.T_CENTRAL_BANK_CODE}','{t12338.T_BANK_CODE}','{t12338.T_LANG2_NAME}','{t12338.T_LANG1_NAME}','{t12338.T_BANK_ACTIVE}')");
            return true;
        }
        public bool UpdateToT12338(M12338 t12338, string user)
        {
            Command($"UPDATE T12338 SET T_UPD_USER='{user}',T_UPD_DATE=TRUNC(SYSDATE),T_BANK_ACTIVE='{t12338.T_BANK_ACTIVE}' WHERE T_CENTRAL_BANK_CODE = '{t12338.T_CENTRAL_BANK_CODE}' AND T_BANK_CODE = '{t12338.T_BANK_CODE}'");
            return true;
        }
    }
}