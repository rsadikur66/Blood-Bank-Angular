using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface.Report;
using FastReport.Export.Pdf;

namespace BloodBank.Controllers.Report
{
    public class R12304Controller : Controller
    {
        private IR12304 _repository;

        public R12304Controller(IR12304 objectIRepository)
        {
            _repository = objectIRepository;
        }

        // GET: R12046
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getR12046_Report(string reqno)
        {
            string site = Session["T_SITE_CODE"].ToString();
            string lang = Session["T_LANG"].ToString();
            DataTable dt = _repository.getR12046_Report(reqno, site, lang);
            DataTable dtSite = _repository.GetSite(site);

            dt.TableName = "R12046";
            dtSite.TableName = "R12046_Site";

            DataSet ds=new DataSet();
            ds.Tables.Add(dt);
            ds.Tables.Add(dtSite);

            //ds.WriteXmlSchema(Server.MapPath("~/Report/xml/R12046.xml"));

            using (var webReport=new FastReport.Report())
            {
                webReport.Report.Load(Server.MapPath("~/Report/Report/R12046.frx"));

                webReport.Report.RegisterData(dt,"R12046");
                webReport.Report.RegisterData(dtSite,"R12046_Site");

                var HijriDTFI=new CultureInfo("ar-SA",true).DateTimeFormat;
                HijriDTFI.Calendar=new HijriCalendar();
                webReport.SetParameterValue("RequestDate_H",Convert.ToDateTime(dt.Rows[0]["T_REQUEST_DATE"].ToString()).ToString("dd/MM/yyyy",HijriDTFI));

                webReport.Report.Prepare();
                using (var report=new MemoryStream())
                {
                    var pdfExport=new PDFExport();
                    webReport.Export(pdfExport,report);
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