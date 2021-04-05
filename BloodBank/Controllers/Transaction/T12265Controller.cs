using BloodBankDAL.Repository.Interface.Transaction;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers.Transaction
{
    public class T12265Controller : Controller
    {
        private IT12265 repository;
        public T12265Controller(IT12265 _repository)
        {
            repository = _repository;
        }
        // GET: T12265
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRequestListData()
        {
            try
            {
                string empCode = HttpContext.Session["T_EMP_CODE"].ToString();
                var data = repository.GetRequestListData(empCode);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetHandOverDataFromCenter()
        {
            try
            {
                string empCode = HttpContext.Session["T_EMP_CODE"].ToString();
                var data = repository.GetHandOverDataFromCenter(empCode);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetLocationDeliveryMan(string bldReqNo)
        {
            try
            {
                string empCode = HttpContext.Session["T_EMP_CODE"].ToString();
                var data = repository.GetLocationDeliveryMan(bldReqNo);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetAllDeliveryManLocation(string bldReqNo)
        {
            try
            {
                string empCode = HttpContext.Session["T_EMP_CODE"].ToString();
                var data = repository.GetAllDeliveryManLocation(bldReqNo);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult updateT12091(string acpt, string reqId)
        {
            try
            {
                string user = HttpContext.Session["T_EMP_CODE"].ToString();
                string siteCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var data = repository.updateT12091(acpt, reqId, user);
                var JSONString = String.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult updateT12091ForReceived(string reqNo )
        {
            try
            {
                string user = HttpContext.Session["T_EMP_CODE"].ToString();
                string siteCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var data = repository.updateT12091ForReceived(reqNo, user);
                var JSONString = String.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult updateT91T92ForDrop(string reqNo)
        {
            try
            {
                string user = HttpContext.Session["T_EMP_CODE"].ToString();
                string siteCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var data = repository.updateT91T92ForDrop(reqNo, user);
                var JSONString = String.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult insertT91(string reqId,string reqNo, string devMan, string estDelDis, string estDelTime,string siteCode,string canReason)
        {
            try
            {
                string entryuser = HttpContext.Session["T_EMP_CODE"].ToString();
                //string siteCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var data = repository.insertT91(reqId,reqNo, devMan, estDelDis, estDelTime,entryuser,siteCode,canReason);
                var JSONString = String.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult updT65unassign(string reqId,string reqNo, string siteCode)
        {
            try
            {
                string empCode = HttpContext.Session["T_EMP_CODE"].ToString();
                //string siteCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var data = repository.updT65unassign(reqId,reqNo, siteCode,empCode);
                var JSONString = String.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult UpdateActiveStatus()
        {
            try
            {
                string entryuser = HttpContext.Session["T_EMP_CODE"].ToString();
                //string siteCode = HttpContext.Session["T_REFERRAL_CODE"].ToString();
                var data = repository.UpdateActiveStatus(entryuser);
                var JSONString = String.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

    }
}