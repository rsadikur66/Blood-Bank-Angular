using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Repository.Interface.Report;
using BloodBankDAL.Repository.Query.Report;

namespace BloodBankDAL.Repository.Implementation.Report
{
    public class R12302Repository : IR12302
    {
        //R12302 r12302 = new R12302();

        private readonly R12302 r12302 = new R12302();

        public R12302Repository(R12302 _r12302)
        {
            r12302 = _r12302;
        }

        public DataTable GetReport(string siteCode)
        {
            //var Data = r12302.GetReport(siteCode);
            //return Data;

            var data = new DataTable();

            try
            {
                data = r12302.GetReport(siteCode);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                r12302.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetPatInf()
        {
            //var Data = r12302.GetPatInf();
            //return Data;

            var data = new DataTable();

            try
            {
                data = r12302.GetPatInf();
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                r12302.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;

        }

        public DataTable GetSite(string siteCode)
        {
            //var Data = r12302.GetSite(siteCode);
            //return Data;

            var data = new DataTable();

            try
            {
                data = r12302.GetSite(siteCode);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                r12302.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }
        public DataTable getPatInfo(string patno)
        {
            //var Data = r12302.getPatInfo(patno);
            //return Data;

            var data = new DataTable();

            try
            {
                data = r12302.getPatInfo(patno);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                r12302.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }
        public DataTable geHistoryData(string patno, string siteCode)
        {
            //var Data = r12302.geHistoryData(patno, siteCode);
            //return Data;

            var data = new DataTable();

            try
            {
                data = r12302.geHistoryData(patno, siteCode);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                r12302.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

       public DataTable getR12065_Report(string patno)
        {
            //var Data = r12302.getR12065_Report(patno);
            //return Data;

            var data = new DataTable();

            try
            {
                data = r12302.getR12065_Report(patno);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                r12302.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

       public DataTable getR12036A_Report(string patno)
        {
            //var Data = r12302.getR12036A_Report(patno);
            //return Data;


            var data = new DataTable();

            try
            {
                data = r12302.getR12036A_Report(patno);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                r12302.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }
        public DataTable getR12012_Report(string reqno, string site, string lang)
        {
            //var Data = r12302.getR12012_Report(reqno, site, lang);
            //return Data;


            var data = new DataTable();

            try
            {
                data = r12302.getR12012_Report(reqno, site, lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                r12302.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }
    }
}