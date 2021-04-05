using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface;
using GenCode128;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Transaction
{
    public class T12244Controller : Controller
    {
        private IT12244 repository;
        private IError err;
        public T12244Controller(IT12244 ObjectIRepository,IError errRepo)
        {
            repository = ObjectIRepository;
            err = errRepo;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult getPatNo(string P_PAT_NO)
        {
            try
            {
                string site = Session["T_SITE_CODE"].ToString();
                var data = repository.getPatNo(P_PAT_NO, site);
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
        [HttpPost]
        public ActionResult getQuestions(int type, string P_SEX, string P_PAT_NO)
        {
            try
            {
                var data = repository.getQuestions(type, P_SEX, P_PAT_NO);
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
        [HttpPost]
        public ActionResult getConsent(int type)
        {
            try
            {
                var data = repository.getConsent(type);
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
        [HttpPost]
        public ActionResult insert(CommonModel t12017)
        {
            try
            {
                t12017.T_ENTRY_USER = Session["T_EMP_CODE"].ToString();
                var data = repository.insert(t12017);
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
        [HttpPost]
        public ActionResult singleInsert(CommonModel t71)
        {
            try
            {
                t71.T_ENTRY_USER = Session["T_EMP_CODE"].ToString();
                var data = repository.singleInsert(t71);
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
        [HttpPost]
        public ActionResult testPrint()
        {
            try
            {
                using (MemoryStream m = new MemoryStream())
                {
                    Image myimg = Code128Rendering.MakeBarcodeImage("National Id: 00033118", int.Parse("2"), true);
                    myimg.Save(m, ImageFormat.Png);
                    byte[] imageBytes = m.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);
                    string JSONString = string.Empty;
                    JSONString = JsonConvert.SerializeObject(base64String);
                    return Json(JSONString, JsonRequestBehavior.AllowGet);

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
    }
}