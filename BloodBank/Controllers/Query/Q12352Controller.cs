using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface.Query;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Query
{
    public class Q12352Controller : Controller
    {
        private IQ12352 repository;

        public Q12352Controller(IQ12352 ObjectIRepository)
        {
            repository = ObjectIRepository;

        }
        // GET: Q12352
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetChartData(string productCode)
        {
            try
            {
                string l = Session["T_LANG"].ToString();
                string siteCode = Session["T_SITE_CODE"].ToString();
                var referCode = Session["T_REFERRAL_CODE"].ToString();
                var data = repository.GetChartData(productCode);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        //public ActionResult GetChartDataForPLT()
        //{
        //    try
        //    {
        //        string l = Session["T_LANG"].ToString();
        //        string siteCode = Session["T_SITE_CODE"].ToString();
        //        var referCode = Session["T_REFERRAL_CODE"].ToString();
        //        var data = repository.GetChartDataForPLT();
        //        string JSONString = string.Empty;
        //        JSONString = JsonConvert.SerializeObject(data);
        //        return Json(JSONString, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception e)
        //    {
        //        return Json(e.Message, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //public ActionResult GetChartDataForFFP()
        //{
        //    try
        //    {
        //        string l = Session["T_LANG"].ToString();
        //        string siteCode = Session["T_SITE_CODE"].ToString();
        //        var referCode = Session["T_REFERRAL_CODE"].ToString();
        //        var data = repository.GetChartDataForFFP();
        //        string JSONString = string.Empty;
        //        JSONString = JsonConvert.SerializeObject(data);
        //        return Json(JSONString, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception e)
        //    {
        //        return Json(e.Message, JsonRequestBehavior.AllowGet);
        //    }
        //}

    }
}