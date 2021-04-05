using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Repository.Interface.Query;
using BloodBankDAL.Repository.Query.Query;

namespace BloodBankDAL.Repository.Implementation.Query
{
    public class Q12025Repository: IQ12025
    {
        private readonly Q12025 obj = new Q12025();
        public Q12025Repository(Q12025 _obj)
        {
            obj = _obj;
        }

      public  DataTable GetSiteData(string lang)
        {
            //var obj = this.obj.GetSiteData(lang);
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetSiteData(lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

      public  DataTable GetBloodGroupData(string lang)
        {
            //var obj = this.obj.GetBloodGroupData(lang);
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetBloodGroupData(lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

      public  DataTable GetProductData(string lang)
        {
            //var obj = this.obj.GetProductData(lang);
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetProductData(lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetStocktData(string lang, string donTiFrom, string donTiTo, string siteCode,
            string bloodGrp, string product)
        {
            //var obj = this.obj.GetStocktData(lang, donTiFrom,  donTiTo, siteCode, bloodGrp, product);
            //return obj;


            var data = new DataTable();

            try
            {
                data = this.obj.GetStocktData(lang, donTiFrom, donTiTo, siteCode, bloodGrp, product);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }
    }
}