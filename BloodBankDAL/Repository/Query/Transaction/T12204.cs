using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12204 : CommonDAL
    {
        public DataTable GatCompStatusData(string lang, string d)
        {
            if (d == "1")
            {
                return Query($"Select T_DONATION_COMPLETION_STATUS,T_LANG{lang}_NAME T_LANG2_NAME from T12072");
            }
            else
            {
                if (lang == "1")
                {
                    return Query($"SELECT '4' T_DONATION_COMPLETION_STATUS,'بيانات فصادة' T_LANG2_NAME FROM dual");
                }
                else
                {
                    return Query($"SELECT '4' T_DONATION_COMPLETION_STATUS,'Aphersis Data' T_LANG2_NAME FROM dual");
                }

            }

        }

        public DataTable GetBedUsedData(string lang, string id)
        {
            if (id == "0")
            {
                return Query($"Select T_BAG_USED_CODE,T_LANG2_NAME T_LANG{lang}_NAME from T12077 ");
            }
            else
            {
                return Query($"Select T_BAG_USED_CODE,T_LANG2_NAME T_LANG{lang}_NAME from T12077 where T_BAG_USED_CODE = '{id}'");
                //return Query($"Select T_BAG_USED_CODE,T_LANG{lang}_NAME T_LANG2_NAME from T12077"); 
            }

        }

        public DataTable GetPatDetails(string lang, string siteCode, string patNo, string patId)
        {
            return Query($"SELECT DISTINCT t71.T_DONOR_PATNO, T_FIRST_LANG{lang}_NAME  ||' '  ||T_FATHER_LANG{lang}_NAME  ||' '  || T_GFATHER_LANG{lang}_NAME  ||' '  ||T_FAMILY_LANG{lang}_NAME Pat_Name,  NVL(t22.T_ACCEPT_STATUS,0)T_ACCEPT_STATUS,  " +
                         $"t01.T_GENDER,  t06.T_LANG{lang}_NAME GENDER,  t01.T_NTNLTY_ID,  t01.T_NTNLTY_CODE,  t03.T_LANG{lang}_NAME NATIONALITY,  t29.T_LANG{lang}_NAME REJ_NAME,  " +
                         $"T_BIRTH_DATE,  TRUNC(MONTHS_BETWEEN(SYSDATE,T_BIRTH_DATE) / 12, 0) YRS,  TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T_BIRTH_DATE), 12), 0) MOS, " +
                         $" MAX(t71.T_DONOR_EPISODE) OVER (PARTITION BY t71.T_DONOR_PATNO) MAX_EPISODE,  (SELECT DISTINCT MAX (T_DIFFERAL_DAY)  FROM T12071  WHERE T12071.T_DONOR_PATNO ='{patNo}'  OR T12071.T_DONOR_ID       ='{patId}'  " +
                         $"AND T12071.T_DONOR_EPISODE =    (SELECT MAX(t71.T_DONOR_EPISODE)    FROM T12071    WHERE T12071.T_DONOR_PATNO ='{patNo}'    OR T12071.T_DONOR_ID       ='{patId}'    )  )T_DIFFERAL_DAY," +
                         $"  (SELECT DISTINCT SYSDATE+MAX (T_DIFFERAL_DAY)  FROM T12071  WHERE T12071.T_DONOR_PATNO ='{patNo}'  OR t71.T_DONOR_ID          ='{patId}'  AND T12071.T_DONOR_EPISODE =    (SELECT MAX(t71.T_DONOR_EPISODE) " +
                         $"   FROM T12071    WHERE T12071.T_DONOR_PATNO ='{patNo}'    OR t71.T_DONOR_ID          ='{patId}'    )  )DIFF_UPTO   ,T17.T_BLOOD_DONATION_STATUS ,T17.T_REQUEST_ID FROM T12071 t71 JOIN T03001 t01 ON t71.T_DONOR_PATNO = t01.T_PAT_NO " +
                         $"JOIN T12022 t22 ON t71.T_DONOR_PATNO    = t22.T_PAT_NO AND t71.T_DONOR_EPISODE = t22.T_EPISODE_NO JOIN T12017 T17 ON T17.T_REQUEST_ID=t22.T_REQUEST_ID LEFT JOIN T12029 t29 ON t22.T_REJ_STATUS = t29.T_REJ_MAIN_CODE " +
                         $"LEFT JOIN T02003 t03 ON t01.T_NTNLTY_CODE = t03.T_NTNLTY_CODE LEFT JOIN T02006 t06 ON t01.T_GENDER = t06.T_SEX_CODE WHERE (SELECT MAX(T_EPISODE_NO)  FROM T12022 " +
                         $" WHERE T12022.T_PAT_NO ='{patNo}'  OR t71.T_DONOR_ID     ='{patId}' ) =  (SELECT MAX(t71.T_DONOR_EPISODE)  FROM T12071  WHERE T12071.T_DONOR_PATNO ='{patNo}'  OR t71.T_DONOR_ID          ='{patId}'  )" +
                         $"AND (t71.T_DONOR_PATNO = '{patNo}'OR t71.T_DONOR_ID      ='{patId}')AND t17.T_SITE_CODE    ='{siteCode}' AND t71.T_REQUEST_ID   =t22.T_REQUEST_ID");

            //return Query($"SELECT DISTINCT t71.T_DONOR_PATNO,  T_FIRST_LANG{lang}_NAME  ||' '  ||T_FATHER_LANG{lang}_NAME  ||' '  || T_GFATHER_LANG{lang}_NAME  ||' '  ||T_FAMILY_LANG{lang}_NAME Pat_Name, " +
            //             $" nvl(t22.T_ACCEPT_STATUS,0)T_ACCEPT_STATUS,  t01.T_GENDER,  t06.T_LANG{lang}_NAME GENDER, " +
            //             $" t01.T_NTNLTY_ID,  t01.T_NTNLTY_CODE,  t03.T_LANG{lang}_NAME NATIONALITY,  " +
            //             $"t29.T_LANG{lang}_NAME REJ_NAME,t17.T_BLOOD_DONATION_STATUS, T_BIRTH_DATE, TRUNC(MONTHS_BETWEEN(SYSDATE," +
            //             $"T_BIRTH_DATE) / 12, 0) YRS, TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T_BIRTH_DATE), 12), 0) MOS, " +
            //             $"MAX(t71.T_DONOR_EPISODE) OVER (PARTITION BY t71.T_DONOR_PATNO) MAX_EPISODE,(SELECT DISTINCT MAX (T_DIFFERAL_DAY)  " +
            //             $"FROM T12071  WHERE T12071.T_DONOR_PATNO ='{patNo}'OR T12071.T_DONOR_ID ='{patId}' " +
            //             $"AND T12071.T_DONOR_EPISODE = (SELECT MAX(t71.T_DONOR_EPISODE) " +
            //             $"FROM T12071 WHERE T12071.T_DONOR_PATNO ='{patNo}'OR T12071.T_DONOR_ID ='{patId}' ))T_DIFFERAL_DAY," +
            //             $"(SELECT DISTINCT SYSDATE+MAX (T_DIFFERAL_DAY)  FROM T12071  " +
            //             $"WHERE T12071.T_DONOR_PATNO ='{patNo}' OR t71.T_DONOR_ID ='{patId}' " +
            //             $"AND T12071.T_DONOR_EPISODE = (SELECT MAX(t71.T_DONOR_EPISODE) " +
            //             $"FROM T12071 WHERE T12071.T_DONOR_PATNO ='{patNo}' OR t71.T_DONOR_ID ='{patId}' ))DIFF_UPTO " +
            //             $"FROM T12071 t71 JOIN T03001 t01 ON t71.T_DONOR_PATNO = t01.T_PAT_NO " +
            //             $"JOIN T12022 t22 ON t71.T_DONOR_PATNO = t22.T_PAT_NO and t71.T_DONOR_EPISODE = t22.T_EPISODE_NO " +
            //             $"JOIN T12017 T17 ON T17.T_REQUEST_ID=t22.T_REQUEST_ID " +
            //             $"LEFT JOIN T12029 t29 ON t22.T_REJ_STATUS = t29.T_REJ_MAIN_CODE " +
            //             $"LEFT JOIN T02003 t03 ON t01.T_NTNLTY_CODE = t03.T_NTNLTY_CODE LEFT JOIN T02006 t06 ON t01.T_GENDER  = t06.T_SEX_CODE LEFT JOIN T12017 t17 ON t71.T_DONOR_PATNO = t17.T_PAT_NO " +
            //             $"WHERE (SELECT MAX(T_EPISODE_NO) FROM T12022 where T12022.T_PAT_NO ='{patNo}'" +
            //             $"OR t71.T_DONOR_ID ='{patId}' ) = (SELECT MAX(t71.T_DONOR_EPISODE) " +
            //             $"FROM T12071  WHERE T12071.T_DONOR_PATNO ='{patNo}'OR t71.T_DONOR_ID ='{patId}')" +
            //             $"AND (t71.T_DONOR_PATNO    = '{patNo}'OR t71.T_DONOR_ID ='{patId}') AND t17.T_SITE_CODE='{siteCode}' AND t71.T_REQUEST_ID=t22.T_REQUEST_ID ");

            //return Query($"SELECT DISTINCT t71.T_DONOR_PATNO,  T_FIRST_LANG{lang}_NAME  ||' '  ||T_FATHER_LANG{lang}_NAME  ||' '  || T_GFATHER_LANG{lang}_NAME  ||' '  ||T_FAMILY_LANG{lang}_NAME Pat_Name, " +
            //             $" nvl(t22.T_ACCEPT_STATUS,0)T_ACCEPT_STATUS,  t01.T_GENDER,  t06.T_LANG{lang}_NAME GENDER, " +
            //             $" t01.T_NTNLTY_ID,  t01.T_NTNLTY_CODE,  t03.T_LANG{lang}_NAME NATIONALITY,  " +
            //             $"t29.T_LANG{lang}_NAME REJ_NAME, T_BIRTH_DATE, TRUNC(MONTHS_BETWEEN(SYSDATE," +
            //             $"T_BIRTH_DATE) / 12, 0) YRS, TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T_BIRTH_DATE), 12), 0) MOS, " +
            //             $"MAX(t71.T_DONOR_EPISODE) OVER (PARTITION BY t71.T_DONOR_PATNO) MAX_EPISODE,(SELECT DISTINCT MAX (T_DIFFERAL_DAY)  " +
            //             $"FROM T12071  WHERE T12071.T_DONOR_PATNO ='{patNo}'OR T12071.T_DONOR_ID ='{patId}' " +
            //             $"AND T12071.T_DONOR_EPISODE = (SELECT MAX(t71.T_DONOR_EPISODE) " +
            //             $"FROM T12071 WHERE T12071.T_DONOR_PATNO ='{patNo}'OR T12071.T_DONOR_ID ='{patId}' ))T_DIFFERAL_DAY," +
            //             $"(SELECT DISTINCT SYSDATE+MAX (T_DIFFERAL_DAY)  FROM T12071  " +
            //             $"WHERE T12071.T_DONOR_PATNO ='{patNo}' OR t71.T_DONOR_ID ='{patId}' " +
            //             $"AND T12071.T_DONOR_EPISODE = (SELECT MAX(t71.T_DONOR_EPISODE) " +
            //             $"FROM T12071 WHERE T12071.T_DONOR_PATNO ='{patNo}' OR t71.T_DONOR_ID ='{patId}' ))DIFF_UPTO " +
            //             $"FROM T12071 t71 JOIN T03001 t01 ON t71.T_DONOR_PATNO = t01.T_PAT_NO " +
            //             $"JOIN T12022 t22 ON t71.T_DONOR_PATNO = t22.T_PAT_NO and t71.T_DONOR_EPISODE = t22.T_EPISODE_NO LEFT JOIN T12029 t29 ON t22.T_REJ_STATUS = t29.T_REJ_MAIN_CODE " +
            //             $"LEFT JOIN T02003 t03 ON t01.T_NTNLTY_CODE = t03.T_NTNLTY_CODE LEFT JOIN T02006 t06 ON t01.T_GENDER  = t06.T_SEX_CODE LEFT JOIN T12017 t17 ON t71.T_DONOR_PATNO = t17.T_PAT_NO " +
            //             $"WHERE (SELECT MAX(T_EPISODE_NO) FROM T12022 where T12022.T_PAT_NO ='{patNo}'" +
            //             $"OR t71.T_DONOR_ID ='{patId}' ) = (SELECT MAX(t71.T_DONOR_EPISODE) " +
            //             $"FROM T12071  WHERE T12071.T_DONOR_PATNO ='{patNo}'OR t71.T_DONOR_ID ='{patId}')" +
            //             $"AND (t71.T_DONOR_PATNO    = '{patNo}'OR t71.T_DONOR_ID ='{patId}') AND t17.T_SITE_CODE='{siteCode}' AND t71.T_REQUEST_ID=t22.T_REQUEST_ID ");




            //return Query($"SELECT DISTINCT t71.T_DONOR_PATNO,  T_FIRST_LANG{lang}_NAME  ||' '  ||T_FATHER_LANG{lang}_NAME  ||' '  || T_GFATHER_LANG{lang}_NAME  ||' '  ||T_FAMILY_LANG{lang}_NAME Pat_Name, " +
            //             $" nvl(t22.T_ACCEPT_STATUS,0)T_ACCEPT_STATUS,  t01.T_GENDER,  t06.T_LANG{lang}_NAME GENDER, " +
            //             $" t01.T_NTNLTY_ID,  t01.T_NTNLTY_CODE,  t03.T_LANG{lang}_NAME NATIONALITY,  " +
            //             $"t29.T_LANG{lang}_NAME REJ_NAME, T_BIRTH_DATE, TRUNC(MONTHS_BETWEEN(SYSDATE," +
            //             $"T_BIRTH_DATE) / 12, 0) YRS, TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T_BIRTH_DATE), 12), 0) MOS, " +
            //             $"MAX(t71.T_DONOR_EPISODE) OVER (PARTITION BY t71.T_DONOR_PATNO) MAX_EPISODE,(SELECT DISTINCT MAX (T_DIFFERAL_DAY)  " +
            //             $"FROM T12071  WHERE T12071.T_DONOR_PATNO ='{patNo}'OR T12071.T_DONOR_ID ='{patId}' " +
            //             $"AND T12071.T_DONOR_EPISODE = (SELECT MAX(t71.T_DONOR_EPISODE) " +
            //             $"FROM T12071 WHERE T12071.T_DONOR_PATNO ='{patNo}'OR T12071.T_DONOR_ID ='{patId}' ))T_DIFFERAL_DAY," +
            //             $"(SELECT DISTINCT SYSDATE+MAX (T_DIFFERAL_DAY)  FROM T12071  " +
            //             $"WHERE T12071.T_DONOR_PATNUpdateT12022O ='{patNo}' OR t71.T_DONOR_ID ='{patId}' " +
            //             $"AND T12071.T_DONOR_EPISODE = (SELECT MAX(t71.T_DONOR_EPISODE) " +
            //             $"FROM T12071 WHERE T12071.T_DONOR_PATNO ='{patNo}' OR t71.T_DONOR_ID ='{patId}' ))DIFF_UPTO " +
            //             $"FROM T12071 t71 JOIN T03001 t01 ON t71.T_DONOR_PATNO = t01.T_PAT_NO " +
            //             $"JOIN T12022 t22 ON t71.T_DONOR_PATNO = t22.T_PAT_NO and t71.T_DONOR_EPISODE = t22.T_EPISODE_NO LEFT JOIN T12029 t29 ON t22.T_REJ_STATUS = t29.T_REJ_MAIN_CODE " +
            //             $"LEFT JOIN T02003 t03 ON t01.T_NTNLTY_CODE = t03.T_NTNLTY_CODE LEFT JOIN T02006 t06 ON t01.T_GENDER  = t06.T_SEX_CODE " +
            //             $"WHERE (SELECT MAX(T_EPISODE_NO) FROM T12022 where T12022.T_PAT_NO ='{patNo}'" +
            //             $"OR t71.T_DONOR_ID ='{patId}' ) = (SELECT MAX(t71.T_DONOR_EPISODE) " +
            //             $"FROM T12071  WHERE T12071.T_DONOR_PATNO ='{patNo}'OR t71.T_DONOR_ID ='{patId}')" +
            //             $"AND t71.T_DONOR_PATNO    = '{patNo}'OR t71.T_DONOR_ID ='{patId}'");

            // return Query($"Select DISTINCT t71.T_DONOR_PATNO,T_FIRST_LANG2_NAME ||' ' ||T_FATHER_LANG2_NAME ||' '|| T_GFATHER_LANG2_NAME ||' ' ||T_FAMILY_LANG2_NAME PAT_NAME,t01.T_GENDER,t06.T_LANG2_NAME GENDER,t01.T_NTNLTY_ID,t01.T_NTNLTY_CODE,t03.T_LANG2_NAME NATIONALITY,T_BIRTH_DATE,TRUNC(MONTHS_BETWEEN(SYSDATE,T_BIRTH_DATE) / 12, 0) YRS,TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T_BIRTH_DATE), 12), 0) MOS,MAX(t71.T_DONOR_EPISODE) OVER (PARTITION BY t71.T_DONOR_PATNO) MAX_EPISODE,(select DISTINCT MAX (T_DIFFERAL_DAY) from T12071  Where T12071.T_DONOR_PATNO ='{patNo}'  AND T12071.T_DONOR_EPISODE= (select MAX(t71.T_DONOR_EPISODE) from T12071 Where T12071.T_DONOR_PATNO ='{patNo}') )T_DIFFERAL_DAY from T12071 t71 join  T03001 t01 on t71.T_DONOR_PATNO = t01.T_PAT_NO join  T12022 t22 on t71.T_DONOR_PATNO = t22.T_PAT_NO LEFT JoIN T02003 t03 on t01.T_NTNLTY_CODE = t03.T_NTNLTY_CODE LEFT JoIN T02006 t06 on t01.T_GENDER = t06.T_SEX_CODE where t22.T_ACCEPT_STATUS='1' AND t71.T_DONOR_PATNO = '{patNo}'");
        }



        public DataTable GetReson_AcStatus(string lang, int bagWet)
        {
            //return Query($"SELECT T_WEIGHT_CODE,T_ACTION, T_LANG{lang}_NAME T_LANG2_NAME, (SELECT T_LANG{lang}_NAME  FROM T12134  WHERE T_ACTION_CODE =(SELECT T_ACTION FROM T12081 WHERE {bagWet} BETWEEN T_WEIGHT_FR AND T_WEIGHT_TO)  )UINT_ACCEPT_STATUS FROM T12081 WHERE {bagWet} BETWEEN T_WEIGHT_FR AND T_WEIGHT_TO");
            return Query($"SELECT ROWNUM, T12081.T_WEIGHT_CODE,  T12081.T_ACTION,  T12081.T_LANG2_NAME T_LANG2_NAME,   T12134.T_LANG2_NAME UINT_ACCEPT_STATUS FROM T12081 JOIN T12134 ON T12081.T_ACTION= T12134.T_ACTION_CODE WHERE {bagWet} BETWEEN T_WEIGHT_FR AND T_WEIGHT_TO AND ROWNUM=1");
        }

        public DataTable GetBed(string lang)
        {
            return Query($"SELECT T_BED_CODE,T_BED_NAME_LANG{lang} T_BED_NAME_LANG2 FROM T12123 ORDER BY T_BED_CODE ASC");
        }

        public DataTable GetDiscurtReason(string lang)
        {
            return Query($"SELECT T_RJ_RSN_CODE, T_LANG{lang}_NAME T_LANG_NAME FROM T12008 ORDER BY T_RJ_RSN_CODE ASC");
        }

        public DataTable GetbodyMermt(string pat, string epst)
        {
            return Query($"SELECT T_WEIGHT,T_HB,T_PULS,T_TEMPTURE, T_BP_HIGH,T_BP_LOW FROM T12022 WHERE T_PAT_NO = '{pat}' AND T_EPISODE_NO= '{epst}'");
        }

        public DataTable GetQuestion(string pat, string epst)
        {
            return Query($"SELECT DISTINCT T12068.T_QNO,  T12068.T_LANG2_NAME QUES_DESC,  T12071.T_QNO_ANS,  T12068.T_EXP_ANS,  NVL(T12068.T_IF_FAIL, 0) T_IF_FAIL,  T12071.T_DIFFERAL_DAY FROM T12071 INNER JOIN T12017 ON T12071.T_DONOR_PATNO = T12017.T_PAT_NO INNER JOIN T12068 ON T12071.T_QNO  = T12068.T_QNO INNER JOIN T12069 ON T12068.T_QHEAD_NO = T12069.T_QHEAD_NO WHERE T12071.T_DONOR_EPISODE = '{epst}' AND T12071.T_DONOR_PATNO = '{pat}' ORDER BY T_IF_FAIL DESC");
        }

        public DataTable GetImages(string pat, string epst)
        {
            return Query($"select CASE WHEN MAX(T_IF_FAIL) =1 THEN 'GREEN' WHEN MAX(T_IF_FAIL) =2 THEN 'yellow' ELSE 'red' END T_STATUS from (select distinct case when T12068.T_EXP_ANS=T12071.T_QNO_ANS then 1 when T12068.T_EXP_ANS<>T12071.T_QNO_ANS and  T12068.T_IF_FAIL ='1' then 2 else 3 end T_IF_FAIL from T12071 inner join T12068 on T12071.T_QNO = T12068.T_QNO where T_DONOR_PATNO = '{pat}' and T_DONOR_EPISODE = (select max(T_DONOR_EPISODE) from T12071 INNER JOIN T12022 ON T12022.T_PAT_NO = T12071.T_DONOR_PATNO AND T12022.T_EPISODE_NO = T12071.T_DONOR_EPISODE where T_DONOR_PATNO = '{pat}'))");
            // return Query($"SELECT DISTINCT T12068.T_EXP_ANS,T12071.T_DONOR_PATNO,T12071.T_DONOR_EPISODE,T12068.T_IF_FAIL ,DECODE(MAX(T12068.T_IF_FAIL),NULL,'GREEN','1','YELLOW','2','RED') DIFF_STTS_SIGN FROM T12071 INNER JOIN T12068 ON T12071.T_QNO = T12068.T_QNO Where T12071.T_DONOR_EPISODE  = '{epst}' AND T12071.T_DONOR_PATNO      = '{pat}' AND T12068.T_IF_FAIL =(SELECT MAX(T12068.T_IF_FAIL) FROM T12068) GROUP BY T12071.T_QNO_ANS,T12068.T_EXP_ANS,T12071.T_DONOR_PATNO,T12071.T_DONOR_EPISODE,T12068.T_IF_FAIL");
        }

        public DataTable getUnit_SegmNo()
        {
            //return Query("SELECT T_DEFAULT_SEQ||LPAD(NVL(T_SEQ_NO,0)+1,5,0)T_UNIT_NO,LPAD(NVL(T_SEQ_NO,0)+1,5,0)T_SEQ_NO FROM T12035 WHERE T_HOSPITAL ='1' AND T_WS_CODE ='12'");
            return Query("SELECT T_ISPT_NO||T_DEFAULT_SEQ||LPAD(NVL(T_SEQ_NO,0)+1,6,0)T_UNIT_NO,LPAD(NVL(T_SEQ_NO,0)+1,6,0)T_SEQ_NO FROM T12035 WHERE T_HOSPITAL ='1' AND T_WS_CODE ='12'");

        }

        public DataTable Getpin(string emNo)
        {
            return Query($"SELECT T_EMP_CODE,T_PIN  FROM T01009 WHERE T_EMP_CODE ='{emNo}'");
        }

        public bool InsertT12075(CommonModel t12022)
        {

            bool msg = false;
            string storeId = "";
            string collection = Query($"select (SELECT   max(CASE  WHEN T_UNIT_NO  = '{t12022.T_UNIT_NO}' AND T_SEGMENT_NO = '{t12022.T_SEGMENT_NO}'  THEN '1'  ELSE '0' END) from T12075) SAVEstatus from dual").Rows[0]["SAVEstatus"].ToString();
            if (collection == "0")
            {
                storeId = Query("SELECT NVL(MAX(T_BLD_STORE_ID),0)+1 T_BLD_STORE_ID FROM T12075").Rows[0]["T_BLD_STORE_ID"].ToString();
            }
            //  else if (collection == "1")
            //  {
            // msg = false;
            //  }
            if (storeId != "")
            {
                Command($"INSERT INTO T12075(T_ENTRY_DATE, T_UNIT_NO, T_SEGMENT_NO,T_BLD_STORE_ID,T_DONATION_DATE)"
                        + $" VALUES (SYSDATE, '{t12022.T_UNIT_NO}', '{t12022.T_SEGMENT_NO}','{storeId}',SYSDATE)");

                Command($"UPDATE T12035  SET T_SEQ_NO = '{t12022.T_SEQ_NO}' WHERE T_HOSPITAL ='1' AND T_WS_CODE = '12'");


                msg = true;
            }

            return msg;




            //  return Command($"UPDATE T12035  SET T_SEQ_NO = '{t12022.T_SEQ_NO}' WHERE T_HOSPITAL ='1' AND T_WS_CODE = '12'");
            //&& Command($"UPDATE T12017  SET T_BLOOD_DONATION_STATUS = '{t12022.T_BLOOD_DONATION_STATUS}' WHERE T_PAT_NO ='{t12022.T_DONOR_PATNO}' AND T_EPISODE_NO ='{t12022.MAX_EPISODE}'AND T_REQUEST_ID ='{t12022.T_REQUEST_ID}'");

        }
        internal bool UpdateT12022(CommonModel t12022)
        {

            //Command($"UPDATE T12022  SET T_DONATION_DATE=SYSDATE, T_UNIT_NO='{t12022.T_UNIT_NO}',T_SEGMENT_NO='{t12022.T_SEGMENT_NO}',T_PIN='{t12022.T_PIN}',T_BAG_BARCODE = '{t12022.T_BAG_BARCODE}',T_DONATION_TIME ='{t12022.T_HOUR_MIN}'" +
            //              $"WHERE T_PAT_NO = '{t12022.T_DONOR_PATNO}' AND T_EPISODE_NO = '{t12022.MAX_EPISODE}' ");
            string chkDig = "";
            string time = "";
            DataTable dtDig = Query($"select check_digit('{t12022.T_UNIT_NO}') CHKDIG,TO_CHAR(SYSDATE,'HH24MI') TIME from dual");
            if (dtDig.Rows.Count > 0)
            {
                chkDig = dtDig.Rows[0]["CHKDIG"].ToString();
                time = dtDig.Rows[0]["TIME"].ToString();
            }




            if (t12022.T_BAG_WEIGHT != null && t12022.Phebotomy != null)
            {
                Command($"UPDATE T12017  SET T_BLOOD_DONATION_STATUS = '{t12022.T_BLOOD_DONATION_STATUS}' WHERE T_PAT_NO ='{t12022.T_DONOR_PATNO}' AND T_EPISODE_NO ='{t12022.MAX_EPISODE}'"); //AND T_REQUEST_ID ='{t12022.T_REQUEST_ID}'
            }


            return Command($"UPDATE T12022  SET T_DONATION_DATE=SYSDATE, T_UNIT_NO='{t12022.T_UNIT_NO}'," +
                            $"T_SEGMENT_NO='{t12022.T_SEGMENT_NO}',T_PIN='{t12022.T_PIN}',T_BAG_BARCODE = '{t12022.T_BAG_BARCODE}'," +
                            $"T_DONATION_TIME ='{t12022.T_HOUR_MIN}', T_GENERAL_APP_CHECK_YN = '{t12022.ChkGenlApp}', " +
                            $"T_DHQ_CHECK_YN = '{t12022.ChkbxDHQ}', T_LEFT_ARM_CHECK_YN = '{t12022.ChkbxLetArm}'," +
                            $"T_RIGHT_ARM_CHECK_YN='{t12022.ChkbxRightArm}',T_BAG_CHECK_YN='{t12022.ChkbxBag}'," +
                            $"T_APHERESIS='{t12022.ChkAPheresis}',T_PLT='{t12022.ChkPLT}',T_RBCS='{t12022.ChkRBCS}'," +
                            $"T_PLSMA='{t12022.ChkPlasma}',T_DONATION_START_TIME='{t12022.DonationStartTime}'," +
                            $"T_DONATION_END_TIME='{t12022.DonationEndTime}',T_BED_NO='{t12022.T_BED_CODE}'," +
                            $"T_COMMENTS='{t12022.T_COMMENTS}',T_BAG_WEIGHT = '{t12022.T_BAG_WEIGHT}'," +
                            $"T_CANCEL_REASON='{t12022.CancelReason}',T_DONATION_COMPLETION_STATUS='{t12022.T_DONATION_COMPLETION_STATUS}'," +
                            $"T_UNIT_ACCEPT_STATUS = '{t12022.T_ACTION}',T_REMARKS='{t12022.Marks}',DISCARD_REASON_CODE='{t12022.DISCARD_REASON_CODE}'," +
                            $"T_TACD_USED='{t12022.T_TACD_USED}',T_ER_TIME='{t12022.T_ER_TIME}',T_LR_TIME='{t12022.T_LR_TIME}',T_POST_PLT ='{t12022.T_POST_PLT}'," +
                            $"T_POST_HCT='{t12022.T_POST_HCT}',T_AACD_DONOR='{t12022.T_AACD_DONOR}',T_BLOOD_PROCESSED='{t12022.T_BLOOD_PROCESSED}'," +
                            $"T_TSAL_USED='{t12022.T_TSAL_USED}',T_KIT_LOT='{t12022.T_KIT_LOT}',T_LOT_EXPIRY='{t12022.T_LOT_EXPIRY}',T_ACD_LOT ='{t12022.T_ACD_LOT}'," +
                            $"T_ACD_EXPIRY='{t12022.T_ACD_EXPIRY}',T_PLT_M_V='{t12022.T_PLT_M_V}',T_YLD_PLT='{t12022.T_YLD_PLT}',T_ACD_PLT_V='{t12022.T_ACD_PLT_V}'," +
                            $"T_PLSMA_M_V='{t12022.T_PLSMA_M_V}',T_ACD_V_PLASMA='{t12022.T_ACD_V_PLASMA}',T_RBCS_M_V='{t12022.T_RBCS_M_V}',T_ACD_V_RBC='{t12022.T_ACD_V_RBC}'," +
                            $"T_HTC_RBC='{t12022.T_HTC_RBC}',T_COMPLETE='{t12022.T_COMPLETE}',T_BAG_USED_CODE='{t12022.T_BAG_USED_CODE}',T_PHLEBOTOMY='{t12022.Phebotomy}',T_RECEIVED='1'" +
                            $",T_UNIT_DIG='{chkDig}',t_unit_char='21',T_ENTRY_TIME='{time}'" +
                            $"WHERE T_PAT_NO = '{t12022.T_DONOR_PATNO}' AND T_EPISODE_NO = '{t12022.MAX_EPISODE}' ");
            //  $"WHERE T_PAT_NO = '{t12022.T_DONOR_PATNO}' AND T_EPISODE_NO = '{t12022.MAX_EPISODE}' AND T_UNIT_NO='{t12022.T_UNIT_NO}' AND T_SEGMENT_NO='{t12022.T_SEGMENT_NO}'");

        }

        public DataTable GetMaxBidStoreId()
        {
            return Query("SELECT NVL(MAX(T_BLD_STORE_ID),0)+1 T_BLD_STORE_ID FROM T12075");
        }

        public DataTable GetComment(int phel, string lang)
        {
            return Query($"SELECT T_LANG{lang}_NAME T_COMMENTS,T_TIME_CODE FROM T12082 where {phel} BETWEEN T_NR_FROM AND T_NR_TO");
        }
        public DataTable GetComntT12328(string lang, int ple)
        {
            return Query($"SELECT T_TIME_CODE,T_LANG{lang}_NAME T_COMMENTS,T_NR_FROM, T_NR_TO FROM T12328 WHERE {ple} BETWEEN T_NR_FROM AND T_NR_TO");
        }
        internal bool SecondUpdate(CommonModel t12022)
        {
            //bool msg = false;
            //string storeId = "";
            ////string collection = Query($"SELECT T_UNIT_NO, CASE  WHEN T_UNIT_NO = '{t12022.T_UNIT_NO}' AND T_SEGMENT_NO = '{t12022.T_SEGMENT_NO}' Then '1' else   '0' end SAVEstatus FROM T12075 WHERE T_UNIT_NO  ='{t12022.T_UNIT_NO}' AND T_SEGMENT_NO ='{t12022.T_SEGMENT_NO}'").Rows[0]["SAVEstatus"].ToString();
            //string collection = Query($"select (SELECT   max(CASE  WHEN T_UNIT_NO  = '{t12022.T_UNIT_NO}' AND T_SEGMENT_NO = '{t12022.T_SEGMENT_NO}'  THEN '1'  ELSE '0' END) from T12075) SAVEstatus from dual").Rows[0]["SAVEstatus"].ToString();
            //if (collection=="0")
            //{
            //     storeId = Query("SELECT NVL(MAX(T_BLD_STORE_ID),0)+1 T_BLD_STORE_ID FROM T12075").Rows[0]["T_BLD_STORE_ID"].ToString();
            //}
            //else if (collection == "1")
            //{
            //    msg = false;
            //}
            //if (storeId !="")
            //{
            //  Command($"INSERT INTO T12075(T_ENTRY_DATE, T_UNIT_NO, T_SEGMENT_NO,T_BLD_STORE_ID,T_DONATION_DATE)"
            //    + $" VALUES (SYSDATE, '{t12022.T_UNIT_NO}', '{t12022.T_SEGMENT_NO}','{storeId}',SYSDATE)");

            Command($"UPDATE T12017  SET T_BLOOD_DONATION_STATUS = '{t12022.T_BLOOD_DONATION_STATUS}' WHERE T_PAT_NO ='{t12022.T_DONOR_PATNO}' AND T_EPISODE_NO ='{t12022.MAX_EPISODE}'"); //AND T_REQUEST_ID ='{t12022.T_REQUEST_ID}'

            return Command($"UPDATE T12022  SET T_GENERAL_APP_CHECK_YN = '{t12022.ChkGenlApp}', " +
                          $"T_DHQ_CHECK_YN = '{t12022.ChkbxDHQ}', T_LEFT_ARM_CHECK_YN = '{t12022.ChkbxLetArm}'," +
                          $"T_RIGHT_ARM_CHECK_YN='{t12022.ChkbxRightArm}',T_BAG_CHECK_YN='{t12022.ChkbxBag}'," +
                          $"T_APHERESIS='{t12022.ChkAPheresis}',T_PLT='{t12022.ChkPLT}',T_RBCS='{t12022.ChkRBCS}'," +
                          $"T_PLSMA='{t12022.ChkPlasma}',T_DONATION_START_TIME='{t12022.DonationStartTime}'," +
                          $"T_DONATION_END_TIME='{t12022.DonationEndTime}',T_BED_NO='{t12022.T_BED_CODE}'," +
                          $"T_COMMENTS='{t12022.T_COMMENTS}',T_BAG_WEIGHT = '{t12022.T_BAG_WEIGHT}',T_BAG_BARCODE = '{t12022.T_BAG_BARCODE}'," +
                          $"T_CANCEL_REASON='{t12022.CancelReason}',T_DONATION_COMPLETION_STATUS='{t12022.T_DONATION_COMPLETION_STATUS}'," +
                          $"T_UNIT_ACCEPT_STATUS = '{t12022.T_ACTION}',T_REMARKS='{t12022.Marks}',DISCARD_REASON_CODE='{t12022.DISCARD_REASON_CODE}'," +
                          $"T_TACD_USED='{t12022.T_TACD_USED}',T_ER_TIME='{t12022.T_ER_TIME}',T_LR_TIME='{t12022.T_LR_TIME}',T_POST_PLT ='{t12022.T_POST_PLT}'," +
                          $"T_POST_HCT='{t12022.T_POST_HCT}',T_AACD_DONOR='{t12022.T_AACD_DONOR}',T_BLOOD_PROCESSED='{t12022.T_BLOOD_PROCESSED}'," +
                          $"T_TSAL_USED='{t12022.T_TSAL_USED}',T_KIT_LOT='{t12022.T_KIT_LOT}',T_LOT_EXPIRY='{t12022.T_LOT_EXPIRY}',T_ACD_LOT ='{t12022.T_ACD_LOT}'," +
                          $"T_ACD_EXPIRY='{t12022.T_ACD_EXPIRY}',T_PLT_M_V='{t12022.T_PLT_M_V}',T_YLD_PLT='{t12022.T_YLD_PLT}',T_ACD_PLT_V='{t12022.T_ACD_PLT_V}'," +
                          $"T_PLSMA_M_V='{t12022.T_PLSMA_M_V}',T_ACD_V_PLASMA='{t12022.T_ACD_V_PLASMA}',T_RBCS_M_V='{t12022.T_RBCS_M_V}',T_ACD_V_RBC='{t12022.T_ACD_V_RBC}'," +
                          $"T_HTC_RBC='{t12022.T_HTC_RBC}',T_COMPLETE='{t12022.T_COMPLETE}',T_BAG_USED_CODE='{t12022.T_BAG_USED_CODE}',T_PHLEBOTOMY='{t12022.Phebotomy}',T_RECEIVED='1'" +
                          $"WHERE T_PAT_NO = '{t12022.T_DONOR_PATNO}' AND T_EPISODE_NO = '{t12022.MAX_EPISODE}' AND T_UNIT_NO='{t12022.T_UNIT_NO}' AND T_SEGMENT_NO='{t12022.T_SEGMENT_NO}'");
            //  msg = true;
            //}

            //return msg;
        }
        //internal bool SecondUpdate(List<CommonModel> t12022)
        //{
        //    foreach (var list in t12022)
        //    {
        //    Command($"UPDATE T12022  SET T_GENERAL_APP_CHECK_YN = '{list.ChkGenlApp}', " +
        //                   $"T_DHQ_CHECK_YN = '{list.ChkbxDHQ}', T_LEFT_ARM_CHECK_YN = '{list.ChkbxLetArm}'," +
        //                   $"T_RIGHT_ARM_CHECK_YN='{list.ChkbxRightArm}',T_BAG_CHECK_YN='{list.ChkbxBag}'," +
        //                   $"T_APHERESIS='{list.ChkAPheresis}',T_PLT='{list.ChkPLT}',T_RBCS='{list.ChkRBCS}'," +
        //                   $"T_PLSMA='{list.ChkPlasma}',T_DONATION_START_TIME='{list.DonationStartTime}'," +
        //                   $"T_DONATION_END_TIME='{list.DonationEndTime}',T_BED_NO='{list.T_BED_CODE}'," +
        //                   $"T_COMMENTS='{list.T_COMMENTS}',T_BAG_WEIGHT = '{list.T_BAG_WEIGHT}',T_BAG_BARCODE = '{list.T_BAG_BARCODE}'," +
        //                   $"T_CANCEL_REASON='{list.CancelReason}',T_DONATION_COMPLETION_STATUS='{list.T_DONATION_COMPLETION_STATUS}'," +
        //                   $"T_UNIT_ACCEPT_STATUS = '{list.T_ACTION}',T_REMARKS='{list.Marks}',DISCARD_REASON_CODE='{list.DISCARD_REASON_CODE}'," +
        //                   $"T_TACD_USED='{list.T_TACD_USED}',T_ER_TIME='{list.T_ER_TIME}',T_LR_TIME='{list.T_LR_TIME}',T_POST_PLT ='{list.T_POST_PLT}'," +
        //                   $"T_POST_HCT='{list.T_POST_HCT}',T_AACD_DONOR='{list.T_AACD_DONOR}',T_BLOOD_PROCESSED='{list.T_BLOOD_PROCESSED}'," +
        //                   $"T_TSAL_USED='{list.T_TSAL_USED}',T_KIT_LOT='{list.T_KIT_LOT}',T_LOT_EXPIRY='{list.T_LOT_EXPIRY}',T_ACD_LOT ='{list.T_ACD_LOT}'," +
        //                   $"T_ACD_EXPIRY='{list.T_ACD_EXPIRY}',T_PLT_M_V='{list.T_PLT_M_V}',T_YLD_PLT='{list.T_YLD_PLT}',T_ACD_PLT_V='{list.T_ACD_PLT_V}'," +
        //                   $"T_PLSMA_M_V='{list.T_PLSMA_M_V}',T_ACD_V_PLASMA='{list.T_ACD_V_PLASMA}',T_RBCS_M_V='{list.T_RBCS_M_V}',T_ACD_V_RBC='{list.T_ACD_V_RBC}'," +
        //                   $"T_HTC_RBC='{list.T_HTC_RBC}',T_COMPLETE='{list.T_COMPLETE}',T_BAG_USED_CODE='{list.T_BAG_USED_CODE}',T_PHLEBOTOMY='{list.Phebotomy}',T_RECEIVED='1'" +
        //                   $"WHERE T_PAT_NO = '{list.T_DONOR_PATNO}' AND T_EPISODE_NO = '{list.MAX_EPISODE}' AND T_UNIT_NO='{list.T_UNIT_NO}' AND T_SEGMENT_NO='{list.T_SEGMENT_NO}'");
        //    }
        //    return true;
        //}

        public DataTable showDataFromT12022(string lang, string patNo, string epsort)
        {
            return Query($"SELECT T_UNIT_NO,  T_SEGMENT_NO,  T_DHQ_CHECK_YN,  T_BAG_CHECK_YN, " +
                         $" T_GENERAL_APP_CHECK_YN,  T_LEFT_ARM_CHECK_YN,  T_RIGHT_ARM_CHECK_YN,  " +
                         $"T_PLSMA,  T_PLT,  T_RBCS,  T_APHERESIS,  T_DONATION_START_TIME,  " +
                         $"T_DONATION_END_TIME,  T_BED_NO,  T_COMMENTS,  T_BAG_WEIGHT,  T_CANCEL_REASON," +
                         $"  T_REMARKS,  T_UNIT_ACCEPT_STATUS,T12134.T_LANG{lang}_NAME UNIT_ACCEPT_STATUS,T12077.T_LANG{lang}_NAME BAG_USED,  DISCARD_REASON_CODE,  T_TACD_USED," +
                         $" T_ER_TIME,  T_LR_TIME,  T_POST_PLT,  T_POST_HCT,  T_AACD_DONOR,  " +
                         $"T_BLOOD_PROCESSED,  T_TSAL_USED,  T_KIT_LOT,  T_LOT_EXPIRY,  T_ACD_LOT, " +
                         $" T_ACD_EXPIRY,  T_PLT_M_V,  T_YLD_PLT,  T_ACD_PLT_V,  T_PLSMA_M_V, " +
                         $" T_ACD_V_PLASMA,  T_RBCS_M_V,  T_RBCS_M_V,  T_ACD_V_RBC,  T_HTC_RBC, T_COMPLETE, " +
                         $"T12123.T_BED_NAME_LANG{lang} T_BED_NAME_LANG2,  T12008.T_LANG{lang}_NAME DISCAD_NAME, " +
                         $" T_DONATION_COMPLETION_STATUS,T_PHLEBOTOMY, T12022.T_BAG_USED_CODE FROM T12022 " +
                         $"LEFT JOIN T12123 ON T12022.T_BED_NO =T12123.T_BED_CODE " +
                         $"LEFT JOIN T12008 ON T12022.DISCARD_REASON_CODE = T12008.T_RJ_RSN_CODE " +
                         $"LEFT JOIN T12134 ON T12022.T_UNIT_ACCEPT_STATUS = T12134.T_ACTION_CODE LEFT JOIN T12077 ON T12022.T_BAG_USED_CODE = T12077.T_BAG_USED_CODE " +
                         $"WHERE T_PAT_NO   = '{patNo}' AND T_EPISODE_NO = '{epsort}' AND T_UNIT_NO is not null AND T_SEGMENT_NO is not null");
        }
    }
}