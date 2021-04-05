using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Interface.Query;
using BloodBankDAL.Repository.Interface.Transaction;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Query
{
    public class Q12207Controller : Controller
    {
        // GET: Q12207
        private IQ12207 repository;
        private IError err;
        public Q12207Controller(IQ12207 ObjectIRepository, IError errRepo)
        {
            repository = ObjectIRepository;
            err = errRepo;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetGridData()
        {
            try
            {
                var data = repository.GetGridData();
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        //[HttpPost]
        //public ActionResult GetBloodGroupData()
        //{
        //    try
        //    {
        //        var data = repository.GetBloodGroupData(Session["T_LANG"].ToString());
        //        string JSONString = string.Empty;
        //        JSONString = JsonConvert.SerializeObject(data);
        //        return Json(JSONString, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception e)
        //    {
        //        err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
        //            ControllerContext.RouteData.Values["action"].ToString(),
        //            Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
        //        return Json(e.Message, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //[HttpPost]
        //public ActionResult GetProductData()
        //{
        //    try
        //    {
        //        var data = repository.GetProductData(Session["T_LANG"].ToString());
        //        string JSONString = string.Empty;
        //        JSONString = JsonConvert.SerializeObject(data);
        //        return Json(JSONString, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception e)
        //    {
        //        err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
        //            ControllerContext.RouteData.Values["action"].ToString(),
        //            Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
        //        return Json(e.Message, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //[HttpPost]
        //public ActionResult GetStocktData(string donTiFrom, string donTiTo, string siteCode, string bloodGrp, string product)
        //{
        //    try
        //    {
        //        var data = repository.GetStocktData(Session["T_LANG"].ToString(), donTiFrom, donTiTo, siteCode, bloodGrp, product);
        //        string JSONString = string.Empty;
        //        JSONString = JsonConvert.SerializeObject(data);
        //        return Json(JSONString, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception e)
        //    {
        //        err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
        //            ControllerContext.RouteData.Values["action"].ToString(),
        //            Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
        //        return Json(e.Message, JsonRequestBehavior.AllowGet);
        //    }
        //}
        ////GetStocktData
    }
}