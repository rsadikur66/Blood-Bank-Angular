using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Interface.Initialization;
using BloodBankDAL.Repository.Interface.Query;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Query
{
    public class Q12012Controller : Controller
    {
        private IQ12012 repository;
        private IError err;
        // GET: Q12012
        public Q12012Controller(IQ12012 ObjectIRepository,IError errRepo)
        {
            repository = ObjectIRepository;
            err = errRepo;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult getAllXMatchData(string req)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                string site = Session["T_SITE_CODE"].ToString();
                var data = repository.getAllXMatchData(lang, site, req);
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