using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Interface.Transaction;
using GenCode128;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Transaction
{
    public class T12202Controller : Controller
    {
        PrintDocument printDoc;
        private IT12202 repository;
        private IError err;
        public T12202Controller(IT12202 ObjectIRepository,IError errRepo)
        {
            repository = ObjectIRepository;
            err = errRepo;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult getPatDetail(string P_PAT_NO, string P_NTNLTY_ID)
        {
            try
            {
                string l = Session["T_LANG"].ToString();
                string site = Session["T_SITE_CODE"].ToString();
                var data = repository.getPatDetail(P_PAT_NO, P_NTNLTY_ID, l, site);
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
        public ActionResult GetUnitData(string unitNo)
        {
            try
            {
                string l = Session["T_LANG"].ToString();
                string site = Session["T_SITE_CODE"].ToString();
                var data = repository.GetUnitData(unitNo);
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
        public ActionResult getQues(string P_PAT_NO,string P_NTNLTY_ID, int P_REQUEST_ID, string P_SEX)
        {
            try
            {
                string l = Session["T_LANG"].ToString();
                var data = repository.getQues(P_PAT_NO, P_NTNLTY_ID, P_REQUEST_ID, l, P_SEX);
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
        public ActionResult getValidation(string P_VITAL_CODE, decimal Value)
        {
            try
            {
                string l = Session["T_LANG"].ToString();
                var data = repository.getValidation(P_VITAL_CODE, Value, l);
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
         public ActionResult insert(T12022 t12022, string t)
         {
            try
            {
                string u = Session["T_EMP_CODE"].ToString();
                var data = repository.insert(t12022, t, u);
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
        public ActionResult singleInsert(T12071 t71)
        {
            try
            {
                t71.T_ENTRY_USER = Session["T_EMP_CODE"].ToString();
                t71.T_ENTRY_TIME = DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes.ToString();
                t71.T_UPD_USER = Session["T_EMP_CODE"].ToString();
                var data = repository.singleInsert(t71);
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