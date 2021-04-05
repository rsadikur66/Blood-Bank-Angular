using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12244:CommonDAL
    {
        public DataTable getPatNo(string P_PAT_NO, String T_SITE_CODE)
        {
            
        return Query(
                $"SELECT T_PAT_NO,NAME_ARB,NAME_ENG ,T_NTNLTY_ID,T_GENDER,MAX_EPISODE,T_REQUEST_ID,T_BLOOD_DONATION_STATUS FROM (SELECT DISTINCT T12017.T_PAT_NO,T12017.T_EPISODE_NO,T03001.T_GENDER,T03001.T_NTNLTY_ID, T03001.T_FIRST_LANG1_NAME ||' ' || T03001.T_FATHER_LANG1_NAME ||' ' || T03001.T_FAMILY_LANG1_NAME NAME_ARB ,T03001.T_FIRST_LANG2_NAME || ' '|| T03001.T_FATHER_LANG2_NAME ||' ' || T03001.T_FAMILY_LANG2_NAME NAME_ENG ,MAX(T12017.T_EPISODE_NO) OVER (PARTITION BY T12017.T_PAT_NO) MAX_EPISODE,T12017.T_REQUEST_ID,T12017.T_BLOOD_DONATION_STATUS FROM T12017 INNER JOIN T03001 ON T12017.T_PAT_NO = T03001.T_PAT_NO LEFT JOIN T12071 on T12017.T_REQUEST_ID=T12071.T_REQUEST_ID WHERE   T12017.T_SITE_CODE='{T_SITE_CODE}' /* AND (T12017.T_BLOOD_DONATION_STATUS IS NULL OR T12017.T_BLOOD_DONATION_STATUS<3)  AND T12017.T_ENTRY_DATE >= SYSDATE-1*/ ORDER BY T12017.T_PAT_NO) WHERE T_EPISODE_NO=MAX_EPISODE AND T_PAT_NO='{P_PAT_NO}'");
        }
        public DataTable getQuestions(int type, string P_SEX, string P_PAT_NO)
        {

            //return Query($"SELECT ROWNUM R,T.* FROM (SELECT DISTINCT SUM(T12068.T_QHEAD_NO) HEADER_NO,(SELECT COUNT(T12068.T_QNO) FROM T12068 A WHERE A.T_QHEAD_NO=T12068.T_QHEAD_NO AND (A.T_SEX  IS NULL  OR A.T_SEX = '" + P_SEX + "')) TOTAL_QUES, T12068.T_LANG" + type + "_NAME QUES_DESC, T12068.T_QHEAD_NO,T12069.T_LANG" + type + "_NAME QUES_HEADER,T12068.T_QNO, T12068.T_DISP_SEQ, T12068.T_DIFFERAL_DAY,T_EXP_ANS,T_IF_FAIL FROM T12068 INNER JOIN T12069 ON T12068.T_QHEAD_NO = T12069.T_QHEAD_NO WHERE T12068.T_SEX  IS NULL OR T12068.T_SEX      = '" + P_SEX + "' GROUP BY   T12068.T_LANG" + type + "_NAME, T12068.T_QHEAD_NO, T12069.T_LANG" + type + "_NAME, T12068.T_QNO,T12068.T_DISP_SEQ,    T12068.T_DIFFERAL_DAY, T_EXP_ANS, T_IF_FAIL  ORDER BY T12068.T_QHEAD_NO) T");
            //return Query($"select rownum R, k.* from (WITH tab1 AS (SELECT DISTINCT * FROM (SELECT CASE WHEN(SELECT MAX(T_DONOR_EPISODE) FROM T12071 WHERE T_DONOR_PATNO = '{P_PAT_NO}') IS NULL THEN (SELECT MAX(T_EPISODE_NO) FROM T12017 WHERE T_PAT_NO = '{P_PAT_NO}') ELSE(SELECT MAX(T_DONOR_EPISODE) FROM T12071 WHERE T_DONOR_PATNO = '{P_PAT_NO}') END T_EPISODE_NO,T_PAT_NO,CASE WHEN(SELECT T_EXP_ANS FROM T12068 WHERE T_QNO = T12071.T_QNO) = T_QNO_ANS THEN '1' ELSE '2' END T_QNO_ANS, T_QNO FROM T12017 LEFT OUTER JOIN T12071 ON T12017.T_PAT_NO = T12071.T_DONOR_PATNO WHERE T_PAT_NO = '{P_PAT_NO}')),tab2 AS(SELECT T_DONOR_PATNO,T_DONOR_EPISODE,T_QNO,T_QNO_ANS, T_QUES_ID FROM T12071 WHERE T_DONOR_PATNO = '{P_PAT_NO}' AND T_DONOR_EPISODE =(SELECT MAX(T_DONOR_EPISODE) FROM T12071 WHERE T_DONOR_PATNO = '{P_PAT_NO}')),tab3 AS(SELECT DISTINCT tab2.T_QNO, T_DONOR_PATNO, T_DONOR_EPISODE,tab2.T_QNO_ANS,tab2.T_QUES_ID FROM tab2 LEFT OUTER JOIN tab1 ON tab2.T_DONOR_PATNO = tab1.T_PAT_NO AND tab2.T_QNO = tab1.T_QNO AND tab2.T_DONOR_EPISODE = tab1.T_EPISODE_NO),QuesTab AS(SELECT DISTINCT SUM(T12068.T_QHEAD_NO) HEADER_NO,(SELECT COUNT(T12068.T_QNO) FROM T12068 A WHERE A.T_QHEAD_NO = T12068.T_QHEAD_NO AND(A.T_SEX IS NULL OR A.T_SEX = '" + P_SEX + "')) TOTAL_QUES,T12068.T_LANG" + type + "_NAME QUES_DESC,T12068.T_QHEAD_NO, T12069.T_LANG" + type + "_NAME QUES_HEADER,T12068.T_QNO,T12068.T_DISP_SEQ, T12068.T_DIFFERAL_DAY,T_EXP_ANS,T_IF_FAIL FROM T12068 INNER JOIN T12069 ON T12068.T_QHEAD_NO = T12069.T_QHEAD_NO WHERE(T12068.T_SEX IS NULL OR T12068.T_SEX = '" + P_SEX + "') GROUP BY T12068.T_LANG" + type + "_NAME,T12068.T_QHEAD_NO, T12069.T_LANG" + type + "_NAME,T12068.T_QNO,T12068.T_DISP_SEQ, T12068.T_DIFFERAL_DAY, T_EXP_ANS,T_IF_FAIL ORDER BY T12068.T_QHEAD_NO) SELECT QuesTab.HEADER_NO, QuesTab.TOTAL_QUES, QuesTab.QUES_DESC, QuesTab.T_QHEAD_NO, QuesTab.QUES_HEADER, QuesTab.T_QNO, QuesTab.T_DISP_SEQ, QuesTab.T_DIFFERAL_DAY, QuesTab.T_EXP_ANS, QuesTab.T_IF_FAIL,tab3.T_QNO_ANS,tab3.T_QUES_ID FROM QuesTab LEFT OUTER JOIN tab3 ON NVL(QuesTab.T_QNO, 0) = NVL(tab3.T_QNO, 0) order by QuesTab.HEADER_NO) k");
            return Query($"select rownum R, k.* from (WITH tab1 AS (SELECT DISTINCT * FROM (SELECT CASE WHEN(SELECT MAX(T_DONOR_EPISODE) FROM T12071 WHERE T_DONOR_PATNO = '{P_PAT_NO}') IS NULL THEN (SELECT MAX(T_EPISODE_NO) FROM T12017 WHERE T_PAT_NO = '{P_PAT_NO}') ELSE(SELECT MAX(T_DONOR_EPISODE) FROM T12071 WHERE T_DONOR_PATNO = '{P_PAT_NO}') END T_EPISODE_NO,T_PAT_NO,CASE WHEN(SELECT T_EXP_ANS FROM T12068 WHERE T_QNO = T12071.T_QNO) = T_QNO_ANS THEN '1' ELSE '2' END T_QNO_ANS, T_QNO FROM T12017 LEFT OUTER JOIN T12071 ON T12017.T_PAT_NO = T12071.T_DONOR_PATNO WHERE T_PAT_NO = '{P_PAT_NO}')),tab2 AS(SELECT T_DONOR_PATNO,T_DONOR_EPISODE,T_QNO,T_QNO_ANS, T_QUES_ID FROM T12071 WHERE T_DONOR_PATNO = '{P_PAT_NO}' AND T_DONOR_EPISODE =(SELECT MAX(T_DONOR_EPISODE) FROM T12071 WHERE T_DONOR_PATNO = '{P_PAT_NO}')),tab3 AS(SELECT DISTINCT tab2.T_QNO, T_DONOR_PATNO, T_DONOR_EPISODE,tab2.T_QNO_ANS,tab2.T_QUES_ID FROM tab2 LEFT OUTER JOIN tab1 ON tab2.T_DONOR_PATNO = tab1.T_PAT_NO AND tab2.T_QNO = tab1.T_QNO AND tab2.T_DONOR_EPISODE = tab1.T_EPISODE_NO),QuesTab AS(SELECT DISTINCT SUM(T12068.T_QHEAD_NO) HEADER_NO,(SELECT COUNT(T12068.T_QNO) FROM T12068 A WHERE A.T_QHEAD_NO = T12068.T_QHEAD_NO AND(A.T_SEX IS NULL OR A.T_SEX = '" + P_SEX + "')) TOTAL_QUES,T12068.T_LANG1_NAME QUES_DESC1,T12068.T_LANG2_NAME QUES_DESC2,T12068.T_QHEAD_NO, T12069.T_LANG2_NAME QUES_HEADER2,T12069.T_LANG1_NAME QUES_HEADER1,T12068.T_QNO,T12068.T_DISP_SEQ, T12068.T_DIFFERAL_DAY,T_EXP_ANS,T_IF_FAIL FROM T12068 INNER JOIN T12069 ON T12068.T_QHEAD_NO = T12069.T_QHEAD_NO WHERE(T12068.T_SEX IS NULL OR T12068.T_SEX = '" + P_SEX + "') GROUP BY T12068.T_LANG1_NAME, T12068.T_LANG2_NAME, T12068.T_QHEAD_NO, T12069.T_LANG1_NAME,T12069.T_LANG2_NAME,T12068.T_QNO,T12068.T_DISP_SEQ, T12068.T_DIFFERAL_DAY, T_EXP_ANS,T_IF_FAIL ORDER BY T12068.T_QHEAD_NO,to_number(T_DISP_SEQ)) SELECT QuesTab.HEADER_NO, QuesTab.TOTAL_QUES, QuesTab.QUES_DESC1, QuesTab.QUES_DESC2, QuesTab.T_QHEAD_NO, QuesTab.QUES_HEADER1,QuesTab.QUES_HEADER2, QuesTab.T_QNO, QuesTab.T_DISP_SEQ, QuesTab.T_DIFFERAL_DAY, QuesTab.T_EXP_ANS, QuesTab.T_IF_FAIL,tab3.T_QNO_ANS,tab3.T_QUES_ID FROM QuesTab LEFT OUTER JOIN tab3 ON NVL(QuesTab.T_QNO, 0) = NVL(tab3.T_QNO, 0) order by QuesTab.HEADER_NO,to_number(T_DISP_SEQ)) k");
        }

        public DataTable getConsent(int type)
        {
            return Query("SELECT DISTINCT T_LANG"+ type + "_NAME CNSNT_DESC FROM T12068 WHERE T_QNO='Q100'");
        }
        public bool update17(string T_UPD_USER,string T_BLOOD_DONATION_STATUS, string T_RESEARCH_STTS, int T_REQUEST_ID)
        {
            
            return Command($"UPDATE T12017 SET T_UPD_USER='{T_UPD_USER}',T_UPD_DATE=TRUNC(SYSDATE),T_BLOOD_DONATION_STATUS='{T_BLOOD_DONATION_STATUS}',T_RESEARCH_STTS='{T_RESEARCH_STTS}' WHERE T_REQUEST_ID={T_REQUEST_ID}");
        }

        public bool insert71(string T_ENTRY_USER,string T_ENTRY_TIME,string T_DONOR_ID,string T_DONOR_PATNO,string T_DONOR_EPISODE,string T_QNO,string T_QNO_ANS,string T_QHEAD_NO, string T_DISP_SEQ,int T_DIFFERAL_DAY,int T_REQUEST_ID)
        {
           
            int ques = Int32.Parse(Query($"SELECT  NVL(MAX(T_QUES_ID), 0) + 1 T_QUES_ID FROM T12071").Rows[0]["T_QUES_ID"].ToString());

            return Command($"INSERT INTO T12071 (T_ENTRY_USER,T_ENTRY_DATE,T_ENTRY_TIME,T_DONOR_ID,T_DONOR_PATNO,T_DONOR_EPISODE,T_QNO,T_QNO_ANS,T_QHEAD_NO,T_DISP_SEQ,T_DIFFERAL_DAY,T_REQUEST_ID,T_QUES_ID) VALUES ('{T_ENTRY_USER}',TRUNC(SYSDATE),'{T_ENTRY_TIME}','{T_DONOR_ID}','{T_DONOR_PATNO}','{T_DONOR_EPISODE}','{T_QNO}','{T_QNO_ANS}','{T_QHEAD_NO}','{T_DISP_SEQ}',{T_DIFFERAL_DAY},{T_REQUEST_ID},{ques})");
        }
        public DataTable testPrint()
        {
            return Query("");
        }

        public string insert(CommonModel t12017)
        {
            string user = t12017.T_ENTRY_USER;
            string msg = "";
            //string time = DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes.ToString();
            int stts = 0;
                stts=Int32.Parse(Query($"SELECT NVL(T_BLOOD_DONATION_STATUS,0) T_BLOOD_DONATION_STATUS FROM T12017 WHERE T_REQUEST_ID={t12017.T_REQUEST_ID}").Rows[0]["T_BLOOD_DONATION_STATUS"].ToString());
            if (stts<2)
            {
                BeginTransaction();
                if (Command($"UPDATE T12017 SET T_UPD_USER='{user}',T_UPD_DATE=TRUNC(SYSDATE),T_BLOOD_DONATION_STATUS='{t12017.T_BLOOD_DONATION_STATUS}',T_RESEARCH_STTS='{t12017.T_RESEARCH_STTS}' WHERE T_REQUEST_ID={ t12017.T_REQUEST_ID}"))
                {
                    CommitTransaction();
                    msg = "N0041";
                }
                else
                {
                    RollbackTransaction();
                    msg = "N0072";
                }
            }
            else
            {
                msg = "N0076";
            }
           

            //if (update17)
            //{
            //    int a = 0;
            //    int b = t12071.Count;
            //    foreach (CommonModel t71 in t12071)
            //    {
            //        t71.T_REQUEST_ID = t12017.T_REQUEST_ID;
            //       // int ques = Int32.Parse(Query($"SELECT  NVL(MAX(T_QUES_ID), 0) + 1 T_QUES_ID FROM T12071").Rows[0]["T_QUES_ID"].ToString());
            //        bool insert71= Command($"INSERT INTO T12071 (T_ENTRY_USER,T_ENTRY_DATE,T_ENTRY_TIME,T_DONOR_ID,T_DONOR_PATNO,T_DONOR_EPISODE,T_QNO,T_QNO_ANS,T_QHEAD_NO,T_DISP_SEQ,T_DIFFERAL_DAY,T_REQUEST_ID) VALUES ('{user}',TRUNC(SYSDATE),'{time}','{t71.T_DONOR_ID}','{t71.T_DONOR_PATNO}','{t71.T_DONOR_EPISODE}','{t71.T_QNO}','{t71.T_QNO_ANS}','{t71.T_QHEAD_NO}','{t71.T_DISP_SEQ}',{t71.T_DIFFERAL_DAY},{t71.T_REQUEST_ID})");
            //        a = insert71 ? a + 1 : a;
            //    }

            //    count = a == b && a > 0;
            //}
            //if (count)
            //{

            //}
            
            return msg;
        }

        public string singleInsert(CommonModel t71)
        {
            string user = t71.T_ENTRY_USER;
            string time = DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes.ToString();
            string msg = "";
            int count = Query($"SELECT * FROM T12071 WHERE T_QNO='{t71.T_QNO}' AND T_REQUEST_ID='{t71.T_REQUEST_ID}'").Rows.Count;
            BeginTransaction();
            //if (t71.T_QUES_ID==null|| t71.T_QUES_ID=="")
            if (count==0)
            {
                if (Command($"INSERT INTO T12071 (T_ENTRY_USER,T_ENTRY_DATE,T_ENTRY_TIME,T_DONOR_ID,T_DONOR_PATNO,T_DONOR_EPISODE,T_QNO,T_QNO_ANS,T_QHEAD_NO,T_DISP_SEQ,T_DIFFERAL_DAY,T_REQUEST_ID) VALUES ('{user}',TRUNC(SYSDATE),'{time}','{t71.T_DONOR_ID}','{t71.T_DONOR_PATNO}','{t71.T_DONOR_EPISODE}','{t71.T_QNO}','{t71.T_QNO_ANS}','{t71.T_QHEAD_NO}','{t71.T_DISP_SEQ}',{t71.T_DIFFERAL_DAY},{t71.T_REQUEST_ID})"))
                {
                    CommitTransaction();
                    msg = "N0040";
                }
                else
                {
                    RollbackTransaction();
                    msg = "N0071";
                }
            }
            else
            {
                if (Command(
                    $"UPDATE T12071 SET T_UPD_USER='{user}',T_UPD_DATE=TRUNC(SYSDATE),T_UPD_TIME='{time}', T_QNO_ANS='{t71.T_QNO_ANS}',T_DIFFERAL_DAY='{t71.T_DIFFERAL_DAY}' WHERE T_QNO='{t71.T_QNO}' AND T_REQUEST_ID='{t71.T_REQUEST_ID}'"))
                {
                   CommitTransaction();
                    msg = "N0041";
                }
                else
                {
                    RollbackTransaction();
                    msg = "N0072";
                }
                
            }
            
            
            return msg;
        }

    }
}
