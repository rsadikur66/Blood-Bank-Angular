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
    public class T12246Controller : Controller
    {
        private IT12246 repository;

        public T12246Controller(IT12246 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        // GET: T12246
        public ActionResult Index()
        {
            return View();
        }

        //For Blood Group Data
        [HttpPost]
        public ActionResult GetBloodData()
        {
            var data = this.repository.GetBloodData(Convert.ToString(Session["T_LANG"].ToString()));
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        //For Product Data
        [HttpPost]
        public ActionResult GetProductData()
        {
            var data = this.repository.GetProductData(Convert.ToString(Session["T_LANG"].ToString()));
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetGridData(string productCode, string bloodGroup)
        {
            var data = this.repository.GetGridData(Convert.ToString(Session["T_LANG"].ToString()), productCode,bloodGroup);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Insert_T12211(List<t12246> t12246,string p, string b)
        {
            var user = Session["T_EMP_CODE"].ToString();
            var data = repository.Insert_T12211(t12246,p,b,user);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
    }
}