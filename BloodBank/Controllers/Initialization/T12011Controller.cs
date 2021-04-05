using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Implementation.Initialization;
using BloodBankDAL.Repository.Interface.Initialization;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Initialization
{
    public class T12011Controller : Controller
    {
        private IT12011 repository;

        public T12011Controller(IT12011 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        // GET: T12011
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetGridData()
        {
            var data = this.repository.GetGridData(Convert.ToString(Session["T_LANG"].ToString()));
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Insert_T12011(t12011 t12011)
        {
            var user = Session["T_EMP_CODE"].ToString();
            var data = repository.Insert_T12011(t12011, user);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

    }
}