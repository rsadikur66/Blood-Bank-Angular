using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12241 : CommonDAL
    {
        public CommonDAL _commonDal = new CommonDAL();

        //public DataTable GridResultVirology(string UnitNoFrom, string UnitNoTo,string lang,string siteCode)
        //{
        //    return Query($"SELECT DISTINCT b.t_entry_user T_EMP_CODE,(select t01009.t_user_name{lang} from t01009 where t01009.t_emp_code = b.t_entry_user) T_USER_NAME, a.T_UNIT_NO, a.T_SEGMENT_NO, to_char(a.T_DONATION_DATE,'dd-MM-yyyy') T_DONATION_DATE, b.T_POS,b.T_NEG_VERIFY,b.T_NEG_VARIFY_BY, (select T_USER_NAME{lang} from t01009 where t_emp_code = b.T_NEG_VARIFY_BY) T_NEG_VARIFY_BY_NAME FROM T12022 a JOIN t12034 b ON a.T_UNIT_NO = b.T_UNIT_NO WHERE  a.T_UNIT_NO BETWEEN '{UnitNoFrom}' AND '{UnitNoTo}' AND b.T_POS is null AND a.t_unit_no NOT IN (SELECT t12034.t_unit_no from t12034 where t12034.T_POS = '1')");
        //}

        public DataTable GridResultVirology(string UnitNoFrom, string UnitNoTo, string lang, string siteCode)
        {
            return Query($"SELECT DISTINCT a.T_REQUEST_ID,c.T_SITE_CODE,b.t_entry_user T_EMP_CODE,(select t01009.t_user_name{lang} from t01009 where t01009.t_emp_code = b.t_entry_user) T_USER_NAME, a.T_UNIT_NO, a.T_SEGMENT_NO, to_char(a.T_DONATION_DATE,'dd-MM-yyyy') T_DONATION_DATE, b.T_POS,b.T_NEG_VERIFY,b.T_NEG_VARIFY_BY, (select T_USER_NAME{lang} from t01009 where t_emp_code = b.T_NEG_VARIFY_BY) T_NEG_VARIFY_BY_NAME FROM T12022 a JOIN t12034 b ON a.T_UNIT_NO = b.T_UNIT_NO JOIN T12017 c ON a.T_REQUEST_ID = c.T_REQUEST_ID WHERE a.T_UNIT_NO BETWEEN '{UnitNoFrom}' AND '{UnitNoTo}' AND b.T_POS is null AND a.t_unit_no NOT IN (SELECT t12034.t_unit_no from t12034 where t12034.T_POS = '1') AND c.T_SITE_CODE = '{siteCode}'");
        }
        public DataTable DocEmpCode(string usercode)
        {
            return Query($"SELECT t12031.T_EMP_CODE,t01009.T_USER_NAME FROM t12031 JOIN t01009 ON t12031.t_emp_code = t01009.t_emp_code WHERE t12031.t_emp_code = '{usercode}'");
            //return Query($"SELECT t12031.T_EMP_CODE,t01009.T_USER_NAME FROM t12031 JOIN t01009 ON t12031.t_emp_code = t01009.t_emp_code WHERE t12031.t_emp_code = 'D520'");
        }
        
        public DataTable GetUnitPopUpData()
        {
            return Query($"SELECT DISTINCT T_UNIT_NO CODE FROM T12034 WHERE T_UNIT_NO NOT IN (SELECT T12034.T_UNIT_NO FROM T12034 WHERE T12034.T_POS = '1') ORDER BY T_UNIT_NO");
            
        }
        
        public bool updateVirologyResults(string user, string unitNo,string siteCode)
        {
            Command($"UPDATE t12075 SET T_VIROLOGY_RESULT = '1',T_UPD_USER ='{user}',T_UPD_DATE =TRUNC(SYSDATE),T_VIROLOGY_RESULT_BY='{user}', T_VIROLOGY_RESULT_DATE=TRUNC(SYSDATE) WHERE T_UNIT_NO ='{unitNo}'");

            Command($"UPDATE t12019 SET T_VIOROLOGY_RESULT='1',T_VIRO_TIME=TO_CHAR(SYSDATE,'HH24MI'),T_VIROLOGY_BY='{user}' WHERE t_unit_no ='{unitNo}'");

            Command($"UPDATE t12034 SET T_NEG_VERIFY ='1',T_NEG_VARIFY_BY='{user}',T_NEG_VARIFY_DATE=TRUNC(SYSDATE) WHERE t_unit_no ='{unitNo}'");

            DataTable dt = new DataTable();
            dt = Query(
                $"SELECT T_UNIT_NO,T_ABO_CODE,TO_CHAR(T_DONATION_DATE,'MM/dd/yyyy')T_DONATION_DATE,TO_CHAR(T_EXPIRY_DATE,'MM/dd/yyyy')T_EXPIRY_DATE,T_PRODUCT_CODE FROM T12019 WHERE T_UNIT_NO = '{unitNo}'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var productCode = dt.Rows[i]["T_PRODUCT_CODE"].ToString();
                var bloodGroupCode = dt.Rows[i]["T_ABO_CODE"].ToString();
                var donationDate = dt.Rows[i]["T_DONATION_DATE"].ToString();
                var expiryDate = dt.Rows[i]["T_EXPIRY_DATE"].ToString();
                Command($"INSERT INTO T12223 (T_ENTRY_USER,T_ENTRY_DATE,T_BB_STOCK_ID,T_UNIT_NO,T_PRODUCT_CODE,T_BLOOD_GROUP_CODE,T_DONATION_DATE,T_EXPIRY_DATE,T_BLOOD_STATUS,T_SITE_CODE) VALUES ('{user}',TRUNC(SYSDATE),(SELECT NVL(MAX(T_BB_STOCK_ID),0)+1 T_BB_STOCK_ID FROM T12223),'{unitNo}','{productCode}','{bloodGroupCode}',TO_DATE('{donationDate}', 'MM/DD/YYYY'),TO_DATE('{expiryDate}', 'MM/DD/YYYY'),'1','{siteCode}')");

            }
            return true;
        }

        public bool InsertT12223(string user, string sitecode, string unitNo)
        {
            DataTable dt = new DataTable();
             dt = Query(
                $"SELECT T_UNIT_NO,T_ABO_CODE,TO_CHAR(T_DONATION_DATE,'MM/dd/yyyy')T_DONATION_DATE,TO_CHAR(T_EXPIRY_DATE,'MM/dd/yyyy')T_EXPIRY_DATE,T_PRODUCT_CODE FROM T12019 WHERE T_UNIT_NO = '{unitNo}'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var productCode = dt.Rows[i]["T_PRODUCT_CODE"].ToString();
                var bloodGroupCode = dt.Rows[i]["T_ABO_CODE"].ToString();
                var donationDate =  dt.Rows[i]["T_DONATION_DATE"].ToString();
                var expiryDate = dt.Rows[i]["T_EXPIRY_DATE"].ToString();
               
                Command($"INSERT INTO T12223 (T_ENTRY_USER,T_ENTRY_DATE,T_BB_STOCK_ID,T_UNIT_NO,T_PRODUCT_CODE,T_BLOOD_GROUP_CODE,T_DONATION_DATE,T_EXPIRY_DATE,T_BLOOD_STATUS,T_SITE_CODE) VALUES ('{user}',TRUNC(SYSDATE),(SELECT NVL(MAX(T_BB_STOCK_ID),0)+1 T_BB_STOCK_ID FROM T12223),'{unitNo}','{productCode}','{bloodGroupCode}',TO_DATE('{donationDate}', 'MM/DD/YYYY'),TO_DATE('{expiryDate}', 'MM/DD/YYYY'),'1','{sitecode}')");
                
            }

            return true;
        }
    }
}