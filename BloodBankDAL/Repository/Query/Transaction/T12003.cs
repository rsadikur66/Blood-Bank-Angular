using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12003:CommonDAL
    {
        public DataTable GetHospitalListData()
        {
            return Query($"SELECT T_LANG2_NAME NAME,T_LANG1_NAME, T_BB_CODE CODE FROM T12003");
        }

        public DataTable GetProductWithUnitNo(string unitNo)
        {
            return Query($"SELECT T_UNIT_NO,T_PRODUCT_CODE,T_BLOOD_GROUP,T_EXPIRY_DATE FROM T12019 WHERE T_UNIT_NO = '{unitNo}' AND T_VIOROLOGY_RESULT ='1'");
        }
        
        public DataTable GetProductListData(string unitNo)
        {
            return Query($"SELECT T_PRODUCT_CODE NAME,T_ABO_CODE,T_EXPIRY_DATE FROM T12019 WHERE T_UNIT_NO = '{unitNo}' AND T_VIOROLOGY_RESULT ='1'");
        }
    }
}