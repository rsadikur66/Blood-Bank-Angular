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
    public class T12281Controller : Controller
    {
        // GET: T12281 
        private IT12281 repository;
        public T12281Controller(IT12281 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetAllData()
        {
            var data = repository.GetAllData(Session["T_LANG"].ToString());
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetAllUnitData()
        {
            var data = repository.GetAllUnitData(Session["T_LANG"].ToString());
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveData(M12281 t12281)
        {
            var lang = Session["T_LANG"].ToString();
            var user = Session["T_EMP_CODE"].ToString();
            var data = repository.SaveData(t12281, lang, user);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        //SaveData
    }
}