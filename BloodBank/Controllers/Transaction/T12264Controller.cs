using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Interface.Transaction;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Transaction
{
    public class T12264Controller : Controller
    {
        private IT12264 repository;
        private IError err;

        public T12264Controller(IT12264 _repository)
        {
            repository = _repository;

        }   
        // GET: T12264
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDataWithRequestNo(string T_REQ_NO)
        {
            try
            {
                
                var userName = HttpContext.Session["T_USER_NAME"].ToString();
                string empCode = HttpContext.Session["T_EMP_CODE"].ToString();
                //string siteCode = HttpContext.Session["T_SITE_CODE"].ToString();
                string siteCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                //string zoneCode = HttpContext.Session["ZONE_CODE"].ToString();
                var lang = HttpContext.Session["T_LANG"].ToString();
                var data = repository.GetDataWithRequestNo(T_REQ_NO, siteCode,empCode, userName);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult T12264updateT12067andT12065(M12264 t12264)
        {
            try
            {
                string user = HttpContext.Session["T_EMP_CODE"].ToString();
                //string siteCode = HttpContext.Session["T_SITE_CODE"].ToString();
                string siteCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var data = repository.T12264updateT12067andT12065(t12264, user, siteCode);
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