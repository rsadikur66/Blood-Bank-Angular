﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Query
{
    public class Q03001:CommonDAL
    {
        public DataTable GridData(int pageIndex, int pageSize, string lang)
        {
            return Query($"SELECT *FROM(SELECT ROW_NUMBER() OVER(ORDER BY T03001_New.Id) AS RowNumber,T_PAT_NO,T_FIRST_LANG{lang}_NAME|| ' '|| T_GFATHER_LANG{lang}_NAME|| ' '|| T_FAMILY_LANG{lang}_NAME PAT_NAME,T02005.T_LANG{lang}_NAME RLGN,T02006.T_LANG{lang}_NAME GENDER,T_NTNLTY_ID ,T02003.T_LANG{lang}_NAME NTNLTY,TRUNC(MONTHS_BETWEEN(SYSDATE, T03001_New.T_BIRTH_DATE) / 12, 0) YRS,TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T03001_New.T_BIRTH_DATE), 12), 0) MOS,T02007.T_LANG{lang}_NAME AS MRTL_STATUS FROM T03001 T03001_New left join T02006 on  T03001_New.T_GENDER = T02006.T_SEX_CODE left join T02003 on  T03001_New.T_NTNLTY_CODE = T02003.T_NTNLTY_CODE left join T02005 on T03001_New.T_RLGN_CODE = T02005.T_RLGN_CODE left join T02007 on  T03001_New.T_MRTL_STATUS = T02007.T_MRTL_STATUS_CODE ) r WHERE r.RowNumber BETWEEN(({pageIndex} * {pageSize}) + 1) AND(({pageIndex} + 1) * {pageSize}) ");
        }

        public DataTable GetPatientData_Search_Count(string searchValue, int pageIndex, int pageSize, string lang)
        {
            return Query($"SELECT * FROM (SELECT count(*) cVal  FROM T03001 T03001_New left join T02006 on  T03001_New.T_GENDER = T02006.T_SEX_CODE left join T02003 on  T03001_New.T_NTNLTY_CODE = T02003.T_NTNLTY_CODE left join T02005 on T03001_New.T_RLGN_CODE = T02005.T_RLGN_CODE left join T02007 on  T03001_New.T_MRTL_STATUS = T02007.T_MRTL_STATUS_CODE where (LOWER(T03001_New.T_FIRST_LANG{lang}_NAME) like '%' || LOWER('{searchValue}') || '%' or LOWER(T03001_New.T_FATHER_LANG{lang}_NAME) like '%' || LOWER('{searchValue}') || '%' or LOWER(T_FAMILY_LANG{lang}_NAME)  like '%' || LOWER('{searchValue}') || '%' or LOWER(T_NTNLTY_ID) like '%' || LOWER('{searchValue}') || '%' or  LOWER(T_PAT_NO) like '%' || LOWER('{searchValue}') || '%' or LOWER(T02003.T_LANG{lang}_NAME) like '%' || LOWER('{searchValue}') || '%' or LOWER(T02006.T_LANG{lang}_NAME) like '%' || LOWER('{searchValue}') || '%' or LOWER(T02007.T_LANG{lang}_NAME) like '%' || LOWER('{searchValue}') || '%') order by Id ASC) t");
        }

        public DataTable GetPatientInfo_Search(string searchValue, int pageIndex, int pageSize, string lang)
        {
            return Query($"select * from (SELECT ROW_NUMBER() OVER(ORDER BY t.RowNumber) ROWNUMBER,T_PAT_NO,PAT_NAME, RLGN, GENDER, T_NTNLTY_ID, NTNLTY, YRS, MOS, MRTL_STATUS FROM  (SELECT  T03001_New.Id RowNumber, T_PAT_NO, T_FIRST_LANG{lang}_NAME  || ' '  || T_GFATHER_LANG{lang}_NAME || ' ' || T_FAMILY_LANG{lang}_NAME PAT_NAME, T02005.T_LANG{lang}_NAME RLGN, T02006.T_LANG{lang}_NAME GENDER, T_NTNLTY_ID, T02003.T_LANG{lang}_NAME NTNLTY, TRUNC(MONTHS_BETWEEN(SYSDATE, T03001_New.T_BIRTH_DATE) / 12, 0) YRS, TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T03001_New.T_BIRTH_DATE), 12), 0) MOS, T02007.T_LANG{lang}_NAME AS MRTL_STATUS FROM T03001 T03001_New LEFT JOIN T02006  ON T03001_New.T_GENDER = T02006.T_SEX_CODE LEFT JOIN T02003  ON T03001_New.T_NTNLTY_CODE = T02003.T_NTNLTY_CODE LEFT JOIN T02005 ON T03001_New.T_RLGN_CODE = T02005.T_RLGN_CODE LEFT JOIN T02007 ON T03001_New.T_MRTL_STATUS = T02007.T_MRTL_STATUS_CODE  ) t  WHERE (LOWER(t.PAT_NAME) LIKE '%'   || LOWER('{searchValue}') || '%' OR LOWER(T_PAT_NO) LIKE '%'  || LOWER('{searchValue}') || '%' OR LOWER(t.RLGN) LIKE '%' || LOWER('{searchValue}') || '%' OR LOWER(T_NTNLTY_ID) LIKE '%' || LOWER('{searchValue}') || '%' OR LOWER(t.GENDER) LIKE '%'  || LOWER('{searchValue}') || '%' OR LOWER(t.NTNLTY) LIKE '%'  || LOWER('{searchValue}') || '%') ) r where r.RowNumber BETWEEN(({pageIndex} * {pageSize})+1) AND(({pageIndex} + 1) * {pageSize})  ORDER BY ROWNUMBER ASC ");
            //return Query($"SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY T03001_New.Id) AS RowNumber, T_PAT_NO, T_FIRST_LANG2_NAME|| ' '|| T_GFATHER_LANG2_NAME|| ' '|| T_FAMILY_LANG2_NAME PAT_NAME, T02005.T_LANG2_NAME RLGN, T02006.T_LANG2_NAME GENDER,T_NTNLTY_ID, T02003.T_LANG2_NAME NTNLTY,TRUNC(MONTHS_BETWEEN(SYSDATE, T03001_New.T_BIRTH_DATE) / 12, 0) YRS,TRUNC(MOD(MONTHS_BETWEEN(SYSDATE, T03001_New.T_BIRTH_DATE), 12), 0) MOS,T02007.T_LANG2_NAME AS MRTL_STATUS FROM T03001 T03001_New inner join T02006 on  T03001_New.T_GENDER = T02006.T_SEX_CODE inner join T02003 on  T03001_New.T_NTNLTY_CODE = T02003.T_NTNLTY_CODE inner join T02005 on T03001_New.T_RLGN_CODE = T02005.T_RLGN_CODE inner join T02007 on  T03001_New.T_MRTL_STATUS = T02007.T_MRTL_STATUS_CODE  where (LOWER(T03001_New.T_FIRST_LANG2_NAME) like '%' || LOWER('{searchValue}') || '%' or LOWER(T03001_New.T_FATHER_LANG2_NAME) like '%' || LOWER('{searchValue}') || '%' or LOWER(T_FAMILY_LANG2_NAME)  like '%' || LOWER('{searchValue}') || '%' or LOWER(T_PAT_NO) like '%' || LOWER('{searchValue}') || '%' or LOWER(T02003.T_LANG2_NAME) like '%' || LOWER('{searchValue}') || '%' or LOWER(T_NTNLTY_ID) like '%' || LOWER('{searchValue}') || '%' or LOWER(T02006.T_LANG2_NAME) like '%' || LOWER('{searchValue}') || '%' or LOWER(T02007.T_LANG2_NAME) like '%' || LOWER('{searchValue}') || '%') order by Id ASC) t where t.RowNumber between(({pageIndex}* {pageSize})+1) AND(({pageIndex} + 1) * {pageSize}) ");
        }
    }
}