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
    public class T12332Controller : Controller
    {
        private IT12332 repository;

        public T12332Controller(IT12332 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        // GET: T12332
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetGridData(string unittype, string english, string local, string bag)
        {
            var data = this.repository.GetGridData(unittype,english,local,bag);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Insert_T12332(t12073 t12073)
        {
            var user = Session["T_EMP_CODE"].ToString();
            var data = repository.Insert_T12332(t12073, user);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
    }
}