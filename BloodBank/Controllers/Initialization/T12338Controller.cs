using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface.Initialization;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Initialization
{
    public class T12338Controller : Controller
    {
        private IT12338 repository;

        public T12338Controller(IT12338 _repository)
        {
            repository = _repository;
        }
        // GET: T12338
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCentralBankList()
        {
            var lang = HttpContext.Session["T_LANG"].ToString();
            var data = repository.GetCentralBankList(lang);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTransfusionsList(string bankCode)
        {
            var data = repository.GetTransfusionsList(bankCode);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertToT12338(M12338 t12338)
        {
            string user = HttpContext.Session["T_EMP_CODE"].ToString();
            string siteCode = HttpContext.Session["T_SITE_CODE"].ToString();
            var data = repository.InsertToT12338(t12338, user);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }


    }
}