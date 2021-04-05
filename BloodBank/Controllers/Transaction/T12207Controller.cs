using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Interface.Transaction;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Transaction
{
    public class T12207Controller : Controller
    {
        private IT12207 repository;
        private IError err;
        public T12207Controller(IT12207 ObjectIRepository, IError errRepo)
        {
            repository = ObjectIRepository;
            err = errRepo;
        }
        // GET: T12207
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetRefHospital()
        {
            try
            {
                //var siteCode = Session["T_SITE_CODE"].ToString();
                var siteCode = Session["T_REFERRAL_CODE"].ToString();
                var data = repository.GetRefHospital(siteCode, Convert.ToString(Session["T_LANG"].ToString()));
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


        [HttpPost]
        public ActionResult GetBlood()
        {
            try
            {
                var data = repository.GetBlood(Convert.ToString(Session["T_LANG"].ToString()));
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

        [HttpPost]
        public ActionResult GetProduct()
        {
            try
            {
                var data = repository.GetProduct(Convert.ToString(Session["T_LANG"].ToString()));
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
         public ActionResult getGridDataForTransfusion()
        {
            try
            {
                string siteCode = Convert.ToString(Session["T_REFERRAL_CODE"].ToString());
                var data = repository.GetGridDataForTransfusion(siteCode);
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

        [HttpPost]
        public ActionResult Insert_T12207(t12207 t12207)
        {
            try
            {
                var user = Session["T_EMP_CODE"].ToString();
                //var siteCode = Session["T_SITE_CODE"].ToString();
                var siteCode = Session["T_REFERRAL_CODE"].ToString();
                var data = repository.Insert_T12207(t12207, user, siteCode);
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
        [HttpPost]
        public ActionResult BloodReceiveFromTransfusion(string del,string blNo)
        {
            try
            {
                var user = Session["T_EMP_CODE"].ToString();
                var siteCode = Session["T_SITE_CODE"].ToString();
                var siteCode1 = Session["T_REFERRAL_CODE"].ToString();
                var data = repository.BloodReceiveFromTransfusion(del, blNo, user, siteCode1);
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