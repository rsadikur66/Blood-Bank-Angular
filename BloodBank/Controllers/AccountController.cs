using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BloodBankDAL.Repository;
using BloodBankDAL.Repository.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BloodBank.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        private readonly ILogin repository;
        private IError err;
        CommonDAL _cDal = new CommonDAL();
        public AccountController(ILogin objectRepository, IError errRepo)
        {
            repository = objectRepository;
            err = errRepo;
            //------------------------------------------------------
            //string date = DateTime.Today.ToString("ddMMyyyy");
            //var Files = new DirectoryInfo(@"C:\BloodBankLog").GetFiles(date+".log");
            //if (Files.Length==0)
            //{
            // System.IO.File.WriteAllText(Path.Combine(@"C:\BloodBankLog", date+".log"), "");
            //}


        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetLabelText(string formcode, string language)
        {
            try
            {
                var labelData = repository.GetLabelText(formcode == null ? "MM1212" : formcode, language == null ? "2" : language);
                string JSONstring = string.Empty;
                JSONstring = JsonConvert.SerializeObject(labelData);
                string lang = language != "" ? language : "2";
                Session["T_LANG"] = language == null ? "2" : language;
                Session["FORM_CODE"] = formcode == null ? "MM1212" : formcode;
                return Json(JSONstring, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["action"].ToString(), Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult CheckLogin(string loginName, string password)
        {
            try
            {
                var CheckLoginData = repository.CheckLogin(loginName.ToUpper(), password.ToUpper());
                string JSONstring = string.Empty;
                JSONstring = JsonConvert.SerializeObject(CheckLoginData);
                JArray obj = JArray.Parse(JSONstring);
                if (CheckLoginData.Rows.Count > 0)
                {
                    Session["T_USER_NAME"] = obj[0]["T_USER_NAME"].ToString();
                    Session["T_USER_NAME2"] = obj[0]["T_USER_NAME2"].ToString();
                    Session["T_ROLE_CODE"] = obj[0]["T_ROLE_CODE"].ToString();
                    Session["T_ENTRY_USER"] = obj[0]["T_ENTRY_USER"].ToString();
                    Session["T_UPD_USER"] = obj[0]["T_UPD_USER"].ToString();
                    Session["T_EMP_CODE"] = obj[0]["T_EMP_CODE"].ToString();
                    Session["T_LOGIN_NAME"] = obj[0]["T_LOGIN_NAME"].ToString();
                    Session["T_SITE_CODE"] = obj[0]["T_SITE_CODE"].ToString();
                    Session["T_REFERRAL_CODE"] = obj[0]["T_REFERRAL_CODE"].ToString();
                    string sitecode = Session["T_SITE_CODE"].ToString();
                }
                return Json(JSONstring, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["action"].ToString(), Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public JsonResult EntryUser()
        {
            try
            {
                var EntryUser = Session["T_ENTRY_USER"].ToString();
                return Json(EntryUser, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exc)
            {
                return Json(exc.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult setClientErrorLog(string controller, string action, string message, string source)
        {
            try
            {
                var msg = _cDal.setClientErrorLog(controller, action, message, Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), source);
                string JSONstring = JsonConvert.SerializeObject(msg);
                return Json(JSONstring, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["action"].ToString(), Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult logT92(string userId)
        {
            try
            {
                var CheckLoginData = repository.logT92(userId);
                string JSONstring = string.Empty;
                JSONstring = JsonConvert.SerializeObject(CheckLoginData);
                JArray obj = JArray.Parse(JSONstring);

                return Json(JSONstring, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["action"].ToString(), Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

    }
}