using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12262 : CommonDAL
    {
        public DataTable GetDataBySiteCode(string siteCode, string lang)
        {
            // return Query($"SELECT T_LANG2_NAME,T_LANG1_NAME,T_BANK_CODE FROM T12338 WHERE T_CENTRAL_BANK_CODE ='{siteCode}' AND T_BANK_ACTIVE = '1'");

            //Ruhul 
            return Query($"SELECT DISTINCT T_LANG2_NAME, T_LANG1_NAME,T_BANK_CODE,T_CENTRAL_BANK_CODE FROM ( SELECT T_LANG2_NAME, T_LANG1_NAME, T_BANK_CODE, T_CENTRAL_BANK_CODE FROM T12338 WHERE T_CENTRAL_BANK_CODE ='{siteCode}' AND T_BANK_ACTIVE = '1' )T_1 JOIN T12065 ON T_1.T_CENTRAL_BANK_CODE =T12065.T_REF_HOSP AND T_1.T_BANK_CODE =T12065.T_SITE_CODE WHERE T12065.T_REQUEST_STATUS='1'");
        }

        public DataTable GetDataRequestNo(string siteCode,string refCode, string lang)
        {
            return Query($"SELECT T_BLOOD_REQNO,T_BLOOD_REQTIME,T_SITE_CODE,T_BLOOD_REQDATE FROM T12065 where T_SITE_CODE='{siteCode}' and T_REF_HOSP='{refCode}' and T_REQUEST_STATUS='1'");
        }

        public DataTable GetRequestDetails(string requestNo, string siteCode, string lang)
        {
            return Query($"SELECT T_BLOOD_REQNO, T_BLOOD_REQDATE, T_BLOOD_REQTIME, T_REF_HOSP, T_BLOOD_GRP, T_PRODUCT_CODE, T_NUM_UNIT,T_SITE_CODE, (SELECT T_LANG{lang}_NAME FROM T12337 WHERE T_BANK_CODE = T12065.T_REF_HOSP ) T_REFERRAL_NAME, (SELECT T_LANG2_NAME FROM T12004 WHERE T_ABO_CODE = T12065.T_BLOOD_GRP ) BLD_NAME, (SELECT T_LANG2_NAME FROM T12011 WHERE T_PRODUCT_CODE = T12065.T_PRODUCT_CODE ) T_PRODUCT_NAME FROM T12065 WHERE T_BLOOD_REQNO = '{requestNo}' AND T_SITE_CODE = '{siteCode}' AND T_REQUEST_STATUS = '1' ");
        }
        public DataTable GetRequestDetails(string siteCode, string lang)
        {
            return Query($@"SELECT T_BLOOD_REQNO, T_BLOOD_REQDATE, T_BLOOD_REQTIME, T_REF_HOSP, T_BLOOD_GRP, T_PRODUCT_CODE, T_NUM_UNIT,T_SITE_CODE,
                            (SELECT T_LANG1_NAME FROM T12337 WHERE T_BANK_CODE = T12065.T_SITE_CODE) TRANSFUSTION_HOSPITAL,
                            (SELECT T_LANG1_NAME FROM T12337 WHERE T_BANK_CODE = T12065.T_REF_HOSP) CENTRAL_HOSPITAL, 
                            (SELECT T_LANG2_NAME FROM T12004 WHERE T_ABO_CODE = T12065.T_BLOOD_GRP ) BLD_NAME, 
                            (SELECT T_LANG2_NAME FROM T12011 WHERE T_PRODUCT_CODE = T12065.T_PRODUCT_CODE ) T_PRODUCT_NAME FROM T12065
                            WHERE T_REF_HOSP = '{siteCode}' AND T_REQUEST_STATUS = '1' ORDER BY to_char(t12065.t_blood_reqdate,'yyyyMMdd')||t12065.t_blood_reqtime DESC,t12065.T_SITE_CODE, t12065.t_blood_reqno DESC");
        }

        public DataTable GetuserDetails(string lang, string user)
        {
            return Query($"SELECT T_USER_NAME,T_EMP_CODE FROM t01009 WHERE T_EMP_CODE ='{user}'");
        }

        public string Save(string requestNo, string siteCode,string user,string time)
        {
            string msg = "";
            BeginTransaction();
            if (Command($"UPDATE T12065 SET T_REQUEST_STATUS = '2', T_BB_RECEIVED_FLAG = '1', T_BB_RECEIVED_BY = '{user}', T_BB_RECEIVED_DATE = TRUNC(SYSDATE), T_BB_RECEIVED_TIME = TO_CHAR(SYSDATE,'HH24MI') WHERE T_BLOOD_REQNO = '{requestNo}' AND T_SITE_CODE = '{siteCode}'"))
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