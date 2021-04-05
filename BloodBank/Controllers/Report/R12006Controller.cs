using BloodBankDAL.Repository.Interface.Report;
using FastReport.Export.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Report
{
    public class R12006Controller : Controller
    {
        private IR12006 repository;

        public R12006Controller(IR12006 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }

        // GET: R12006
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getR12006_Report(string patNo)
        {
            //string lang = Session["T_LANG"].ToString();
            //DataTable dt = repository.getReport(lang, nationalId);
            //dt.TableName = "R12006";

            string site = Session["T_SITE_CODE"].ToString();
            string lang = Session["T_LANG"].ToString();
            DataTable dt = repository.getReport(lang, patNo);
            DataTable dtSite = repository.GetR12006Site(site);
            DataTable dtProfile = repository.GetR12006PatProfile(lang, patNo);

            DataTable dtAgreement = repository.GetR12006Agreement(lang, patNo);
            //DataTable dtConfirmation = repository.GetR12006Confirmation(lang);


            dt.TableName = "R12006_Ques";
            dtSite.TableName = "R12006_Site";
            dtProfile.TableName = "R12006_Profile";
            dtAgreement.TableName = "R12006_Agreement";
            //dtConfirmation.TableName = "R12006_Confirmation";

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            ds.Tables.Add(dtSite);
            ds.Tables.Add(dtProfile);
            ds.Tables.Add(dtAgreement);
            //ds.Tables.Add(dtConfirmation);

            //ds.WriteXmlSchema(Server.MapPath("~/Report/xml/R12251A.xml"));


            using (var webReport = new FastReport.Report())
            {
                webReport.Report.Load(Server.MapPath("~/Report/Report/R12251A.frx"));

                webReport.Report.RegisterData(dtSite, "R12006_Site");
                webReport.Report.RegisterData(dt, "R12006_Ques");
                webReport.Report.RegisterData(dtProfile, "R12006_Profile");
                webReport.Report.RegisterData(dtAgreement, "R12006_Agreement");
                //webReport.Report.RegisterData(dtConfirmation, "R12006_Confirmation");


                webReport.Report.Prepare();
                using (var report = new MemoryStream())
                {
                    var pdfExport = new PDFExport();
                    webReport.Export(pdfExport, report);
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Buffer = true;
                    Response.ContentType = "Application/PDF";
                    Response.BinaryWrite(report.ToArray());
                    Response.End();
                }
                ViewBag.WebReport = webReport;
            }

            return View();
        }

        /* R12215 Report By Pervez */


        public ActionResult GetR12215Report(string entryDate)
        {
            int site = Convert.ToInt32(Session["T_SITE_CODE"].ToString());
            string lang = Session["T_LANG"].ToString();

            DataTable dtSite = repository.GetR12215SiteCode(site, lang);
            DataTable dtSummery = repository.GetR12215Summery(entryDate, site, entryDate);
            DataTable dtUnitInfo = repository.GetR12215CollectedUnit(site, entryDate);

            dtSite.TableName = "R12215Site";
            dtSummery.TableName = "R12215Summery";
            dtUnitInfo.TableName = "R12215UnitInfo";

            DataSet dSet = new DataSet();
            dSet.Tables.Add(dtSite);
            dSet.Tables.Add(dtSummery);
            dSet.Tables.Add(dtUnitInfo);


            //dSet.WriteXmlSchema(Server.MapPath("~/Report/xml/R12215.xml"));


            using (var webReport = new FastReport.Report())
            {
                webReport.Report.Load(Server.MapPath("~/Report/Report/R12215A.frx"));

                webReport.RegisterData(dtSite, "R12215Site");
                webReport.RegisterData(dtSummery, "R12215Summery");
                webReport.RegisterData(dtUnitInfo, "R12215UnitInfo");

                webReport.Report.Prepare();

                using (var report = new MemoryStream())
                {
                    var pdfExport = new PDFExport();
                    webReport.Export(pdfExport, report);

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Buffer = true;
                    Response.ContentType = "Application/PDF";
                    Response.BinaryWrite(report.ToArray());
                    Response.End();
                }

                ViewBag.ReportR12215 = webReport;
            }

            return View();
        }

        /* R12215 Report By Pervez */



        //start code by sadik

        public ActionResult GetTechList()
        {
            var siteCode = Session["T_SITE_CODE"].ToString();
            var lang = Session["T_LANG"].ToString();
            var data = repository.GetTechList(siteCode);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetReasonList()
        {
            var siteCode = Session["T_SITE_CODE"].ToString();
            var lang = Session["T_LANG"].ToString();
            var data = repository.GetReasonList(lang);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult getCollector(string fdate)
        {
            var siteCode = Session["T_SITE_CODE"].ToString();
            var lang = Session["T_LANG"].ToString();
            var data = repository.getCollector(lang, fdate);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult getCollection(string fdate)
        {
            var siteCode = Session["T_SITE_CODE"].ToString();
            var lang = Session["T_LANG"].ToString();
            var data = repository.getCollection(lang, fdate);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult getCountTime(string fdate)
        {
            var siteCode = Session["T_SITE_CODE"].ToString();
            var lang = Session["T_LANG"].ToString();
            var data = repository.getCountTime(lang, fdate);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult getInfoData()
        {
            int site = Convert.ToInt32(Session["T_SITE_CODE"].ToString());
            var lang = Session["T_LANG"].ToString();
            var data = repository.GetR12215SiteCode(site, lang);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetR12215Summery(string date)
        {
            int site = Convert.ToInt32(Session["T_SITE_CODE"].ToString());
            var lang = Session["T_LANG"].ToString();
            var data = repository.GetR12215Summery(date, site, date);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        //repository.GetR12215Summery(entryDate, site, entryDate);

    }
}