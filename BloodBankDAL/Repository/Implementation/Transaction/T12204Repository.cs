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
    public class T12204Repository: IT12204
    {
        private readonly T12204 obj = new T12204();
        public T12204Repository(T12204 _obj) : base()
        {
            obj = _obj;
        }
        public DataTable GatCompStatusData(string lang, string d)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GatCompStatusData(lang, d);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GatCompStatusData(lang,d);
            //return Data;
        }
        public DataTable GetBedUsedData(string lang, string id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetBedUsedData(lang, id);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetBedUsedData(lang,id);
            //return Data;
        }

      public  DataTable GetPatDetails(string lang, string siteCode, string patNo,string patId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetPatDetails(lang, siteCode, patNo, patId);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //  var lang = HttpContext.Current.Session["T_LANG"].ToString();
            //var Data = obj.GetPatDetails(lang, siteCode,patNo, patId);
            //return Data;
        }

       public DataTable GetReson_AcStatus(string lang, int bagWet)
       {
           DataTable dt = new DataTable();
           try
           {
               dt = obj.GetReson_AcStatus(lang, bagWet);

            }
           catch (Exception e)
           {
               MethodBase m = MethodBase.GetCurrentMethod();
               obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
           }
           return dt;
            //var lang = HttpContext.Current.Session["T_LANG"].ToString();
            //var Data = obj.GetReson_AcStatus(lang,bagWet);
            //return Data;
        }

       public DataTable GetBed(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetBed(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;

            //var Data = obj.GetBed(lang);
            //return Data;
        }

        public DataTable GetDiscurtReason(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetDiscurtReason(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;

            //var data = obj.GetDiscurtReason(lang);
            //return data;

        }

      public  DataTable GetbodyMermt(string pat, string epst)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetbodyMermt(pat, epst);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var data = obj.GetbodyMermt(pat, epst);
            //return data;
        }

        public DataTable GetQuestion(string pat, string epst)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetQuestion(pat, epst);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var data = obj.GetQuestion(pat, epst);
            //return data;
        }

        public DataTable GetImages(string pat, string epst)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetImages(pat, epst);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var data = obj.GetImages(pat, epst);
            //return data;
        }

        public DataTable getUnit_SegmNo()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.getUnit_SegmNo();

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var data = obj.getUnit_SegmNo();
            //return data;
        }

        public DataTable Getpin( string emNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.Getpin(emNo);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var data = obj.Getpin( emNo);
            //return data;
        }

        public string SaveData(CommonModel t12022)
        {
            string msg = "";
            bool isInsert = false;
            try
            {
                obj.BeginTransaction();
                if (obj.UpdateT12022(t12022))
                {
                    isInsert = obj.InsertT12075(t12022);
                }
                if (isInsert)
                {
                    obj.CommitTransaction();
                    msg = "Save Successfully";
                }
                else
                {
                    obj.RollbackTransaction();
                    msg = "f";
                }
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            //obj.BeginTransaction();
            //if (obj.UpdateT12022(t12022))
            //{
            //    isInsert= obj.InsertT12075(t12022);
            //}
            //if (isInsert)
            //{
            //    obj.CommitTransaction();
            //    msg = "Save Successfully";
            //}
            //else
            //{
            //    obj.RollbackTransaction();
            //    msg = "f";
            //}
            return msg;
        }

        public DataTable GetMaxBidStoreId()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetMaxBidStoreId();

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var data = obj.GetMaxBidStoreId();
            //return data;
        }
        public DataTable GetComment(int phel, string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetComment(phel, lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            // var lang = HttpContext.Current.Session["T_LANG"].ToString();
            //var Data = obj.GetComment(phel, lang);
            //return Data;
        }
        public DataTable GetComntT12328(string lang,int ple)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetComntT12328(lang, ple);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //  var lang = HttpContext.Current.Session["T_LANG"].ToString();
            //var data = obj.GetComntT12328(lang,ple);
            //return data;
        }
        public string Update(CommonModel t12022)
        {
            string msg = "";
            bool isInsert = false;
            try
            {
                obj.BeginTransaction();
                if (obj.SecondUpdate(t12022))
                {
                    obj.CommitTransaction();
                    msg = "Save Successfully";
                }
                else
                {
                    msg = "You are not able to Edit data";
                }
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            //obj.BeginTransaction();
            //if (obj.SecondUpdate(t12022))
            //{
            //    obj.CommitTransaction();
            //    msg = "Save Successfully";
            //}
            //else
            //{
            //    msg = "You are not able to Edit data";
            //}
            return msg;
        }

        public DataTable showDataFromT12022(string lang, string patNo, string epsort)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.showDataFromT12022(lang, patNo, epsort);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            // var lang = HttpContext.Current.Session["T_LANG"].ToString();
            //var Data = obj.showDataFromT12022(lang, patNo, epsort);
            //return Data;
        }


        // DataTable GetBed()
    }
}