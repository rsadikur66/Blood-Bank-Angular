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
    public class R12006Repository : IR12006
    {
        private readonly R12006 obj = new R12006();

        readonly R12302 _r12302 = new R12302();

        public R12006Repository(R12006 _obj,R12302 r12302) : base()
        {
            obj = _obj;
            _r12302 = r12302;
        }
        public R12006Repository()
        {
        }

        public DataTable getReport(string l, string nationalId)
        {
            //var Data = obj.getReport(l,from,to,prod);
            //return Data;

            var data = new DataTable();

            try
            {
                data = obj.getReport(l, nationalId);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetR12006Site(string scode)
        {
            var data = new DataTable();

            try
            {
                data = _r12302.GetSite(scode);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetR12006PatProfile(string lang, string patNo)
        {
            var data = new DataTable();

            try
            {
                data = obj.GetR12006PatProfile(lang,patNo);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetR12006Agreement(string l, string patNo)
        {
            var data = new DataTable();

            try
            {
                data = obj.GetR12006Agreement(l,patNo);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetR12006Confirmation(string lang)
        {
            var data = new DataTable();

            try
            {
                data = obj.GetR12006Confirmation(lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetR12215Summery(string entryDate, int siteCode, string donationDate)
        {
            var data=new DataTable();

            try
            {
                data = obj.GetR12215Summery(entryDate, siteCode, entryDate);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }


        public DataTable GetR12215SiteCode(int siteCode, string lang)
        {
            var data = new DataTable();

            try
            {
                data = obj.GetR12215SiteCode(siteCode, lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetR12215CollectedUnit(int siteCode, string donationDate)
        {
            var data = new DataTable();

            try
            {
                data = obj.GetR12215CollectedUnit(siteCode,donationDate);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetTechList(string site)
        {
            var data = obj.GetTechList(site);
            return data;
        }
        public DataTable GetReasonList(string lang)
        {
            var data = obj.GetReasonList(lang);
            return data;
        }

      public DataTable getCollector(string lang, string fdate)
      {
          var data = obj.getCollector(lang, fdate);
          return data;
      }

       public DataTable getCollection(string lang, string fdate)
        {
            var data = obj.getCollection(lang, fdate);
            return data;
        }

      public  DataTable getCountTime(string lang, string fdate)
        {
            var data = obj.getCountTime(lang, fdate);
            return data;
        }


    }
}