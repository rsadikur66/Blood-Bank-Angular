using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12091 : CommonDAL
    {
        
        public DataTable GetDeliveryManData()
        {
            return Query($"SELECT T12092.T_EMP_CODE CODE, T01009.T_USER_NAME NAME, T12091.T_BLOOD_REQ_NO, T12091.T_SITE_CODE FROM T12092 JOIN T01009 ON T12092.T_EMP_CODE = T01009.T_EMP_CODE JOIN T12091 ON T12092.T_EMP_CODE = T12091.T_EMP_CODE JOIN T12065 ON T12091.T_BLOOD_REQ_NO = T12065.T_BLOOD_REQNO AND T12091.T_SITE_CODE = T12065.T_SITE_CODE WHERE  T12065.T_REQUEST_STATUS='3' AND T_STATUS ='2' AND T_REQ_ACCEPT_FLG ='1' AND T_BLOOD_RCVD_FLG  is null");
        }

        public DataTable GetReqDetails(string bldReq, string site,string lang)
        {
            return Query($"SELECT T_BLOOD_REQNO, T_BLOOD_REQDATE, T_BLOOD_REQTIME, T_REF_HOSP, T_BLOOD_GRP, T_PRODUCT_CODE, T_NUM_UNIT,T_SITE_CODE, (SELECT T_LANG{lang}_NAME FROM T12337 WHERE T_BANK_CODE = T12065.T_REF_HOSP ) T_REFERRAL_NAME, (SELECT T_LANG2_NAME FROM T12004 WHERE T_ABO_CODE = T12065.T_BLOOD_GRP ) BLD_NAME, (SELECT T_LANG2_NAME FROM T12011 WHERE T_PRODUCT_CODE = T12065.T_PRODUCT_CODE ) T_PRODUCT_NAME FROM T12065 WHERE T_BLOOD_REQNO = '{bldReq}' AND T_SITE_CODE = '{site}' AND T_REQUEST_STATUS = '3'");
        }

        public DataTable GetuserDetails(string lang, string user)
        {

            return Query($"SELECT T_USER_NAME,T_EMP_CODE FROM t01009 WHERE T_EMP_CODE ='{user}'");
        }
        public string Save(string requestNo, string siteCode, string user, string time)
        {
            string msg = "";
            BeginTransaction();
            if (Command($"UPDATE T12065 SET T_REQUEST_STATUS = '4', T_BB_HANDOVER_FLG = '1', T_BB_HANDOVER_BY = '{user}', T_BB_HANDOVER_DATE = TRUNC(SYSDATE), T_BB_HANDOVER_TIME = to_char(sysdate,'HH24MI') WHERE T_BLOOD_REQNO = '{requestNo}' AND T_SITE_CODE = '{siteCode}'"))
            {
                CommitTransaction();
                msg = "N0040";
            }
            else
            {
                RollbackTransaction();
                msg = "N0071";
            }
            return msg;
        }
    }
}