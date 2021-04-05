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
    public class T12233Controller : Controller
    {
        private IT12233 repository;
        private IError err;
        public T12233Controller(IT12233 ObjectIRepository,IError errRepo)
        {
            repository = ObjectIRepository;
            err = errRepo;
        }
        // GET: T12233
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetGridData(string unitno)
        {
            try
            {
                var data = repository.GetGridData(unitno, Convert.ToString(Session["T_LANG"].ToString()), Convert.ToString(Session["T_LANG"].ToString()));
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
        public ActionResult GetVerifyData(string lang)
        {
            try
            {
                var data = repository.GetVerifyData(Convert.ToString(Session["T_LANG"].ToString()));
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
        public ActionResult Insert_T13016(List<t12233> t12233)
        {
            try
            {
                string user = Session["T_EMP_CODE"].ToString();
                string lang = Session["T_LANG"].ToString();
                var data = repository.Insert_T13016(t12233, user, lang);
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
    }
}