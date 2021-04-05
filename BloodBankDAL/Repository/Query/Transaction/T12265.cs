using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12265:CommonDAL
    {
        public DataTable GetRequestListData(string empCode)
        {
            
            return Query($"SELECT T_REQ_ID, T_BLOOD_REQ_NO BLOOD_REQ_NO, T_REQ_ACCEPT_FLG, T_REQ_ACCEPT_DATE, T_REQ_ACCEPT_TIME, T_BLOOD_RCVD_FLG, T_BLOOD_RCVD_DATE, T_BLOOD_RCVD_TIME, T_BLOOD_DROP_FLG, T_BLOOD_DROP_DATE, T_BLOOD_DROP_TIME, T_REQ_CANCEL_FLG, T12065.T_REQUEST_STATUS, T12065.T_NUM_UNIT, ref49.T_LANG2_NAME T_REF_HOSPITAL, site49.T_LANG2_NAME T_SITE_HOSPITAL, T12091.T_ESTIMATED_DELIVERY_TIME, T12091.T_ESTIMATED_DELIVERY_DIST FROM T12091 JOIN T12065 ON T12091.T_BLOOD_REQ_NO = T12065.T_BLOOD_REQNO and t12065.t_site_code=t12091.t_site_code JOIN T02049 ref49 ON T12065.T_REF_HOSP = ref49.T_REFERRAL_CODE JOIN T02049 site49 ON T12065.T_SITE_CODE = site49.T_REFERRAL_CODE WHERE T_EMP_CODE = '{empCode}' AND T12091.T_BLOOD_DROP_FLG IS NULL AND T12091.T_REQ_CANCEL_FLG IS NULL");
           
        }

        public DataTable GetHandOverDataFromCenter(string empCode)
        {
            return Query($"SELECT * FROM T12065 WHERE T_BB_HANDOVER_FLG IS NOT NULL AND T_DELIVERY_MAN = '{empCode}'");
        }
        public DataTable GetLocationDeliveryMan(string bldReqNo)
        {
           // return Query($"select t12091.T_EMP_CODE, T12091.T_BLOOD_REQ_NO,T12065.T_REF_HOSP,T02049.T_LANG2_NAME, T12065.T_SITE_CODE SITECODE,T02065.T_SITE_CODE,t02065.T_LANG2_NAME,t02065.T_LATITUDE CML,T02065.T_LONGITUDE CMLO, t12092.T_LATITUDE DMLL,T12092.T_LONGITUDE DMLLO from T12091 INNER JOIN T12065 ON T12091.T_BLOOD_REQ_NO = T12065.T_BLOOD_REQNO INNER JOIN t02049 ON t12065.T_REF_HOSP = t02049.T_REFERRAL_CODE INNER JOIN T02065 ON T02049.T_BILL_SOFT_CODE = T02065.T_SITE_CODE INNER JOIN t12092 ON t12091.T_EMP_CODE = t12092.T_EMP_CODE WHERE T12091.T_BLOOD_REQ_NO = '{bldReqNo}' and T_STATUS not in('4','5')");
            return Query($"SELECT DISTINCT t12091.T_EMP_CODE, T12091.T_BLOOD_REQ_NO, T12065.T_REF_HOSP, T02049.T_LANG2_NAME, T12065.T_SITE_CODE SITECODE, T02065.T_SITE_CODE, t02065.T_LANG2_NAME, t02065.T_LATITUDE CML, T02065.T_LONGITUDE CMLO, t12092.T_LATITUDE DMLL, T12092.T_LONGITUDE DMLLO FROM T12091 INNER JOIN T12065 ON T12091.T_BLOOD_REQ_NO = T12065.T_BLOOD_REQNO AND T12091.T_SITE_CODE = T12065.T_SITE_CODE INNER JOIN t02049 ON t12065.T_REF_HOSP = t02049.T_REFERRAL_CODE INNER JOIN T02065 ON T02049.T_BILL_SOFT_CODE = T02065.T_SITE_CODE INNER JOIN t12092 ON t12091.T_EMP_CODE = t12092.T_EMP_CODE WHERE T12091.T_BLOOD_REQ_NO = '{bldReqNo}' AND T_STATUS NOT IN('4','5')");
        }
        public DataTable GetAllDeliveryManLocation(string bldReqNo)
        {
            return Query($"SELECT T_SITE_CODE CODE, T_LANG2_NAME NAME, T_LATITUDE LAT, T_LONGITUDE LON FROM T02065 WHERE T_SITE_CODE = (SELECT DISTINCT T_BILL_SOFT_CODE FROM T12091 INNER JOIN T12065 ON T12091.T_BLOOD_REQ_NO = T12065.T_BLOOD_REQNO INNER JOIN T02049 ON T02049.T_REFERRAL_CODE = T12065.T_REF_HOSP WHERE T_BLOOD_REQ_NO = '{bldReqNo}') UNION ALL SELECT T12092.T_EMP_CODE CODE, T01009.T_USER_NAME NAME, T_LATITUDE LAT, T_LONGITUDE LON FROM T12092 JOIN T01009 ON T12092.T_EMP_CODE = T01009.T_EMP_CODE WHERE T12092.T_LOGIN_STATUS = '1' AND T_STATUS IS NULL");            
        }

        public bool updateT12091(string acpt,string reqId, string user)
        {
            return Command(
               $"UPDATE T12091 SET T_REQ_ACCEPT_FLG = '{acpt}', T_REQ_ACCEPT_DATE = TRUNC(SYSDATE), T_REQ_ACCEPT_TIME = TO_CHAR(SYSDATE,'HH24MI') WHERE T_EMP_CODE = '{user}' AND T_REQ_ID = '{reqId}'");
        }
        public bool updateT12091ForReceived(string reqNo , string user)
        {           
                return Command(
               $"UPDATE T12091 SET T_BLOOD_RCVD_FLG = '1', T_BLOOD_RCVD_DATE = TRUNC(SYSDATE), T_BLOOD_RCVD_TIME = TO_CHAR(SYSDATE,'HH24MI') WHERE T_EMP_CODE = '{user}' AND T_BLOOD_REQ_NO = '{reqNo}'");           
        }

        public bool updatet91ForDrop(string reqNo, string user)
        {
            return Command(
              $"UPDATE T12091 SET T_BLOOD_DROP_FLG = '1', T_BLOOD_DROP_DATE = TRUNC(SYSDATE), T_BLOOD_DROP_TIME = TO_CHAR(SYSDATE,'HH24MI'),T_BLOOD_RCVD_BY = '{user}' WHERE T_EMP_CODE = '{user}' AND T_BLOOD_REQ_NO = '{reqNo}'");
        }
        public bool updateT12092(string user)
        {
            return Command($"UPDATE T12092 SET T_STATUS = '2' WHERE T_EMP_CODE = '{user}'");
        }
         public bool updateT12092ForReceived(string user)
        {          
                return Command($"UPDATE T12092 SET T_STATUS = '3' WHERE T_EMP_CODE = '{user}'");                    
            
        }
        public bool updateT92ForDrop(string user)
        {
            return Command($"UPDATE T12092 SET T_STATUS = '4' WHERE T_EMP_CODE = '{user}'");
        }

        //insertT91
        public bool insertT91(string reqId,string reqNo, string devMan, string estDelDis, string estDelTime, string user, string siteCode)
        {
            //var max = Query($"SELECT MAX(T_REQ_ID)+1 ID FROM T12091").Rows[0]["ID"].ToString();
            var max = Query($"SELECT MAX(TO_NUMBER(T_REQ_ID))+1 ID FROM T12091").Rows[0]["ID"].ToString();
            return Command($"insert into t12091 (T_REQ_ID, T_ENTRY_USER, T_ENTRY_DATE, T_BLOOD_REQ_NO, T_SITE_CODE, T_EMP_CODE, T_ESTIMATED_DELIVERY_DIST, T_ESTIMATED_DELIVERY_TIME) VALUES ('{max}', '{user}', Trunc( SYSDATE ), '{reqNo}', '{siteCode}', '{devMan}', '{estDelDis}', '{estDelTime}')");            
        }
        public bool updateT65(string siteCode, string devMan, string reqNo)
        {
           return Command($"UPDATE T12065 SET T_DELIVERY_MAN = '{devMan}' WHERE T_BLOOD_REQNO ={reqNo} and T_SITE_CODE = '{siteCode}'");
        }
        public bool updateT91( string canReason, string reqId)
        {
            return Command($"UPDATE T12091 SET T_REQ_CANCEL_REASON = '{canReason}',T_REQ_CANCEL_FLG ='1', T_REQ_CANCEL_TIME = TO_CHAR(SYSDATE,'HH24MI') WHERE T_REQ_ID = '{reqId}'");
        }
        public bool updateT92(string entryuser , string devMan)
        {
            Command($"UPDATE T12092 SET T_STATUS = '5' WHERE T_EMP_CODE = '{entryuser}'");
            return Command($"UPDATE T12092 SET T_STATUS = '1' WHERE T_EMP_CODE = '{devMan}'");
        }
        public bool updT65unassign(string reqId, string reqNo, string siteCode, string empCode)
        {            
             Command($"UPDATE T12091 SET T_REQ_CANCEL_FLG = '1', T_REQ_CANCEL_DATE = TRUNC(SYSDATE), T_REQ_CANCEL_TIME = TO_CHAR(SYSDATE,'HH24MI') WHERE T_REQ_ID = '{reqId}' AND T_BLOOD_REQ_NO='{reqNo}' AND T_EMP_CODE ='{empCode}'");
            Command($"UPDATE T12092 SET T_STATUS = '5' WHERE T_EMP_CODE = '{empCode}'");
            return Command($"UPDATE T12065 SET T_REQUEST_STATUS = '2' WHERE T_SITE_CODE = '{siteCode}' AND T_BLOOD_REQNO='{reqNo}'");
        }
       public bool UpdateActiveStatus(string entryuser)
        {            
            return Command($"UPDATE T12092 SET T_STATUS = '' WHERE T_EMP_CODE = '{entryuser}'");
        }
       
    }
}