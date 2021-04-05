using BloodBankDAL.Repository.Interface.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers.Query
{
    public class Q12263Controller : Controller
    {
        private IQ12263 repository;
       
        public Q12263Controller(IQ12263 ObjectIRepository)
        {
            repository = ObjectIRepository;
           
        }
        // GET: Q12263
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetGridData()
        {
            try
            {
                string l = Session["T_LANG"].ToString();
                 string siteCode = Session["T_SITE_CODE"].ToString();
                var referCode = Session["T_REFERRAL_CODE"].ToString();
                var data = repository.GetGridData(siteCode, referCode);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}