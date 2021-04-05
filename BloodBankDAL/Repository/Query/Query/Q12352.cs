using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Query
{
    public class Q12352:CommonDAL
    {
        internal DataTable GetChartData(string productCode)
        {
            return Query($"SELECT count(t_unit_no) v_cnt, T_ABO_CODE BLOOD_GROUP FROM t12019 WHERE t12019.t_UNIT_STATUS IS NULL AND t_product_code = '{productCode}' AND T_EXPIRY_DATE > TRUNC(SYSDATE) AND T_ABO_CODE IS NOT NULL AND T_VIOROLOGY_RESULT='1' GROUP BY T_PRODUCT_CODE, T_ABO_CODE");
        }
    }
}