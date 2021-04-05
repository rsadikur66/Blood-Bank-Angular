using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Mvc;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface.Transaction;
using System.Data;
using System.IO;
using FastReport.Export.Pdf;
using BloodBankDAL.Repository.Interface;

namespace BloodBank.Controllers.Transaction
{
    public class T12302Controller : Controller
    {
       private IT12302 repository;
        private IError err;
        public T12302Controller(IT12302 ObjectIRepository,IError errRepo)
        {
            repository = ObjectIRepository;
            err = errRepo;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult reqList(string req)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                string site = Session["T_SITE_CODE"].ToString();
                var data = repository.reqList(lang, site, req);
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
        public ActionResult reqDet(string req)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                string site = Session["T_SITE_CODE"].ToString();
                var data = repository.reqDet(lang, site, req);
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
        public ActionResult bgList(string code)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                var data = repository.bgList(lang, code);
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
        public ActionResult techList(string code)
        {
            try
            {
                string site = Session["T_SITE_CODE"].ToString();
                var data = repository.techList(site, code);
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
        public ActionResult antTypAutoList(string code, string type)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                var data = repository.antTypAutoList(lang, code, type);
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
        public ActionResult antTypFinalList(string code, string type)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                var data = repository.antTypFinalList(lang, code, type);
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
        public ActionResult antiList()
        {
            try
            {
                var data = repository.antiList();
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
        public ActionResult dctList()
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                var data = repository.dctList(lang);
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
        public ActionResult getbgByControl(string P_ANTI_A, string P_ANTI_B, string P_ANTI_D, string P_CONTROL)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                var data = repository.getbgByControl(lang, P_ANTI_A, P_ANTI_B, P_ANTI_D, P_CONTROL);
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
        public ActionResult getbgByControl6(string P_ANTI_A, string P_ANTI_B, string P_ANTI_D, string P_CONTROL, string P_ACELL, string P_BCELL)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                var data = repository.getbgByControl6(lang, P_ANTI_A, P_ANTI_B, P_ANTI_D, P_CONTROL, P_ACELL, P_BCELL);
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
        public ActionResult checkBg(string P_PAT_NO)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                var data = repository.checkBg(P_PAT_NO, lang);
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
        public ActionResult checkT_SC(string P_PAT_NO)
        {
            try
            {
                string site = Session["T_SITE_CODE"].ToString();
                var data = repository.checkT_SC(P_PAT_NO, site);
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
        public ActionResult chkDoctor()
        {
            try
            {
                string site = Session["T_SITE_CODE"].ToString();
                string emp = Session["T_EMP_CODE"].ToString();
                var data = repository.chkDoctor(emp, site);
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
        public ActionResult unitList(string P_PAT_NO, string P_PHENO, string P_REQUISITION, string P_ABO_CODE, string P_UNIT_NO, string P_REQUEST_NO)
        {
            try
            {
                string site = Session["T_SITE_CODE"].ToString();
                string lang = Session["T_LANG"].ToString();
                var data = repository.unitList(P_PAT_NO, site, P_PHENO, P_REQUISITION, P_ABO_CODE, P_UNIT_NO, P_REQUEST_NO, lang);
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
        public ActionResult insert(T12013 t12013,List<T12256> t12256)
        {
            try
            {
                string site = Session["T_SITE_CODE"].ToString();
                string emp = Session["T_EMP_CODE"].ToString();
                var data = repository.insert(t12013, t12256);
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
        public ActionResult getUserId()
        {
            try
            {
                string site = Session["T_SITE_CODE"].ToString();
                string emp = Session["T_EMP_CODE"].ToString();
                string lang = Session["T_LANG"].ToString();
                var data = repository.getUserId(site, emp, lang);
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
        public ActionResult checkBlood(string patId)
        {

            try
            {
                var data = repository.checkBlood(patId);
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
        //checkBlood
    }

}