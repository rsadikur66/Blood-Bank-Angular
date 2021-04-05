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
    public class T12087Controller : Controller
    {

        private IT12087 repository;
        public T12087Controller(IT12087 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        // GET: T12087
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetGridData()
        {
            var data = repository.GetGridData();
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult GetGridDataChild(string viralCode)
        {
            var data = repository.GetGridDataChild(viralCode, Convert.ToString(Session["T_LANG"].ToString()));
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update_T12087(List<t12087> t12087, List<M12087> M12087)
        {
            var user = Session["T_EMP_CODE"].ToString();
            var data = repository.Update_T12087(t12087, M12087, user, Convert.ToString(Session["T_LANG"].ToString()));
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
    }
}