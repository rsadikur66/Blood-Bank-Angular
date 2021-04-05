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
    public class T01004Controller : Controller
    {
        private IT01004 repository;
        public T01004Controller(IT01004 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetGridData()
        {
            var data = repository.GetGridData();
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(data);
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        public ActionResult insertData(M01004 tm01004)
        {
            string user = HttpContext.Session["T_EMP_CODE"].ToString();
            var data = repository.insertData(tm01004,user);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
    }
}