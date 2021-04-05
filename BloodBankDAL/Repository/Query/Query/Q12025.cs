﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Query
{
    public class Q12025 : CommonDAL
    {
        public DataTable GetSiteData(string lang)
        {
            return Query($"SELECT T23.T_SITE_CODE,T65.T_LANG{lang}_NAME SITE_NAME FROM T02065 T65 JOIN T12223 T23 ON T65.T_SITE_CODE=T23.T_SITE_CODE GROUP BY T23.T_SITE_CODE, T65.T_LANG2_NAME");
        }

        public DataTable GetBloodGroupData(string lang)
        {
            return Query($"SELECT T_LANG{lang}_NAME T_BLOOD_NAME,T_ABO_CODE BLD_CODE FROM T12004 ORDER BY 1");

        }

        public DataTable GetProductData(string lang)
        {
            return Query($"SELECT T_PRODUCT_CODE,T_LANG{lang}_NAME PRODUCT_NAME FROM t12011 WHERE T_ACTIVE IS NOT NULL AND t_frequest is not null ORDER BY 1");
        }

        public DataTable GetStocktData(string lang, string donTiFrom, string donTiTo, string siteCode, string bloodGrp, string product)
        {
            return Query($"SELECT t23.T_BLOOD_GROUP_CODE, TO_CHAR(t23.T_DONATION_DATE,'dd-MM-yyyy') T_DONATION_DATE, TO_CHAR(t23.T_EXPIRY_DATE,'dd-MM-yyyy')T_EXPIRY_DATE,to_number(t23.T_EXPIRY_DATE - to_date('01-JAN-1970','DD-MON-YYYY')) * (24 * 60 * 60 * 1000)EXPER_MILLISECONDS, to_number(SYSDATE - to_date('01-JAN-1970','DD-MON-YYYY')) * (24 * 60 * 60 * 1000) NEW_MILLISECONDS, t23.T_PRODUCT_CODE,  t23.T_SITE_CODE,  t65.T_LANG2_NAME SITE_NAME,  t23.T_UNIT_NO,t23.T_UNIT_NO T_UNIT_TYPE,  t23.T_USED_FLG,  t63.RH_KELL,  t63.RH_PHENO, t63.T_ANTIBODY, t63.T_DU,t19.T_NOTES FROM t12223 t23 JOIN T02065 t65 ON t23.T_SITE_CODE = t65.T_SITE_CODE LEFT JOIN T12163 t63 ON t23.T_UNIT_NO = t63.T_UNIT_NO LEFT JOIN T12019 t19 ON t23.T_UNIT_NO = t19.T_UNIT_NO WHERE ( t23.t_donation_date BETWEEN NVL ('{donTiFrom}', t23.t_donation_date) AND NVL ('{donTiTo}', t23.t_donation_date) AND t23.t_site_code    = NVL ('{siteCode}', t23.t_site_code)AND t23.T_BLOOD_GROUP_CODE = NVL ('{bloodGrp}', t23.T_BLOOD_GROUP_CODE)AND t23.T_PRODUCT_CODE     = NVL ('{product}', t23.T_PRODUCT_CODE) ) AND  TO_DATE(t23.T_EXPIRY_DATE,'dd-MM-yyyy') > TO_DATE(SYSDATE,'dd-MM-yyyy') GROUP BY t23.T_BLOOD_GROUP_CODE,t23.T_DONATION_DATE,t23.T_EXPIRY_DATE,t23.T_PRODUCT_CODE,  t23.T_SITE_CODE,  t65.T_LANG2_NAME,  t23.T_UNIT_NO,  t23.T_USED_FLG,  t63.RH_KELL,  t63.RH_PHENO, t63.T_ANTIBODY, t63.T_DU,t19.T_NOTES ORDER BY T_UNIT_NO DESC");
            // return Query($"SELECT T_BLOOD_GROUP_CODE,to_char(T_DONATION_DATE,'dd-MM-yyyy') T_DONATION_DATE,to_char(T_EXPIRY_DATE,'dd-MM-yyyy')T_EXPIRY_DATE,T_PRODUCT_CODE,t23.T_SITE_CODE,t65.T_LANG{lang}_NAME SITE_NAME, t23.T_UNIT_NO,  T_USED_FLG,  t63.RH_KELL,  t63.RH_PHENO, t63.T_ANTIBODY, t63.T_DU FROM t12223 t23 JOIN T02065 t65 ON t23.T_SITE_CODE = t65.T_SITE_CODE LEFT JOIN T12163 t63 ON t23.T_UNIT_NO = t63.T_UNIT_NO WHERE ( t_donation_date BETWEEN NVL ('{donTiFrom}', t_donation_date) AND NVL ('{donTiTo}', t_donation_date)AND t23.t_site_code = NVL ('{siteCode}', t23.t_site_code)AND T_BLOOD_GROUP_CODE = NVL ('{bloodGrp}', T_BLOOD_GROUP_CODE)AND T_PRODUCT_CODE = NVL ('{product}', T_PRODUCT_CODE) )");
        }
    }
}