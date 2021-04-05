using BloodBankDAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12322:CommonDAL
    {

        public DataTable GetProductList()
        {
            return Query($"SELECT T_PRODUCT_CODE,T_EXPIRY_DAYS  FROM T12011 WHERE T_ACTIVE='1'  AND T_PRODUCT_CODE NOT IN ('NSFS','MTP')");
        }
        public DataTable GetReasonList(string lang)
        {
            return Query($"SELECT T_LANG{lang}_NAME NAME,T_REASON CODE FROM T12139 ORDER BY TO_NUMBER(T_REASON)");
        }
        public DataTable GetSingleUnit(string unit, string lang)
        {
            return Query($"SELECT DISTINCT T22.T_UNIT_NO T22T_UNIT_NO, T22.T_DONATION_DATE,T23.T_UNIT_NO T23T_UNIT_NO,T35.T_UNIT_NO T35T_UNIT_NO,T35.T_REASON,T39.T_LANG{lang}_NAME REASONNAME,T35.T_PROD_CODE,NVL(T11.T_EXPIRY_DAYS,0) T_EXPIRY_DAYS FROM T12022 T22 LEFT JOIN T12223 T23 ON T22.T_UNIT_NO=T23.T_UNIT_NO LEFT JOIN T12135 T35 ON T22.T_UNIT_NO=T35.T_UNIT_NO AND T35. T_PROD_CODE='NSFS' AND T35.T_UNIT_NO='{unit}' LEFT JOIN T12139 T39 ON T39.T_REASON=T35.T_REASON LEFT JOIN T12011 T11 ON T35.T_PROD_CODE=T11.T_PRODUCT_CODE WHERE T22.T_UNIT_NO='{unit}' OR (T23.T_UNIT_NO='{unit}' OR T23.T_SEQ_NO='{unit}')");
        }
        public string saveList(List<T12320> t23List, string user, string lang)
        {
            string uList = "";
            string msg = "";
            foreach (var item in t23List)
            {
                DataTable dt = Query($"Select * from T12320 where T_UNIT_NO='{item.T_UNIT_NO}' and T_PRODUCT_CODE='{item.T_PRODUCT_CODE}'");
                if (dt.Rows.Count>0)
                {
                    //uList += item.T_UNIT_NO + ",";
                    msg = "Record already exists";
                }
                else
                {
                    if (Command($"Insert into T12320 (T_UNIT_NO,T_PRODUCT_CODE,T_SELECTED,T_ENTRY_DATE,T_ENTRY_USER,T_REMARKS,T_EXPIRY_DATE,DONATION_DATE) values ('{item.T_UNIT_NO}','{item.T_PRODUCT_CODE}','{item.T_SELECTED}',trunc(sysdate),'{user}','{item.T_REMARKS}','{item.T_EXPIRY_DATE}','{item.DONATION_DATE}')"))
                    {
                        msg = "Data Saved Successfully";
                    }
                   
                }

            }
            //if (uList != "")
            //{

            //}






            return msg;
            
        }
    }
}