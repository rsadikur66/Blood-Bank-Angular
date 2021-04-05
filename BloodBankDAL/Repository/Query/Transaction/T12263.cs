﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12263 : CommonDAL
    {
        public DataTable GetSiteList(string siteCode, string refCode, string lang)
        {
            
            //Ruhul 
            

           

          //  return Query($@"SELECT t12065.T_BLOOD_REQNO T_REQNO, t12065.T_NUM_UNIT, t12065.T_BLOOD_GRP, t12065.T_BLOOD_REQDATE, t12065.T_BLOOD_REQTIME, t12065.T_PRODUCT_CODE, t12065.T_REF_HOSP, t12065.T_BB_RECEIVED_DATE, t12065.T_BB_RECEIVED_TIME, t12065.T_BB_HANDOVER_DATE, t12065.T_BB_HANDOVER_TIME,T12091.T_REQ_ACCEPT_FLG, T12091.T_REQ_ACCEPT_DATE, T12091.T_REQ_ACCEPT_TIME,T12065.T_DELIVERY_MAN,  T01009.T_USER_NAME, T_67.T_BB_ISSUED_DATE, T_67.T_BB_ISSUED_TIME, T_2.* FROM ( SELECT DISTINCT T_BILL_SOFT_CODE, NAME, CODE, TRANS_LAT, TRANS_LNG, CNTR_LAT, CNTR_LNG, T_CENTRAL_BANK_CODE FROM (SELECT t49.T_BILL_SOFT_CODE , t38.T_LANG2_NAME NAME, t38.T_BANK_CODE CODE, t65.T_LATITUDE TRANS_LAT, t65.T_LONGITUDE TRANS_LNG, t65C.T_LATITUDE CNTR_LAT, t65C.T_LONGITUDE CNTR_LNG, T_CENTRAL_BANK_CODE FROM T12338 t38 LEFT JOIN t02049 t49 ON t38.T_BANK_CODE=t49.T_REFERRAL_CODE LEFT JOIN t02065 t65 ON t49.T_BILL_SOFT_CODE = t65.T_SITE_CODE LEFT JOIN t02065 t65C ON t65C.T_SITE_CODE ='{siteCode}' WHERE T_CENTRAL_BANK_CODE='{refCode}' AND T_BANK_ACTIVE ='1' )T_1 JOIN T12065 ON T_1.T_CENTRAL_BANK_CODE =T12065.T_REF_HOSP AND T_1.CODE =T12065.T_SITE_CODE WHERE T12065.T_REQUEST_STATUS IN ('2','3') ) T_2 JOIN T12065 ON T_2.T_CENTRAL_BANK_CODE =T12065.T_REF_HOSP LEFT JOIN T12091 ON T12065.T_BLOOD_REQNO =T12091.T_BLOOD_REQ_NO AND T12065.T_SITE_CODE = T12091.T_SITE_CODE LEFT JOIN T01009 ON T12065.T_DELIVERY_MAN =T01009.T_EMP_CODE LEFT JOIN (SELECT DISTINCT T_BLOOD_REQNO, T_BB_ISSUED_DATE, T_BB_ISSUED_TIME FROM T12067 ) T_67 ON T12065.T_BLOOD_REQNO =T_67.T_BLOOD_REQNO WHERE T_REF_HOSP ='{refCode}' AND T_REQUEST_STATUS IN ('2','3') AND T12091.T_REQ_CANCEL_FLG IS NULL ORDER BY t12065.T_BLOOD_REQNO DESC");


            return Query($@"SELECT DISTINCT T12091.T_REQ_ACCEPT_FLG, T12091.T_REQ_ACCEPT_DATE, T12091.T_REQ_ACCEPT_TIME,T12091.T_BLOOD_RCVD_DATE,T12091.T_BLOOD_RCVD_TIME,   T12091.T_BLOOD_RCVD_FLG,T01009.T_USER_NAME, T_67.T_BB_ISSUED_DATE, T_67.T_BB_ISSUED_TIME, T_2.* FROM ( SELECT DISTINCT T_BILL_SOFT_CODE, NAME, CODE, TRANS_LAT, TRANS_LNG, CNTR_LAT, CNTR_LNG, T_CENTRAL_BANK_CODE, T12065.T_BLOOD_REQNO T_REQNO, T12065.T_NUM_UNIT, T12065.T_BLOOD_GRP, T12065.T_BLOOD_REQDATE, T12065.T_BLOOD_REQTIME, T12065.T_PRODUCT_CODE, T12065.T_REF_HOSP, T12065.T_BB_RECEIVED_DATE, T12065.T_BB_RECEIVED_TIME, T12065.T_BB_HANDOVER_DATE, T12065.T_BB_HANDOVER_TIME, T12065.T_DELIVERY_MAN, T12065.T_REQUEST_STATUS, T12065.T_SITE_CODE FROM (SELECT t49.T_BILL_SOFT_CODE , t38.T_LANG2_NAME NAME, t38.T_BANK_CODE CODE, t65.T_LATITUDE TRANS_LAT, t65.T_LONGITUDE TRANS_LNG, t65C.T_LATITUDE CNTR_LAT, t65C.T_LONGITUDE CNTR_LNG, T_CENTRAL_BANK_CODE FROM T12338 t38 LEFT JOIN t02049 t49 ON t38.T_BANK_CODE=t49.T_REFERRAL_CODE LEFT JOIN t02065 t65 ON t49.T_BILL_SOFT_CODE = t65.T_SITE_CODE LEFT JOIN t02065 t65C ON t65C.T_SITE_CODE ='{siteCode}' WHERE T_CENTRAL_BANK_CODE='{refCode}' AND T_BANK_ACTIVE ='1' )T_1 JOIN T12065 ON T_1.T_CENTRAL_BANK_CODE =T12065.T_REF_HOSP AND T_1.CODE =T12065.T_SITE_CODE WHERE T12065.T_REQUEST_STATUS IN ('2','3') ) T_2 LEFT JOIN T12091 ON T_2.T_REQNO =T12091.T_BLOOD_REQ_NO AND T_2.T_SITE_CODE = T12091.T_SITE_CODE LEFT JOIN T01009 ON T_2.T_DELIVERY_MAN =T01009.T_EMP_CODE LEFT JOIN (SELECT DISTINCT T_BLOOD_REQNO, T_BB_ISSUED_DATE, T_BB_ISSUED_TIME,T_SITE_CODE FROM T12067 ) T_67 ON T_2.T_REQNO =T_67.T_BLOOD_REQNO AND T_2.T_SITE_CODE=T_67.T_SITE_CODE  WHERE T_2.T_REF_HOSP ='{refCode}' AND T_2.T_REQUEST_STATUS IN ('2','3') AND T12091.T_REQ_CANCEL_FLG IS NULL ORDER BY to_char(T_2.t_blood_reqdate,'yyyyMMdd')||T_2.t_blood_reqtime DESC,T_2.T_SITE_CODE, t_2.t_reqno DESC");
        }
        public DataTable GetRequestedData(string siteCode, string requestNo)
        {
            return Query($"SELECT T_BLOOD_REQNO,T_NUM_UNIT,T_BLOOD_GRP,T_BLOOD_REQDATE,T_BLOOD_REQTIME,T_PRODUCT_CODE from t12065 where T_BLOOD_REQNO = '{requestNo}' and T_SITE_CODE='{siteCode}'");
        }
        public DataTable GetRequestList(string siteCode, string refCode)
        {
            return Query($"SELECT T_BLOOD_REQNO CODE,T_NUM_UNIT,T_BLOOD_GRP,T_BLOOD_REQDATE,T_BLOOD_REQTIME,T_PRODUCT_CODE from t12065 where T_SITE_CODE='{siteCode}' and T_REF_HOSP='{refCode}' and T_REQUEST_STATUS='2' ");
        }
        public DataTable GetGridData(string bldGrp, string proCode, string empCode, string userName)
        {
            //return Query($"SELECT T_UNIT_NO,T_PRODUCT_CODE,T_ABO_CODE,T_EXPIRY_DATE,'{empCode}' T_EMP_CODE,'{userName}' T_USER_NAME FROM T12019 WHERE T_ABO_CODE='{bldGrp}' AND T_PRODUCT_CODE='{proCode}' AND T_VIOROLOGY_RESULT='1' ORDER BY T_EXPIRY_DATE");
            return Query($@"SELECT T_UNIT_NO, T_PRODUCT_CODE,T_ABO_CODE, T_BLOOD_BAG_GROUP, T_EXPIRY_DATE,'{empCode}' T_EMP_CODE,'{userName}' T_USER_NAME FROM T12019 WHERE T_EXPIRY_DATE >= TRUNC(SYSDATE) AND T_PRODUCT_CODE = '{proCode}' AND T_ABO_CODE = '{bldGrp}' AND T_VIOROLOGY_RESULT = '1' AND T_UNIT_STATUS IS NULL ORDER BY T_EXPIRY_DATE,T_UNIT_NO DESC");
        }
        public DataTable CrossmatchCheck(string reqNo, string bldGrp, string proCode)
        {
            return Query($"SELECT * FROM T12065 WHERE T_BLOOD_REQNO='{reqNo}' AND T_PRODUCT_CODE='PRBC' AND T_BLOOD_GRP='ABN' AND T_CROSSMATCH_FLAG='1'");
        }

        public bool T12067Check(M12263 t12263, string siteCode)
        {
            //Command(
            //    $"SELECT* FROM T12067, T12121 WHERE T12121.T_EMP_CODE = T12067.T_BB_ISSUED_BY AND T12067.T_BLOOD_REQNO = '{t12263.T_BLOOD_REQNO}' AND T12067.T_UNIT_NO = '{t12263.T_UNIT_NO}' AND T12067.T_PRODUCT_CODE = '{t12263.T_PRODUCT_CODE}' AND T12067.T_BLOOD_GRP = '{t12263.T_BLOOD_GRP}' AND T12067.T_SITE_CODE = '{siteCode}' AND T12067.T_ZONE_CODE = '{ZoneCode}'");

            return Query($@"SELECT * FROM T12067, T01009 WHERE T01009.T_EMP_CODE = T12067.T_BB_ISSUED_BY AND T12067.T_BLOOD_REQNO = '{t12263.T_BLOOD_REQNO}' AND T12067.T_UNIT_NO = '{t12263.T_UNIT_NO}' AND
                T12067.T_PRODUCT_CODE = '{t12263.T_PRODUCT_CODE}' AND T12067.T_BLOOD_GRP = '{t12263.T_BLOOD_GRP}' AND T12067.T_SITE_CODE = '{t12263.T_SITE_CODE}'").Rows.Count > 0;

        }

        public bool checkT91(M12263 m12263)
        {
            return Query($"SELECT * FROM T12091 WHERE T_BLOOD_REQ_NO ='{m12263.T_BLOOD_REQNO}' AND T_REQ_CANCEL_FLG ='1'").Rows.Count > 0;
        }

        public bool T12263insertT12067(M12263 t12263, string user, string siteCode)
        {
            Command(
                $"INSERT INTO T12067 (T_ENTRY_USER,T_ENTRY_DATE,T_BLOOD_GRP,T_PRODUCT_CODE,T_BLOOD_REQNO,T_UNIT_NO,T_BB_ISSUED_BY,T_BB_ISSUED_DATE,T_BB_ISSUED_TIME,T_BLOOD_EXPIRY_DATE,T_SITE_CODE) VALUES ('{user}',Trunc(sysdate), '{t12263.T_BLOOD_GRP}', '{t12263.T_PRODUCT_CODE}', '{t12263.T_BLOOD_REQNO}', '{t12263.T_UNIT_NO}', '{t12263.T_BB_ISSUED_BY}',Trunc(sysdate),TO_CHAR(SYSDATE,'HH24MI'),TO_DATE('{t12263.T_BLOOD_EXPIRY_DATE}','DD/MM/YYYY'),'{t12263.T_SITE_CODE}')");
            return true;
        }


        public bool UpdateT12019(M12263 t12263)
        {
            return Command($@"UPDATE T12019 SET T_SENT_OUTSIDE_FLAG = '1', T_UNIT_STATUS = '9' WHERE T_UNIT_NO = '{t12263.T_UNIT_NO}' AND T_ABO_CODE = '{t12263.T_BLOOD_GRP}' AND T_PRODUCT_CODE = '{t12263.T_PRODUCT_CODE}'");
        }

        public bool UpdateT12065(M12263 t63, string T_REQUEST_STATUS)
        {
            return Command($@"UPDATE T12065 SET T_REQUEST_STATUS = '{T_REQUEST_STATUS}',T_COURIER_CODE='{t63.T_COURIER_CODE}',T_TRACKING_NO='{t63.T_TRACKING_NO}',T_ESTIMATED_DELIVERY_TIME='{t63.T_ESTIMATED_DELIVERY_TIME}',T_DELIVERY_MAN='{t63.T_DELIVERY_MAN}',T_ESTIMATION_TYPE='{t63.T_ESTIMATION_TYPE}' WHERE T_BLOOD_REQNO = '{t63.T_BLOOD_REQNO}' AND T_SITE_CODE = '{t63.T_SITE_CODE}'");
        }
        public bool InsertT12091(M12263 t12263, string user)
        {
            var max = Query($"SELECT MAX(TO_NUMBER(T_REQ_ID))+1 ID FROM T12091").Rows[0]["ID"].ToString();
            Command($@"UPDATE T12092 SET T_STATUS = '1' WHERE T_EMP_CODE = '{t12263.T_DELIVERY_MAN}'");
            Command(
                $"INSERT INTO T12091(T_REQ_ID,T_ENTRY_USER,T_ENTRY_DATE,T_ENTRY_TIME,T_BLOOD_REQ_NO,T_SITE_CODE,T_EMP_CODE,T_ESTIMATED_DELIVERY_DIST,T_ESTIMATED_DELIVERY_TIME) VALUES ('{max}','{user}',Trunc(sysdate),TO_CHAR(SYSDATE,'HH24MI'), '{t12263.T_BLOOD_REQNO}', '{t12263.T_SITE_CODE}','{t12263.T_DELIVERY_MAN}','{t12263.ESTIMATE_DISTANCE}','{t12263.ESTIMATE_TIME}')");
            return true;
        }

        public DataTable checkExistorNot()
        {
            return Query($"");
        }

        public DataTable GetCourierServiceData(string siteCode, string lang)
        {
            return Query($"SELECT T_COURIER_CODE,T_LANG{lang}_NAME COURIER_NAME FROM T30057 WHERE T_INACTIVE_STATUS IS NULL");
        }

        public DataTable GetdeliveryByData(string siteCode, string lang)
        {
            return Query("SELECT T_EMP_CODE, T_USER_NAME FROM T01009 WHERE T_ROLE_CODE = '0044' AND T_ACTIVE_FLAG = '1'");
        }

        public DataTable GetDeliveryManLocation(string siteCode, string lang)
        {
            // return Query("SELECT T12092.T_EMP_CODE,T01009.T_USER_NAME, T_LATITUDE, T_LONGITUDE, T_LOGIN_STATUS FROM T12092 JOIN T01009 ON T12092.T_EMP_CODE =T01009.T_EMP_CODE WHERE T12092.T_LOGIN_STATUS = '1'");
            return Query($"Select T_SITE_CODE CODE, T_LANG2_NAME NAME,T_LATITUDE LAT,T_LONGITUDE LON from T02065 Where T_SITE_CODE ='{siteCode}' UNION ALL SELECT T12092.T_EMP_CODE CODE,T01009.T_USER_NAME NAME, T_LATITUDE LAT, T_LONGITUDE LON FROM T12092 JOIN T01009 ON T12092.T_EMP_CODE =T01009.T_EMP_CODE WHERE T12092.T_LOGIN_STATUS = '1' AND T12092.T_STATUS is null");
        }
    }
}