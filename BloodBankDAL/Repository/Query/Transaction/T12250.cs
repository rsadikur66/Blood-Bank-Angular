using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12250 : CommonDAL
    {
        public DataTable checkDonor(string P_PAT_NO, string P_NTNLTY_ID, string LANG)
        {
            return Query($"SELECT DISTINCT * FROM (SELECT T.T_PAT_NO,T.T_NTNLTY_ID,T.PAT_NAME,T.YRS,T.MOS,T.T_SEX,T.GENDER,T.T_NTNLTY_CODE,T.NATIONALITY,T.MRTL_STTS,T.T_MRTL_STATUS,NVL(TO_NUMBER(T.T_EPISODE_NO),0) T_EPISODE_NO,MAX(NVL(TO_NUMBER(T.T_EPISODE_NO),0)) OVER (PARTITION BY T.T_PAT_NO) LAST_EPISODE , T.T_ARRIVAL_DATE,T.T_ARRIVAL_TIME,(MAX(NVL(TO_NUMBER(T.T_DIFFERAL_DAY),0)) OVER (PARTITION BY T.T_PAT_NO)) DIFF_DAY,  T.T_ENTRY_DATE +(MAX(TO_NUMBER(T.T_DIFFERAL_DAY)) OVER (PARTITION BY T.T_PAT_NO))  DIFF_UPTO,  DECODE(NVL(T.T_BLOOD_DONATION_STATUS,0),0,NULL,1, (MAX(NVL(TO_NUMBER(T.T_IF_FAIL),0)) OVER (PARTITION BY T.T_PAT_NO))) DIFF_STTS,  (SELECT   CASE WHEN MAX(T_IF_FAIL) = 0 THEN 'GREEN' WHEN MAX(T_IF_FAIL) = 1         THEN 'YELLOW'  WHEN MAX(T_IF_FAIL) = 2 THEN 'RED' ELSE 'WHITE' END T_STATUS FROM   (SELECT DISTINCT  CASE  WHEN T12068.T_EXP_ANS = T12071.T_QNO_ANS    THEN 0    WHEN T12068.T_EXP_ANS <> T12071.T_QNO_ANS  AND T12068.T_IF_FAIL = '1'  THEN 1 WHEN T12068.T_EXP_ANS <> T12071.T_QNO_ANS  AND T12068.T_IF_FAIL = '2'    THEN 2    ELSE null  END T_IF_FAIL FROM T12071 INNER JOIN T12068 ON T12071.T_QNO = T12068.T_QNO  WHERE T_DONOR_PATNO = '{P_PAT_NO}' AND T_DONOR_EPISODE = (SELECT MAX(T_DONOR_EPISODE) FROM T12071 INNER JOIN T12022 ON T12022.T_PAT_NO = T12071.T_DONOR_PATNO AND T12022.T_EPISODE_NO = T12071.T_DONOR_EPISODE  WHERE T_DONOR_PATNO = '{P_PAT_NO}') )) DIFF_STTS_SIGN,  T.T_UNIT_NO FROM (SELECT  T03001.T_PAT_NO,T03001.T_NTNLTY_ID, T03001.T_FIRST_LANG{LANG}_NAME  ||' '  || T03001.T_FATHER_LANG{LANG}_NAME  ||' '  ||T03001.T_GFATHER_LANG{LANG}_NAME  ||' '  || T03001.T_FAMILY_LANG{LANG}_NAME PAT_NAME,    TRUNC(MONTHS_BETWEEN(SYSDATE,T03001.T_BIRTH_DATE) / 12, 0) YRS,  TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T03001.T_BIRTH_DATE), 12), 0) MOS,  T03001.T_GENDER T_SEX,  T02006.T_LANG{LANG}_NAME GENDER,    T03001.T_NTNLTY_CODE,  T02003.T_LANG{LANG}_NAME NATIONALITY,  T02007.T_LANG{LANG}_NAME MRTL_STTS,  T03001.T_MRTL_STATUS,  T12017.T_EPISODE_NO,T12017.T_ARRIVAL_DATE,T12017.T_ARRIVAL_TIME,T12071.T_DIFFERAL_DAY,T12017.T_ENTRY_DATE, CASE        WHEN T12068.T_EXP_ANS = T12071.T_QNO_ANS        THEN 0        WHEN T12068.T_EXP_ANS <> T12071.T_QNO_ANS        AND T12068.T_IF_FAIL = '1'        then 1        WHEN T12068.T_EXP_ANS <> T12071.T_QNO_ANS        AND T12068.T_IF_FAIL = '2'        THEN 2        ELSE null      END T_IF_FAIL, T12017.T_BLOOD_DONATION_STATUS,T12022.T_UNIT_NO FROM T03001 INNER JOIN T02006 ON T03001.T_GENDER = T02006.T_SEX_CODE INNER JOIN T02007 ON T03001.T_MRTL_STATUS = T02007.T_MRTL_STATUS_CODE INNER JOIN T02003 ON T03001.T_NTNLTY_CODE  = T02003.T_NTNLTY_CODE LEFT OUTER JOIN T12017 ON T03001.T_PAT_NO = T12017.T_PAT_NO LEFT OUTER JOIN T12071 ON T12017.T_PAT_NO = T12071.T_DONOR_PATNO AND T12071.T_DONOR_EPISODE  = T12017.T_EPISODE_NO LEFT OUTER JOIN T12022  ON T12071.T_DONOR_PATNO = T12022.T_PAT_NO AND T12071.T_DONOR_EPISODE  = T12022.T_EPISODE_NO LEFT JOIN T12068 ON T12071.T_QNO = T12068.T_QNO  WHERE ('{P_PAT_NO}' IS NULL OR T03001.T_PAT_NO = '{P_PAT_NO}') AND ('{P_NTNLTY_ID}' IS NULL OR T03001.T_NTNLTY_ID = '{P_NTNLTY_ID}') ) T GROUP BY T.T_PAT_NO,T.T_NTNLTY_ID,T.PAT_NAME,T.YRS,T.MOS,T.T_SEX,T.GENDER,T.T_NTNLTY_CODE,T.NATIONALITY,T.MRTL_STTS,T.T_MRTL_STATUS,T.T_EPISODE_NO,T.T_EPISODE_NO,T.T_ARRIVAL_DATE,T.T_ARRIVAL_TIME ,T.T_DIFFERAL_DAY ,T.T_ENTRY_DATE ,T.T_IF_FAIL ,T.T_BLOOD_DONATION_STATUS,T.T_UNIT_NO ) WHERE T_EPISODE_NO = LAST_EPISODE");
        }

        public DataTable GetReasonList(int age, string lang)
        {
            return Query($"SELECT T_DOTN_RSN_CODE CODE,T_LANG{lang}_NAME NAME FROM T12006 WHERE {age} between TO_NUMBER(T_AGE_FRM) AND  TO_NUMBER(T_AGE_TO) ORDER BY T_DOTN_RSN_CODE");
        }
        public DataTable GetSingleReason(int age, string lang, string reasonCode)
        {
            return Query($"SELECT T_DOTN_RSN_CODE CODE,T_LANG{lang}_NAME NAME FROM T12006 WHERE {age} between TO_NUMBER(T_AGE_FRM) AND  TO_NUMBER(T_AGE_TO) AND ('{reasonCode}' IS NULL OR T_DOTN_RSN_CODE = '{reasonCode}') ORDER BY T_DOTN_RSN_CODE");
        }


        public DataTable GetPatientData(string lang, string searchValue)
        {
            return Query($"SELECT * FROM (SELECT T_REF_PAT_NO,T_OTHER_PAT_NAME,RowNum rww FROM( SELECT T_PAT_NO T_REF_PAT_NO,T_FIRST_LANG{lang}_NAME ||' '|| T_FATHER_LANG{lang}_NAME ||' '|| T_GFATHER_LANG{lang}_NAME ||' '|| T_MOTHER_LANG{lang}_NAME || ' ' || T_FAMILY_LANG{lang}_NAME T_OTHER_PAT_NAME FROM T03001) WHERE (UPPER(T_OTHER_PAT_NAME)like '%' || UPPER('{searchValue}') || '%' OR T_REF_PAT_NO LIKE '%'|| UPPER('{searchValue}') || '%')) where rww < 500");
        }

        public string GetArabicName(string patNo)
        {
            return Query($"SELECT T_FIRST_LANG1_NAME||' '||T_FATHER_LANG1_NAME||' '|| T_GFATHER_LANG1_NAME||' '|| T_MOTHER_LANG1_NAME|| ' '|| T_FAMILY_LANG1_NAME T_PAT_NAME FROM T03001 WHERE t_pat_no ='{patNo}'").Rows[0][0].ToString();
        }
        //-----------------------------------Hamla Registration-------------------Save
        public string insert(string USER, string T_PAT_NO, string T_DONOR_NTNLTY_ID, string T_DOTN_RSN_CODE, string T_REF_PAT_NO, string T_OTHER_PAT_NAME, string T_SEX, string T_ENTRY_TIME, string T_SITE_CODE)
        {
            //bool isInsert01 = false;
            bool isInsert17 = false;
            bool isInsert22 = false;
            int counter = 0;
            int c = 0;
            int i = 0;
            string msg = "";
            //-------------------------------------------01------------------------------------------
            BeginTransaction();
            //if (Command(
              //  $"UPDATE T03001 SET T_UPD_USER='{USER}',T_UPD_DATE=TRUNC(SYSDATE),T_HAMLA_STTS=1 WHERE T_PAT_NO='{T_PAT_NO}'")
          //  )
          //  {
                //CommitTransaction(); 
              //  isInsert01 = true;
         //   }
          //  else { //RollbackTransaction(); 
           //     }
            //-------------------------------------------17------------------------------------------

            string episode = Query($"SELECT NVL(MAX(TO_NUMBER(NVL(T_EPISODE_NO,0))),0)+1 T_EPISODE_NO   FROM T12017 WHERE T_PAT_NO = '{T_PAT_NO}' AND T_DONOR_NTNLTY_ID = '{T_DONOR_NTNLTY_ID}'")
                .Rows[0]["T_EPISODE_NO"].ToString();

            string seq = Query($"SELECT LPAD(donation_no_seq.nextval,8,'0') T_DONATION_SEQ_NO FROM DUAL").Rows[0]["T_DONATION_SEQ_NO"].ToString();

            int req = Int32.Parse(Query($"SELECT NVL(MAX(T_REQUEST_ID),0)+1 T_REQUEST_ID FROM T12017").Rows[0]["T_REQUEST_ID"].ToString());

            //BeginTransaction();
            if (Command(
                $"INSERT INTO T12017 (T_ENTRY_USER,T_ENTRY_DATE,T_REQUEST_ID,T_PAT_NO,T_DONOR_NTNLTY_ID,T_EPISODE_NO,T_DONATION_SEQ_NO,T_DONATION_DATE,T_ARRIVAL_DATE,T_DOTN_RSN_CODE,T_REF_PAT_NO,T_OTHER_PAT_NAME,T_UPD_USER,T_UPD_DATE,T_BLOOD_DONATION_STATUS,T_SITE_CODE,T_HAMLA_STTS) VALUES ('{USER}',SYSDATE,{req},'{T_PAT_NO}','{T_DONOR_NTNLTY_ID}','{episode}','{seq}',SYSDATE, SYSDATE ,'{T_DOTN_RSN_CODE}','{T_REF_PAT_NO}','{T_OTHER_PAT_NAME}','{USER}',TRUNC(SYSDATE),'2','{T_SITE_CODE}',1)")
            )
            {
                //CommitTransaction(); 
                isInsert17 = true;
            }
            else
            {
                //RollbackTransaction(); isInsert17 = false;
            }
            //-------------------------------------------22------------------------------------------
            int vital = Int32.Parse(Query($"SELECT NVL(MAX(T_VITAL_ID),0)+1 T_VITAL_ID FROM T12022").Rows[0]["T_VITAL_ID"].ToString());
            DataTable dt = Query("SELECT T_NORML_VALUE T FROM T02087");
            //BeginTransaction();
            if (Command(
                $"INSERT INTO T12022 (T_ENTRY_USER,T_ENTRY_DATE, T_PAT_NO, T_EPISODE_NO, T_REQUEST_ID,T_MAX_DIFFERED_DATE,T_MAX_DIFFERED_DAY,T_WEIGHT,T_TEMPTURE,T_HB,T_PULS,T_BP_HIGH,T_BP_LOW,REC_DIF_DAY,T_DIFFERED_DATE,  T_ACCEPT_STATUS,T_VITAL_ID,T_DONATION_SEQ_NO,T_DONATION_NO,T_SITE_CODE) VALUES ('{USER}',TRUNC(SYSDATE),'{T_PAT_NO}','{episode}','{req}',TRUNC(SYSDATE),0,'{dt.Rows[2]["T"]}' ,'{dt.Rows[5]["T"]}','{dt.Rows[4]["T"]}','{dt.Rows[3]["T"]}','{dt.Rows[0]["T"]}', '{dt.Rows[1]["T"]}',0,TRUNC(SYSDATE), '1',{vital},'{seq}','{seq}','{T_SITE_CODE}')")
            )
            {
                //CommitTransaction(); 
                isInsert22 = true;
            }
            else {
                //RollbackTransaction(); isInsert22 = false;
            }
            //-------------------------------------------71------------------------------------------
           
            DataTable dt_ques = Query($"SELECT DISTINCT T12068.T_QNO, T_EXP_ANS,T12068.T_QHEAD_NO,T12068.T_DISP_SEQ FROM T12068 INNER JOIN T12069 ON T12068.T_QHEAD_NO = T12069.T_QHEAD_NO UNION SELECT DISTINCT  T12068.T_QNO, T_EXP_ANS,T12068.T_QHEAD_NO,T12068.T_DISP_SEQ FROM T12068 INNER JOIN T12069 ON T12068.T_QHEAD_NO = T12069.T_QHEAD_NO WHERE T12068.T_SEX = '{T_SEX}'");
            if (isInsert17 && isInsert22)
            {
               
                if (dt_ques.Rows.Count>0)
                {
                    //BeginTransaction();
                    for (i = 0; i < dt_ques.Rows.Count; i++)
                    {
                        //int ques = Int32.Parse(Query($"SELECT MAX(NVL(T_QUES_ID,0))+1 T_QUES_ID FROM T12071").Rows[0]["T_QUES_ID"].ToString());
                        bool isInsert71 = Command(
                            $"INSERT INTO T12071 (T_ENTRY_USER,T_ENTRY_DATE,T_ENTRY_TIME,T_DONOR_ID,T_DONOR_PATNO,T_DONOR_EPISODE,T_QNO,T_QNO_ANS,T_QHEAD_NO,T_DISP_SEQ,T_DIFFERAL_DAY,T_REQUEST_ID,T_UPD_USER,T_UPD_DATE,T_SITE_CODE) VALUES ('{USER}',TRUNC(SYSDATE),'{T_ENTRY_TIME}','{T_DONOR_NTNLTY_ID}','{T_PAT_NO}','{episode}','{dt_ques.Rows[i]["T_QNO"]}','{dt_ques.Rows[i]["T_EXP_ANS"]}','{dt_ques.Rows[i]["T_QHEAD_NO"]}','{dt_ques.Rows[i]["T_DISP_SEQ"]}',0,{req},'{USER}',TRUNC(SYSDATE),'{T_SITE_CODE}')");
                        c = isInsert71 ? c + 1 : c;
                    }

                    if (c==i && i>0)
                    {
                       // CommitTransaction();
                        counter = 0;
                    }
                    else
                    {
                        //RollbackTransaction();
                        counter = 1;
                    }
                }
                
               
            }

                if (isInsert17 && isInsert22 && counter == 0)
                {
                    CommitTransaction();
                    msg =  "Data Saved Succssfully";
                }
                else
                {
                    RollbackTransaction();
                    msg = "Data Not Saved";
                }
            
            return msg;
        }






    }
}