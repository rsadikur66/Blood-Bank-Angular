using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12309:CommonDAL
    {
        public DataTable GetUnitData()
        {
          return  Query($"select distinct t23.T_UNIT_NO,t23.T_PRODUCT_CODE from T12256 t56 JOIN T12223 t23 on t56.T_BB_STOCK_ID = t23.T_BB_STOCK_ID");
        }

        public DataTable GetProductDetails(string unitNo, string prodCode, string lang)
        {
            return Query($"SELECT t56.T_AUTO_ISSUE_DET_ID, t56.T_DONOR_NO, TO_CHAR(t56.T_EXPIRY_DATE,'DD-MON-YYYY')T_EXPIRY_DATE, TO_CHAR(t56.T_ISSUE_DATE, 'DD-MON-YYYY')T_ISSUE_DATE, t56.T_ISSUE_TIME, t56.T_SITE_CODE, t56.T_AUTO_ISSUE_ID, t56.T_UNIT_STATUS , t23.T_UNIT_NO, t23.T_PRODUCT_CODE, t11.T_LANG{lang}_NAME PRODUCT_NAME, t13.T_PAT_NO,t01.T_FIRST_LANG2_NAME ||' '||t01.T_FATHER_LANG2_NAME ||' '||t01.T_GFATHER_LANG2_NAME ||' '|| t01.T_FAMILY_LANG2_NAME PAT_NAME, trunc(months_between(sysdate,t01.T_BIRTH_DATE)/12) YEAR, trunc(mod(months_between(sysdate,t01.T_BIRTH_DATE),12)) MONTH, trunc(sysdate-add_months(t01.T_BIRTH_DATE,trunc(months_between(sysdate,t01.T_BIRTH_DATE)/12)*12+trunc(mod(months_between(sysdate,t01.T_BIRTH_DATE),12)))) DAY, t13.T_REQUEST_NO, t12.T_REQUEST_DATE, t01.T_BIRTH_DATE, t01.T_BIRTH_PLACE, t01.T_MRTL_STATUS, t01.T_GENDER, t01.T_NTNLTY_CODE, t06.T_LANG{lang}_NAME GENDER, t07.T_LANG{lang}_NAME MARL_STATUS_NAME, t03.T_LANG{lang}_NAME NATIONALITY, t42.T_LANG{lang}_NAME LOCATION_NAME, t12.T_LOCATION_CODE FROM T12256 t56 JOIN T12223 t23 ON t56.T_BB_STOCK_ID = t23.T_BB_STOCK_ID JOIN T12011 t11 ON t23.T_PRODUCT_CODE = t11.T_PRODUCT_CODE JOIN T12013 t13 ON t56.T_AUTO_ISSUE_ID = t13.T_AUTO_ISSUE_ID JOIN T03001 t01 ON t13.T_PAT_NO = t01.T_PAT_NO JOIN T02006 t06 ON t01.T_GENDER =t06.T_SEX_CODE JOIN T02007 t07 ON t01.T_MRTL_STATUS =t07.T_MRTL_STATUS_CODE JOIN T02003 t03 ON t01.T_NTNLTY_CODE =t03.T_NTNLTY_CODE JOIN T12012 t12 ON t13.T_REQUEST_NO =t12.T_REQUEST_NO JOIN T02042 t42 ON t12.T_LOCATION_CODE =t42.T_LOC_CODE WHERE t23.T_UNIT_NO ='{unitNo}' AND t23.T_PRODUCT_CODE = '{prodCode}' AND t23.T_USED_FLG ='1' AND t56.T_ISSUE_FLAG is null ");
        }

        public string SaveData(M12309 t12309, string user, string siteCode)
        {
            string sms = "";
            if (Command($"UPDATE T12256 SET T_TRANSFUSED_YN = '', T_UNIT_RETURNBB_YN = '1', T_CANCEL_BY ='{user}', T_CANCEL_DATE = TRUNC(SYSDATE), T_CANCEL_TIME = TO_CHAR(SYSDATE, 'HH:MI') WHERE T_AUTO_ISSUE_DET_ID = {t12309.T_AUTO_ISSUE_DET_ID}"))
            {
                sms = "Save Successfully";
            }
           ;
            
                return sms;
        }
    }
}