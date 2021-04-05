using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Menus
{
    public class MenuQuery : CommonDAL
    {
        public DataTable FormAuthorization(string T_FORM_CODE, string T_USER_ID, string T_ROLE_CODE)
        {
            return Query($"select * from T01009 inner join T12199 on T01009.T_ROLE_CODE = T12199.T_ROLE_CODE where T01009.T_ROLE_CODE = '{T_ROLE_CODE}' and T_EMP_CODE = '{T_USER_ID}' and T_LINK_TEXT = '{T_FORM_CODE}' and T_PERMIT_STS is null");
        }
        public bool FormAuth(string T_FORM_CODE, string T_EMP_CODE, string T_ROLE_CODE)
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(T_EMP_CODE) && !string.IsNullOrEmpty(T_ROLE_CODE))
            {
                dt = FormAuthorization(T_FORM_CODE, T_EMP_CODE, T_ROLE_CODE);
            }

            return dt.Rows.Count > 0;
        }

        public DataTable MenuData(string lang, string T_LINK_SEPERATION, string T_ROLE_CODE)
        {
            //return Query($"SELECT ROWNUM,T_LANG{lang}_NAME LINK_LABEL,T_LINK_SEPERATION,  T_LINK_TEXT FROM T12199 WHERE T_LINK_TEXT  IS NOT NULL AND T_LINK_SEPERATION ='{ T_LINK_SEPERATION }' AND T_ROLE_CODE = '{T_ROLE_CODE}' AND T_INACTIVE_FLAG  IS NULL ORDER BY T_ORDER");
            return Query($"SELECT ROWNUM, T.* FROM (SELECT ROWNUM,T_LANG{lang}_NAME LINK_LABEL,T_LINK_SEPERATION,  T_LINK_TEXT FROM T12199 WHERE T_LINK_TEXT  IS NOT NULL AND T_LINK_SEPERATION ='{ T_LINK_SEPERATION }' AND T_ROLE_CODE = '{T_ROLE_CODE}' AND T_INACTIVE_FLAG  IS NULL ORDER BY TO_NUMBER(T_ORDER)) T ORDER BY ROWNUM");
        }

        public DataTable loginData(string id)
        {
            return Query($"select T_LOGIN_NAME,T_PWD, from T01009 where T_LOGIN_NAME ={id}");
        }

        public string LogoutT92(string emp)
        {
            string msg = "";
            BeginTransaction();
            if (Command($"UPDATE T12092 SET T_LOGIN_STATUS = '' WHERE T_EMP_CODE = '{emp}'"))
            {
                CommitTransaction();
                // msg = "N0040";
            }
            else
            {
                RollbackTransaction();
                // msg = "N0071";
            }
            return msg;
        }
    }
}