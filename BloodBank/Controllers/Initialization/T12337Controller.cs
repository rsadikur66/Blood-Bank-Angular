using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL;
using BloodBankDAL.Repository.Interface.Initialization;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Initialization
{
    public class T12337Controller : Controller
    {
        private IT12337 repository;

        public T12337Controller(IT12337 _repository)
        {
            repository = _repository;
        }
        // GET: T12337
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetZoneList()
        {
            var lang = HttpContext.Session["T_LANG"].ToString();
            var data = repository.GetZoneList(lang);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSiteList()
        {
            var lang = HttpContext.Session["T_LANG"].ToString();
            var data = repository.GetSiteList(lang);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetGridListData()
        {
            var lang = HttpContext.Session["T_LANG"].ToString();
            var data = repository.GetGridListData();
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult GetHospitalListByBankType(string typeCode)
        //{
        //    var lang = HttpContext.Session["T_LANG"].ToString();
        //    var data = repository.GetHospitalList(typeCode);
        //    string JSONString = string.Empty;
        //    JSONString = JsonConvert.SerializeObject(data);
        //    return Json(JSONString, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult GetBankTypeList()
        {
            var lang = HttpContext.Session["T_LANG"].ToString();
            var data = repository.GetBankTypeList(lang);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertToT12337(M12337 t12337)
        {
            string user = HttpContext.Session["T_EMP_CODE"].ToString();
            string siteCode = HttpContext.Session["T_SITE_CODE"].ToString();
            var data = repository.InsertToT12337(t12337,user,siteCode);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult UpdateToT12337(M12337 t12337)
        //{
        //    string user = HttpContext.Session["T_EMP_CODE"].ToString();
        //    string siteCode = HttpContext.Session["T_SITE_CODE"].ToString();
        //    var data = repository.UpdateToT12337(t12337, user, siteCode);
        //    string JSONString = string.Empty;
        //    JSONString = JsonConvert.SerializeObject(data);
        //    return Json(JSONString, JsonRequestBehavior.AllowGet);
        //}
    }
}