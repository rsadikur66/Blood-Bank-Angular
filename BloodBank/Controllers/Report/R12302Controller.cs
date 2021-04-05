using FastReport.Export.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface.Report;
using GenCode128;
using System.Globalization;

namespace BloodBank.Controllers.Report
{
    public class R12302Controller : Controller
    {

        // GET: R12050
        private IR12302 repository;
        public R12302Controller(IR12302 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getReportbloodGroup(string from, string to, string prod)
        {
            string siteCode = Session["T_SITE_CODE"].ToString();
            DataTable T12302_ = repository.GetReport(siteCode);
            DataTable T12302_PatInf_ = repository.GetPatInf();
            DataTable T12302_Site_ = repository.GetSite(siteCode);

            T12302_.TableName = "R12302";
            T12302_PatInf_.TableName = "R12302_PatInf";
            T12302_Site_.TableName = "R12302_Site";

            DataSet ds = new DataSet();
            ds.Tables.Add(T12302_);
            ds.Tables.Add(T12302_PatInf_);
            ds.Tables.Add(T12302_Site_);

            // dtT12302.TableName = "T12302";

            //----------- for barcode start-----------------
            // dtT12025.Columns.Add("Pat_BarCode", typeof(Bitmap));
            // Image myimg = Code128Rendering.MakeBarcodeImage(dtT12204.Rows[0]["T_BAG_BARCODE"].ToString(), int.Parse("2"), true);
            //  dtT12025.Rows[0]["Pat_BarCode"] = myimg;
            //----------- for barcode end-----------------

            // dtT12204.Columns.Add("Time", typeof(string));
            //dtT12204.Rows[0]["Time"] = Session["Hou_Min"].ToString();

            // ds.WriteXmlSchema(Server.MapPath("~/Report/xml/T12050.xml"));
            //  return View();
            using (var webReport = new FastReport.Report())
            {
                webReport.Report.Load(Server.MapPath("~/Report/Report/R12050.frx"));

                webReport.Report.RegisterData(T12302_, "R12302");
                webReport.Report.RegisterData(T12302_PatInf_, "R12302_PatInf");
                webReport.Report.RegisterData(T12302_Site_, "R12302_Site");

                // System.Data.DataSet dataSet = new System.Data.DataSet();
                //webReport.Report.RegisterData(dtT12302, "T12302");
                webReport.Report.Prepare();
                using (var Report = new MemoryStream())
                {
                    // var excelExport = new Excel2007Export();
                    // webReport.Report.Export(excelExport, strm);
                    // var pdfExport = new PDFExport();
                    // webReport.Report.Export(pdfExport, strm);
                    // Response.ClearContent();
                    // Response.ClearHeaders();
                    // Response.Buffer = true;
                    //// Response.ContentType = "Application/vnd.ms-excel";
                    //  Response.ContentType = "Application/PDF";
                    // Response.BinaryWrite(strm.ToArray());
                    // Response.End();
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

        public ActionResult getReportxmatch(string patno)
        {
            string siteCode = Session["T_SITE_CODE"].ToString();
            DataTable dt = repository.getPatInfo(patno);
            DataTable dt_1 = repository.geHistoryData(patno, siteCode);
            DataTable T12302_Site_ = repository.GetSite(siteCode);

            dt.TableName = "R12302_xmatchinfo";
            dt_1.TableName = "R12302_xmatchHistory";
            T12302_Site_.TableName = "R12302_Site";

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            ds.Tables.Add(dt_1);
            ds.Tables.Add(T12302_Site_);
            //ds.WriteXmlSchema(Server.MapPath("~/Report/xml/R12302xmatch.xml"));
            //return View();
            using (var Report = new FastReport.Report())
            {
                Report.Report.Load(Server.MapPath("~/Report/Report/R12049.frx"));
                Report.Report.RegisterData(dt, "R12302_xmatchinfo");
                Report.Report.RegisterData(dt_1, "R12302_xmatchHistory");
                Report.Report.RegisterData(T12302_Site_, "R12302_Site");
                Report.Report.Prepare();
                using (var strm = new MemoryStream())
                {
                    var pdfExport = new PDFExport();
                    Report.Export(pdfExport, strm);
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Buffer = true;
                    Response.ContentType = "Application/PDF";
                    Response.BinaryWrite(strm.ToArray());
                    Response.End();
                }
                ViewBag.WebReport = Report;
            }

            return View();
        }

        public ActionResult getR12065_Report(string patno)
        {
            // string siteCode = Session["T_SITE_CODE"].ToString();
            DataTable dt = repository.getR12065_Report(patno);


            dt.TableName = "R12065";
            //dt_1.TableName = "R12302_xmatchHistory";
            //T12302_Site_.TableName = "R12302_Site";

            // DataSet ds = new DataSet();
            // ds.Tables.Add(dt);
            // ds.Tables.Add(dt_1);
            //ds.Tables.Add(T12302_Site_);
            //foreach (DataTable V in dt.Rows)
            //{
                
            //}
            //----------- for barcode start-----------------
            dt.Columns.Add("Pat_BarCode", typeof(Bitmap));
            Image myimg = Code128Rendering.MakeBarcodeImage(dt.Rows[0]["T_UNIT_NO"].ToString(), int.Parse("2"), true);
            dt.Rows[0]["Pat_BarCode"] = myimg;
            //----------- for barcode end-----------------


            //dt.WriteXmlSchema(Server.MapPath("~/Report/xml/R12065.xml"));
           // return View();
            using (var Report = new FastReport.Report())
            {
                Report.Report.Load(Server.MapPath("~/Report/Report/R12065.frx"));
                System.Data.DataSet dataSet = new System.Data.DataSet();
                Report.Report.RegisterData(dt, "R12065");
               
                //Report.Report.RegisterData(dt_1, "R12302_xmatchHistory");
                // Report.Report.RegisterData(T12302_Site_, "R12302_Site");
                Report.Report.Prepare();
                using (var strm = new MemoryStream())
                {
                    var pdfExport = new PDFExport();
                    Report.Export(pdfExport, strm);
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Buffer = true;
                    Response.ContentType = "Application/PDF";
                    Response.BinaryWrite(strm.ToArray());
                    Response.End();
                }
                ViewBag.WebReport = Report;
            }

            return View();
        }

        public ActionResult getR12036A_Report(string patno)
        {
            // string siteCode = Session["T_SITE_CODE"].ToString();
            DataTable dt = repository.getR12036A_Report(patno);
            dt.TableName = "R12036";
            //dt_1.TableName = "R12302_xmatchHistory";
            //T12302_Site_.TableName = "R12302_Site";

            // DataSet ds = new DataSet();
            // ds.Tables.Add(dt);
            // ds.Tables.Add(dt_1);
            //ds.Tables.Add(T12302_Site_);
            //foreach (DataTable V in dt.Rows)
            //{

            //}
            //----------- for barcode start-----------------
            //dt.Columns.Add("Pat_BarCode", typeof(Bitmap));
            //Image myimg = Code128Rendering.MakeBarcodeImage(dt.Rows[0]["T_UNIT_NO"].ToString(), int.Parse("2"), true);
            //dt.Rows[0]["Pat_BarCode"] = myimg;
            //----------- for barcode end-----------------


            //dt.WriteXmlSchema(Server.MapPath("~/Report/xml/R12036.xml"));
            // return View();
            using (var Report = new FastReport.Report())
            {
                Report.Report.Load(Server.MapPath("~/Report/Report/R12036A.frx"));
                Report.Report.RegisterData(dt, "R12036");

                //Report.Report.RegisterData(dt_1, "R12302_xmatchHistory");
                // Report.Report.RegisterData(T12302_Site_, "R12302_Site");
                Report.Report.Prepare();
                using (var strm = new MemoryStream())
                {
                    var pdfExport = new PDFExport();
                    Report.Export(pdfExport, strm);
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Buffer = true;
                    Response.ContentType = "Application/PDF";
                    Response.BinaryWrite(strm.ToArray());
                    Response.End();
                }
                ViewBag.WebReport = Report;
            }

            return View();
        }
        //getR12036A_Report
        public ActionResult getR12012_Report(string reqno)
        {
            string site = Session["T_SITE_CODE"].ToString();
            string lang = Session["T_LANG"].ToString();
            DataTable dt = repository.getR12012_Report(reqno, site,lang);
            DataTable dt_site = repository.GetSite(site);

            dt.TableName = "R12012";
            dt_site.TableName = "R12012_site";

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            ds.Tables.Add(dt_site);


            //ds.WriteXmlSchema(Server.MapPath("~/Report/xml/R12012.xml"));


            using (var webReport = new FastReport.Report())
            {
                webReport.Report.Load(Server.MapPath("~/Report/Report/R12012.frx"));

                webReport.Report.RegisterData(dt, "R12012");
                webReport.Report.RegisterData(dt_site, "R12012_site");


                var HijriDTFI = new CultureInfo("ar-SA", false).DateTimeFormat;
                HijriDTFI.Calendar = new HijriCalendar();
                webReport.SetParameterValue("RequestDate_H", Convert.ToDateTime(dt.Rows[0]["T_REQUEST_DATE"].ToString()).ToString("dd/MM/yyyy", HijriDTFI));

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