using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface.Transaction;
using BloodBankDAL.Repository.Query.Transaction;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    public class T12233Repository:IT12233
    {
        private readonly T12233 obj = new T12233();

        public T12233Repository(T12233 _obj) : base()
        {
            obj = _obj;
        }

        public T12233Repository()
        {
        }

        public DataTable GetGridData(string unitno, string lang, string language)
        {
            var userlang = "";
            if (language == "2") userlang = "";
            else userlang = "2";
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetGridData(unitno, lang, userlang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetGridData(unitno, lang, userlang);
            //return obj;
        }

        public DataTable GetVerifyData(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetVerifyData(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetVerifyData(lang);
            //return obj;
        }

        public DataTable GetUnitData()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetUnitData();

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetUnitData();
            //return obj;
        }

        public string Insert_T13016(List<t12233> t12233, string user, string lang)
        {
            string msg = "";
            obj.BeginTransaction();
            int count = 0;
            int i;
            var userlang = "";
            if (lang == "2") userlang = "";
            else userlang = "2";
            var Condition = obj.GetGridData(t12233[0].T_UNIT_NO, lang, userlang);
            var siteCode = HttpContext.Current.Session["T_SITE_CODE"].ToString();
           
            try
            {
                for (i = 0; i < t12233.Count; i++)
                {
                    var T_VIOROLOGY_RESULT = "";
                    if (Condition.Rows.Count == 1)
                    {
                        var Condition04 = obj.GetDataCheck(t12233[0].T_UNIT_NO, lang, userlang, "04");
                        var Condition03 = obj.GetDataCheck(t12233[0].T_UNIT_NO, lang, userlang, "03");
                        if (Condition04.Rows.Count == 1)
                        {
                            t12233[i].T_VIOROLOGY_RESULT = "1";
                        }
                        else if (Condition03.Rows.Count == 1)
                        {
                            t12233[i].T_VIOROLOGY_RESULT = "1";
                        }
                        else
                        {
                            t12233[i].T_VIOROLOGY_RESULT = "3";
                        }
                    }
                    if (Condition.Rows.Count == 2)
                    {

                        var Condition_03_04 = obj.GetDataCheck_03_04(t12233[0].T_UNIT_NO, lang, userlang);
                        if (Condition_03_04.Rows.Count == 2)
                        {
                            t12233[i].T_VIOROLOGY_RESULT = "1";
                        }
                        else
                        {
                            t12233[i].T_VIOROLOGY_RESULT = "3";
                        }
                    }
                    if (Condition.Rows.Count > 2)
                    {
                        t12233[i].T_VIOROLOGY_RESULT = "3";
                    }
                    if (
                        obj.UpdateT12019(t12233[i].T_VIOROLOGY_RESULT, t12233[i].T_UNIT_NO) &&
                        obj.UpdateT12034(t12233[i].T_POS2_VERIFY, t12233[i].T_SEND_FLAG, t12233[i].T_LAB_REQ_NO, t12233[i].T_UNIT_NO, t12233[i].T_VIRUS_CODE, user) &&
                        obj.UpdateT12075(t12233[i].T_VIOROLOGY_RESULT, t12233[i].T_UNIT_NO))

                        if (obj.Insert_T13016(t12233[i].T_ENTRY_USER, t12233[i].T_REQUEST_NO, t12233[i].T_ANALYSIS_CODE) && obj.InsertT12223(t12233[i].T_ENTRY_USER, t12233[i].T_UNIT_NO, siteCode))
                        {
                            count++;
                        }


                }
                if (i == count && i > 0)
                {
                    obj.CommitTransaction();
                    msg = obj.GetUserMsg("N0040", "LANG" + lang);
                }
                else
                {
                    obj.RollbackTransaction();
                    msg = obj.GetUserMsg("N0071", "LANG" + lang);
                }

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return msg;
            //for (i = 0; i < t12233.Count; i++)
            //{
            //    var T_VIOROLOGY_RESULT = "";
            //    if (Condition.Rows.Count == 1)
            //    {
            //        var Condition04 = obj.GetDataCheck(t12233[0].T_UNIT_NO, lang, userlang, "04");
            //        var Condition03 = obj.GetDataCheck(t12233[0].T_UNIT_NO, lang, userlang, "03");
            //        if (Condition04.Rows.Count == 1)
            //        {
            //            t12233[i].T_VIOROLOGY_RESULT = "1";
            //        }
            //        else if (Condition03.Rows.Count == 1)
            //        {
            //            t12233[i].T_VIOROLOGY_RESULT = "1";
            //        }
            //        else
            //        {
            //            t12233[i].T_VIOROLOGY_RESULT = "3";
            //        }
            //    }
            //    if (Condition.Rows.Count == 2)
            //    {
                   
            //        var Condition_03_04 = obj.GetDataCheck_03_04(t12233[0].T_UNIT_NO, lang, userlang);
            //        if (Condition_03_04.Rows.Count == 2)
            //        {
            //            t12233[i].T_VIOROLOGY_RESULT = "1";
            //        }
            //        else
            //        {
            //            t12233[i].T_VIOROLOGY_RESULT = "3";
            //        }
            //    }
            //    if (Condition.Rows.Count > 2)
            //    {
            //        t12233[i].T_VIOROLOGY_RESULT = "3";                    
            //    }
            //    if (
            //        obj.UpdateT12019(t12233[i].T_VIOROLOGY_RESULT, t12233[i].T_UNIT_NO) &&
            //        obj.UpdateT12034(t12233[i].T_POS2_VERIFY, t12233[i].T_SEND_FLAG,t12233[i].T_LAB_REQ_NO, t12233[i].T_UNIT_NO, t12233[i].T_VIRUS_CODE,user) &&
            //        obj.UpdateT12075(t12233[i].T_VIOROLOGY_RESULT, t12233[i].T_UNIT_NO))

            //        if (obj.Insert_T13016(t12233[i].T_ENTRY_USER, t12233[i].T_REQUEST_NO, t12233[i].T_ANALYSIS_CODE) && obj.InsertT12223(t12233[i].T_ENTRY_USER, t12233[i].T_UNIT_NO, siteCode))
            //        {
            //        count++;
            //    }

                
            //}
            //if (i == count && i > 0)
            //{
            //    obj.CommitTransaction();
            //    msg = obj.GetUserMsg("N0040", "LANG" + lang);
            //}
            //else
            //{
            //    obj.RollbackTransaction();
            //    msg = obj.GetUserMsg("N0071", "LANG" + lang);
            //}

            //    return msg;

            }
        }
}