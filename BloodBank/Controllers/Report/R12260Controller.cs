using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface.Report;
using FastReport.Export.Pdf;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Report
{
    public class R12260Controller : Controller
    {
        private IR12260 repository;

        public R12260Controller(IR12260 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        // GET: R12260
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult getDate(string f, string t)
        {
            var site = Session["T_SITE_CODE"].ToString();
            var lang = Session["T_LANG"].ToString();
            var data = repository.getDate(site, f, t);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult showReport(string f, string t)
        {
            var site = Session["T_SITE_CODE"].ToString();
            var lang = Session["T_LANG"].ToString();
            var data = repository.showReport(site, f, t);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult getTimeData(string f, string t)
        {
            var site = Session["T_SITE_CODE"].ToString();
            var lang = Session["T_LANG"].ToString();
            var data = repository.getTimeData(site, f, t);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult getInfoData()
        {
            var site = Session["T_SITE_CODE"].ToString();
            var lang = Session["T_LANG"].ToString();
            var data = repository.GetInforData(site, lang);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }
        //getDate
        public ActionResult getReport(string fromDate,string toDate)
        {
            var site = Session["T_SITE_CODE"].ToString();
            string lang = Session["T_LANG"].ToString();

            DataTable dtInfor = repository.GetInforData(site, lang);
            DataTable dtDetails = repository.GetDetails(site, fromDate,  toDate);
            //DataTable dtUnitInfo = repository.GetR12215CollectedUnit(site, entryDate);

            dtInfor.TableName = "R12260Infor";
            dtDetails.TableName = "R12260Details";
           // dtUnitInfo.TableName = "R12215UnitInfo";

            DataSet dSet = new DataSet();
            dSet.Tables.Add(dtInfor);
            dSet.Tables.Add(dtDetails);
            // dSet.Tables.Add(dtUnitInfo);


           // dSet.WriteXmlSchema(Server.MapPath("~/Report/xml/R12260.xml"));

           // return View();
            using (var webReport = new FastReport.Report())
            {
                webReport.Report.Load(Server.MapPath("~/Report/Report/R12260.frx"));
                //webReport.Report.Load(Server.MapPath("~/Report/Report/R12260_Test.frx"));
                webReport.RegisterData(dtInfor, "R12260Infor");
                webReport.RegisterData(dtDetails, "R12260Details");
                webReport.Report.SetParameterValue("FromDate", fromDate);
                webReport.Report.SetParameterValue("ToDate", toDate);
               // webReport.RegisterData(dtUnitInfo, "R12215UnitInfo");

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
    }
}