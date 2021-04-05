using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface.Transaction;
using BloodBankDAL.Repository.Query.Transaction;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    public class T12202Repository:IT12202
    {
        private readonly T12202 obj = new T12202();
        public T12202Repository(T12202 _obj) : base()
        {
            obj = _obj;
        }
        public DataTable getPatDetail(string P_PAT_NO,string P_NTNLTY_ID,string l, string T_SITE_CODE)
        {
            DataTable dt = new DataTable();
            try
            {
                string lang = l;
                dt = obj.getPatDetail(P_PAT_NO, P_NTNLTY_ID, lang, T_SITE_CODE);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //string lang = l;
            //var Data = obj.getPatDetail(P_PAT_NO,P_NTNLTY_ID, lang, T_SITE_CODE);
            //return Data;
        }
        public DataTable GetUnitData(string unitNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetUnitData(unitNo);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
        }
        public DataTable getQues(string P_PAT_NO,string P_NTNLTY_ID,int P_REQUEST_ID, string l, string P_SEX)
        {
            DataTable dt = new DataTable();
            try
            {
                string lang = l;
                dt = obj.getQues(P_PAT_NO, P_NTNLTY_ID, P_REQUEST_ID, lang, P_SEX);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //string lang = l;
            //var Data = obj.getQues(P_PAT_NO, P_NTNLTY_ID,P_REQUEST_ID, lang, P_SEX);
            //return Data;
        }
        public DataTable getValidation(string P_VITAL_CODE, decimal Value, string l)
        {
            DataTable dtRes = new DataTable();
            try
            {
                string lang = l;
                //DataTable dtRes = new DataTable();
                dtRes.Columns.Add("T_ACCEPT_STATUS", typeof(string));
                dtRes.Columns.Add("T_DIFFERED_STATUS", typeof(string));
                dtRes.Columns.Add("T_RES_CODE", typeof(string));
                dtRes.Columns.Add("NAME", typeof(string));
                DataRow dr = dtRes.NewRow();

                DataTable dtval = obj.getValidation(P_VITAL_CODE);
                decimal min = decimal.Parse(dtval.Rows[0]["T_MIN_VALUE"].ToString());
                decimal max = decimal.Parse(dtval.Rows[0]["T_MAX_VALUE"].ToString());
                if (min <= Value && Value <= max)
                {
                    dr["T_ACCEPT_STATUS"] = "1";
                    dr["T_DIFFERED_STATUS"] = null;
                    dr["T_RES_CODE"] = null;
                    dr["NAME"] = null;
                    dtRes.Rows.Add(dr);
                }
                else
                {
                    switch (P_VITAL_CODE)
                    {
                        case "0001": dtRes = obj.getValidationReason("15", lang); break;
                        case "0002": dtRes = obj.getValidationReason("16", lang); break;
                        case "0003": dtRes = obj.getValidationReason("27", lang); break;
                        case "0004":
                            if (Value > max) { dtRes = obj.getValidationReason("17", lang); }
                            else if (Value < max) { dtRes = obj.getValidationReason("18", lang); }
                            break;
                        case "0005":
                            if (Value > max) { dtRes = obj.getValidationReason("19", lang); }
                            else if (Value < max) { dtRes = obj.getValidationReason("20", lang); }
                            break;
                        case "0006":
                            dr["T_ACCEPT_STATUS"] = "2";
                            dr["T_DIFFERED_STATUS"] = null;
                            dr["T_RES_CODE"] = null;
                            dr["NAME"] = null;
                            dtRes.Rows.Add(dr);
                            break;


                    }
                }
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dtRes;
            //string lang = l;
            //DataTable dtRes = new DataTable();
            //dtRes.Columns.Add("T_ACCEPT_STATUS", typeof(string));
            //dtRes.Columns.Add("T_DIFFERED_STATUS", typeof(string));
            //dtRes.Columns.Add("T_RES_CODE", typeof(string));
            //dtRes.Columns.Add("NAME", typeof(string));
            //DataRow dr = dtRes.NewRow();

            //DataTable dtval=obj.getValidation(P_VITAL_CODE);
            //decimal min = decimal.Parse(dtval.Rows[0]["T_MIN_VALUE"].ToString());
            //decimal max = decimal.Parse(dtval.Rows[0]["T_MAX_VALUE"].ToString());
            //if (min <= Value && Value <= max)
            //{
            //    dr["T_ACCEPT_STATUS"] = "1";
            //    dr["T_DIFFERED_STATUS"] = null;
            //    dr["T_RES_CODE"] = null;
            //    dr["NAME"] = null;
            //    dtRes.Rows.Add(dr);
            //}
            //else
            //{
            //    switch (P_VITAL_CODE)
            //    {
            //        case "0001":dtRes = obj.getValidationReason("15", lang);break;
            //        case "0002": dtRes = obj.getValidationReason("16", lang); break;
            //        case "0003": dtRes = obj.getValidationReason("27", lang); break;
            //        case "0004":
            //            if (Value>max){ dtRes = obj.getValidationReason("17", lang); }
            //       else if (Value<max){ dtRes = obj.getValidationReason("18", lang); }
            //            break;
            //        case "0005":
            //            if (Value > max) { dtRes = obj.getValidationReason("19", lang); }
            //            else if (Value < max) { dtRes = obj.getValidationReason("20", lang); }
            //            break;
            //        case "0006":
            //            dr["T_ACCEPT_STATUS"] = "2";
            //            dr["T_DIFFERED_STATUS"] = null;
            //            dr["T_RES_CODE"] = null;
            //            dr["NAME"] = null;
            //            dtRes.Rows.Add(dr);
            //            break;


            //    }
            //}
            //return dtRes;
        }
        public string insert(T12022 t22,  string t, string u)
        {
            string user = u;
            string msg = "";
          
            obj.BeginTransaction();
            if (t=="i")
            {
                if (obj.insert22(user, t22.T_PAT_NO, t22.T_EPISODE_NO, t22.T_REQUEST_ID, t22.T_SER_USE, t22.T_MAX_DIFFERED_DATE, t22.T_MAX_DIFFERED_DAY, t22.T_WEIGHT, t22.T_TEMPTURE, t22.T_HB, t22.T_PULS, t22.T_BP_HIGH, t22.T_BP_LOW, t22.T_REJECT_REASON, t22.REC_DIF_DAY, t22.T_COMMENT, t22.T_DIFFERED_DATE, t22.T_DIFFERED_STATUS, t22.T_ACCEPT_STATUS))
                {obj.CommitTransaction();
                    msg = "Data Saved Successfully";
                }
                else
                {
                    obj.RollbackTransaction();
                    msg = "Data not Saved";
                }
             
            }
            else if (t=="u")
            {
                if (obj.update22(user, t22.T_PAT_NO, t22.T_EPISODE_NO, t22.T_REQUEST_ID, t22.T_SER_USE,
                    t22.T_MAX_DIFFERED_DATE, t22.T_MAX_DIFFERED_DAY, t22.T_WEIGHT, t22.T_TEMPTURE, t22.T_HB, t22.T_PULS,
                    t22.T_BP_HIGH, t22.T_BP_LOW, t22.T_REJECT_REASON, t22.REC_DIF_DAY, t22.T_COMMENT,
                    t22.T_DIFFERED_DATE, t22.T_DIFFERED_STATUS, t22.T_ACCEPT_STATUS, t22.T_VITAL_ID))
                {
                    obj.CommitTransaction();
                    msg = "Data Updated Successfully";
                }
                else
                {obj.RollbackTransaction();
                    msg = "Data not Updated";
                }

            }

            //if (isInsert)
            //{
            //    obj.CommitTransaction();
            //    if (t12071!=null)
            //    {
            //        i = t12071.Count;
            //        obj.BeginTransaction();
            //        foreach (T12071 t71 in t12071)
            //        {
            //            isInsert71 = obj.update71(user, t71.T_QNO, t71.T_QNO_ANS, t71.T_QUES_ID, t22.T_REQUEST_ID,
            //                t22.T_PAT_NO, t22.T_EPISODE_NO, t71.T_DIFFERAL_DAY);

            //            a = isInsert71 ? a + 1 : a;
            //        //{ obj.CommitTransaction(); }
            //        //else { obj.RollbackTransaction(); }

            //    }

            //        if (a==i&&a>0)
            //        {
            //            obj.CommitTransaction();
            //        }
            //        else
            //        {
            //            obj.RollbackTransaction();

            //        }
            //    }
                
            //}
            //else
            //{
            //    obj.RollbackTransaction();
            //    msg = "Data not Saved";
            //}
            
            return msg;
        }
        public int singleInsert(T12071 t71)
        {
            int msg = 0;
          


                obj.BeginTransaction();
                if (t71.T_QUES_ID == 0)
                {
                    int res = obj.insertSingleQues71(t71.T_ENTRY_USER, t71.T_ENTRY_TIME, t71.T_DONOR_ID,
                        t71.T_DONOR_PATNO,
                        t71.T_DONOR_EPISODE, t71.T_QNO, t71.T_QNO_ANS, t71.T_QHEAD_NO, t71.T_DISP_SEQ,
                        t71.T_DIFFERAL_DAY,
                        t71.T_REQUEST_ID);
                    if (res > 0)
                    {
                        obj.CommitTransaction();
                        msg = res;
                    }
                    else
                    {
                        obj.RollbackTransaction();
                    }

                }
                else
                {
                    if (obj.updateSingleQues71(t71.T_UPD_USER, t71.T_QNO, t71.T_QNO_ANS, t71.T_QUES_ID,
                        t71.T_REQUEST_ID, t71.T_DONOR_PATNO, t71.T_DONOR_EPISODE, t71.T_DIFFERAL_DAY))
                    {
                        obj.CommitTransaction();
                        msg = t71.T_QUES_ID;
                    }
                    else
                    {
                        obj.RollbackTransaction();
                    }
                }
            
            



            return msg;
        }
    }
}