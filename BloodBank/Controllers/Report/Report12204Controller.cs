using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface.Report;
using FastReport.Export.OoXML;
using FastReport.Export.Pdf;
using GenCode128;

namespace BloodBank.Controllers.Report
{
    public class Report12204Controller : Controller
    {
        // GET: Report12204

        private RI12204 repository;
        public Report12204Controller(RI12204 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult GetReport( string patid, string epsort)
        {
           var dtT12204 = repository.GetReport(patid, epsort);
            dtT12204.TableName = "T12204";
            
            dtT12204.Columns.Add("Pat_BarCode", typeof(Bitmap));
            Image myimg = Code128Rendering.MakeBarcodeImage(dtT12204.Rows[0]["T_BAG_BARCODE"].ToString(), int.Parse("2"), true);
            dtT12204.Rows[0]["Pat_BarCode"] = myimg;
           // dtT12204.Columns.Add("Time", typeof(string));
            //dtT12204.Rows[0]["Time"] = Session["Hou_Min"].ToString();
            // dtT12204.WriteXmlSchema(Server.MapPath("~/Report/xml/T12204.xml"));
            // return View();
            using (var webReport = new FastReport.Report())
            {
                webReport.Report.Load(Server.MapPath("~/Report/Report/R12204.frx"));
                System.Data.DataSet dataSet = new System.Data.DataSet();
                webReport.Report.RegisterData(dtT12204, "T12204");
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
    }
}