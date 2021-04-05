using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL;
using BloodBankDAL.Repository.Interface.Initialization;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Initialization
{
    public class T12132Controller : Controller
    {
        private IT12132 repository;
        public T12132Controller(IT12132 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetGridData()
        {
            var data = this.repository.GetGridData();
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetAllFormCodeData()
        {
            var data = repository.GetAllFormCodeData();
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveData(M12132 t12132)
        {
            var lang = Session["T_LANG"].ToString();
            var user = Session["T_EMP_CODE"].ToString();
            var data = repository.SaveData(t12132, lang, user);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
    }
}