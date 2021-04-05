using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BloodBankDAL.Repository.Interface;

namespace BloodBankDAL.Repository.Query
{
    public class Login : CommonDAL
    {

        public DataTable CheckLogin(string T_LOGIN_NAME, string T_PWD)
        {
            return Query($"SELECT T01009.*,(SELECT T_REFERRAL_CODE FROM T02049 WHERE T_BILL_SOFT_CODE = T01009.T_SITE_CODE) T_REFERRAL_CODE FROM T01009 WHERE T_LOGIN_NAME= '{T_LOGIN_NAME}' AND T_PWD = '{T_PWD}'");
        }

        public string logT92(string userId)
        {
            string msg = "";
            BeginTransaction();
            if (Command($"UPDATE T12092 SET T_LOGIN_STATUS = '1' WHERE T_EMP_CODE = '{userId}'"))
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