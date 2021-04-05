using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Query
{
    public class Q12200:CommonDAL
    {
        public DataTable GetGridData(string dateParam)
        {
            DataTable dt1 =
                Query(
                    $"select t17.t_pat_no,t01.T_FATHER_LANG2_NAME ||''||t01.T_FAMILY_LANG2_NAME PAT_NAME,t03.T_LANG2_NAME NATIONALITY,'' AS EXAMINATION_DESC,'' AS DONATION_DESC, '' AS EXAM_TIME, '' AS DONAT_TIME from t12017 t17 left join t03001 t01 on t17.T_PAT_NO = t01.T_PAT_NO left join t02003 t03 on t01.T_NTNLTY_CODE = t03.T_NTNLTY_CODE where to_char(t17.t_entry_date,'dd/mm/yyyy') = '{dateParam}'");
            //06/01/19
            //dt1.Columns.Add("EXAMINATION_DESC");
            //dt1.Columns.Add("DONATION_DESC");
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string patno = dt1.Rows[i]["T_PAT_NO"].ToString();
                string countwithdonationdate = Query(
                    $"SELECT COUNT(*) FROM T12022 WHERE T_PAT_NO = '{patno}' AND to_char(t_donation_date, 'dd/mm/yy') = '{dateParam}' AND T_UNIT_NO IS NOT NULL").Rows[0][0].ToString();
                if (countwithdonationdate != "0")
                {
                    dt1.Rows[i]["EXAMINATION_DESC"] = "TECHNICIAN CHECKED";
                    dt1.Rows[i]["DONATION_DESC"] = "BLOOD TAKEN";
                    dt1.Rows[i]["DONAT_TIME"] =
                        Query(
                            $"select T_DONATION_TIME DONAT_TIME from T12022 WHERE to_char(t_donation_date,'dd/mm/yy')= '{dateParam}' AND T_PAT_NO='{patno}'").Rows[0][0].ToString();
                    dt1.Rows[i]["EXAM_TIME"] = Query($"select T_ENTRY_TIME EXAM_TIME from T12022 WHERE to_char(t_donation_date,'dd/mm/yy')= '{dateParam}' AND T_PAT_NO='{patno}'").Rows[0][0].ToString();
                }
                else
                {
                    dt1.Rows[i]["DONATION_DESC"] = "NOT YET";
                }

                string countwithentrydate = Query($"SELECT COUNT(*) V FROM T12022 WHERE T_PAT_NO='{patno}' AND to_char(T_ENTRY_DATE,'dd/mm/yy')='{dateParam}'").Rows[0][0].ToString();

                if (countwithentrydate != "0")
                {
                    string acceptstatus = Query($"SELECT T_ACCEPT_STATUS FROM T12022 WHERE T_PAT_NO='{patno}' AND to_char(T_ENTRY_DATE,'dd/mm/yy')='{dateParam}'").Rows[0][0].ToString();

                    dt1.Rows[i]["EXAM_TIME"] = Query($"Select T_ENTRY_TIME EXAM_TIME from T12022 WHERE to_char(T_ENTRY_DATE,'dd/mm/yy')='{dateParam}' AND T_PAT_NO='{patno}'").Rows[0][0].ToString();

                    if (acceptstatus == "1")
                    {
                        dt1.Rows[i]["EXAMINATION_DESC"] = "TECHNICIAN CHECKED";
                    }
                    else
                    {
                        dt1.Rows[i]["EXAMINATION_DESC"] = "TECHNICIAN REJECT";
                    }
                }
                else
                {
                    dt1.Rows[i]["EXAMINATION_DESC"]= "NOT YET";
                }
            }
            //DataTable dt2 = Query($"")

            //return Query($"SELECT T12017.T_PAT_NO,T03001.T_FIRST_LANG2_NAME || T03001.T_FATHER_LANG2_NAME || T03001.T_FAMILY_LANG2_NAME PAT_NAME,TO_CHAR(T12017.T_ARRIVAL_DATE,'HH:MM AM') T_ARRIVAL_TIME, T02003.T_LANG2_NAME NATIONALITY, T12022.T_DONATION_TIME , 'BLOOD TAKEN' DONATION_DESC, CASE WHEN T12022.T_ACCEPT_STATUS = 1 THEN 'TECHNICIAN CHECKED' ELSE 'TECHNICIAN REJECT' END AS EXAMINATION_DESC FROM T12017 LEFT JOIN T03001 on T12017.T_PAT_NO = T03001.T_PAT_NO LEFT JOIN t02003 on T03001.T_NTNLTY_CODE = T02003.T_NTNLTY_CODE LEFT JOIN T12022 ON T03001.T_PAT_NO = T12022.T_PAT_NO WHERE TO_CHAR(T12022.T_DONATION_DATE,'DD/MM/YYYY') = '{dateParam}' AND T12022.T_UNIT_NO IS NOT NULL");
            return dt1;
        }

        public DataTable GetReportInfo()
        {
            DataTable reportInfo = Query($"select T_SITE_CODE,T_COUNTRY_LANG1_NAME,T_COUNTRY_LANG2_NAME,T_MIN_LANG1_NAME,T_MIN_LANG2_NAME,T_SITE_LANG1_NAME,T_SITE_LANG2_NAME,T_LOGO_ID,T_LOGO_NAME,T_LOGO,t_lcence_no from t01028");
            return reportInfo;
        }

        public DataTable GetReportData()
        {
            DataTable reportData = Query($"SELECT T22.T_DONATION_DATE, T22.T_PAT_NO, (select t_first_lang1_name||' '||t_father_lang1_name||' '||t_family_lang1_name from t03001 where t_pat_no=t22.T_PAT_NO) PAT_NAME, T22.T_EPISODE_NO, T22.T_UNIT_NO, T22.T_ENTRY_USER, T22.T_PIN, (select t_user_name from t01009 where t_emp_code=T22.T_ENTRY_USER) EXAMINE_BY, TO_CHAR(TO_DATE(T17.T_arrival_TIME,'HH24MI'),'HH24:MI AM')ARRIVAL_TIME, TO_CHAR(TO_DATE(T22.T_ENTRY_TIME,'HH24:MI'),'HH24:MI AM')EXAM_TIME, TO_CHAR(TO_DATE(T22.T_DONATION_TIME,'HH24:MI'),'HH24:MI AM')DONA_TIM FROM T12017 T17 LEFT JOIN T12022 T22 ON T17.T_REQUEST_ID=T22.T_REQUEST_ID WHERE to_date(T22.T_DONATION_DATE) BETWEEN TO_DATE('06-JAN-19','DD/MM/YY') AND TO_DATE('06-JAN-19','DD/MM/YY') AND T17.T_SITE_CODE='0001' AND T_DONATION_TIME IS NOT NULL AND T22.T_ENTRY_DATE IS NOT NULL ORDER BY T22.T_DONATION_DATE,T17.T_ARRIVAL_TIME");
            return reportData;
        }

    }
}