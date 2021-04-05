using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12302 : CommonDAL
    {
        public DataTable reqList(string lang, string site, string req)
        {
            return Query($"SELECT T12.T_REQUEST_NO, T12.T_LAB_NO,T12.T_REQUEST_DATE ,T12.T_PAT_NO,T03.T_FIRST_LANG{lang}_NAME ||' '|| T03.T_FATHER_LANG{lang}_NAME ||' '|| T03.T_GFATHER_LANG{lang}_NAME ||' '|| T03.T_FAMILY_LANG{lang}_NAME AS PAT_NAME,TRUNC(MONTHS_BETWEEN(SYSDATE,T03.T_BIRTH_DATE) / 12, 0) YRS,TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T03.T_BIRTH_DATE), 12), 0) MOS,T03.T_GENDER T_SEX,T06.T_LANG{lang}_NAME GENDER,T03.T_NTNLTY_CODE,T02.T_LANG{lang}_NAME NATIONALITY,T03.T_MRTL_STATUS, T07.T_LANG{lang}_NAME MRTL_STTS,T12.T_LOCATION_CODE,T42.T_LANG{lang}_NAME LOC_DESC,T12.T_REQUISITION,T11.T_LANG{lang}_NAME REQ_DESC,T12.T_UNITNO,T12.T_ABO_CODE,T04.T_LANG{lang}_NAME ABO_DESC,T12.T_REQ_STATUS,T13.T_FORM_NAME,(SELECT T_BLOOD_GROUP FROM T12013  WHERE  T_REQUEST_NO = (SELECT LPAD(MAX(TO_NUMBER(T13.T_REQUEST_NO)),8,'0') FROM T12013 T13 WHERE T13.T_PAT_NO=T12.T13.T_PAT_NO AND T13.T_REQUEST_NO!=T12.T_REQUEST_NO AND TO_NUMBER(T13.T_REQUEST_NO)< TO_NUMBER(T12.T_REQUEST_NO)   AND T13.T_SITE_CODE = T12.T_SITE_CODE )) OLD_BLOOD_GROUP FROM T12012 T12 LEFT JOIN T03001 T03 ON T03.T_PAT_NO=T12.T_PAT_NO LEFT JOIN T02006 T06 ON T03.T_GENDER=T06.T_SEX_CODE LEFT JOIN T02003 T02 ON T03.T_NTNLTY_CODE = T02.T_NTNLTY_CODE LEFT JOIN T02007 T07 ON T03.T_MRTL_STATUS = T07.T_MRTL_STATUS_CODE LEFT JOIN T02042 T42 ON T12.T_LOCATION_CODE = T42.T_LOC_CODE LEFT JOIN T12011 T11 ON T11.T_PRODUCT_CODE=T12.T_REQUISITION LEFT JOIN T12004 T04 ON T04.T_ABO_CODE = T12.T_ABO_CODE LEFT JOIN T12013 T13 ON T13.T_REQUEST_NO=T12.T_REQUEST_NO WHERE ('{req}' IS NULL OR T12.T_REQUEST_NO='{req}') AND T12.T_SITE_CODE = '{site}'  ORDER BY T12.T_REQUEST_DATE DESC");
            
        }
        public DataTable reqDet(string lang, string site, string req)
        {
             return Query($"SELECT T12.T_REQUEST_NO, T12.T_LAB_NO, T12.T_REQUEST_DATE , T12.T_PAT_NO, T03.T_FIRST_LANG{lang}_NAME ||' ' || T03.T_FATHER_LANG{lang}_NAME ||' ' || T03.T_GFATHER_LANG{lang}_NAME ||' ' || T03.T_FAMILY_LANG{lang}_NAME AS PAT_NAME, TRUNC(MONTHS_BETWEEN(SYSDATE,T03.T_BIRTH_DATE) / 12, 0) YRS, TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T03.T_BIRTH_DATE), 12), 0) MOS, T03.T_GENDER T_SEX, T06.T_LANG{lang}_NAME GENDER, T03.T_NTNLTY_CODE, T02.T_LANG{lang}_NAME NATIONALITY, T03.T_MRTL_STATUS, T07.T_LANG{lang}_NAME MRTL_STTS, T12.T_LOCATION_CODE, T42.T_LANG{lang}_NAME LOC_DESC, T12.T_REQUISITION, T11.T_LANG{lang}_NAME REQ_DESC, T12.T_UNITNO, T12.T_ABO_CODE, T04.T_LANG{lang}_NAME ABO_DESC, T12.T_REQ_STATUS, T13.T_FORM_NAME, (SELECT T_BLOOD_GROUP FROM T12013 WHERE T_REQUEST_NO = (SELECT LPAD(MAX(TO_NUMBER(T13.T_REQUEST_NO)),8,'0') FROM T12013 T13 WHERE T13.T_PAT_NO =T12.T13.T_PAT_NO AND T13.T_REQUEST_NO! =T12.T_REQUEST_NO AND TO_NUMBER(T13.T_REQUEST_NO)< TO_NUMBER(T12.T_REQUEST_NO) AND T13.T_SITE_CODE = T12.T_SITE_CODE ) ) OLD_BLOOD_GROUP ,T13.T_ANTI_A,GET_T12302_DESC(T13.T_ANTI_A,1,{lang},1) T_ANTI_A_desc ,T13.T_ANTI_B,GET_T12302_DESC(T13.T_ANTI_B,1,{lang},1) T_ANTI_B_desc ,T13.T_ANTI_D,GET_T12302_DESC(T13.T_ANTI_D,1,{lang},1) T_ANTI_D_desc ,T13.T_CONTROL,GET_T12302_DESC(T13.T_CONTROL,1,{lang},1) T_CONTROL_desc ,T13.T_CELLS_A,GET_T12302_DESC(T13.T_CELLS_A,1,{lang},1) T_CELLS_A_desc ,T13.T_CELLS_B,GET_T12302_DESC(T13.T_CELLS_B,1,{lang},1) T_CELLS_B_desc ,T13.T_BLOOD_GROUP,GET_T12302_DESC(T13.T_BLOOD_GROUP,2,{lang},1) T_BLOOD_GROUP_desc ,T13.T_SC_I,GET_T12302_DESC(T13.T_SC_I,1,{lang},1) T_SC_I_desc ,T13.T_SC_II,GET_T12302_DESC(T13.T_SC_II,1,{lang},1) T_SC_II_desc ,T13.T_SC_III,GET_T12302_DESC(T13.T_SC_III,1,{lang},1) T_SC_III_desc ,T13.T_SC_III,GET_T12302_DESC(T13.T_SC_III,1,{lang},1) T_SC_III_desc ,T13.T_DCT,GET_T12302_DESC(T13.T_DCT,3,{lang},1) T_DCT_desc ,T13.T_AUTO_CONTROL,GET_T12302_DESC(T13.T_AUTO_CONTROL,1,{lang},1) T_AUTO_CONTROL_desc ,T13.T_INTERPRETATION,T13.T_TS_START_TIME, T13.T_TS_END_TIME ,T13.T_TECH_CODE,GET_T12302_DESC(T13.T_TECH_CODE,4,{lang},1) T_TECH_CODE_desc , T13.T_REMARKS, T13.T_BG_ND,T13.T_BG_N,T13.T_AUTO_ANTI, T13.T_ALLO_ANTI,T13.T_NON_SPEC ,T13.T_ANTI_TYPE_AUTO,GET_T12302_DESC(T13.T_ANTI_TYPE_AUTO,5,{lang},1) T_ANTI_TYPE_AUTO_desc ,T13.T_AUTO_OTHERS ,T13.T_ANTI_TYPE_ALLO,GET_T12302_DESC(T13.T_ANTI_TYPE_ALLO,5,{lang},2) T_ANTI_TYPE_ALLO_desc ,T13.T_ALLO_OTHERS ,T13.T_ANTI_FINAL,GET_T12302_DESC(T13.T_ANTI_FINAL,7,{lang},1) T_ANTI_FINAL_desc , T13.T_ANTI_FINAL1,GET_T12302_DESC(T13.T_ANTI_FINAL1,7,{lang},1) T_ANTI_FINAL1_desc, T13.T_ANTI_FINAL2,GET_T12302_DESC(T13.T_ANTI_FINAL2,7,{lang},1) T_ANTI_FINAL2_desc,T13.T_NONS_OTHERS,T13.T_PHENO, T13.T_D,T13.T_CC,T13.T_CS,T13.T_EC,T13.T_ES,T13.T_KC, T13.T_KS,T13.T_JKA, T13.T_JKB,T13.T_FYA,T13.T_FYB,T13.T_M,T13.T_N,T13.T_SC,T13.T_SS,T13.T_LEA, T13.T_LEB ,T13.T_ENTRY_USER T13T_ENTRY_USER ,GET_T12302_DESC(T13.T_ENTRY_USER,4,{lang},2) T13T_ENTRY_USER_name ,T13.T_ENTRY_DATE T13T_ENTRY_DAT,T13.T_SITE_CODE,T13.T_AUTO_ISSUE_ID ,NVL(T56.T_UPD_USER,T56.T_ENTRY_USER) T56T_ENTRY_USER ,GET_T12302_DESC(NVL(T56.T_UPD_USER,T56.T_ENTRY_USER),4,{lang},2) T56T_ENTRY_USER_name ,T56.T_ENTRY_DATE T56T_ENTRY_DATE ,T56.T_ISSUED_BY ,GET_T12302_DESC(T56.T_ISSUED_BY,4,{lang},2) T_ISSUED_BY_name , T56.T_ISSUE_DATE,T56.T_ISSUE_TIME,T56.T_BB_STOCK_ID, I23.T_UNIT_NO, i23.T_BLOOD_GROUP_CODE,I23.T_PRODUCT_CODE,I23.T_EXPIRY_DATE ,T56.T_IS ,GET_T12302_DESC(T56.T_IS,3,{lang},1) T_IS_desc ,T56.T_C ,GET_T12302_DESC(T56.T_C,3,{lang},1) T_C_desc ,T56.T_AHG ,GET_T12302_DESC(T56.T_AHG,3,{lang},1) T_AHG_desc ,T56.T_CCC ,GET_T12302_DESC(T56.T_CCC,3,{lang},1) T_CCC_desc ,T56.T_GEL_AHG ,GET_T12302_DESC(T56.T_GEL_AHG,3,{lang},1) T_GEL_AHG_desc ,T56.T_COMPATIBLE,GET_T12302_DESC(T56.T_COMPATIBLE,6,{lang},1) T_COMPATIBLE_desc,T56.T_AUTO_ISSUE_DET_ID FROM T12012 T12 LEFT JOIN T03001 T03 ON T03.T_PAT_NO=T12.T_PAT_NO LEFT JOIN T02006 T06 ON T03.T_GENDER=T06.T_SEX_CODE LEFT JOIN T02003 T02 ON T03.T_NTNLTY_CODE = T02.T_NTNLTY_CODE LEFT JOIN T02007 T07 ON T03.T_MRTL_STATUS = T07.T_MRTL_STATUS_CODE LEFT JOIN T02042 T42 ON T12.T_LOCATION_CODE = T42.T_LOC_CODE LEFT JOIN T12011 T11 ON T11.T_PRODUCT_CODE=T12.T_REQUISITION LEFT JOIN T12004 T04 ON T04.T_ABO_CODE = T12.T_ABO_CODE LEFT JOIN T12013 T13 ON T13.T_REQUEST_NO =T12.T_REQUEST_NO LEFT JOIN T12256 T56 ON T56.T_AUTO_ISSUE_ID=T13.T_AUTO_ISSUE_ID left join t12223 i23 on t56.T_BB_STOCK_ID=i23.T_BB_STOCK_ID WHERE ('{req}' IS NULL OR T12.T_REQUEST_NO ='{req}') AND T12.T_SITE_CODE = '{site}' ORDER BY T12.T_REQUEST_DATE DESC");
        }

        public DataTable bgList(string lang, string code)
        {
            return Query(
                $"SELECT T_ABO_CODE , T_LANG{lang}_NAME T_ABO_DESC FROM T12004 WHERE '{code}' IS NULL OR UPPER(T_ABO_CODE) = UPPER('{code}') ORDER BY  T_ABO_CODE");
        }

        public DataTable techList(string site, string code)
        {
            return Query(
                $"SELECT T_USER_NAME,T_EMP_CODE   FROM T01009 WHERE T_ROLE_CODE IN ('0012','0001') AND T_ACTIVE_FLAG='1' AND T_SITE_CODE = '{site}' AND ('{code}' IS NULL OR UPPER(T_EMP_CODE) = UPPER('{code}')) ORDER BY T_USER_NAME");
        }

        public DataTable antTypAutoList(string lang, string code, string type)
        {
            return Query(
                $"SELECT T_ANTI_TYPE ,T_LANG{lang}_NAME AS T_ANTI_TYPE_DESC FROM T12221 WHERE T_ANTI_CODE ='{code}' AND ('{type}' IS NULL OR T_ANTI_TYPE = '{type}') ORDER BY T_ANTI_TYPE");
        }

        public DataTable antTypFinalList(string lang, string code, string type)
        {
            return Query(
                $"SELECT T_ANTI_TYPE T_ANTI_TYPECODE,T_LANG{lang}_NAME T_ANTI_TYPEDESC FROM T12222 WHERE T_ANTI_CODE = {code} AND ('{type}' IS NULL OR T_ANTI_TYPE = '{type}') ORDER BY TO_NUMBER(T_ANTI_TYPE)");
        }

        public DataTable antiList()
        {
            DataTable dt = Query($"SELECT T_ANTI_CODE, T_ANTI_LEVEL FROM T12023");
            return WithBlankRow(dt);
        }

        public DataTable dctList(string lang)
        {
            DataTable dt = Query($"SELECT T_CODE, T_LANG{lang}_NAME NAME  FROM T12024");
            return WithBlankRow(dt);
        }

        public DataTable getbgByControl(string lang, string P_ANTI_A, string P_ANTI_B, string P_ANTI_D,
            string P_CONTROL)
        {
            return Query(
                $"SELECT  T10.T_BLOOD_GROUP  T_BLOOD_GROUP_CODE , T04.T_LANG{lang}_NAME  T_BLOOD_GROUP_DESC FROM T12210  T10 LEFT JOIN T12004  T04 ON T10.T_BLOOD_GROUP= T04.T_ABO_CODE WHERE T_ANTI_A={P_ANTI_A} AND T_ANTI_B={P_ANTI_B} AND T_ANTI_D={P_ANTI_D} AND T_CONTROL={P_CONTROL}");
        }
        public DataTable getbgByControl6(string lang, string P_ANTI_A, string P_ANTI_B, string P_ANTI_D,
            string P_CONTROL, string P_ACELL, string P_BCELL)
        {
            return Query(
                $"SELECT  T10.T_BLOOD_GROUP  T_BLOOD_GROUP_CODE , T04.T_LANG{lang}_NAME  T_BLOOD_GROUP_DESC FROM T12210  T10 LEFT JOIN T12004  T04 ON T10.T_BLOOD_GROUP= T04.T_ABO_CODE WHERE T_ANTI_A={P_ANTI_A} AND T_ANTI_B={P_ANTI_B} AND T_ANTI_D={P_ANTI_D} AND T_CONTROL={P_CONTROL} AND T_ACELL ={P_ACELL} AND T_BCELL={P_BCELL}");
        }
        public DataTable checkBg(string P_PAT_NO, string lang)
        {
            return Query($"SELECT * FROM (SELECT T13.T_AUTO_ISSUE_ID ,T13.T_REQUEST_NO,T13.T_BLOOD_GROUP,T04.T_LANG{lang}_NAME BG_DESC FROM T12013 T13 LEFT JOIN T12004 T04 ON UPPER(T13.T_BLOOD_GROUP)=UPPER(T04.T_ABO_CODE) WHERE T_PAT_NO='{P_PAT_NO}' ORDER BY T_AUTO_ISSUE_ID DESC ) WHERE ROWNUM=1");
        }

        internal DataTable getUserId(string site,string emp, string lang)
        {
            string l = lang == "2"?"":"2";
            //if (lang=="2"){l = "";}else{l = "2";}
            return Query($"select T_USER_NAME{l},T_EMP_CODE from T01009 where T_EMP_CODE='{emp}'");
        }

        public DataTable checkT_SC(string P_PAT_NO, string site)
        {
            return Query($"SELECT TEMP.* FROM (SELECT T_AUTO_ISSUE_ID, T_UPD_DATE, T_ENTRY_DATE, T_SC_I, T_SC_II, T_SC_III FROM t12013 WHERE T_PAT_NO='{P_PAT_NO}' AND T_SITE_CODE='{site}' ORDER BY NVL(T_UPD_DATE,T_ENTRY_DATE) DESC , T_AUTO_ISSUE_ID DESC) TEMP WHERE ROWNUM=1 AND NVL(T_UPD_DATE,T_ENTRY_DATE)>=SYSDATE-3");
        }

        public DataTable unitList(string P_PAT_NO, string P_SITE_CODE, string P_PHENO, string P_REQUISITION,
            string P_ABO_CODE, string P_UNIT_NO, string P_REQUEST_NO, string lang)
        {
            DataTable dt = new DataTable();
            int v = Int32.Parse(Query(
                    $"SELECT COUNT(*) v FROM T12013 WHERE T_PAT_NO = '{P_PAT_NO}' AND(T_SC_I IN('1', '2', '3', '4') OR T_SC_II IN('1', '2', '3', '4') OR T_SC_III IN('1', '2', '3', '4')) AND T_SITE_CODE = '{P_SITE_CODE}'")
                .Rows[0]["v"].ToString());
            int s = Int32.Parse(
                Query(
                        $"SELECT COUNT(DISTINCT(T_BLOOD_GROUP)) s FROM T12013 WHERE T_PAT_NO='{P_PAT_NO}' AND T_SITE_CODE='{P_SITE_CODE}'")
                    .Rows[0]["s"].ToString());
            string q = "";
            if (v == 0 && s == 1 && !string.IsNullOrEmpty(P_PHENO))
            {//---------------------Original------------------------------------
                q = "T63.RH_PHENO||','||decode(T63.RH_KELL,'neg','k','pos','K','')='" + P_PHENO +
                    "' AND (T19.T_ANTIBODY_1 <>'0' OR T19.T_ANTIBODY_1 IS NULL)";
                //----------------------------temp fake-------------need to be removed
                //q = "T63.RH_PHENO||','||decode(T63.RH_KELL,'neg','k','pos','K','')='" + P_PHENO +
                //    "'AND (T19.T_ANTIBODY_1 IS NULL)";

            }
            else
            {//---------------------Original------------------------------------
                q = "AND  T19.T_ANTIBODY_1 <>'0' AND  T19.T_ANTIBODY_1 IS NOT NULL";
                //----------------------------temp fake-------------need to be removed
                //q = "AND  T19.T_ANTIBODY_1 IS NOT NULL";
            }

            dt = Query(
                $"SELECT DISTINCT I23.T_BB_STOCK_ID,I23.T_UNIT_NO UNIT_NO ,I23.T_BLOOD_GROUP_CODE T_ABO_NO_CODE,I23.T_PRODUCT_CODE,I23.T_EXPIRY_DATE ,T11.T_LANG{lang}_NAME PRODUCT_DESC,T04.T_LANG{lang}_NAME ABO_NO_DESC FROM T12223 I23 INNER JOIN T12019 T19 ON T19.T_UNIT_NO=I23.T_UNIT_NO INNER JOIN T12163 T63 ON T63.T_UNIT_NO=I23.T_UNIT_NO INNER JOIN T12011 T11 ON T11.T_PRODUCT_CODE=I23.T_PRODUCT_CODE INNER JOIN T12004 T04 ON T04.T_ABO_CODE = I23.T_BLOOD_GROUP_CODE WHERE  I23.T_UNIT_NO IS NOT NULL AND    I23.T_EXPIRY_DATE >= TRUNC(SYSDATE) AND   T19.T_UNIT_STATUS IS NULL AND   T19.T_VIOROLOGY_RESULT ='1' AND T19.T_ANTIBODY_1 NOT IN (SELECT T_ANTI_CODE FROM T12201) AND I23.T_BLOOD_GROUP_CODE IN (SELECT T_BLOOD_GROUP FROM T12211 WHERE T_PRODUCT_CODE='{P_REQUISITION}' AND  T_BLOOD_GROUP='{P_ABO_CODE}') AND I23.T_SITE_CODE='{P_SITE_CODE}' AND I23.T_PRODUCT_CODE='{P_REQUISITION}' AND ('{P_UNIT_NO}' IS NULL OR I23.T_UNIT_NO='{P_UNIT_NO}') AND I23.T_USED_FLG IS NULL " +
                q);
            
            return dt;

        }

        public int chkDoctor(string P_EMP_CODE, string P_SITE_CODE)
        {
            return Int32.Parse(
                Query(
                        $"SELECT COUNT(*) CNT FROM T12031 T31 INNER JOIN T01009 T09 ON T09.T_EMP_CODE=T31.T_EMP_CODE WHERE T09.T_ROLE_CODE='0235' AND T09.T_EMP_CODE='{P_EMP_CODE}' AND T09.T_SITE_CODE='{P_SITE_CODE}' ")
                    .Rows[0]["CNT"].ToString());
        }

        public string insert(T12013 t12013, List<T12256> t12256)
        {
            string msg = "";
            string Unit_count = "";
            bool ist13 = false;
            int count = 0;
            string time = DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes.ToString();
            if (t12013.T_AUTO_ISSUE_ID==0|| t12013.T_AUTO_ISSUE_ID == null)
            {
                //----------------------------------insert-----------------------------
                t12013.T_AUTO_ISSUE_ID = Int32.Parse(Query($"SELECT TO_NUMBER(NVL(MAX(T_AUTO_ISSUE_ID),0)+1) T_AUTO_ISSUE_ID FROM T12013").Rows[0]["T_AUTO_ISSUE_ID"].ToString());

                BeginTransaction();
                if (Command($"INSERT INTO T12013 (T_REQUEST_NO,T_PAT_NO,T_PRODUCT_CODE,T_UNITS_ISSUED,T_ANTI_A,T_ANTI_B,T_ANTI_D,T_CONTROL,T_CELLS_A,T_CELLS_B,T_BLOOD_GROUP,T_SC_I,T_SC_II,T_SC_III,T_DCT,T_AUTO_CONTROL,T_INTERPRETATION,T_TS_START_TIME,T_TS_END_TIME,T_TECH_CODE,T_REMARKS,T_BG_ND,T_BG_N,T_AUTO_ANTI,T_ALLO_ANTI,T_NON_SPEC,T_ANTI_TYPE_AUTO,T_AUTO_OTHERS,T_ANTI_TYPE_ALLO,T_ALLO_OTHERS,T_ANTI_FINAL,T_ANTI_FINAL1,T_ANTI_FINAL2,T_NONS_OTHERS,T_PHENO,T_D,T_CC,T_CS,T_EC,T_ES,T_KC,T_KS,T_JKA,T_JKB,T_FYA,T_FYB,T_M,T_N,T_SC,T_SS,T_LEA,T_LEB,T_ENTRY_USER,T_ENTRY_DATE,T_SITE_CODE,T_AUTO_ISSUE_ID) VALUES ('{t12013.T_REQUEST_NO}','{t12013.T_PAT_NO}','{t12013.T_PRODUCT_CODE}','{t12013.T_UNITS_ISSUED}','{t12013.T_ANTI_A}','{t12013.T_ANTI_B}','{t12013.T_ANTI_D}','{t12013.T_CONTROL}','{t12013.T_CELLS_A}','{t12013.T_CELLS_B}','{t12013.T_BLOOD_GROUP}','{t12013.T_SC_I}','{t12013.T_SC_II}','{t12013.T_SC_III}','{t12013.T_DCT}','{t12013.T_AUTO_CONTROL}', '{t12013.T_INTERPRETATION}','{t12013.T_TS_START_TIME}','{t12013.T_TS_END_TIME}','{t12013.T_TECH_CODE}','{t12013.T_REMARKS}','{t12013.T_BG_ND}','{t12013.T_BG_N}','{t12013.T_AUTO_ANTI}','{t12013.T_ALLO_ANTI}','{t12013.T_NON_SPEC}','{t12013.T_ANTI_TYPE_AUTO}','{t12013.T_AUTO_OTHERS}','{t12013.T_ANTI_TYPE_ALLO}','{t12013.T_ALLO_OTHERS}','{t12013.T_ANTI_FINAL}','{t12013.T_ANTI_FINAL1}','{t12013.T_ANTI_FINAL2}','{t12013.T_NONS_OTHERS}','{t12013.T_PHENO}','{t12013.T_D}','{t12013.T_CC}','{t12013.T_CS}','{t12013.T_EC}','{t12013.T_ES}','{t12013.T_KC}','{t12013.T_KS}','{t12013.T_JKA}','{t12013.T_JKB}','{t12013.T_FYA}','{t12013.T_FYB}','{t12013.T_M}','{t12013.T_N}','{t12013.T_SC}','{t12013.T_SS}','{t12013.T_LEA}','{t12013.T_LEB}','{t12013.T_ENTRY_USER}','{t12013.T_ENTRY_DATE}','{t12013.T_SITE_CODE}',{t12013.T_AUTO_ISSUE_ID})")
                )
                {
                    CommitTransaction();
                    ist13 = true;
                }
                else
                {
                    RollbackTransaction();
                }
                if (t12256 != null)
                {
                    if (t12256.Count > 0)
                    {
                        foreach (var t56 in t12256)
                        {
                            t56.T_AUTO_ISSUE_DET_ID = Int32.Parse(Query($"SELECT TO_NUMBER(NVL(MAX(T_AUTO_ISSUE_DET_ID),0)+ 1) T_AUTO_ISSUE_DET_ID FROM T12256").Rows[0]["T_AUTO_ISSUE_DET_ID"].ToString());
                            BeginTransaction();
                            if (Command($"INSERT INTO T12256 (T_ENTRY_USER,T_ENTRY_DATE,T_BB_STOCK_ID,T_IS,T_C,T_AHG,T_CCC,T_GEL_AHG,T_COMPATIBLE,T_AUTO_ISSUE_ID,T_AUTO_ISSUE_DET_ID) VALUES ('{t12013.T_ENTRY_USER}',TRUNC(SYSDATE),'{t56.T_BB_STOCK_ID}','{t56.T_IS}', '{t56.T_C}', '{t56.T_AHG}','{t56.T_CCC}','{t56.T_GEL_AHG}','{t56.T_COMPATIBLE}','{t12013.T_AUTO_ISSUE_ID}','{t56.T_AUTO_ISSUE_DET_ID}')") && Command($"UPDATE T12223 SET T_UPD_DATE=TRUNC(SYSDATE), T_UPD_USER ='{t12013.T_ENTRY_USER}',T_USED_FLG=1 WHERE T_BB_STOCK_ID={t56.T_BB_STOCK_ID}"))
                            {
                                CommitTransaction();
                                count++;
                            }
                            else
                            {
                                RollbackTransaction();
                            }

                        }


                    }
                    if (t12256.Count != count)
                    {
                        ist13 = false;
                    }
                }


                msg = ist13 ? "Data inserted Successfully" : "Data not inserted";

            }
            else
            {
                //----------------------------------update-----------------------------
                BeginTransaction();
                if (Command($"UPDATE T12013  SET T_REQUEST_NO='{t12013.T_REQUEST_NO}',T_PAT_NO='{t12013.T_PAT_NO}',T_PRODUCT_CODE='{t12013.T_PRODUCT_CODE}',T_UNITS_ISSUED='{t12013.T_UNITS_ISSUED}',T_ANTI_A='{t12013.T_ANTI_A}',T_ANTI_B='{t12013.T_ANTI_B}',T_ANTI_D='{t12013.T_ANTI_D}',T_CONTROL='{t12013.T_CONTROL}',T_CELLS_A='{t12013.T_CELLS_A}',T_CELLS_B='{t12013.T_CELLS_B}',T_BLOOD_GROUP='{t12013.T_BLOOD_GROUP}',T_SC_I='{t12013.T_SC_I}',T_SC_II='{t12013.T_SC_II}',T_SC_III='{t12013.T_SC_III}',T_DCT='{t12013.T_DCT}',T_AUTO_CONTROL='{t12013.T_AUTO_CONTROL}',T_INTERPRETATION='{t12013.T_INTERPRETATION}',T_TS_START_TIME='{t12013.T_TS_START_TIME}',T_TS_END_TIME='{t12013.T_TS_END_TIME}',T_TECH_CODE='{t12013.T_TECH_CODE}',T_REMARKS='{t12013.T_REMARKS}',T_BG_ND='{t12013.T_BG_ND}',T_BG_N='{t12013.T_BG_N}',T_AUTO_ANTI='{t12013.T_AUTO_ANTI}',T_ALLO_ANTI='{t12013.T_ALLO_ANTI}',T_NON_SPEC='{t12013.T_NON_SPEC}',T_ANTI_TYPE_AUTO='{t12013.T_ANTI_TYPE_AUTO}',T_AUTO_OTHERS='{t12013.T_AUTO_OTHERS}',T_ANTI_TYPE_ALLO='{t12013.T_ANTI_TYPE_ALLO}',T_ALLO_OTHERS='{t12013.T_ALLO_OTHERS}',T_ANTI_FINAL='{t12013.T_ANTI_FINAL}',T_ANTI_FINAL1='{t12013.T_ANTI_FINAL1}',T_ANTI_FINAL2='{t12013.T_ANTI_FINAL2}',T_NONS_OTHERS='{t12013.T_NONS_OTHERS}',T_PHENO='{t12013.T_PHENO}',T_D='{t12013.T_D}',T_CC='{t12013.T_CC}',T_CS='{t12013.T_CS}',T_EC='{t12013.T_EC}',T_ES='{t12013.T_ES}',T_KC='{t12013.T_KC}',T_KS='{t12013.T_KS}',T_JKA='{t12013.T_JKA}',T_JKB='{t12013.T_JKB}',T_FYA='{t12013.T_FYA}',T_FYB='{t12013.T_FYB}',T_M='{t12013.T_M}',T_N='{t12013.T_N}',T_SC='{t12013.T_SC}',T_SS='{t12013.T_SS}',T_LEA='{t12013.T_LEA}',T_LEB='{t12013.T_LEB}',T_ENTRY_USER='{t12013.T_ENTRY_USER}',T_ENTRY_DATE='{t12013.T_ENTRY_DATE}',T_SITE_CODE='{t12013.T_SITE_CODE}' WHERE T_AUTO_ISSUE_ID={t12013.T_AUTO_ISSUE_ID}")
                )
                {
                    CommitTransaction();
                    ist13 = true;
                }
                else
                {
                    RollbackTransaction();
                }
                if (t12256 != null)
                {
                    if (t12256.Count > 0)
                    {
                        foreach (var t56 in t12256)
                        {
                            BeginTransaction();
                            if (t56.T_AUTO_ISSUE_DET_ID == null || t56.T_AUTO_ISSUE_DET_ID == 0)

                            {
                                t56.T_AUTO_ISSUE_DET_ID = Int32.Parse(Query($"SELECT TO_NUMBER(NVL(MAX(T_AUTO_ISSUE_DET_ID),0)+ 1) T_AUTO_ISSUE_DET_ID FROM T12256").Rows[0]["T_AUTO_ISSUE_DET_ID"].ToString());

                                if (Command($"INSERT INTO T12256 (T_ENTRY_USER,T_ENTRY_DATE,T_BB_STOCK_ID,T_IS,T_C,T_AHG,T_CCC,T_GEL_AHG,T_COMPATIBLE,T_AUTO_ISSUE_ID,T_AUTO_ISSUE_DET_ID) VALUES ('{t12013.T_ENTRY_USER}',TRUNC(SYSDATE),'{t56.T_BB_STOCK_ID}','{t56.T_IS}', '{t56.T_C}', '{t56.T_AHG}','{t56.T_CCC}','{t56.T_GEL_AHG}','{t56.T_COMPATIBLE}','{t12013.T_AUTO_ISSUE_ID}','{t56.T_AUTO_ISSUE_DET_ID}')") && Command($"UPDATE T12223 SET T_UPD_DATE=TRUNC(SYSDATE), T_UPD_USER ='{t12013.T_ENTRY_USER}',T_USED_FLG=1 WHERE T_BB_STOCK_ID={t56.T_BB_STOCK_ID}"))
                                {
                                    CommitTransaction();
                                    count++;
                                }
                                else
                                {
                                    RollbackTransaction();
                                }
                            }
                            else if (t56.T_AUTO_ISSUE_DET_ID != null)
                            {
                                DataTable dtIssue =Query($"SELECT T23.T_UNIT_NO,T56.T_ISSUE_FLAG FROM T12256 T56 INNER JOIN T12223 T23 ON T56.T_BB_STOCK_ID=T23.T_BB_STOCK_ID WHERE T56.T_AUTO_ISSUE_DET_ID ='{t56.T_AUTO_ISSUE_DET_ID}'");
                                //if (dtIssue.Rows.Count>0)
                                //{
                                    if (string.IsNullOrEmpty(dtIssue.Rows[0]["T_ISSUE_FLAG"].ToString()))
                                    {
                                        if (Command($"UPDATE T12256  SET T_UPD_USER = '{t12013.T_ENTRY_USER}' , T_UPD_DATE = TRUNC(SYSDATE), T_BB_STOCK_ID='{t56.T_BB_STOCK_ID}', T_IS='{t56.T_IS}', T_C = '{t56.T_C}',T_AHG='{t56.T_AHG}',T_CCC='{t56.T_CCC}',T_GEL_AHG='{t56.T_GEL_AHG}',T_COMPATIBLE='{t56.T_COMPATIBLE}' WHERE T_AUTO_ISSUE_DET_ID='{t56.T_AUTO_ISSUE_DET_ID}'"))
                                        {
                                            CommitTransaction();
                                            count++;
                                        }
                                        else
                                        {
                                            RollbackTransaction();
                                        }
                                    }
                                    else
                                    {
                                        CommitTransaction();
                                    Unit_count += dtIssue.Rows[0]["T_UNIT_NO"]+",";
                                        count++;
                                    }
                                //}
                                




                                
                            }
                            else
                            {
                                count++;
                            }



                        }


                    }
                    if (t12256.Count != count)
                    {
                        ist13 = false;
                    }
                }

                //Unit_count= Unit_count!=""? Unit_count.Remove(Unit_count.Length - 1):"";
                string msgWithUnit = Unit_count != "" ? "This " + Unit_count.Remove(Unit_count.Length - 1) + " Units are issued. Can not be updated. ":"";
                msg = ist13 ? msgWithUnit+"Data updated Successfully" : "Data not updated";
            }
            return msg;

        }

        public DataTable checkBlood(string patId)
        {
            return Query($"select T_BLOOD_GROUP from T12013 WHERE T_PAT_NO = '{patId}'");
        }
    }
}