using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12264 : CommonDAL
    {
        public DataTable GetDataWithRequestNo(string tReqNo,string siteCode,string empCode,string userName)
        {
            return Query($"SELECT T12065.T_BLOOD_REQNO,'{empCode}' T_EMP_CODE,'{userName}' T_USER_NAME, T12065.T_BLOOD_GRP T_BLOOD_GRP_REQ, T12065.T_PRODUCT_CODE T_PRODUCT_CODE_REQ, T12065.T_NUM_UNIT, T12065.T_BLOOD_REQDATE, T12065.T_BLOOD_REQTIME, T12067.T_BLOOD_GRP T_BLOOD_GRP, T12067.T_PRODUCT_CODE, T12067.T_UNIT_NO, T12067.T_BB_ISSUED_DATE, T12067.T_BB_ISSUED_TIME, T12067.T_BLOOD_EXPIRY_DATE, T12067.T_HOSP_RECEIVED_BY, T12067.T_HOSP_RECEIVED_FLAG, T12067.T_HOSP_RECEIVED_DATE, T12067.T_HOSP_RECEIVED_TIME,T12065.T_SITE_CODE from T12065 join t12067 on t12065.T_BLOOD_REQNO = t12067.T_BLOOD_REQNO LEFT join t01009 on T12067.T_HOSP_RECEIVED_BY = t01009.T_EMP_CODE where T12065.T_REQUEST_STATUS = '3' AND T12065.T_BLOOD_REQNO = '{tReqNo}' AND T12065.T_SITE_CODE = '{siteCode}'");
        }


        public bool T12264updateT12067(M12264 t12264, string user)
        {
            return Command(
                $"UPDATE T12067 SET T_HOSP_RECEIVED_FLAG = '{t12264.T_HOSP_RECEIVED_FLAG}', T_HOSP_RECEIVED_BY = '{t12264.T_HOSP_RECEIVED_BY}', T_HOSP_RECEIVED_DATE = TO_DATE('{t12264.T_HOSP_RECEIVED_DATE}','dd/mm/yyyy'), T_HOSP_RECEIVED_TIME = '{t12264.T_HOSP_RECEIVED_TIME}' WHERE T_UNIT_NO = '{t12264.T_UNIT_NO}' AND T_BLOOD_REQNO = '{t12264.T_BLOOD_REQNO}' AND T_SITE_CODE = '{t12264.T_SITE_CODE}'");
             
        }
        public bool T12264updateT12065(M12264 t12264, string user,string siteCode)
        {
            Command(
                $@"UPDATE T12065 SET T_REQUEST_STATUS = '{t12264.T_REQUEST_STATUS}' WHERE T_BLOOD_REQNO = '{t12264.T_BLOOD_REQNO}' AND T_SITE_CODE = '{siteCode}'");
            return true;
        }
    }
}