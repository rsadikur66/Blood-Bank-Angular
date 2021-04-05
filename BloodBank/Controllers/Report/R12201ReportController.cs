using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface.Report;
using FastReport.Export.OoXML;
using FastReport.Export.Pdf;
using FastReport;
using GenCode128;

namespace BloodBank.Controllers.Report
{
    public class R12201ReportController : Controller
    {

        private RI12201 repository;
        public R12201ReportController(RI12201 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        // GET: T12201Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetReport(string patNo, string patName,string nationalityId, string lastepisode, string arrivaldate, string gender, string year, string nationality)
        {
            var arabicname = repository.GetArabicName(patNo);
            //var dtT12201 = repository.GetReport(patid);
            DataTable dtT12201 = new DataTable();
            dtT12201.TableName = "T12201";

            dtT12201.Columns.Add("Pat_BarCode", typeof(Bitmap));
            dtT12201.Columns.Add("patNo", typeof(string));
            dtT12201.Columns.Add("patName", typeof(string));
            dtT12201.Columns.Add("arabicname", typeof(string));
            dtT12201.Columns.Add("nationalityId", typeof(string));
            dtT12201.Columns.Add("lastepisode", typeof(string));
            dtT12201.Columns.Add("arrivaldate", typeof(string));
            dtT12201.Columns.Add("gender", typeof(string));
            dtT12201.Columns.Add("year", typeof(string));
            dtT12201.Columns.Add("nationality", typeof(string));
            Image myimg = Code128Rendering.MakeBarcodeImage(patNo, int.Parse("2"), true);
            DataRow dr = dtT12201.NewRow();
            dtT12201.Rows.Add(dr);
            dtT12201.Rows[0]["Pat_BarCode"] = myimg;
            dtT12201.Rows[0]["patNo"] = patNo;
            dtT12201.Rows[0]["patName"] = patName;
            dtT12201.Rows[0]["arabicname"] = arabicname;
            dtT12201.Rows[0]["nationalityId"] = nationalityId;
            dtT12201.Rows[0]["lastepisode"] = lastepisode;
            dtT12201.Rows[0]["arrivaldate"] = arrivaldate;
            dtT12201.Rows[0]["gender"] = gender;
            dtT12201.Rows[0]["year"] = year;
            dtT12201.Rows[0]["nationality"] = nationality;
           
            //dtT12201.WriteXmlSchema(Server.MapPath("~/Report/xml/T12201.xml"));
            //return View();
            using (var Report = new FastReport.Report())
            {
                Report.Report.Load(Server.MapPath("~/Report/Report/R12201.frx"));
                System.Data.DataSet dataSet = new System.Data.DataSet();
                Report.Report.RegisterData(dtT12201, "T12201");
                Report.Report.Prepare();
                using (var strm = new MemoryStream())
                {
                    // var excelExport = new Excel2007Export();
                    // webReport.Report.Export(excelExport, strm);
                    // var pdfExport = new PDFExport();
                    // Report.Report.Export(pdfExport, strm);
                    // Response.ClearContent();
                    // Response.ClearHeaders();
                    // Response.Buffer = true;
                    //// Response.ContentType = "Application/vnd.ms-excel";
                    // Response.ContentType = "Application/PDF";
                    // Response.BinaryWrite(strm.ToArray());
                    // Response.End();

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
    }
}