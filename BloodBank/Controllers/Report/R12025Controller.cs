using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface.Report;
using FastReport.Export.Pdf;
using GenCode128;

namespace BloodBank.Controllers.Report
{
    public class R12025Controller : Controller
    {
        // GET: R12025
        private IR12025 repository;
        public R12025Controller(IR12025 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetReport( string donTiFrom, string donTiTo, string siteCode, string bloodGrp, string product)
        {
            var dtT12025 = repository.GetReport(Session["T_LANG"].ToString(), donTiFrom, donTiTo, siteCode, bloodGrp, product);
            dtT12025.TableName = "T12025";

            //----------- for barcode start-----------------
            // dtT12025.Columns.Add("Pat_BarCode", typeof(Bitmap));
            // Image myimg = Code128Rendering.MakeBarcodeImage(dtT12204.Rows[0]["T_BAG_BARCODE"].ToString(), int.Parse("2"), true);
            //  dtT12025.Rows[0]["Pat_BarCode"] = myimg;
            //----------- for barcode end-----------------

            // dtT12204.Columns.Add("Time", typeof(string));
            //dtT12204.Rows[0]["Time"] = Session["Hou_Min"].ToString();

           // dtT12025.WriteXmlSchema(Server.MapPath("~/Report/xml/T12025.xml"));
           //  return View();
            using (var webReport = new FastReport.Report())
            {
                webReport.Report.Load(Server.MapPath("~/Report/Report/R12025.frx"));
                System.Data.DataSet dataSet = new System.Data.DataSet();
                webReport.Report.RegisterData(dtT12025, "T12025");
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