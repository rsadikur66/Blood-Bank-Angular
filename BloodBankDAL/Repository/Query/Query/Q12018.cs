using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Query
{
    public class Q12018:CommonDAL
    {
        public DataTable GetFirstGrid(string unitNo)
        {
            return Query($"SELECT DISTINCT t23.T_UNIT_NO, t23.T_BB_STOCK_ID, t56.T_AUTO_ISSUE_ID, t13.T_REQUEST_NO, t23.T_PRODUCT_CODE, t11.T_LANG2_NAME PRODUCT_DESC, t23.T_BLOOD_GROUP_CODE, TO_CHAR(t23.T_DONATION_DATE,'dd-MON-YYYY') T_DONATION_DATE, t23.T_BLOOD_STATUS , to_char(t23.T_EXPIRY_DATE,'dd-MON-YYYY') T_EXPIRY_DATE, t56.T_UNIT_STATUS, (SELECT t_lang2_name FROM t12106 t06 WHERE t06.t_status_id = t56.T_UNIT_STATUS AND t06.t_status_type = 1 ) unit_status,v13.T_TYPE,t56.T_BB_CODE,t03.T_LANG2_NAME HOSPITAL_NAME,to_char(t56.T_ISSUE_DATE,'dd-MON-yyyy') T_ISSUE_DATE from t12223 t23 join t12256 t56 on t23.T_BB_STOCK_ID = t56.T_BB_STOCK_ID join t12013 t13 on t56.T_AUTO_ISSUE_ID = t13.T_AUTO_ISSUE_ID join t12011 t11 on t23.T_PRODUCT_CODE = t11.T_PRODUCT_CODE join v12013 v13 on t23.T_UNIT_NO = v13.T_UNIT_NO LEFT join t12003 t03 on t56.T_BB_CODE = t03.T_BB_CODE where t23.T_UNIT_NO = {unitNo}");
        }

        public DataTable GetSecondGrid(string unitNo)
        {
            return Query($"SELECT DISTINCT t23.T_UNIT_NO, t23.T_BB_STOCK_ID, t56.T_AUTO_ISSUE_ID, t13.T_REQUEST_NO, t23.T_PRODUCT_CODE, t11.T_LANG2_NAME PRODUCT_DESC, t23.T_BLOOD_GROUP_CODE, TO_CHAR(t23.T_DONATION_DATE,'dd-MON-YYYY') T_DONATION_DATE, t23.T_BLOOD_STATUS , to_char(t23.T_EXPIRY_DATE,'dd-MON-YYYY') T_EXPIRY_DATE, t56.T_UNIT_STATUS, (SELECT t_lang2_name FROM t12106 t06 WHERE t06.t_status_id = t56.T_UNIT_STATUS AND t06.t_status_type = 1 ) unit_status,v13.T_TYPE,t56.T_BB_CODE,t03.T_LANG2_NAME HOSPITAL_NAME,to_char(t56.T_ISSUE_DATE,'dd-MON-yyyy') T_ISSUE_DATE from t12223 t23 join t12256 t56 on t23.T_BB_STOCK_ID = t56.T_BB_STOCK_ID join t12013 t13 on t56.T_AUTO_ISSUE_ID = t13.T_AUTO_ISSUE_ID join t12011 t11 on t23.T_PRODUCT_CODE = t11.T_PRODUCT_CODE join v12013 v13 on t23.T_UNIT_NO = v13.T_UNIT_NO LEFT join t12003 t03 on t56.T_BB_CODE = t03.T_BB_CODE where t23.T_UNIT_NO = {unitNo}");
        }
    }
}