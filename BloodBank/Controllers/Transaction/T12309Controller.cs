using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Interface.Transaction;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Transaction
{
    public class T12309Controller : Controller
    {
        private IT12309 repository;
        private IError err;

        public T12309Controller(IT12309 ObjectIRepository,IError errRepo)
        {
            repository = ObjectIRepository;
            err = errRepo;
        }
        // GET: T12232
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetUnitData()
        {
            try
            {
                var data = repository.GetUnitData();
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
        public ActionResult GetProductDetails(string unitNo, string prodCode)
        {
            try
            {
                var lang = Session["T_LANG"].ToString();
                var data = repository.GetProductDetails(unitNo, prodCode, lang);
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
        public ActionResult SaveData(M12309 t12309)
        {
            try
            {
                var lang = Session["T_LANG"].ToString();
                var user = Session["T_ENTRY_USER"].ToString();
                var siteCode = Session["T_SITE_CODE"].ToString();
                var data = repository.SaveData(t12309, user, siteCode);
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
        //SaveData
    }
}