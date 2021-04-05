using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12245 : CommonDAL
    {
        public DataTable GetCentrifugeList(string lang)
        {
            return Query($"SELECT T_CENTRIFUGE_MACHINE_CODE CODE,T_LANG{lang}_NAME NAME FROM T12090");
        }
        public DataTable GetProgramList(string lang)
        {
            return Query($"SELECT T_PROGRAM_CODE CODE,T_LANG{lang}_NAME NAME, T_SPEED,T_TEMP,T_TIME FROM T12099");
        }
        public DataTable GetSegment(string UnitNo)
        {
            //return Query($"SELECT T_SEGMENT_NO,TO_CHAR(T_DONATION_DATE,'DD MON YYYY')T_DONATION_DATE FROM t12022 WHERE T_UNIT_NO = '{UnitNo}'"); 
            return Query($"SELECT T_SEGMENT_NO,TO_CHAR(T_DONATION_DATE,'DD MON YYYY')T_DONATION_DATE FROM T12022 WHERE T_UNIT_NO = '{UnitNo}'");
        }
        public DataTable CheckUnitNo(string UnitNo)
        {
            return Query($"SELECT * from t12135 where T_UNIT_NO='{UnitNo}'");
        }
        public DataTable GetGridDataList(string UnitNo,string donationDate, string segmentNo)
        {
            return Query($"select p.t_product_code,p.T_LANG2_NAME,to_date('{donationDate}')T_DONATION_DATE,p.T_EXPIRY_DAYS+to_date('{donationDate}') Expiry_Date,'{segmentNo}' SEGMENTNO from (SELECT b.t_product_code,b.T_LANG2_NAME, b.T_EXPIRY_DAYS FROM (SELECT t_product_code FROM T12011 MINUS SELECT t_prod_code FROM T12135 WHERE t_unit_no = '{UnitNo}') a, t12011 b WHERE a.t_product_code = b.t_product_code AND T_ACTIVE = '1' ORDER BY TO_NUMBER(T_PROD_PRIORITY)) p"); 
        }
        public DataTable SecondGetGridDataList(string UnitNo, string user)
        {
            //return Query($"SELECT a.T_PROD_CODE,b.T_LANG2_NAME,a.T_REASON,a.T_DONATION_DATE,a.T_PROD_EXPIRY_DATE from t12135 a INNER JOIN t12011 b ON a.T_PROD_CODE = b.T_PRODUCT_CODE WHERE a.T_UNIT_NO = '{UnitNo}' and a.T_ENTRY_USER = '{user}'");
            return Query($"SELECT DISTINCT a.T_PROD_CODE,b.T_LANG2_NAME,b.T_LANG1_NAME,a.T_REASON,c.T_SEGMENT_NO,b.T_PROD_PRIORITY,TO_CHAR(c.T_DONATION_DATE,'DD/MM/YYYY') T_DONATION_DATE,(SELECT TO_CHAR(c.T_DONATION_DATE + b.T_EXPIRY_DAYS,'DD/MM/YYYY') from DUAL)T_PROD_EXPIRY_DATE, a.T_CHECK_FLAG FROM t12135 a INNER JOIN t12011 b ON a.T_PROD_CODE = b.T_PRODUCT_CODE INNER JOIN t12022 c ON a.T_UNIT_NO = c.T_UNIT_NO WHERE a.T_UNIT_NO = '{UnitNo}' and a.T_ENTRY_USER = '{user}'  ORDER BY b.T_PROD_PRIORITY");
        }
        public DataTable GetMessagesList()
        {
            //return Query($"SELECT a.T_PROD_CODE,b.T_LANG2_NAME,a.T_REASON,a.T_DONATION_DATE,a.T_PROD_EXPIRY_DATE from t12135 a INNER JOIN t12011 b ON a.T_PROD_CODE = b.T_PRODUCT_CODE WHERE a.T_UNIT_NO = '{UnitNo}' and a.T_ENTRY_USER = '{user}'");
            return Query($"select  T_LANG1_MSG,T_LANG2_MSG  from t01004 where T_MSG_CODE='S0005'");
        }
        //public bool Insert(string T_ENTRY_USER, t12135 T12135)
        //{

        //    return Command($"INSERT INTO T12135 (T_ENTRY_USER,T_ENTRY_DATE,T_CENTRIFUGE_MACHINE_CODE,T_PROGRAM_CODE,T_UNIT_NO,T_PROD_CODE) VALUES ('{T_ENTRY_USER}',SYSDATE,'{T12135.T_CENTRIFUGE_MACHINE_CODE}','{T12135.T_PROGRAM_CODE}','{T12135.T_UNIT_NO}','{T12135.T_PROD_CODE}')");
        //}
        public bool Insert(string T_ENTRY_USER, t12135 T12135)
        {
            //BLOOD_GROUP,ANTIBODY,VERIFY,DU,SEG_BLOOD
            //Command($"INSERT INTO T12135 (T_ENTRY_USER,T_ENTRY_DATE,T_CENTRIFUGE_MACHINE_CODE,T_PROGRAM_CODE,T_UNIT_NO,T_PROD_CODE,T_PROD_EXPIRY_DATE,T_DONATION_DATE,T_CHECK_FLAG) VALUES ('{T_ENTRY_USER}',SYSDATE,'{T12135.T_CENTRIFUGE_MACHINE_CODE}','{T12135.T_PROGRAM_CODE}','{T12135.T_UNIT_NO}','{T12135.T_PROD_CODE}',to_date(SUBSTR('{T12135.T_PROD_EXPIRY_DATE}', 0, 10), 'DD/MM/yyyy'),to_date(SUBSTR('{T12135.T_DONATION_DATE}', 0, 10), 'DD/MM/yyyy'),'{T12135.T_CHECK_FLAG}')");
            Command($"INSERT INTO T12135 (T_ENTRY_USER,T_ENTRY_DATE,T_CENTRIFUGE_MACHINE_CODE,T_PROGRAM_CODE,T_UNIT_NO,T_PROD_CODE,T_PROD_EXPIRY_DATE,T_DONATION_DATE,T_CHECK_FLAG) VALUES ('{T_ENTRY_USER}',TRUNC(SYSDATE),'{T12135.T_CENTRIFUGE_MACHINE_CODE}','{T12135.T_PROGRAM_CODE}','{T12135.T_UNIT_NO}','{T12135.T_PROD_CODE}','{T12135.T_PROD_EXPIRY_DATE.ToString("dd-MMM-yyyy")}','{T12135.T_DONATION_DATE.ToString("dd-MMM-yyyy")}','{T12135.T_CHECK_FLAG}')");

            DataTable dt = new DataTable();

            dt =Query($"SELECT DISTINCT T_ABO_CODE,T_ANTIBODY_1,T_VERIFY,T_DU,T_SEG_ABO,T_PRODUCT_CODE FROM T12019 WHERE T_UNIT_NO='{T12135.T_UNIT_NO}' AND T_PRODUCT_CODE!='{T12135.T_PROD_CODE}'");

            string BLOOD_GROUP = dt.Rows[0]["T_ABO_CODE"].ToString();
            string ANTIBODY = dt.Rows[0]["T_ANTIBODY_1"].ToString();
            string VERIFY = dt.Rows[0]["T_VERIFY"].ToString();
            string DU = dt.Rows[0]["T_DU"].ToString();
            string SEG_BLOOD = dt.Rows[0]["T_SEG_ABO"].ToString();
            string PROD_COD = dt.Rows[0]["T_PRODUCT_CODE"].ToString();
            if (PROD_COD != "NSFS")
            {
                Command($"INSERT INTO t12019 (t_entry_date, t_entry_user, t_destroy_flag, t_donation_date, t_expiry_date, t_product_code, t_reject_flag, t_unit_no,T_UNIT_SEPERATION_DATE, T_ABO_CODE, T_ANTIBODY_1, T_VERIFY, T_DU, T_SEG_ABO, T_BLOOD_BAG_GROUP) VALUES (TRUNC(SYSDATE),'{T_ENTRY_USER}', '2','{T12135.T_DONATION_DATE.ToString("dd-MMM-yyyy")}','{T12135.T_PROD_EXPIRY_DATE.ToString("dd-MMM-yyyy")}','{T12135.T_PROD_CODE}','2','{T12135.T_UNIT_NO}', TRUNC(SYSDATE),'{BLOOD_GROUP}', '{ANTIBODY}','{VERIFY}','{DU}','{SEG_BLOOD}','{BLOOD_GROUP}')");
                return true;
            }

            //to_date(SUBSTR('31/10/2018 12:00:00 AM', 0, 10), 'DD/MM/yyyy')
            
            else
            {
                return false;
                //---------------Commneted for check -------------------
                //Command($"INSERT INTO t12019 (t_entry_date, t_entry_user, t_destroy_flag, t_donation_date, t_expiry_date, t_product_code, t_reject_flag, t_unit_no,T_UNIT_SEPERATION_DATE,T_UNIT_STATUS, T_ABO_CODE, T_ANTIBODY_1, T_VERIFY, T_DU, T_SEG_ABO, T_BLOOD_BAG_GROUP) VALUES (TRUNC(SYSDATE),'{T_ENTRY_USER}', '2','{T12135.T_DONATION_DATE.ToString("dd-MMM-yyyy")}','{T12135.T_PROD_EXPIRY_DATE.ToString("dd-MMM-yyyy")}','{T12135.T_PROD_CODE}','2','{T12135.T_UNIT_NO}', TRUNC(SYSDATE),'10','{BLOOD_GROUP}', '{ANTIBODY}','{VERIFY}','{DU}','{SEG_BLOOD}','{BLOOD_GROUP}')");
            }

        }

        public bool UpdateT12135(string user,string UnitNo)
        {
            Command($"UPDATE T12135 SET T_UPD_DATE=TRUNC(SYSDATE),T_UPD_USER='{user}', T_CHECK_FLAG='2' WHERE T_UNIT_NO='{UnitNo}' AND T_CHECK_FLAG IS NULL");
            return true;
        }
        public bool DeleteRowData(string T_UNIT_NO, string T_PRODUCT_CODE)
        {
            bool deleteT12019 = Command($"DELETE FROM T12019 WHERE T_UNIT_NO ='{T_UNIT_NO}' AND T_PRODUCT_CODE='{T_PRODUCT_CODE}'");
            bool deleteT12135 =
                Command($"DELETE FROM T12135 WHERE T_UNIT_NO = '{T_UNIT_NO}' AND T_PROD_CODE='{T_PRODUCT_CODE}'");
            return true;
        }
    }
}