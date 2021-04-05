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
    public class R12016Controller : Controller
    {
        private IR12016 repository;
        public R12016Controller(IR12016 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult getUnit()
        {
            string site = Session["T_SITE_CODE"].ToString();
            var data = repository.getUnit( site);
            string jSONString = JsonConvert.SerializeObject(data);
            return Json(jSONString, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult getPRCode(string from, string to)
        {
            string lang = Session["T_LANG"].ToString();
            var data = repository.getPRCode(lang,from,to);
            string jSONString = JsonConvert.SerializeObject(data);
            return Json(jSONString, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult getReport(string from, string to, string prod)
        {
            string lang = Session["T_LANG"].ToString();
            DataTable dt = repository.getReport(lang,from,to, prod);
            dt.TableName = "R12016";
            //dt.WriteXmlSchema(Server.MapPath("~/Report/xml/R12016.xml"));
            //return View();
            using (var Report = new FastReport.Report())
            {
                Report.Report.Load(Server.MapPath("~/Report/Report/R12016.frx"));
                Report.Report.RegisterData(dt, "R12016");
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
    }
}