﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12304 : CommonDAL
    {
        public DataTable reqList(string lang, string site, string req)
        {
            return Query(
                $"SELECT T12.T_REQUEST_NO,T12.T_LAB_NO,TO_CHAR(T12.T_REQUEST_DATE,'DD-MON-YYYY') T_REQUEST_DATE, T12.T_PAT_NO, T03.T_FIRST_LANG{lang}_NAME ||' ' || T03.T_FATHER_LANG{lang}_NAME ||' ' || T03.T_GFATHER_LANG{lang}_NAME ||' ' || T03.T_FAMILY_LANG{lang}_NAME AS PAT_NAME, TRUNC(MONTHS_BETWEEN(SYSDATE,T03.T_BIRTH_DATE) / 12, 0) YRS, TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T03.T_BIRTH_DATE), 12), 0) MOS, T06.T_LANG2_NAME GENDER, T02.T_LANG2_NAME NATIONALITY, T07.T_LANG2_NAME MRTL_STTS, T12.T_LOCATION_CODE, T42.T_LANG2_NAME LOC_DESC FROM T12012 T12 LEFT JOIN T03001 T03 ON T03.T_PAT_NO=T12.T_PAT_NO LEFT JOIN T02006 T06 ON T03.T_GENDER=T06.T_SEX_CODE LEFT JOIN T02003 T02 ON T03.T_NTNLTY_CODE = T02.T_NTNLTY_CODE LEFT JOIN T02007 T07 ON T03.T_MRTL_STATUS = T07.T_MRTL_STATUS_CODE LEFT JOIN T02042 T42 ON T12.T_LOCATION_CODE = T42.T_LOC_CODE LEFT JOIN T12011 T11 ON T11.T_PRODUCT_CODE=T12.T_REQUISITION LEFT JOIN T12013 T13 ON T13.T_REQUEST_NO =T12.T_REQUEST_NO WHERE ('{req}' IS NULL OR T12.T_REQUEST_NO ='{req}') AND T12.T_SITE_CODE = '{site}'");
        }
        public DataTable Griddatalist(string reqNo)
        {
            return Query($"SELECT T12.T_REQUEST_NO, T12.T_REQUEST_DATE , I23.T_UNIT_NO, i23.T_BLOOD_GROUP_CODE, I23.T_PRODUCT_CODE, TO_CHAR(I23.T_EXPIRY_DATE,'DD-MON-YY') T_EXPIRY_DATE, T13.T_SITE_CODE, T56.T_AUTO_ISSUE_ID,T56.T_AUTO_ISSUE_DET_ID,T56.T_ISSUE_FLAG,TO_CHAR(T56.T_ISSUE_DATE,'DD-MON-YY') T_ISSUE_DATE ,T56.T_ISSUE_TIME,T56.T_ISSUED_BY,T09.T_USER_NAME T_ISSUED_BY_NAME,(select T09.T_USER_NAME from T01009 T09 where T09.T_EMP_CODE = T56.T_RECEIVED_BY) T_RECEIVED_BY,T56.T_VIS_INSP FROM T12012 T12 LEFT JOIN T03001 T03 ON T03.T_PAT_NO=T12.T_PAT_NO LEFT JOIN T12011 T11 ON T11.T_PRODUCT_CODE=T12.T_REQUISITION LEFT JOIN T12004 T04 ON T04.T_ABO_CODE = T12.T_ABO_CODE LEFT JOIN T12013 T13 ON T13.T_REQUEST_NO =T12.T_REQUEST_NO LEFT JOIN T12256 T56 ON T56.T_AUTO_ISSUE_ID=T13.T_AUTO_ISSUE_ID LEFT JOIN t12223 i23 ON t56.T_BB_STOCK_ID=i23.T_BB_STOCK_ID LEFT JOIN T01009 T09 ON T09.T_EMP_CODE = T56.T_ISSUED_BY WHERE ('{reqNo}' IS NULL OR T12.T_REQUEST_NO ='{reqNo}') AND T12.T_SITE_CODE = '0001' ORDER BY T12.T_REQUEST_DATE DESC");
            //AND T56.T_ISSUE_FLAG IS NULL
        }
        public DataTable get_Issuedby_name(string lang, string empCode)
        {
            return Query($"SELECT T_USER_NAME{lang},T_EMP_CODE FROM T01009 WHERE T_EMP_CODE='{empCode}'");
            //AND T56.T_ISSUE_FLAG IS NULL
        }

        public bool Insert(string user,List<t12304> t12304)
        {
            for (int i = 0; i < t12304.Count; i++)
            {
                Command(
                    $"UPDATE T12256 SET T_UPD_DATE = TRUNC(SYSDATE),T_UPD_USER ='{user}',T_ISSUE_FLAG='{t12304[i].T_ISSUE_FLAG}',T_ISSUE_DATE ='{t12304[i].T_ISSUE_DATE}',T_ISSUE_TIME = '{t12304[i].T_ISSUE_TIME}',T_UNIT_STATUS ='3',T_ISSUED_BY = '{user}',T_VIS_INSP = '{t12304[i].T_VISUAL_INSPECTION}',T_RECEIVED_BY ='{t12304[i].T_RECEIVED_BY}' WHERE T_AUTO_ISSUE_ID ='{t12304[i].T_AUTO_ISSUE_ID}' AND T_AUTO_ISSUE_DET_ID ='{t12304[i].T_AUTO_ISSUE_DET_ID}'");
            }
            
            return true;
        }


        //------------------------------------Report----------------------------
        public DataTable GetSite(string siteCode)
        {
            return Query($"select T_SITE_CODE , T_COUNTRY_LANG1_NAME , T_COUNTRY_LANG2_NAME , T_MIN_LANG1_NAME , T_MIN_LANG2_NAME , T_SITE_LANG1_NAME , T_SITE_LANG2_NAME , T_LOGO_ID , T_LOGO_NAME , T_LOGO , t_lcence_no from t01028 where t_site_code ={siteCode}");
        }
        public DataTable getR12046_xMatch(string reqno, string site, string lang)
        {
            return Query($"select T13.T_PAT_NO, T13.T_REQUEST_NO, T12.T_LAB_NO, T01.T_X_RMC_CHRTNO, T01.T_FIRST_LANG{lang}_NAME||' '||T01.T_FATHER_LANG{lang}_NAME||' '||T01.T_GFATHER_LANG{lang}_NAME||' '||T01.T_FAMILY_LANG2_NAME NAME, TRUNC(MONTHS_BETWEEN(SYSDATE,T01.T_BIRTH_DATE) / 12, 0) ||' Y '|| TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T01.T_BIRTH_DATE), 12), 0) ||' M' Age, T06.T_LANG{lang}_NAME GENDER, T48.T_LANG{lang}_NAME HospitalName, T42.T_LANG{lang}_NAME T_WARD_NAME, t12.T_REQUEST_DATE, GET_T12302_DESC(T13.T_ANTI_A,1,{lang},1) T_ANTI_A_desc, GET_T12302_DESC(T13.T_ANTI_B,1,{lang},1) T_ANTI_B_desc, GET_T12302_DESC(T13.T_ANTI_D,1,{lang},1) T_ANTI_D_desc, GET_T12302_DESC(T13.T_CONTROL,1,{lang},1) T_CONTROL_desc, GET_T12302_DESC(T13.T_CELLS_A,1,{lang},1) T_CELLS_A_desc, GET_T12302_DESC(T13.T_CELLS_B,1,{lang},1) T_CELLS_B_desc, GET_T12302_DESC(T13.T_BLOOD_GROUP,2,{lang},1) T_BLOOD_GROUP_desc, GET_T12302_DESC(T13.T_SC_I,1,{lang},1) T_SC_I_desc, GET_T12302_DESC(T13.T_SC_II,1,{lang},1) T_SC_II_desc, GET_T12302_DESC(T13.T_SC_II,1,{lang},1) T_SC_III_desc, GET_T12302_DESC(T13.T_AUTO_CONTROL,1,{lang},1) T_AUTO_CONTROL_desc , GET_T12302_DESC(T13.T_DCT,8,{lang},1) T_DCT_desc , GET_T12302_DESC(T13.T_ICT,8,{lang},1) T_ICT_desc , T13.T_INTERPRETATION, T23.T_UNIT_NO , GET_T12302_DESC(T23.T_BLOOD_GROUP_CODE,2,{lang},1) T_BLOOD_GROUP_descLst , t23.T_PRODUCT_CODE , t23.T_EXPIRY_DATE , GET_T12302_DESC(T56.T_IS,8,{lang},1) T_IS_desc , GET_T12302_DESC(T56.T_C,8,{lang},1) T_37C_desc , GET_T12302_DESC(T56.T_AHG,8,{lang},1) T_AHG_desc , GET_T12302_DESC(T56.T_CCC,8,{lang},1) T_CCC_desc , GET_T12302_DESC(T56.T_GEL_AHG,8,{lang},1) T_GEL_AHG_desc , GET_T12302_DESC(T56.T_COMPATIBLE,6,{lang},1) T_COMPATIBLE_desc, T13.T_TS_START_TIME, T13.T_TS_END_TIME, T13.T_ENTRY_DATE CROSSMATCH_DATE, T13.T_REMARKS, GET_T12302_DESC(T13.T_TECH_CODE,4,{lang},2) TECH_NAME FROM T12013 T13 left join T03001 T01 on T13.T_PAT_NO=T01.T_PAT_NO LEFT JOIN T02006 T06 ON T01.T_GENDER=T06.T_SEX_CODE left join t12012 t12 on T13.T_REQUEST_NO=T12.T_REQUEST_NO left join T02048 t48 on t12.T_HOSP_CODE=T48.T_HOSP_CODE left join T02042 t42 on t12.T_LOCATION_CODE = t42.T_LOC_CODE left join t12256 t56 on t13.T_AUTO_ISSUE_ID=T56.T_AUTO_ISSUE_ID left join t12223 t23 on T23.T_BB_STOCK_ID=t56.T_BB_STOCK_ID left join t12022 t22 on T22.T_UNIT_NO=T23.T_UNIT_NO WHERE T13.T_REQUEST_NO= '{reqno}' AND T13.T_SITE_CODE='{site}'");
        }
        public DataTable getR12046_Issue(string reqno, string site, string lang)
        {
            return Query($"SELECT T23.T_UNIT_NO, GET_T12302_DESC(T56.T_ISSUED_BY,4,{lang},2) T_ISSUED_BY, TO_CHAR(T56.T_ISSUE_DATE,'DD/MM/RRRR')||' '||T56.T_ISSUE_TIME ISSUEDATETIME, GET_T12302_DESC(T56.T_RECEIVED_BY,4,{lang},2) T_RECEIVED_BY from t12256 T56 INNER JOIN T12223 T23 ON T23.T_BB_STOCK_ID=T56.T_BB_STOCK_ID INNER JOIN T12013 T13 ON T13.T_AUTO_ISSUE_ID=T56.T_AUTO_ISSUE_ID WHERE T56.T_ISSUE_FLAG='1' AND T13.T_REQUEST_NO= '{reqno}' AND T13.T_SITE_CODE='{site}'");
        }

        public DataTable GetReqNoList(string site)
        {
            return Query(
                $"SELECT T12.T_REQUEST_NO, T12.T_LAB_NO, TO_CHAR(T12.T_REQUEST_DATE,'DD-MON-YYYY') T_REQUEST_DATE, T12.T_PAT_NO,T12.T_ABO_CODE,T11.T_PRODUCT_CODE, T03.T_FIRST_LANG2_NAME ||' ' || T03.T_FATHER_LANG2_NAME ||' ' || T03.T_GFATHER_LANG2_NAME ||' ' || T03.T_FAMILY_LANG2_NAME AS PAT_NAME, TRUNC(MONTHS_BETWEEN(SYSDATE,T03.T_BIRTH_DATE) / 12, 0) YRS, TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T03.T_BIRTH_DATE), 12), 0) MOS, T06.T_LANG2_NAME GENDER, T02.T_LANG2_NAME NATIONALITY, T07.T_LANG2_NAME MRTL_STTS, T12.T_LOCATION_CODE, T42.T_LANG2_NAME LOC_DESC FROM T12012 T12 LEFT JOIN T03001 T03 ON T03.T_PAT_NO=T12.T_PAT_NO LEFT JOIN T02006 T06 ON T03.T_GENDER=T06.T_SEX_CODE LEFT JOIN T02003 T02 ON T03.T_NTNLTY_CODE = T02.T_NTNLTY_CODE LEFT JOIN T02007 T07 ON T03.T_MRTL_STATUS = T07.T_MRTL_STATUS_CODE LEFT JOIN T02042 T42 ON T12.T_LOCATION_CODE = T42.T_LOC_CODE LEFT JOIN T12011 T11 ON T11.T_PRODUCT_CODE=T12.T_REQUISITION LEFT JOIN T12013 T13 ON T13.T_REQUEST_NO =T12.T_REQUEST_NO WHERE T12.T_SITE_CODE = '{site}'");
        }


    }
}