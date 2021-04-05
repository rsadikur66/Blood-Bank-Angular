using BloodBankDAL.Repository.Interface.Transaction;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers.Transaction
{
    public class T12266Controller : Controller
    {
        private IT12266 repository;
        public T12266Controller(IT12266 ObjectIRepository)
        {
            repository = ObjectIRepository;

        }
        // GET: T12266
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDeliveryManData()
        {
            try
            {
                string l = Session["T_LANG"].ToString();
                // string site = Session["T_SITE_CODE"].ToString();
                var siteCode = Session["T_REFERRAL_CODE"].ToString();
                var data = repository.GetDeliveryManData(siteCode);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetReqDetails(string bldReq, string site)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                //string site = Session["T_SITE_CODE"].ToString();
                var data = repository.GetReqDetails(bldReq, site, lang);
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
                var user = Session["T_EMP_CODE"].ToString();
                var lang = HttpContext.Session["T_LANG"].ToString();
                var data = repository.GetuserDetails(lang, user);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Save(string delCode, string requestNo, string time, string site)
        {
            try
            {
                //var siteCode = HttpContext.Session["T_SITE_CODE"].ToString();
                var siteCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var user = Session["T_EMP_CODE"].ToString();
                var data = repository.Save(delCode,requestNo, site, user, time);
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