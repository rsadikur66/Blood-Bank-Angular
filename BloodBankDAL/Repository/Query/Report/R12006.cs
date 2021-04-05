﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Report
{
    public class R12006 : CommonDAL
    {
        public DataTable getReport(string lang, string patNo)
        {
            return Query($"SELECT rownum R, k.* FROM (WITH tab1 AS (SELECT DISTINCT * FROM (SELECT CASE WHEN(SELECT MAX(T_DONOR_EPISODE) FROM T12071 WHERE T_DONOR_PATNO = '{patNo}') IS NULL THEN (SELECT MAX(T_EPISODE_NO) FROM T12017 WHERE T_PAT_NO = '{patNo}' ) ELSE (SELECT MAX(T_DONOR_EPISODE) FROM T12071 WHERE T_DONOR_PATNO = '{patNo}' ) END T_EPISODE_NO, T_PAT_NO, CASE WHEN(SELECT T_EXP_ANS FROM T12068 WHERE T_QNO = T12071.T_QNO) = T_QNO_ANS THEN '1' ELSE '2' END T_QNO_ANS, T_QNO ,T_RESEARCH_STTS FROM T12017 LEFT OUTER JOIN T12071 ON T12017.T_PAT_NO = T12071.T_DONOR_PATNO WHERE T_PAT_NO = '{patNo}' ) ), tab2 AS (SELECT T_DONOR_PATNO, T_DONOR_EPISODE, T_QNO, T_QNO_ANS, T_QUES_ID FROM T12071 WHERE T_DONOR_PATNO = '{patNo}' AND T_DONOR_EPISODE = (SELECT MAX(T_DONOR_EPISODE) FROM T12071 WHERE T_DONOR_PATNO = '{patNo}' ) ), tab3 AS (SELECT DISTINCT tab2.T_QNO, T_DONOR_PATNO, T_DONOR_EPISODE, tab2.T_QNO_ANS, tab2.T_QUES_ID,tab1.T_RESEARCH_STTS FROM tab2 LEFT OUTER JOIN tab1 ON tab2.T_DONOR_PATNO = tab1.T_PAT_NO AND tab2.T_QNO = tab1.T_QNO AND tab2.T_DONOR_EPISODE = tab1.T_EPISODE_NO ), QuesTab AS (SELECT DISTINCT SUM(T12068.T_QHEAD_NO) HEADER_NO, (SELECT COUNT(T12068.T_QNO) FROM T12068 A WHERE A.T_QHEAD_NO = T12068.T_QHEAD_NO AND(A.T_SEX IS NULL OR A.T_SEX = '1') ) TOTAL_QUES, T12068.T_LANG{lang}_NAME QUES_DESC, T12068.T_QHEAD_NO, T12069.T_LANG{lang}_NAME QUES_HEADER,T12068.T_QNO, T12068.T_DISP_SEQ, T12068.T_DIFFERAL_DAY, T_EXP_ANS, T_IF_FAIL FROM T12068 INNER JOIN T12069 ON T12068.T_QHEAD_NO = T12069.T_QHEAD_NO WHERE(T12068.T_SEX IS NULL OR T12068.T_SEX = '1') GROUP BY T12068.T_LANG1_NAME, T12068.T_LANG2_NAME, T12068.T_QHEAD_NO, T12069.T_LANG1_NAME, T12069.T_LANG2_NAME, T12068.T_QNO, T12068.T_DISP_SEQ, T12068.T_DIFFERAL_DAY, T_EXP_ANS, T_IF_FAIL ORDER BY T12068.T_QHEAD_NO, to_number(T_DISP_SEQ) ) SELECT QuesTab.HEADER_NO, QuesTab.TOTAL_QUES, QuesTab.QUES_DESC, QuesTab.T_QHEAD_NO, QuesTab.QUES_HEADER, QuesTab.T_QNO, QuesTab.T_DISP_SEQ, QuesTab.T_DIFFERAL_DAY, QuesTab.T_EXP_ANS, QuesTab.T_IF_FAIL, tab3.T_QNO_ANS, tab3.T_QUES_ID, tab3.T_RESEARCH_STTS FROM QuesTab LEFT OUTER JOIN tab3 ON NVL(QuesTab.T_QNO, 0) = NVL(tab3.T_QNO, 0) ORDER BY QuesTab.HEADER_NO, to_number(T_DISP_SEQ) ) k");
        }

        public DataTable GetR12006PatProfile(string lang,string patNo)
        {
            return Query(
                $"SELECT T_PAT_NO,NAME,T_NTNLTY_ID,T_LANG2_NAME AS NATIONALITY,TRUNC(MONTHS_BETWEEN(SYSDATE,T_BIRTH_DATE) / 12, 0) as YRS,T_PHONE_HOME,T_UNIT_NO,T_GENDER,MAX_EPISODE,T_REQUEST_ID,T_BLOOD_DONATION_STATUS,REASON,DONATION_DATE FROM (SELECT DISTINCT T12017.T_PAT_NO,T12017.T_EPISODE_NO,T03001.T_GENDER,T03001.T_NTNLTY_ID,T02003.T_LANG2_NAME,T03001.T_BIRTH_DATE,T03001.T_PHONE_HOME,T12019.T_UNIT_NO,T03001.T_FIRST_LANG{lang}_NAME ||' ' || T03001.T_FATHER_LANG{lang}_NAME ||' ' || T03001.T_FAMILY_LANG{lang}_NAME NAME,MAX(T12017.T_EPISODE_NO) OVER (PARTITION BY T12017.T_PAT_NO) MAX_EPISODE,T12017.T_REQUEST_ID,T12017.T_BLOOD_DONATION_STATUS,T12006.T_LANG{lang}_NAME as REASON,T12017.T_DONATION_DATE as DONATION_DATE FROM T12017 INNER JOIN T03001 ON T12017.T_PAT_NO = T03001.T_PAT_NO INNER JOIN T02003 ON T03001.T_NTNLTY_CODE= T02003.T_NTNLTY_CODE LEFT JOIN T12019 ON T12019.T_SITE_CODE=T12017.T_SITE_CODE LEFT JOIN T12071 on T12017.T_REQUEST_ID=T12071.T_REQUEST_ID INNER JOIN T12006 on T12017.T_DOTN_RSN_CODE=T12006.T_DOTN_RSN_CODE WHERE   T12017.T_SITE_CODE='0001'  ORDER BY T12017.T_PAT_NO) WHERE T_EPISODE_NO=MAX_EPISODE AND T_PAT_NO='{patNo}'");
        }

        public DataTable GetR12006Agreement(string lang,string patNo)
        {
            //return Query(
            //    $"SELECT T_LANG{lang}_NAME AGREEMENT FROM T12068 WHERE T_QNO='Q100'");

            return Query(
                $"SELECT T_LANG{lang}_NAME Agreement,(SELECT T_CONTROL_TEXT_LANG{lang}  from T12132 WHERE T_CONTROL_NAME='lblTrunsPatient') as Confirmation from T12068 where T_QNO='Q100'");
        }

        public DataTable GetR12006Confirmation(string lang)
        {
            return Query($"SELECT T_CONTROL_TEXT_LANG{lang} CONFIRMATION  from T12132 WHERE T_CONTROL_NAME='lblTrunsPatient'");
        }

        /* R12215 Report Query By Pervez */

        public DataTable GetR12215Summery(string entryDate, int siteCode, string donationDate)
        {
            return Query($"WITH count1 AS (SELECT COUNT(*) Registered FROM t12017 WHERE TO_DATE(T_ENTRY_DATE,'dd/MM/yyyy') = TO_DATE('{entryDate}','dd/MM/yyyy') AND T_SITE_CODE ={siteCode} ), count2 AS (SELECT COUNT(*) Examined FROM t12022 INNER JOIN t12017 ON t12022.T_REQUEST_ID =T12017.T_REQUEST_ID WHERE TO_DATE(t12022.T_ENTRY_DATE,'dd/MM/yyyy') = TO_DATE('{entryDate}','dd/MM/yyyy') AND T12017.T_SITE_CODE ={siteCode} ), count3 AS (SELECT COUNT(T_UNIT_NO) donated FROM t12022 INNER JOIN t12017 ON t12022.T_REQUEST_ID =T12017.T_REQUEST_ID WHERE TO_DATE(t12022.T_DONATION_DATE,'dd/MM/yyyy') = TO_DATE('{entryDate}','dd/MM/yyyy') AND T12017.T_SITE_CODE ={siteCode} AND t12022.t_unit_no IS NOT NULL ), count4 AS (SELECT CASE WHEN REJECTED IS NULL THEN REJECTED1 ELSE REJECTED END AS REJECTED FROM( SELECT COUNT(*) AS REJECTED, NuLL AS REJECTED1 FROM t12022 INNER JOIN t12017 ON t12022.T_REQUEST_ID =T12017.T_REQUEST_ID WHERE TO_DATE(t12022.T_ENTRY_DATE,'dd/MM/yyyy') = TO_DATE('{entryDate}','dd/MM/yyyy') AND t_unit_no IS NULL AND T_ACCEPT_STATUS! ='1' GROUP BY t12022.T_ENTRY_DATE UNION SELECT Null AS REJECTED,0 AS REJECTED1 FROM DUAL WHERE NOT EXISTS (SELECT COUNT(*) FROM t12022 INNER JOIN t12017 ON t12022.T_REQUEST_ID =T12017.T_REQUEST_ID WHERE TO_DATE(t12022.T_ENTRY_DATE,'dd/MM/yyyy') = TO_DATE('{entryDate}','dd/MM/yyyy') AND t_unit_no IS NULL AND T_ACCEPT_STATUS! ='1' GROUP BY t12022.T_ENTRY_DATE) )), count5 AS (SELECT COUNT(*) cancelled FROM t12022 INNER JOIN t12017 ON t12022.T_REQUEST_ID =T12017.T_REQUEST_ID WHERE TO_DATE(t12022.T_DONATION_DATE,'dd/MM/yyyy') = TO_DATE('{entryDate}','dd/MM/yyyy') AND t_unit_no IS NOT NULL AND T_DONATION_COMPLETION_STATUS ='3' ) SELECT Registered, Examined, donated, REJECTED, cancelled FROM count1, count2, count3, count4, count5");
            // return Query($"with count1 as ( select count(*) Registered from t12017 where TRUNC(T_ENTRY_DATE) = TO_DATE('{entryDate}','dd/MM/yyyy') AND T_SITE_CODE={siteCode} ), count2 as ( select count(*) Examined from t12022 INNER join t12017 on t12022.T_REQUEST_ID=T12017.T_REQUEST_ID where TRUNC(t12022.T_ENTRY_DATE) = TO_DATE('{entryDate}','dd/MM/yyyy') AND T12017.T_SITE_CODE={siteCode} ), count3 as ( select count(T_UNIT_NO) donated from t12022 INNER join t12017 on t12022.T_REQUEST_ID=T12017.T_REQUEST_ID where TRUNC(t12022.T_DONATION_DATE) = TO_DATE('{donationDate}','dd/MM/yyyy') AND T12017.T_SITE_CODE={siteCode} AND t12022.t_unit_no is not null ), count4 as ( select count(*) REJECTED from t12022 INNER join t12017 on t12022.T_REQUEST_ID=T12017.T_REQUEST_ID where TRUNC(t12022.T_ENTRY_DATE) = TO_DATE('{entryDate}','dd/MM/yyyy') AND t_unit_no is null AND T_ACCEPT_STATUS!='1' ), count5 as ( select count(*) cancelled from t12022 INNER join t12017 on t12022.T_REQUEST_ID=T12017.T_REQUEST_ID where TRUNC(t12022.T_DONATION_DATE) = TO_DATE('{donationDate}','dd/MM/yyyy') AND t_unit_no is not null AND T_DONATION_COMPLETION_STATUS='3' ) select Registered, Examined,donated,REJECTED,cancelled from count1, count2,count3,count4,count5");
        }

        public DataTable GetR12215SiteCode(int siteCode, string lang)
        {
            return Query($"select T_SITE_CODE , T_COUNTRY_LANG1_NAME , T_COUNTRY_LANG2_NAME , T_MIN_LANG1_NAME , T_MIN_LANG2_NAME , T_SITE_LANG1_NAME , T_SITE_LANG2_NAME , T_LOGO_ID , T_LOGO_NAME , T_LOGO , t_lcence_no from t01028 where t_site_code={siteCode}");
        }


        public DataTable GetR12215CollectedUnit(int siteCode,string donationDate)
        {
            return Query(
                $"SELECT T_UNIT_NO || ' ' || T_DONATION_TIME donation_time,T12022.T_PIN,T01009.T_USER_NAME FROM T12022 INNER JOIN T12017 ON T12022.T_REQUEST_ID=T12017.T_REQUEST_ID INNER JOIN T01009 ON T12022.T_PIN=T01009.T_PIN WHERE TO_DATE(T12022.T_DONATION_DATE,'dd/MM/yyyy') = TO_DATE('{donationDate}','dd/MM/yyyy') AND T12017.T_SITE_CODE={siteCode} order by t_donation_time");
        }

        /* R12215 Report Query By Pervez */

        //start code by sadik
        public DataTable GetTechList(string site)
        {
            return Query($"select t_pin,t_user_name from t01009 where t_pin is not null AND T_SITE_CODE = '{site}'");
        }
        public DataTable GetReasonList(string lang)
        {
            return Query($"SELECT T_DOTN_RSN_CODE,T_LANG{lang}_NAME FROM T12006");
        }


        //end code by sadik
        public DataTable getCollector(string lang, string fdate)
        {
            return Query($"SELECT T01009.T_EMP_CODE , T01009.T_USER_NAME,TO_CHAR(T12022.T_DONATION_DATE,'DAY')T_DAY, COUNT(*)T_COUNT FROM T12022 INNER JOIN T12017 ON T12022.T_REQUEST_ID=T12017.T_REQUEST_ID INNER JOIN T01009 ON T12022.T_PIN =T01009.T_PIN WHERE TO_DATE(T12022.T_DONATION_DATE,'dd/MM/yyyy') = TO_DATE('{fdate}','dd/MM/yyyy') AND T12017.T_SITE_CODE =0001 GROUP BY T01009.T_EMP_CODE ,T01009.T_USER_NAME,TO_CHAR(T12022.T_DONATION_DATE,'DAY')");
        }

        public DataTable getCollection(string lang, string fdate)
        {
            return Query($"SELECT T_UNIT_NO || ' ' || T_DONATION_TIME DONATION_TIME, T12022.T_PIN, T01009.T_USER_NAME, T01009.T_EMP_CODE FROM T12022 INNER JOIN T12017 ON T12022.T_REQUEST_ID=T12017.T_REQUEST_ID INNER JOIN T01009 ON T12022.T_PIN =T01009.T_PIN WHERE TO_DATE(T12022.T_DONATION_DATE,'dd/MM/yyyy') = TO_DATE('{fdate}','dd/MM/yyyy') AND T12017.T_SITE_CODE =0001 ORDER BY DONATION_TIME");
        }

        public DataTable getCountTime(string lang, string fdate)
        {
            return Query($"SELECT TABLE_1.T_EMP_CODE, COUNT(*)T_COUNT_TIME FROM ( SELECT SUBSTR(T_DONATION_TIME,1,2) T_DONATION_TIME, T01009.T_EMP_CODE, COUNT(*)T_COUNT FROM T12022 INNER JOIN T12017 ON T12022.T_REQUEST_ID=T12017.T_REQUEST_ID INNER JOIN T01009 ON T12022.T_PIN =T01009.T_PIN WHERE TO_DATE(T12022.T_DONATION_DATE,'dd/MM/yyyy') = TO_DATE('{fdate}','dd/MM/yyyy') AND T12017.T_SITE_CODE =0001 GROUP BY SUBSTR(T_DONATION_TIME,1,2), T01009.T_EMP_CODE )TABLE_1 GROUP BY TABLE_1.T_EMP_CODE");
        }
    }
}