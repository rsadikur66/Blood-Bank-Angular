using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Initialization
{
    public class T12068:CommonDAL
    {
        public CommonDAL _commonDal = new CommonDAL();

        public DataTable GetAllGender(string language)
        {
            DataTable dt = Query($"SELECT T_SEX_CODE, T_LANG{language}_NAME T_SEX FROM T02006 ORDER BY 1");
            return WithBlankRow(dt);
        }

        public DataTable GetQstHeadData(string language)
        {
            return Query($"SELECT T_QHEAD_NO,T_LANG{language}_NAME T_QHEAD FROM T12069 WHERE T_LANGUAGE IS NOT NULL");
        }

        public DataTable GetFailData()
        {
            return Query($"SELECT '1' T_CODE,'YELLOW' T_IF_FAIL FROM DUAL UNION SELECT '2' T_CODE,'RED' T_IF_FAIL FROM DUAL");
        }

        public DataTable GetGridData(int PageIndex, int PageSize,string language)
        {
            return Query($"SELECT DISTINCT * FROM (SELECT ROWNUM RowNumber ,T12068.T_QNO,T12068.T_LANG2_NAME,T12068.T_LANG1_NAME, T12069.T_QHEAD_NO, CASE WHEN '{language}'='2' THEN T12069.T_LANG2_NAME ELSE  T12069.T_LANG1_NAME END T_QHEAD, T12068.T_QUS_YES_COLOR,CASE WHEN T12068.T_EXP_ANS = '1' THEN 'YES' WHEN T12068.T_EXP_ANS = '2' THEN 'NO' END T_EXP_ANS,T12068.T_QUS_WEIGHT,T12068.T_DISP_SEQ, T12068.T_DIFFERAL_DAY, T12068.T_QUS_NO_COLOR,T12068.T_SEX,CASE WHEN T12068.T_SEX = '1' THEN 'MALE' WHEN T12068.T_SEX = '2' THEN 'FEMALE' WHEN T12068.T_SEX = '3' THEN  'UNKNOWN' END T_GENDER, T12068.T_ACTION, CASE WHEN T12068.T_IF_FAIL = '1' THEN 'YELLOW' WHEN T12068.T_IF_FAIL = '2' THEN 'RED' END T_IF_FAIL, T12068.T_ACTIVE FROM T12068, T12069 WHERE T12068.T_QHEAD_NO = T12069.T_QHEAD_NO AND T12069.T_LANGUAGE IS NOT NULL) t where t.RowNumber between(({PageIndex} * {PageSize}) + 1) AND(({PageIndex} + 1) * {PageSize}) ORDER BY t.T_QHEAD ");
        }

        public DataTable GetGridData_Search(string searchValue, int PageIndex, int PageSize,string language)
        {
            return Query($"SELECT DISTINCT * FROM (SELECT ROWNUM RowNumber, T12068.T_QNO,T12068.T_LANG2_NAME,T12068.T_LANG1_NAME, T12069.T_QHEAD_NO, CASE WHEN '{language}'='2' THEN T12069.T_LANG2_NAME ELSE  T12069.T_LANG1_NAME END T_QHEAD, T12068.T_QUS_YES_COLOR,CASE WHEN T12068.T_EXP_ANS = '1' THEN 'YES' WHEN T12068.T_EXP_ANS = '2' THEN 'NO' END T_EXP_ANS,T12068.T_QUS_WEIGHT,T12068.T_DISP_SEQ, T12068.T_DIFFERAL_DAY, T12068.T_QUS_NO_COLOR,T12068.T_SEX,CASE WHEN T12068.T_SEX = '1' THEN 'MALE' WHEN T12068.T_SEX = '2' THEN 'FEMALE' WHEN T12068.T_SEX = '3' THEN  'UNKNOWN' END T_GENDER, T12068.T_ACTION, CASE WHEN T12068.T_IF_FAIL = '1' THEN 'YELLOW' WHEN T12068.T_IF_FAIL = '2' THEN 'RED' END T_IF_FAIL, T12068.T_ACTIVE FROM T12068, T12069 WHERE T12068.T_QHEAD_NO = T12069.T_QHEAD_NO AND T12069.T_LANGUAGE IS NOT NULL  AND (lower(T12069.T_LANG{language}_NAME) like '%' || LOWER('{searchValue}')|| '%' or (LOWER(T12068.T_QNO) LIKE '%'|| LOWER('{searchValue}') || '%' OR LOWER(T12068.T_LANG{language}_NAME) LIKE '%' || LOWER('{searchValue}') || '%' OR LOWER(T12068.T_LANG{language}_NAME) LIKE '%' || LOWER('{searchValue}') || '%' OR LOWER(T12068.T_EXP_ANS) LIKE '%' || LOWER ('{searchValue}') || '%' OR LOWER(T12068.T_SEX) LIKE '%' || LOWER('{searchValue}') || '%' OR LOWER(T12068.T_IF_FAIL) LIKE '%' || LOWER('{searchValue}') || '%'))) t where t.RowNumber between(({PageIndex} * {PageSize}) + 1) AND(({PageIndex} + 1) * {PageSize})ORDER BY t.T_QHEAD ");
        }

        public DataTable GetGridData_Count(string searchValue, int PageIndex, int PageSize,string language)
        {
            return Query($"SELECT count(*) cval FROM T12068, T12069 WHERE T12068.T_QHEAD_NO = T12069.T_QHEAD_NO AND T12069.T_LANGUAGE IS NOT NULL");
        }


        public DataTable GetGridData_Search_Count(string searchValue, int PageIndex, int PageSize, string language)
        {
            return Query($"SELECT count(*) cval FROM T12068, T12069 WHERE T12068.T_QHEAD_NO = T12069.T_QHEAD_NO AND T12069.T_LANGUAGE IS NOT NULL AND (lower(T12069.T_LANG{language}_NAME) like '%' || LOWER('{searchValue}')|| '%' or (LOWER(T12068.T_QNO) LIKE '%'|| LOWER('{searchValue}') || '%' OR LOWER(T12068.T_LANG{language}_NAME) LIKE '%' || LOWER('{searchValue}') || '%' OR LOWER(T12068.T_LANG{language}_NAME) LIKE '%' || LOWER('{searchValue}') || '%' OR LOWER(T12068.T_EXP_ANS) LIKE '%' || LOWER ('{searchValue}') || '%' OR LOWER(T12068.T_SEX) LIKE '%' || LOWER('{searchValue}') || '%' OR LOWER(T12068.T_IF_FAIL) LIKE '%' || LOWER('{searchValue}') || '%'))");
        }
        public bool InsertT12068(String T_ENTRY_USER, String T_QNO, String T_QHEAD_NO, String T_LANG2_NAME, String T_LANG1_NAME, String T_QUS_WEIGHT, String T_DISP_SEQ, String T_DIFFERAL_DAY, String T_SEX, String T_IF_FAIL, String T_EXP_ANS, String T_ACTIVE)
        {
            DataTable maxNumber = Query($"select 'Q'||lpad(TO_CHAR(max(to_number(SUBSTR(T_QNO, 2,3))))+1,3,'0') T_QNO  from T12068");
            var max = maxNumber.Rows[0][0];
            return Command($"INSERT INTO T12068 (T_ENTRY_USER,T_ENTRY_DATE,T_QNO,T_QHEAD_NO,T_LANG2_NAME,T_LANG1_NAME,T_QUS_WEIGHT,T_DISP_SEQ,T_DIFFERAL_DAY,T_SEX,T_IF_FAIL,T_EXP_ANS,T_ACTIVE)VALUES('{T_ENTRY_USER}',SYSDATE,'{max}','{T_QHEAD_NO}','{T_LANG2_NAME}','{T_LANG1_NAME}','{T_QUS_WEIGHT}','{T_DISP_SEQ}','{T_DIFFERAL_DAY}','{T_SEX}','{T_IF_FAIL}','{T_EXP_ANS}','{T_ACTIVE}')");
        }

        public bool UpdateT12068(String T_UPD_USER, String T_QHEAD_NO, String T_LANG2_NAME, String T_LANG1_NAME, String T_QUS_WEIGHT, String T_DISP_SEQ, String T_DIFFERAL_DAY, String T_SEX, String T_IF_FAIL, String T_EXP_ANS, String T_ACTIVE, String T_QNO)
        {
            return Command($"UPDATE T12068 SET T_UPD_USER='{T_UPD_USER}',T_UPD_DATE=SYSDATE,T_QHEAD_NO='{T_QHEAD_NO}',T_LANG2_NAME='{T_LANG2_NAME}',T_LANG1_NAME='{T_LANG1_NAME}',T_QUS_WEIGHT='{T_QUS_WEIGHT}',T_DISP_SEQ='{T_DISP_SEQ}',T_DIFFERAL_DAY='{T_DIFFERAL_DAY}',T_SEX='{T_SEX}',T_IF_FAIL='{T_IF_FAIL}',T_EXP_ANS='{T_EXP_ANS}',T_ACTIVE='{T_ACTIVE}' WHERE T_QNO='{T_QNO}'");
        }

        public bool DeleteT12068(String T_QNO)
        {
            return Command($"DELETE FROM T12068 WHERE T_QNO ='{T_QNO}'");
        }

        public bool InsertT12069(String T_ENTRY_USER, String T_QHEAD_NO, String T_LANG2_NAME, String T_LANG1_NAME)
        {
            return Command($"INSERT INTO T12069 (T_ENTRY_USER,T_ENTRY_DATE,T_QHEAD_NO,T_LANG2_NAME,T_LANG1_NAME)VALUES('{T_ENTRY_USER}',SYSDATE,'{T_QHEAD_NO}','{T_LANG2_NAME}','{T_LANG1_NAME}')");
        }

    }
}