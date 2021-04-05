using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Interface.Transaction;
using FastReport.Export.Pdf;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Transaction
{
    public class T12304Controller : Controller
    {
        private IT12304 repository;
        private IError err;
        public T12304Controller(IT12304 objectRepository, IError errRepo)
        {
            repository = objectRepository;
            err = errRepo;
        }

        // GET: T12304
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult reqList(string req)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                string site = Session["T_SITE_CODE"].ToString();
                var data = repository.reqList(lang, site, req);
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
        public ActionResult GetReqNoList(string req)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                string site = Session["T_SITE_CODE"].ToString();
                var data = repository.GetReqNoList(site);
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
        public ActionResult secondGrid(string reqNo)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                string site = Session["T_SITE_CODE"].ToString();
                var data = repository.Griddatalist(reqNo);
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
        public ActionResult GetIssuedbyName(string empCode)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                var data = repository.get_Issuedbyname(lang, empCode);
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
        public ActionResult insertT12304(List<t12304> t12304)
        {

            try
            {
                string lang = Session["T_LANG"].ToString();
                string site = Session["T_SITE_CODE"].ToString();
                string user = Session["T_EMP_CODE"].ToString();
                var data = repository.Insert(user, t12304, lang);
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
        //------------------------------------Report----------------------------
        public ActionResult getR12046_Report(string reqno)
        {
            string site = Session["T_SITE_CODE"].ToString();
            string lang = Session["T_LANG"].ToString();

            DataTable dt_site = repository.GetSite(site);
            DataTable dt_xMatch = repository.getR12046_xMatch(reqno, site, lang);
            DataTable dt_issue = repository.getR12046_Issue(reqno, site, lang);

            dt_site.TableName = "R12046_Site";
            dt_xMatch.TableName = "R12046";
            dt_issue.TableName = "R12046i";


            DataSet ds = new DataSet();
            ds.Tables.Add(dt_site);
            ds.Tables.Add(dt_xMatch);
            ds.Tables.Add(dt_issue);


            //ds.WriteXmlSchema(Server.MapPath("~/Report/xml/R12046.xml"));


            using (var webReport = new FastReport.Report())
            {
                webReport.Report.Load(Server.MapPath("~/Report/Report/R12046.frx"));

                webReport.Report.RegisterData(dt_site, "R12046_Site");
                webReport.Report.RegisterData(dt_xMatch, "R12046");
                webReport.Report.RegisterData(dt_issue, "R12046i");


                webReport.Report.Prepare();
                using (var Report = new MemoryStream())
                {
                    var pdfExport = new PDFExport();
                    webReport.Export(pdfExport, Report);
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Buffer = true;
                    Response.ContentType = "Application/PDF";
                    Response.BinaryWrite(Report.ToArray());
                    Response.End();
                }
                ViewBag.WebReport = webReport;
            }

            return View();
        }
    }
}