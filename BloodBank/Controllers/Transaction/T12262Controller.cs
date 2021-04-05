using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface.Transaction;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Transaction
{
    public class T12262Controller : Controller
    {
        private IT12262 repository;
       

        public T12262Controller(IT12262 _repository)
        {
            repository = _repository;
           
        }
        // GET: T12262
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDataBySiteCode()
        {
            try
            {
                //var siteCode = HttpContext.Session["T_SITE_CODE"].ToString();
                var siteCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var lang = HttpContext.Session["T_LANG"].ToString();
                var data = repository.GetDataBySiteCode(siteCode, lang);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetDataRequestNo(string siteCode)
        {
            try
            {
                var refCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var lang = HttpContext.Session["T_LANG"].ToString();
                var data = repository.GetDataRequestNo(siteCode, refCode, lang);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetRequestDetails(string requestNo, string siteCode)
        {
            try
            {
                //var siteCode = HttpContext.Session["T_SITE_CODE"].ToString();
                var lang = HttpContext.Session["T_LANG"].ToString();
                var data = repository.GetRequestDetails(requestNo, siteCode, lang);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetRequestDetail()
        {
            try
            {
                var siteCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var lang = HttpContext.Session["T_LANG"].ToString();
                var data = repository.GetRequestDetails(siteCode, lang);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetuserDetails()
        {
            try
            {
                //var siteCode = HttpContext.Session["T_SITE_CODE"].ToString();
                // Session["T_EMP_CODE"]
               // var user =Session["T_ENTRY_USER"].ToString();
                var user = Session["T_EMP_CODE"].ToString();
                var lang = HttpContext.Session["T_LANG"].ToString();
                var data = repository.GetuserDetails(lang,user);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Save(string requestNo,string time,string site)
        {
            try
            {
                //var siteCode = HttpContext.Session["T_SITE_CODE"].ToString();
                var siteCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var user = Session["T_EMP_CODE"].ToString();
                var data = repository.Save(requestNo, site, user, time);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}