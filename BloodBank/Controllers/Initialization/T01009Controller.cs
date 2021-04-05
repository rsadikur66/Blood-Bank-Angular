using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface.Initialization;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Initialization
{
    public class T01009Controller : Controller
    {
        private IT01009 repository;
        public T01009Controller(IT01009 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        // GET: T01009
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult GetAllUserData()
        {
            string siteCode = HttpContext.Session["T_SITE_CODE"].ToString();
            var data = repository.GetAllUserData(siteCode);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            var jsonResult = Json(JSONString, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}