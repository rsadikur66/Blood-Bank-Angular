using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Interface.Query;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Query
{
    public class Q12017Controller : Controller
    {
        private IQ12017 repository;
        private IError err;
        public Q12017Controller(IQ12017 ObjectIRepository, IError errRepo)
        {
            repository = ObjectIRepository;
            err = errRepo;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetAllData(string REQUEST_NO)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                var data = repository.GetAllData(REQUEST_NO, lang);
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