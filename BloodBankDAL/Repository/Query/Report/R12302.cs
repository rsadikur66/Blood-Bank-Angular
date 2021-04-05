﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Report
{
    public class R12302 : CommonDAL
    {
        public DataTable GetReport(string siteCode)
        {
            //return Query($"SELECT A.T_REQUEST_NO , A.T_PAT_NO,A.T_REQUEST_DATE,A.T_PAT_TYPE, A.T_LOCATION_CODE , B.T_RESULT_VALUE , B.T_CLOSE_FLAG , B.T_UPD_DATE , B.T_UPD_USER , B.T_ANALYSIS_CODE , C.T_LANG2_NAME, A.T_SITE_CODE, D.T_FIRST_LANG2_NAME||' '||D.T_FATHER_LANG2_NAME||' '||D.T_GFATHER_LANG2_NAME||' '||D.T_FAMILY_LANG2_NAME NAME, D.T_BIRTH_DATE, D.T_GENDER, E.T_COUNTRY_LANG1_NAME , E.T_COUNTRY_LANG2_NAME , E.T_MIN_LANG1_NAME , E.T_MIN_LANG2_NAME , E.T_SITE_LANG1_NAME , E.T_SITE_LANG2_NAME , E.T_LOGO_ID , E.T_LOGO_NAME , E.T_LOGO , E.t_lcence_no FROM T13015 A --JOIN T12012 E ON A.T_PAT_NO = E.T_PAT_NO JOIN T13018 B ON A.T_REQUEST_NO = B.T_REQUEST_NO JOIN T13006 C ON B.T_RESULT_VALUE = C.T_RESULT_CODE JOIN T03001 D ON A.T_PAT_NO = D.T_PAT_NO JOIN T01028 E ON A.T_SITE_CODE = E.T_SITE_CODE WHERE A.T_REQUEST_NO ='0006816548'");

            return Query($"select distinct t_request_no,t_pat_no,t_request_date,t_location_code,t_pat_type from v13181 where t_pat_no='00606286' AND T_SITE_CODE='{siteCode}' group by t_request_no,t_pat_no,t_request_date,t_location_code,t_pat_type order by 1");
        }

        public DataTable getR12065_Report(string patno)
        {
            return Query($"SELECT T23.T_UNIT_NO, T01.T_PAT_NO, T01.T_FIRST_LANG2_NAME ||' '||T_FATHER_LANG2_NAME ||' '||T_FAMILY_LANG2_NAME PAT_NAME, T12.T_ABO_CODE , T04.T_LANG2_NAME PAT_BLOOD_GROUP, T23.T_BLOOD_GROUP_CODE, T04.T_LANG2_NAME DONER_BLOOD_GROUP, T11.T_LANG2_NAME PRODUCT_DESCRIPTION FROM T12256 T56 INNER JOIN T12013 T13 ON T56.T_AUTO_ISSUE_ID=T13.T_AUTO_ISSUE_ID INNER JOIN T03001 T01 ON T13.T_PAT_NO = T01.T_PAT_NO INNER JOIN T12223 T23 ON T56.T_BB_STOCK_ID=T23.T_BB_STOCK_ID INNER JOIN T12012 T12 ON T13.T_REQUEST_NO = T12.T_REQUEST_NO INNER JOIN T12011 T11 ON T23.T_PRODUCT_CODE = T11.T_PRODUCT_CODE INNER JOIN T12004 T04 ON T23.T_BLOOD_GROUP_CODE = T04.T_ABO_CODE AND T12.T_ABO_CODE = T04.T_ABO_CODE where T13.T_PAT_NO ='{patno}'");
        }

        public DataTable GetSite(string siteCode)
        {
            return Query($"select T_SITE_CODE , T_COUNTRY_LANG1_NAME , T_COUNTRY_LANG2_NAME , T_MIN_LANG1_NAME , T_MIN_LANG2_NAME , T_SITE_LANG1_NAME , T_SITE_LANG2_NAME , T_LOGO_ID , T_LOGO_NAME , T_LOGO , t_lcence_no from t01028 where t_site_code ={siteCode}");
        }

        public DataTable GetPatInf()
        {
            return Query($"SELECT C.T_PAT_NO, C.T_FIRST_LANG2_NAME ||' ' ||C.T_FATHER_LANG2_NAME ||' ' ||C.T_GFATHER_LANG2_NAME ||' ' ||C.T_FAMILY_LANG2_NAME NAME, C.T_BIRTH_DATE, A.T_LANG2_NAME T_GENDER, B.T_LANG2_NAME T_NTNLTY_CODE , C.T_NTNLTY_ID, TRUNC(months_between(sysdate,C.T_BIRTH_DATE)/12) YEAR, TRUNC(mod(months_between(sysdate,C.T_BIRTH_DATE),12)) MONTH, TRUNC(sysdate-add_months(C.T_BIRTH_DATE,TRUNC(months_between(sysdate,C.T_BIRTH_DATE)/12)*12+ TRUNC(mod(months_between(sysdate,C.T_BIRTH_DATE),12)))) DAY FROM T03001 C JOIN T02003 B ON C.T_NTNLTY_CODE = B.T_NTNLTY_CODE JOIN T02006 A ON C.T_GENDER = A.T_SEX_CODE WHERE T_PAT_NO='00518286'");
        }

        public DataTable getPatInfo(string patno)
        {
            return Query(
                $"SELECT C.T_PAT_NO, c.T_FIRST_LANG2_NAME ||' ' ||c.T_FATHER_LANG2_NAME || ' ' || c.T_GFATHER_LANG2_NAME || ' ' || c.T_FAMILY_LANG2_NAME Patient_Name, C.T_BIRTH_DATE, C.T_GENDER, G.T_LANG2_NAME GENDER, C.T_NTNLTY_CODE, N.T_LANG2_NAME Nationality, C.T_NTNLTY_ID, tRUNC(MONTHS_BETWEEN(sysdate,C.T_BIRTH_DATE)/12)||'Y'||' '|| TRUNC(mod(months_between(sysdate,C.T_BIRTH_DATE),12))||'M'||' ' AGE  FROM T03001 C join T02006 G on C.T_GENDER = G.T_SEX_CODE JOIN T02003 N on C.T_NTNLTY_CODE = N.T_NTNLTY_CODE WHERE T_PAT_NO = '{patno}'");
        }
        public DataTable geHistoryData(string patno,string siteCode)
        {
            return Query(
                $"SELECT a.t_request_no, a.t_pat_no, c.T_BLOOD_GROUP_CODE, d.T_LANG2_NAME Blood_grp, c.T_UNIT_NO, d.T_LANG2_NAME Blood_BAG_grp, a.T_PRODUCT_CODE, b.T_IS, case when b.T_IS ='P' THEN 'POS' WHEN b.T_IS ='N' THEN 'NEG' end IS_STATUS, b.T_C, case when b.T_C='P' then 'POS' WHEN b.T_C='N' then 'NEG' end C, b.T_AHG , case when b.T_AHG='P' then 'POS' WHEN b.T_AHG='N' then 'NEG' end AHG, b.T_CCC, case when b.T_CCC='P' then 'POS' WHEN b.T_CCC='N' then 'NEG' end CCC, b.T_GEL_AHG , b.T_COMPATIBLE, CASE WHEN b.T_COMPATIBLE=1 THEN 'Compatible' WHEN b.T_COMPATIBLE=2 THEN 'Incompatible' WHEN b.T_COMPATIBLE=3 THEN 'Least Incompatible' WHEN b.T_COMPATIBLE=4 THEN 'Not Indicated' ELSE '' END Com_status, b.T_ENTRY_DATE, b.T_ENTRY_USER, e.T_USER_NAME FROM T12013 a, T12256 b, T12223 c, T12004 d, T01009 e WHERE a.t_pat_no = '{patno}' and a.T_AUTO_ISSUE_ID=b.T_AUTO_ISSUE_ID AND b.T_BB_STOCK_ID=c.T_BB_STOCK_ID AND c.T_BLOOD_GROUP_CODE = d.T_ABO_CODE AND b.T_ENTRY_USER = e.T_EMP_CODE AND a.T_SITE_CODE = '{siteCode}' AND c.t_unit_no NOT LIKE '%C'");
        }

        public DataTable getR12036A_Report(string patno)
        {
            return Query($"SELECT t22.T_DONATION_NO, t22.T_DONATION_DATE , t22.T_UNIT_NO, t22.T_BLOOD_GROUP, t19.T_EXPIRY_DATE, t22.T_LAB_REQUEST_NO, t19.T_PRODUCT_CODE, T11.T_LANG2_NAME PROD_DESC, T04.T_LANG2_NAME BLOOD_GROUP_DESCRIPTION, T04.T_RH_NAME, T04.T_RH, T56.T_XMATCH_DONE_TIME, t19.T_KELL , t19.T_RH_PHENOTY, t19.T_SEG_ABO , t19.T_ANTIBODY_1 from t12013 t13 INNER JOIN t12256 t56 on T13.T_AUTO_ISSUE_ID=T56.T_AUTO_ISSUE_ID INNER JOIN t12223 t23 on T23.T_BB_STOCK_ID=T56.T_BB_STOCK_ID INNER JOIN t12022 t22 on T23.T_UNIT_NO = T22.T_UNIT_NO INNER JOIN T12004 T04 ON T23.T_BLOOD_GROUP_CODE = T04.T_ABO_CODE INNER JOIN T12011 T11 ON T23.T_PRODUCT_CODE = T11.T_PRODUCT_CODE INNER JOIN t12019 t19 on T19.T_UNIT_NO=T22.T_UNIT_NO and T19.T_PRODUCT_CODE=T23.T_PRODUCT_CODE WHERE t13.T_REQUEST_NO='{patno}' AND t19.T_VIOROLOGY_RESULT='1' AND t22.T_NAT='1' AND t19.T_ABO_CODE IS NOT NULL AND t19.T_SEG_ABO IS NOT NULL AND t22.T_NAT='1' AND t19.T_VIOROLOGY_RESULT='1' and NVL(t19.T_ANTIBODY_1,'0') not in (select T_ANTI_CODE from t12201) AND t19.T_ANTIBODY_1 IS NOT NULL AND t19.T_ANTIBODY_1<>'0' ORDER BY t22.T_UNIT_NO");

            // It is complete query with full condition but there is no data in database that will meet all condition of query.
            // So, with less of condition data is available 

            //  SELECT t22.T_DONATION_NO, t22.T_DONATION_DATE , t22.T_UNIT_NO, t22.T_BLOOD_GROUP, T56.T_EXPIRY_DATE, t22.T_LAB_REQUEST_NO, t19.T_PRODUCT_CODE, T11.T_LANG2_NAME PROD_DESC, T04.T_LANG2_NAME BLOOD_GROUP_DESCRIPTION, T04.T_RH_NAME, T56.T_XMATCH_DONE_TIME, t19.T_KELL , t19.T_RH_PHENOTY, t19.T_SEG_ABO , t19.T_ANTIBODY_1 from t12013 t13 INNER JOIN t12256 t56 on T13.T_AUTO_ISSUE_ID = T56.T_AUTO_ISSUE_ID INNER JOIN t12223 t23 on T23.T_BB_STOCK_ID = T56.T_BB_STOCK_ID INNER JOIN t12022 t22 on T23.T_UNIT_NO = T22.T_UNIT_NO INNER JOIN T12004 T04 ON T23.T_BLOOD_GROUP_CODE = T04.T_ABO_CODE INNER JOIN T12011 T11 ON T23.T_PRODUCT_CODE = T11.T_PRODUCT_CODE INNER JOIN t12019 t19 on T19.T_UNIT_NO = T22.T_UNIT_NO and T19.T_PRODUCT_CODE = T23.T_PRODUCT_CODE WHERE t13.T_REQUEST_NO = '00000003' AND t19.T_VIOROLOGY_RESULT = '1'--AND t22.T_MALARIYA = '1' AND --A.T_SITE_CODE=0001 AND t22.T_NAT = '1' AND t19.T_ABO_CODE IS NOT NULL AND t19.T_SEG_ABO IS NOT NULL AND t22.T_NAT = '1' AND t19.T_VIOROLOGY_RESULT = '1'--AND t56.T_UNIT_STATUS = '2' and NVL(t19.T_ANTIBODY_1,'0') not in (select T_ANTI_CODE from t12201) AND t19.T_ANTIBODY_1 IS NOT NULL AND t19.T_ANTIBODY_1 <> '0' ORDER BY t22.T_UNIT_NO;

        }
        public DataTable getR12012_Report(string reqno, string site, string lang)
        {
            return Query($"SELECT T13.T_PAT_NO,T13.T_REQUEST_NO,T12.T_LAB_NO,T01.T_FIRST_LANG{lang}_NAME||' '||T01.T_FATHER_LANG{lang}_NAME||' '||T01.T_GFATHER_LANG{lang}_NAME||' '||T01.T_FAMILY_LANG{lang}_NAME NAME, TRUNC(MONTHS_BETWEEN(SYSDATE,T01.T_BIRTH_DATE) / 12, 0) ||' Y '|| TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T01.T_BIRTH_DATE), 12), 0) ||' M' Age, T06.T_LANG{lang}_NAME GENDER, T48.T_LANG{lang}_NAME HospitalName, T42.T_LANG{lang}_NAME T_WARD_NAME, t12.T_REQUEST_DATE, GET_T12302_DESC(T13.T_ANTI_A,1,{lang},1) T_ANTI_A_desc, GET_T12302_DESC(T13.T_ANTI_B,1,{lang},1) T_ANTI_B_desc, GET_T12302_DESC(T13.T_ANTI_D,1,{lang},1) T_ANTI_D_desc, GET_T12302_DESC(T13.T_CONTROL,1,{lang},1) T_CONTROL_desc, GET_T12302_DESC(T13.T_CELLS_A,1,{lang},1) T_CELLS_A_desc, GET_T12302_DESC(T13.T_CELLS_B,1,{lang},1) T_CELLS_B_desc, GET_T12302_DESC(T13.T_BLOOD_GROUP,2,{lang},1) T_BLOOD_GROUP_desc, GET_T12302_DESC(T13.T_SC_I,1,{lang},1) T_SC_I_desc, GET_T12302_DESC(T13.T_SC_II,1,{lang},1) T_SC_II_desc, GET_T12302_DESC(T13.T_SC_II,1,{lang},1) T_SC_III_desc,GET_T12302_DESC(T13.T_AUTO_CONTROL,1,{lang},1) T_AUTO_CONTROL_desc , GET_T12302_DESC(T13.T_DCT,8,{lang},1) T_DCT_desc , GET_T12302_DESC(T13.T_ICT,8,{lang},1) T_ICT_desc , T13.T_INTERPRETATION, antibody_IDENTIFICATION(T13.T_REQUEST_NO) ANtibody_Identification, T13.T_PHENO ,T23.T_UNIT_NO ,T22.T_SEGMENT_NO ,GET_T12302_DESC(T23.T_BLOOD_GROUP_CODE,2,{lang},1) T_BLOOD_GROUP_descLst ,t23.T_PRODUCT_CODE ,t23.T_EXPIRY_DATE ,get_x_match_time(T56.T_XMATCH_DONE_TIME, t23.T_PRODUCT_CODE) T_EXPIRY_TIME ,GET_T12302_DESC(T56.T_IS,8,{lang},1) T_IS_desc ,GET_T12302_DESC(T56.T_C,8,{lang},1) T_37C_desc ,GET_T12302_DESC(T56.T_AHG,8,{lang},1) T_AHG_desc ,GET_T12302_DESC(T56.T_CCC,8,{lang},1) T_CCC_desc ,GET_T12302_DESC(T56.T_GEL_AHG,8,{lang},1) T_GEL_AHG_desc ,GET_T12302_DESC(T56.T_COMPATIBLE,6,{lang},1) T_COMPATIBLE_desc ,GET_T12302_DESC(T56.T_ENTRY_USER,4,{lang},2) T_ENTRY_USER_name ,T13.T_TS_START_TIME ,T13.T_TS_END_TIME ,GET_T12302_DESC(T13.T_ENTRY_USER,4,{lang},2) cROSSmATCH_USER_name ,T13.T_ENTRY_DATE cROSSmATCH_DATE ,T13.T_REMARKS FROM T12013 T13 left join T03001 T01 on T13.T_PAT_NO=T01.T_PAT_NO LEFT JOIN T02006 T06 ON T01.T_GENDER=T06.T_SEX_CODE left join t12012 t12 on T13.T_REQUEST_NO=T12.T_REQUEST_NO left join T02048 t48 on t12.T_HOSP_CODE=T48.T_HOSP_CODE left join T02042 t42 on t12.T_LOCATION_CODE = t42.T_LOC_CODE left join t12256 t56 on t13.T_AUTO_ISSUE_ID=T56.T_AUTO_ISSUE_ID left join t12223 t23 on T23.T_BB_STOCK_ID=t56.T_BB_STOCK_ID left join t12022 t22 on T22.T_UNIT_NO=T23.T_UNIT_NO WHERE T13.T_REQUEST_NO= '{reqno}' AND T13.T_SITE_CODE='{site}'");
        }
    }
}