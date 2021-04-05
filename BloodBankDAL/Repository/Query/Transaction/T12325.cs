using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Schema;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T12325:CommonDAL

    {
    public DataTable GetVirus(string lang, string user)
    {
        return Query($"SELECT T_VIRUS_CODE,T_LANG{lang}_NAME VIRUS_NAME,(SELECT T_USER_NAME FROM T01009 WHERE T_EMP_CODE ='{user}')BY_USER FROM T12033 WHERE T_ACTIVE='1' ORDER BY T_VIRUS_CODE ASC ");
        //return Query($"Select T_VIRUS_CODE,T_LANG{lang}_NAME VIRUS_NAME from T12033");
    }

        public DataTable GetResulDes(string lang, string value)
        {
            return Query($"SELECT T_RESULT_CODE,T_LANG{lang}_NAME RESULT_NAME FROM T13006 WHERE T_RESULT_CODE = '{value}'");
        }

        public DataTable CheckUnitNo(string unit)
        {
            return Query($"select T_UNIT_NO,T_DONATION_DATE From T12022 Where T_UNIT_NO = '{unit}'");
        }

        public string SaveData(string un, List<M12325> vairusList,string T_EMP_CODE, string lang)
        {
            int count = 0;
            int counta = 0;

            int upcount = 0;
            int upcounta = 0;

            int chek = 0;

            string msg = "";
            string T_POS = "";
            double result3 = 0;
            double result4 = 0;

            bool isInsert = false;
            BeginTransaction();
            foreach (var c in vairusList)
            {
                if (c.T_VIRUS_CODE == "03")
                {
                    result3 = Convert.ToDouble(c.T_RESULT_CODE);
                }
                else if (c.T_VIRUS_CODE == "04")
                {
                   result4 = Convert.ToDouble(c.T_RESULT_CODE);
                }
            }

            foreach (var list in vairusList)
            {
                if (list.CheckValue=="1")
                {

                  //var chkData = Query($"SELECT T_UNIT_NO FROM T12034 where  T_UNIT_NO = '{un}' AND T_VIRUS_CODE = '{list.T_VIRUS_CODE}'").Rows[0]["T_UNIT_NO"].ToString();
                  var chkData = Query($"SELECT nvl(max(T_UNIT_NO),0) T_UNIT_NO FROM T12034 where  T_UNIT_NO = '{un}' AND T_VIRUS_CODE = '{list.T_VIRUS_CODE}'").Rows[0]["T_UNIT_NO"].ToString();
          if (chkData == "0")
            {
                
                if (list.T_VIRUS_CODE == "01" || list.T_VIRUS_CODE == "02" || list.T_VIRUS_CODE == "05" || list.T_VIRUS_CODE == "06" || list.T_VIRUS_CODE == "08")
                {
                    double dd = Convert.ToDouble(list.T_RESULT_CODE);
                    if (dd >= 1)
                    {
                        T_POS = "1";
                        counta = counta + 1;
                        if (Command($"INSERT INTO T12034(T_UNIT_NO,T_VIRUS_CODE,T_VIRUS_RESULT,T_POS,T_TEST_VERIFY,T_ENTRY_USER,T_ENTRY_DATE)VALUES ('{un}', '{list.T_VIRUS_CODE}', '{list.T_RESULT_CODE}','1','{list.CheckValue}','{T_EMP_CODE}',SYSDATE)"))
                        {
                                    //&& Command($"INSERT INTO T12218(T_UNIT_NO,T_TEST_CODE,T_RESULT_VAL,T_POS,T_ENTRY_DATE)VALUES ('{un}', '{list.T_VIRUS_CODE}', '{list.T_RESULT_CODE}','1',SYSDATE)")
                                    count = count + 1;
                        }
                   }
                    else
                    {
                        counta = counta + 1;
                        if (Command($"INSERT INTO T12034(T_UNIT_NO,T_VIRUS_CODE,T_VIRUS_RESULT,T_POS,T_TEST_VERIFY,T_ENTRY_USER,T_ENTRY_DATE)VALUES ('{un}', '{list.T_VIRUS_CODE}', '{list.T_RESULT_CODE}','','{list.CheckValue}','{T_EMP_CODE}',SYSDATE)"))
                                {
                            count = count + 1;
                        }
                     }
                    
                }
                    else if (list.T_VIRUS_CODE == "03" || list.T_VIRUS_CODE == "04")
                    {
                        if (result3 >= 1 && result4 >= 1)
                        {
                            counta = counta + 1;
                            if (Command($"INSERT INTO T12034(T_UNIT_NO,T_VIRUS_CODE,T_VIRUS_RESULT,T_POS,T_TEST_VERIFY,T_ENTRY_USER,T_ENTRY_DATE)VALUES ('{un}', '{list.T_VIRUS_CODE}', '{list.T_RESULT_CODE}','','{list.CheckValue}','{T_EMP_CODE}',SYSDATE)"))
                                {
                                count = count + 1;
                                    // if (Command($"INSERT INTO T12034(T_UNIT_NO,T_VIRUS_CODE,T_POS1_VERIFY,T_POS1_VERIFIED_BY,T_POS1_VERIFIED_DATE,T_ENTRY_USER,T_ENTRY_DATE)VALUES ('{un}', '{list.T_VIRUS_CODE}', '{list.CheckValue}','{T_EMP_CODE}','{list.VERYFY_DATE}','{T_EMP_CODE}',SYSDATE)") && Command($"INSERT INTO T12218(T_UNIT_NO,T_TEST_CODE,T_RESULT_VAL,T_POS,T_ENTRY_DATE)VALUES ('{un}', '{list.T_VIRUS_CODE}', '{list.T_RESULT_CODE}','',SYSDATE)"))
                                }
                            }
                        else if (result3 <= 1 && result4 <= 1)
                        {
                            counta = counta + 1;
                            if (Command($"INSERT INTO T12034(T_UNIT_NO,T_VIRUS_CODE,T_VIRUS_RESULT,T_POS,T_TEST_VERIFY,T_ENTRY_USER,T_ENTRY_DATE)VALUES ('{un}', '{list.T_VIRUS_CODE}', '{list.T_RESULT_CODE}','','{list.CheckValue}','{T_EMP_CODE}',SYSDATE)"))
                                {
                                count = count + 1;
                            }
                        }
                        else
                        {
                            T_POS = "1";
                            counta = counta + 1;
                            if (Command($"INSERT INTO T12034(T_UNIT_NO,T_VIRUS_CODE,T_VIRUS_RESULT,T_POS,T_TEST_VERIFY,T_ENTRY_USER,T_ENTRY_DATE)VALUES ('{un}', '{list.T_VIRUS_CODE}', '{list.T_RESULT_CODE}','1','{list.CheckValue}','{T_EMP_CODE}',SYSDATE)"))
                                {
                                count = count + 1;
                            }
                        }
                    }
                    else if (list.T_VIRUS_CODE == "07" || list.T_VIRUS_CODE == "09")
                {
                    if (list.T_RESULT_CODE == "M563")
                    {
                        T_POS = "1";
                            counta = counta + 1;
                        if (Command($"INSERT INTO T12034(T_UNIT_NO,T_VIRUS_CODE,T_VIRUS_RESULT,T_POS,T_TEST_VERIFY,T_ENTRY_USER,T_ENTRY_DATE)VALUES ('{un}', '{list.T_VIRUS_CODE}', '{list.T_RESULT_CODE}','1','{list.CheckValue}','{T_EMP_CODE}',SYSDATE)"))
                                {
                            count = count + 1;
                        }
                    }
                    else
                    {
                        counta = counta + 1;
                        if (Command($"INSERT INTO T12034(T_UNIT_NO,T_VIRUS_CODE,T_VIRUS_RESULT,T_POS,T_TEST_VERIFY,T_ENTRY_USER,T_ENTRY_DATE)VALUES ('{un}', '{list.T_VIRUS_CODE}', '{list.T_RESULT_CODE}','','{list.CheckValue}','{T_EMP_CODE}',SYSDATE)"))
                                {
                            count = count + 1;
                        }
                    }
                 }
                }
          else
          {                  //Update panel

              if (list.T_VIRUS_CODE == "01" || list.T_VIRUS_CODE == "02" || list.T_VIRUS_CODE == "05" || list.T_VIRUS_CODE == "06" || list.T_VIRUS_CODE == "08")
              {
                  double dd = Convert.ToDouble(list.T_RESULT_CODE);
                  if (dd >= 1)
                  {
                      T_POS = "1";
                      upcounta = upcounta + 1;
                      if (Command($"UPDATE T12034 SET T_VIRUS_RESULT='{list.T_RESULT_CODE}', T_POS ='1' WHERE T_UNIT_NO = '{un}' AND T_VIRUS_CODE = '{list.T_VIRUS_CODE}'"))
                      {
                          upcount = upcount + 1;
                      }
                  }
                  else
                  {
                      upcounta = upcounta + 1;
                      if (Command($"UPDATE T12034 SET T_VIRUS_RESULT='{list.T_RESULT_CODE}', T_POS ='' WHERE T_UNIT_NO = '{un}' AND T_VIRUS_CODE = '{list.T_VIRUS_CODE}'"))
                                {
                          upcount = upcount + 1;
                      }
                  }

              }
              else if (list.T_VIRUS_CODE == "03" || list.T_VIRUS_CODE == "04")
              {
                  if (result3 >= 1 && result4 >= 1)
                  {
                      upcounta = upcounta + 1;
                      if (Command($"UPDATE T12034 SET T_VIRUS_RESULT='{list.T_RESULT_CODE}', T_POS ='' WHERE T_UNIT_NO = '{un}' AND T_VIRUS_CODE = '{list.T_VIRUS_CODE}'"))
                                {
                                    upcount = upcount + 1;
                                }
                  }
                  else if (result3 <= 1 && result4 <= 1)
                  {
                      upcounta = upcounta + 1;
                      if (Command($"UPDATE T12034 SET T_VIRUS_RESULT='{list.T_RESULT_CODE}', T_POS ='' WHERE T_UNIT_NO = '{un}' AND T_VIRUS_CODE = '{list.T_VIRUS_CODE}'"))
                                {
                                    upcount = upcount + 1;
                                }
                  }
                  else
                  {
                      T_POS = "1";
                      upcounta = upcounta + 1;
                      if (Command($"UPDATE T12034 SET T_VIRUS_RESULT='{list.T_RESULT_CODE}', T_POS ='1' WHERE T_UNIT_NO = '{un}' AND T_VIRUS_CODE = '{list.T_VIRUS_CODE}'"))
                                {
                          upcount = upcount + 1;
                                }
                  }
              }
              else if (list.T_VIRUS_CODE == "07" || list.T_VIRUS_CODE == "09")
              {
                  if (list.T_RESULT_CODE == "M563")
                  {
                      T_POS = "1";
                      upcounta = upcounta + 1;
                      if (Command($"UPDATE T12034 SET T_VIRUS_RESULT='{list.T_RESULT_CODE}', T_POS ='1' WHERE T_UNIT_NO = '{un}' AND T_VIRUS_CODE = '{list.T_VIRUS_CODE}'"))
                                {
                          upcount = upcount + 1;
                                }
                  }
                  else
                  {
                      upcounta = upcounta + 1;
                      if (Command($"UPDATE T12034 SET T_VIRUS_RESULT='{list.T_RESULT_CODE}', T_POS ='' WHERE T_UNIT_NO = '{un}' AND T_VIRUS_CODE = '{list.T_VIRUS_CODE}'"))
                                {
                          upcount = upcount + 1;
                                }
                  }
              }

                    }
                    
                }

            }

            
            if (T_POS == "1")
            {
                upcounta = upcounta + 1;
                counta = counta + 1;
                if (Command($"UPDATE T12019  SET T_VIOROLOGY_RESULT='2',T_CLOSE_FLAG='1' WHERE T_UNIT_NO = '{un}' ") && Command($"UPDATE t12075  SET T_VIROLOGY_RESULT='2',T_CLOSE_FLAG='1'  WHERE T_UNIT_NO = '{un}'"))
                {
                    count = count + 1;
                    upcount = upcount + 1;
                    //if (Command($"UPDATE T12019  SET T_VIOROLOGY_RESULT='2',  T_VIRO_TIME = TO_CHAR(SYSDATE, 'HH24MI'), T_VIROLOGY_BY='{T_EMP_CODE}',T_CLOSE_FLAG='1' WHERE T_UNIT_NO = '{un}' ") && Command($"UPDATE t12075  SET T_VIROLOGY_RESULT='2',  T_VIROLOGY_RESULT_DATE = TRUNC(SYSDATE), T_VIROLOGY_RESULT_BY='{T_EMP_CODE}',T_CLOSE_FLAG='1'  WHERE T_UNIT_NO = '{un}'"))
                }

            }
            else
            {
                upcounta = upcounta + 1;
                counta = counta + 1;
                if (Command($"UPDATE T12019  SET T_VIOROLOGY_RESULT='',T_CLOSE_FLAG='1' WHERE T_UNIT_NO = '{un}' ") && Command($"UPDATE t12075  SET T_VIROLOGY_RESULT='',T_CLOSE_FLAG='1'  WHERE T_UNIT_NO = '{un}'"))
                {
                    count = count + 1;
                    upcount = upcount + 1;
                }
            }

            if (count>1)
            {
                if (count == counta)
                {
                    CommitTransaction();
                    msg = GetUserMsg("N0040", "LANG" + lang);
                }
                else
                {
                    RollbackTransaction();
                    msg = GetUserMsg("N0071", "LANG" + lang);
                }
            }
            else
            {
                if (upcount == upcounta)
                {
                    CommitTransaction();
                   // msg = GetUserMsg("N0040", "LANG" + lang);
                    msg = "Update Successfully";
                }
                else
                {
                    RollbackTransaction();
                    msg = "Update Not Successfully";
                    //  msg = GetUserMsg("N0071", "LANG" + lang);
                }
            }

            
            return msg;
        }

        //public bool InsertT12218(string un, List<M12325> vairusList, string T_EMP_CODE)
        //{
        //    foreach (var list in vairusList)
        //    {
        //        if (list.T_RESULT_CODE != null)
        //        {
        //            Command($"INSERT INTO T12218(T_UNIT_NO,T_TEST_CODE,T_RESULT_VAL,T_ENTRY_DATE)VALUES ('{un}', '{list.T_VIRUS_CODE}', '{list.T_RESULT_CODE}',SYSDATE)");
        //        }
        //    }
        //    return true;
        //}
        public DataTable GetUnitNo()
        {
            return Query("select T_UNIT_NO,T_DONATION_DATE from T12022");
        }

        public DataTable GerVirusResult(string lang)
        {

            return Query($"select T_RESULT_CODE,T_LANG{lang}_NAME T_LANG_NAME from t13006 where T_RESULT_CODE in ('M563','M562')");
        }

        public DataTable GetAllData(string lang, string unitNo)
        {
            return Query($"SELECT t34.T_UNIT_NO ,  t34.T_VIRUS_CODE ,  t34.T_TEST_VERIFY ,  t34.T_ENTRY_USER ,  t34.T_ENTRY_DATE ," +
                         $"  t34.T_VIRUS_RESULT ,  t33.T_LANG{lang}_NAME VIRUS_NAME,  t09.T_USER_NAME,  t22.T_DONATION_DATE " +
                         $",(SELECT  DISTINCT Max( NVL(T12034.T_POS1_VERIFY,0))Positive FROM T12034  where T12034.T_UNIT_NO = '1829114'  )POSITIVE_VERIFY, " +
                         $"(SELECT DISTINCT NVL(T12034.T_NEG_VERIFY,0)Negative FROM T12034  where T12034.T_UNIT_NO = '1829114' )NEGATIVE_VERIFY " +
                         $"FROM T12034 t34 JOIN T12033 t33 ON t34.T_VIRUS_CODE =t33.T_VIRUS_CODE " +
                         $"JOIN T01009 t09 ON t34.T_ENTRY_USER = t09.T_EMP_CODE " +
                         $"JOIN T12022 t22 ON t34.T_UNIT_NO    = t22.T_UNIT_NO WHERE t34.T_UNIT_NO = '{unitNo}' " +
                         $"ORDER BY T_VIRUS_CODE ASC ");
            //return Query($"SELECT t34.T_UNIT_NO ,t34.T_VIRUS_CODE , t34.T_POS1_VERIFY ,t34.T_POS1_VERIFIED_BY ,t34.T_POS1_VERIFIED_DATE ,t18.T_RESULT_VAL ,t33.T_LANG{lang}_NAME VIRUS_NAME, t09.T_USER_NAME, t22.T_DONATION_DATE FROM T12034 t34 JOIN T12218 t18 ON t34.T_UNIT_NO =t18.T_UNIT_NO and  t34.T_VIRUS_CODE = t18.T_TEST_CODE JOIN T12033 t33 ON t18.T_TEST_CODE =t33.T_VIRUS_CODE JOIN T01009 t09 ON  t34.T_POS1_VERIFIED_BY = t09.T_EMP_CODE JOIN T12022 t22 ON  t34.T_UNIT_NO = t22.T_UNIT_NO where t34.T_UNIT_NO = '{unitNo}'  ORDER BY T_VIRUS_CODE ASC ");
        }
    }
}