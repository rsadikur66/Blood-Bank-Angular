using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12252:CommonDAL
    {
        public DataTable getGridData(string lang, string unitId)
        {
       return Query($"SELECT distinct t23.T_BB_STOCK_ID, t23.T_UNIT_NO, t23.T_SEQ_NO, t23.T_USED_FLG, TO_CHAR(t19.T_DONATION_DATE,'dd-MON-yyyy')DONATION_DATE , t04.T_LANG2_NAME T_BLOOD_GROUP, t19.T_VIOROLOGY_RESULT, t19.T_PRODUCT_CODE, t22.T_SEGMENT_NO , t19.T_ANTIBODY_1 FROM  T12019  t19 LEFT JOIN T12223  t23 ON t19.T_UNIT_NO = t23.T_UNIT_NO AND t19.T_PRODUCT_CODE = t23.T_PRODUCT_CODE LEFT JOIN T12022 t22 ON t23.T_UNIT_NO = t22.T_UNIT_NO LEFT JOIN T12004 t04 ON t23.T_BLOOD_GROUP_CODE = t04.T_ABO_CODE WHERE t19.T_UNIT_NO = '{unitId}' AND t19.T_PRODUCT_CODE IN ('PLT','CRYO')");
        }

        

        public bool UpdateT12223(T12223 t12223,string welId)
        {
            bool sms = false;
            //var T_POOL_SEQ = Query("SELECT  NVL(T_POOL_SEQ,0)+1 T_POOL_SEQ FROM T12035 WHERE T_HOSPITAL ='1' AND T_WS_CODE    ='12'");

            sms= Command($"UPDATE T12223  SET T_SEQ_NO = '{t12223.T_SEQ_NO}',T_WELD_ID = '{welId}' WHERE T_BB_STOCK_ID ={t12223.T_BB_STOCK_ID} ");

            //if (t23)
            //{
            //    sms = Command($"UPDATE T12035  SET T_SEQ_NO = '{T_POOL_SEQ}' WHERE T_HOSPITAL ='1' AND T_WS_CODE = '12'");
            //}
           
            return sms;
        }

        public bool updateT12035(object seq)
        {
            bool s = false;
            s=Command($"UPDATE T12035  SET T_POOL_SEQ = '{seq}' WHERE T_HOSPITAL ='1' AND T_WS_CODE = '12'");
            return s;
        }

        public DataTable pickUpData(string fdate, string tdate,string Seq, string lang)
        {
            return Query($"SELECT DISTINCT t23.T_BB_STOCK_ID, t23.T_UNIT_NO, t23.T_SEQ_NO, TO_CHAR(t19.T_DONATION_DATE,'dd-MON-yyyy')DONATION_DATE , t04.T_LANG2_NAME T_BLOOD_GROUP, t19.T_VIOROLOGY_RESULT, t19.T_PRODUCT_CODE, t23.T_WELD_ID, t22.T_SEGMENT_NO FROM T12223 t23 JOIN T12019 t19 ON t23.T_UNIT_NO = t19.T_UNIT_NO AND t23.T_PRODUCT_CODE=t19.T_PRODUCT_CODE JOIN T12022 t22 ON t23.T_UNIT_NO = t22.T_UNIT_NO JOIN T12004 t04 ON t23.T_BLOOD_GROUP_CODE = t04.T_ABO_CODE WHERE t23.T_SEQ_NO IS NOT NULL AND t19.T_PRODUCT_CODE IN ('PLT','CRYO') AND t19.T_DONATION_DATE BETWEEN '{fdate}' AND '{tdate}' OR T_SEQ_NO =UPPER('{Seq}')");
        }
    }
}