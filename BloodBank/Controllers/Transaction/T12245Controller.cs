using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Interface.Transaction;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Transaction
{
    public class T12245Controller : Controller
    {


        private IT12245 repository;
        private IError err;
        public T12245Controller(IT12245 ObjectIRepository,IError errRepo)
        {
            repository = ObjectIRepository;
            err = errRepo;
        }
        // GET: T12245
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCentrifugeList()
        {
            try
            {
                var data = repository.GetCentrifugeList(Session["T_LANG"].ToString());
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

        public ActionResult GetProgramList()
        {
            try
            {
                var data = repository.GetProgramList(Session["T_LANG"].ToString());
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
        public ActionResult GetGridDataList(string UnitNo)
        {
            try
            {
                var checkUnitNo = repository.CheckUnitNo(UnitNo);
                if (checkUnitNo.Rows.Count > 0)
                {
                    var data1 = repository.GetSegment(UnitNo);
                    string donationDate = data1.Rows[0]["T_DONATION_DATE"].ToString();
                    string segmentNo = data1.Rows[0]["T_SEGMENT_NO"].ToString();
                    var data = repository.GetGridDataList(UnitNo, donationDate, segmentNo);
                    //var data = dt;
                    string JSONString = string.Empty;
                    JSONString = JsonConvert.SerializeObject(data);
                    return Json(JSONString, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return new EmptyResult();
                }
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult SecondGetGridDataList(string UnitNo)
        {
            try
            {
                var user = Session["T_EMP_CODE"].ToString();
                var data = repository.SecondGetGridDataList(UnitNo, user);
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

        public ActionResult Insert(t12135 T12135)
        {
            try
            {
                string user = HttpContext.Session["T_EMP_CODE"].ToString();
                var data = repository.Insert(user, T12135);
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
        public ActionResult UpdateT12135(string UnitNo)
        {
            try
            {
                var data = repository.UpdateT12135(UnitNo);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteRowData(string T_UNIT_NO, string T_PRODUCT_CODE)
        {
            try
            {
                var data = repository.DeleteRowData(T_UNIT_NO, T_PRODUCT_CODE);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetMessagesList()
        {
            try
            {
                var data = repository.GetMessagesList();
                string JsonString = string.Empty;
                JsonString = JsonConvert.SerializeObject(data);
                return Json(JsonString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}

