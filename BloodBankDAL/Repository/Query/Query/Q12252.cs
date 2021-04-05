﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Query
{
    public class Q12252:CommonDAL
    {
        public DataTable GetDataByUnitNo(string P_UNIT_NO)
        {
            return Query($"SELECT V51.T_DONATION_DATE,V51.T_PAT_NO DONORID,NVL(T17.T_DONOR_NTNLTY_ID,T01.T_NTNLTY_ID) T_DONOR_NTNLTY_ID,V51.T_UNIT_NO FROM V12051 V51 INNER JOIN T12017 T17 ON V51.T_REQUEST_ID=T17.T_REQUEST_ID   LEFT JOIN T03001 T01 ON T01.T_PAT_NO=V51.T_PAT_NO	WHERE V51.T_PAT_NO=T17.T_PAT_NO	AND V51.T_EPISODE_NO=T17.T_EPISODE_NO AND V51.T_UNIT_NO='{P_UNIT_NO}'");
        }
        public DataTable GetDataByDonor1(string P_DONOR_ID)
        {
            return Query($"SELECT  V51.T_UNIT_NO, V51.T_DONATION_DATE, V51.T_SEGMENT_NO, V51.T_WEIGHT, V51.T_PULS, V51.T_HB, V51.T_TEMPTURE,V51.T_BP_HIGH, V51.T_BP_LOW, V51.T_ENTRY_TIME, V51.T_DONATION_TIME, T09.T_USER_NAME  EXAMIN_BY  FROM V12051 V51 LEFT JOIN T01009 T09 ON T09.T_EMP_CODE = V51.T_ENTRY_USER WHERE V51.T_PAT_NO='{P_DONOR_ID}' ORDER BY V51.T_DONATION_DATE");
        }
        public DataTable GetDataByDonor2(string P_DONOR_ID, string lang)
        {
            return Query($"SELECT  V52.T_VIOROLOGY_RESULT,V52.T_UNIT_NO, V52.T_DONATION_DATE, V52.T_PRODUCT_CODE, V52.T_BLOOD_BAG_GROUP,V52.T_SEG_ABO,V52.T_ANTIBODY_1,V52.T_UNIT_STATUS,T06.T_LANG{lang}_NAME UNIT_STATUS_DESC,V52.T_PAT_REQ_NO,T09.T_USER_NAME SEPARATED_BY,T19.T_USER_NAME TAKEN_BY FROM V12052 V52 LEFT JOIN T12106 T06 ON  NVL(V52.T_UNIT_STATUS,0)=T06.T_STATUS_ID AND T06.T_STATUS_TYPE='1' LEFT JOIN V12051 V51 ON V51.T_UNIT_NO=V52.T_UNIT_NO LEFT JOIN T01009 T09 ON T09.T_PIN=V51.T_PIN LEFT JOIN T12135 T35 ON T35.T_UNIT_NO=V52.T_UNIT_NO AND T35.T_PROD_CODE = V52.T_PRODUCT_CODE LEFT JOIN T01009 T19 ON T35.T_ENTRY_USER=T19.T_EMP_CODE WHERE V52.T_UNIT_NO IN (SELECT  T_UNIT_NO FROM V12051 WHERE T_PAT_NO='{P_DONOR_ID}') ORDER BY T_DONATION_DATE,T_UNIT_NO");
        }

    }
}