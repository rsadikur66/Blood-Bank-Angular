using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Interface.Transaction;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Transaction
{
    public class T12241Controller : Controller
    {
        private IT12241 repository;
        private IError err;
        public T12241Controller(IT12241 ObjectIRepository, IError errRepo)
        {
            repository = ObjectIRepository;
            err = errRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GridResultVirology(string UnitNoFrom,string UnitNoTo)
        {
            try
            {
                var siteCode = Session["T_SITE_CODE"].ToString();
                var lang = Session["T_LANG"].ToString();
                var data = repository.GridResultVirology(UnitNoFrom, UnitNoTo, lang, siteCode);
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
        
        public ActionResult DocEmpCode()
        {
            try
            {
                var site = Session["T_SITE_CODE"].ToString();
                var data = repository.DocEmpCode(Session["T_EMP_CODE"].ToString());
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
        
        public ActionResult updateVirologyResults(string unitNo)
        {
            try
            {
                string siteCode = Session["T_SITE_CODE"].ToString();
                var data = repository.updateVirologyResults(unitNo, siteCode);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult InsertT12223(string unitNo)
        {
            try
            {
                var siteCode = Session["T_SITE_CODE"].ToString();
                var data = repository.InsertT12223(unitNo, siteCode);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetUnitPopUpData()
        {
            try
            {
                var data = repository.GetUnitPopUpData();
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