using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Model;
using BloodBankDAL.Repository;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Interface.Initialization;
using BloodBankDAL.Repository.Interface.Transaction;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Transaction
{
    public class T12263Controller : Controller
    {
        private IT12263 repository;
        private IError err;
        CommonDAL _cDal = new CommonDAL();
        public T12263Controller(IT12263 _repository, IError errRepo)
        {
            repository = _repository;
            err = errRepo;
        }
        // GET: T12263
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetSiteList()
        {
            try
            {
                var siteCode = HttpContext.Session["T_SITE_CODE"].ToString();
                var refCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var lang = HttpContext.Session["T_LANG"].ToString();
                var data = repository.GetSiteList(siteCode, refCode, lang);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetRequestList(string siteCode)
        {
            try
            {
                var refCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var lang = HttpContext.Session["T_LANG"].ToString();
                var data = repository.GetRequestList(siteCode, refCode);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetGridData(string bldGrp, string proCode)
        {
            try
            {
                var empCode = HttpContext.Session["T_EMP_CODE"].ToString();
                var userName = HttpContext.Session["T_USER_NAME"].ToString();
                var data = repository.GetGridData(bldGrp, proCode, empCode, userName);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetRequestedData(string siteCode, string requestNo)
        {
            try
            {
                var lang = HttpContext.Session["T_LANG"].ToString();
                var data = repository.GetRequestedData(siteCode, requestNo);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CrossmatchCheck(string reqNo, string bldGrp, string proCode)
        {
            try
            {
                var lang = HttpContext.Session["T_LANG"].ToString();
                var data = repository.CrossmatchCheck(reqNo, bldGrp, proCode);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult T12263insert(List<M12263> t12263)
        {
            try
            {
                string user = HttpContext.Session["T_EMP_CODE"].ToString();
                //string siteCode = HttpContext.Session["T_SITE_CODE"].ToString();
                string siteCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();

                var data = repository.T12263insert(t12263, user, siteCode);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCourierServiceData()
        {
            try
            {
                //var siteCode = HttpContext.Session["T_SITE_CODE"].ToString();
                var siteCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var lang = HttpContext.Session["T_LANG"].ToString();
                var data = repository.GetCourierServiceData(siteCode, lang);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetdeliveryByData()
        {
            try
            {
                //var siteCode = HttpContext.Session["T_SITE_CODE"].ToString();
                var siteCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var lang = HttpContext.Session["T_LANG"].ToString();
                var data = repository.GetdeliveryByData(siteCode, lang);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetDeliveryManLocation()
        {
            try
            {
                var siteCode = HttpContext.Session["T_SITE_CODE"].ToString();
                // var siteCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var lang = HttpContext.Session["T_LANG"].ToString();
                var data = repository.GetDeliveryManLocation(siteCode, lang);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

    }
}