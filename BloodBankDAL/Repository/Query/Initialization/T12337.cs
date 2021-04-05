using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace BloodBankDAL.Repository.Query.Initialization
{
    public class T12337 : CommonDAL
    {
        public DataTable GetZoneList(string lang)
        {
            return Query($"select T_ZONE_CODE CODE, T_LANG{lang}_NAME NAME from t02064");
        }

        public DataTable GetBankTypeList(string lang)
        {
            return Query($"select T_HOSP_CODE,T_LANG{lang}_NAME BANK_TYPE_NAME from t02048");
        }

        public DataTable GetSiteList(string lang)
        {
            return Query($"SELECT T_REFERRAL_CODE CODE, T_LANG{lang}_NAME NAME FROM T02049");
        }
        public DataTable GetGridListData()
        {
            return Query($"Select T_BANK_CODE T_SITE_CODE,T_LANG2_NAME ,T_LANG1_NAME,T_BANK_TYPE,T_REORDER_NO,T_EXPIRE_DATE_NO,T_BANK_TEL,T_BANK_MGR,T_MGR_MOBILE_NO,T_BANK_ACTIVE from t12337");
        }



        public bool InsertToT12337(M12337 t12337, string user, string siteCode)
        {
            Command(
                    $"insert into t12337(T_ENTRY_USER,T_ENTRY_DATE,T_ZONE_CODE,T_BANK_CODE,T_LANG2_NAME,T_LANG1_NAME,T_BANK_TYPE,T_BANK_TEL,T_BANK_MGR,T_BANK_ACTIVE,T_MGR_MOBILE_NO,T_EXPIRE_DATE_NO,T_REORDER_NO,T_SITE_CODE) values ('{user}',trunc(sysdate),'{t12337.T_ZONE_CODE}','{t12337.BankCode}','{t12337.BankNameEng}','{t12337.BankNameArb}','{t12337.BankType1}','{t12337.BankTelephn}','{t12337.BankManager}','{t12337.T_ACTIVE}','{t12337.MobileNo}','{t12337.Expiry}','{t12337.Reorder}','{siteCode}')");
            return true;
        }
        public DataTable CheckExistOrNot(M12337 t12337)
        {
            return Query($"select * from t12337 where t_zone_code='{t12337.T_ZONE_CODE}' and t_bank_code='{t12337.BankCode}' and T_BANK_TYPE='{t12337.BankType1}'");
        }

        public bool UpdateToT12337(M12337 t12337, string user, string siteCode)
        {
            Command($"UPDATE t12337 SET T_BANK_TYPE='{t12337.BankType1}',T_BANK_TEL='{t12337.BankTelephn}',T_BANK_MGR='{t12337.BankManager}',T_BANK_ACTIVE = '{t12337.T_ACTIVE}',T_MGR_MOBILE_NO='{t12337.MobileNo}',T_EXPIRE_DATE_NO= '{t12337.Expiry}',T_REORDER_NO='{t12337.Reorder}' WHERE T_BANK_CODE='{t12337.BankCode}' AND T_ZONE_CODE = '{t12337.T_ZONE_CODE}'");
            return true;
        }


        //public DataTable GetHospitalList(string zoneCode)
        //{
        //    return Query($"SELECT t65.T_SITE_CODE,t65.T_LANG1_NAME,t65.T_LANG2_NAME,t37.T_BANK_TYPE,t37.T_BANK_TEL,t37.T_BANK_MGR,t37.T_MGR_MOBILE_NO,t37.T_EXPIRE_DATE_NO,t37.T_REORDER_NO,t37.T_BANK_ACTIVE from t12337 t37 RIGHT JOIN t02065 t65 on t37.t_bank_code = t65.T_SITE_CODE where t65.t_zone_code ='{zoneCode}' ORDER BY t65.T_SITE_CODE");
        //}


        //public DataTable GetHospitalList(string zoneCode)
        //{
        //    return Query(
        //        $"SELECT t65.T_SITE_CODE,t65.T_LANG1_NAME,t65.T_LANG2_NAME,t37.T_BANK_TYPE,t37.T_BANK_TEL,t37.T_BANK_MGR,t37.T_MGR_MOBILE_NO,t37.T_EXPIRE_DATE_NO,t37.T_REORDER_NO,t37.T_BANK_ACTIVE FROM t12337 t37 RIGHT JOIN t02065 t65 ON t37.t_bank_code    = t65.T_SITE_CODE WHERE t65.t_zone_code ='{zoneCode}' and t65.T_SITE_CODE in (select t_site_code from t01009) ORDER BY t65.T_SITE_CODE");
        //}
    }
}