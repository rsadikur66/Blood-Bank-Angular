using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Interface.Query;
using BloodBankDAL.Repository.Interface.Report;
using FastReport.Export.Pdf;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Query
{
    public class Q12200Controller : Controller
    {
        private IQ12200 repository;
        private IError err;
        private IR12006 repository_R12215;

        public Q12200Controller(IQ12200 objectRepository,IError errRepo, IR12006 r12215Reporsitory)
        {
            repository = objectRepository;
            err = errRepo;
            repository_R12215 = r12215Reporsitory;
        }
        // GET: Q12200
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetGridData(string dateParam)
        {
            try
            {
                var data = repository.GetGridData(dateParam);
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

        public ActionResult TAT_Report_R12219(string dateFrom)
        {
            //string lang = Session["T_LANG"].ToString();
            //dt.TableName = "R12006";

            string site = Session["T_SITE_CODE"].ToString();
            string lang = Session["T_LANG"].ToString();
            //DataTable dt = repository.getReport(lang, patNo);
            DataTable dtReportInfo = repository.GetReportInfo();
            DataTable dtReportData = repository.GetReportData();
            
            dtReportInfo.TableName = "Table1";
            dtReportData.TableName = "Table2";            

            DataSet ds = new DataSet();
            ds.DataSetName = "R12219";
            ds.Tables.Add(dtReportInfo);
            ds.Tables.Add(dtReportData);
            

            //ds.WriteXmlSchema(Server.MapPath("~/Report/xml/R12219.xml"));


            using (var webReport = new FastReport.Report())
            {
                webReport.Report.Load(Server.MapPath("~/Report/Report/R12219.frx"));

                webReport.Report.RegisterData(dtReportInfo, "Table1");
                webReport.Report.RegisterData(dtReportData, "Table2");              


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
        public ActionResult UNIT_Report_R12219(string entryDate)
        {
            int site = Convert.ToInt32(Session["T_SITE_CODE"].ToString());
            string lang = Session["T_LANG"].ToString();

            DataTable dtSite = repository_R12215.GetR12215SiteCode(site, lang);
            DataTable dtSummery = repository_R12215.GetR12215Summery(entryDate, site, entryDate);
            DataTable dtUnitInfo = repository_R12215.GetR12215CollectedUnit(site, entryDate);

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
                webReport.Report.Load(Server.MapPath("~/Report/Report/R12215.frx"));

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

        public ActionResult GRAPH_Report_R12219(string dateFrom)
        {
            //string lang = Session["T_LANG"].ToString();
            //DataTable dt = repository.getReport(lang, nationalId);
            //dt.TableName = "R12006";

            string site = Session["T_SITE_CODE"].ToString();
            string lang = Session["T_LANG"].ToString();
            //DataTable dt = repository.getReport(lang, patNo);
            //DataTable dtSite = repository.GetR12006Site(site);
            //DataTable dtProfile = repository.GetR12006PatProfile(lang, patNo);

            //DataTable dtAgreement = repository.GetR12006Agreement(lang, patNo);
            //DataTable dtConfirmation = repository.GetR12006Confirmation(lang);


            //dt.TableName = "R12006_Ques";
            //dtSite.TableName = "R12006_Site";
            //dtProfile.TableName = "R12006_Profile";
            //dtAgreement.TableName = "R12006_Agreement";
            ////dtConfirmation.TableName = "R12006_Confirmation";

            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            //ds.Tables.Add(dtSite);
            //ds.Tables.Add(dtProfile);
            //ds.Tables.Add(dtAgreement);
            ////ds.Tables.Add(dtConfirmation);

            ////ds.WriteXmlSchema(Server.MapPath("~/Report/xml/R12251A.xml"));


            using (var webReport = new FastReport.Report())
            {
                webReport.Report.Load(Server.MapPath("~/Report/Report/R12219.frx"));

                //webReport.Report.RegisterData(dtSite, "R12006_Site");
                //webReport.Report.RegisterData(dt, "R12006_Ques");
                //webReport.Report.RegisterData(dtProfile, "R12006_Profile");
                //webReport.Report.RegisterData(dtAgreement, "R12006_Agreement");
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

    }
}