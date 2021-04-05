using BloodBank.Models;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Interface.Menu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers.Menu
{
    public class MenuController : Controller
    {
        private IMenu repository;
        private IError err;

        public MenuController(IMenu ObjectIRepository, IError errRepo)
        {
            repository = ObjectIRepository;
            err = errRepo;
        }
        // GET: Menu
        //[AuthorizeUserAccessLevel(UserRole = "Index")]
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string)) {
                 dt = repository.FormAuthorization("Index", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());           
            }
            
            if (dt.Rows.Count > 0)
            {
                return View();
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "Account");
            }
        }

        [HttpPost]
        public JsonResult FormAuthorization(string T_FORM_TYPE_ID)
        {
            var formAuthorization = repository.FormAuthorization("MEDISYS", T_FORM_TYPE_ID, "0001");
            string JSONstring = string.Empty;
            JSONstring = JsonConvert.SerializeObject(formAuthorization);
            return Json(JSONstring, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetMenuData(string T_LINK_SEPERATION)
        {
            string language;
            string roleCode="";
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
               roleCode = Session["T_ROLE_CODE"].ToString();
            }
               
            if (string.IsNullOrEmpty(Session["T_LANG"] as string))
            {
              language = "2";
            }
            else
            {
                 language = Session["T_LANG"].ToString();
            }
            var menuData = repository.MenuData(language, T_LINK_SEPERATION, roleCode);
            string JSONstring = string.Empty;
            JSONstring = JsonConvert.SerializeObject(menuData);
            LangName();
            return Json(JSONstring, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult LangName()
        {
            string langName = "";
            if (!string.IsNullOrEmpty(Session["T_LANG"] as string))
            {
                langName = Session["T_LANG"].ToString();
            }
            else
            {
                langName = "Session Out";
            }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(langName);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EmpCode()
        {
            string empCode = "";
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string))
            {
                empCode = Session["T_EMP_CODE"].ToString();
            }
            else
            {
                empCode = "Session Out";
            }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(empCode);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UserName()
        {
            string language = "";
            if (!string.IsNullOrEmpty(Session["T_LANG"] as string))
            {
                language = System.Web.HttpContext.Current.Session["T_LANG"].ToString();
            }
            
            string userName = "";
            if (language == "1")
            {
               
                if (!string.IsNullOrEmpty(Session["T_USER_NAME2"] as string))
                {
                    userName = Session["T_USER_NAME2"].ToString();
                }
                else
                {
                    userName = "Session Out";
                }
            }
            else 
            {
               
                if (!string.IsNullOrEmpty(Session["T_USER_NAME"] as string))
                {
                    userName = Session["T_USER_NAME"].ToString();
                }
                else
                {
                    userName = "Session Out";
                }
            }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(userName);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UserLogout()
        {
            var emp = Session["T_EMP_CODE"].ToString();
            var msg = repository.LogoutT92(emp);
            //repository.Logout();
            Session.Clear();
            return Json(JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetAllUserMsg()
        {
            var msg=repository.GetAllUserMsg(Session["T_LANG"].ToString());
            string JSONstring = JsonConvert.SerializeObject(msg);
            return Json(JSONstring, JsonRequestBehavior.AllowGet);
        }
        public string getServerName()
        {
            var msg = repository.getServerName();
            //string JSONstring = JsonConvert.SerializeObject(msg);
            //return Json(JSONstring, JsonRequestBehavior.AllowGet);
            return msg;
        }
        [HttpPost]
        public JsonResult updateForm(string form)
        {
            try
            {
                var msg = repository.updateForm(Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), form);
                string JSONstring = JsonConvert.SerializeObject(msg);
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