using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.XPath;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Interface.Transaction;
using GenCode128;
using Newtonsoft.Json;


namespace BloodBank.Controllers.Transaction
{
    public class T12250Controller : Controller
    {
        PrintDocument printDoc;
        private IError err;
        private string patno, patname, nationalid, episodeno, arrivaldate, gender, age, nationality, arabicname;
        private IT12250 repository;

        public T12250Controller(IT12250 ObjectIRepository,IError errRepo)
        {
            repository = ObjectIRepository;
            err = errRepo;
        }
        // GET: T12250
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckDonor(string P_PAT_NO, string P_NTNLTY_ID)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                var data = repository.CheckDonor(P_PAT_NO, P_NTNLTY_ID, lang);
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
        public ActionResult GetPatientData(string searchValue)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                var data = repository.GetPatientData(lang, searchValue);
                IEnumerable v = (from DataRow row in data.Rows
                                 select new
                                 {
                                     T_REF_PAT_NO = row["T_REF_PAT_NO"],
                                     T_OTHER_PAT_NAME = row["T_OTHER_PAT_NAME"].ToString()
                                 }).Take(500).ToList();
                return Json(v, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetReasonList(int age)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                var data = repository.GetReasonList(age, lang);
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
        public ActionResult GetSingleReason(int age, string reasonCode)
        {
            try
            {
                string lang = Session["T_LANG"].ToString();
                var data = repository.GetSingleReason(age, reasonCode, lang);
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
        public string insert(CommonModel t12017)
        {
            try
            {
                string user = Session["T_EMP_CODE"].ToString();
                t12017.T_SITE_CODE = Session["T_SITE_CODE"].ToString();
                var data = repository.insert(t12017, user);
                return data;
            }
            catch (Exception e)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), e.Message);
                return e.Message;
            }

        }



        public void GetBarCode(string patNo, string patName, string nationalId, string episodeNo, string arrivalDate, string Gender, string Age, string Nationality)
        {
            patno = patNo;
            patname = patName;
            arabicname = repository.GetArabicName(patNo);
            nationalid = nationalId;
            episodeno = episodeNo;
            arrivaldate = arrivalDate;
            gender = Gender;
            age = Age;
            nationality = Nationality;
            printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(PrintData);
            printDoc.Print();
            //var data = repository.GetBarCode(patNo);
            //string JSONString = string.Empty;
            //JSONString = JsonConvert.SerializeObject(data);
            //return Json(JSONString, JsonRequestBehavior.AllowGet);
        }


        float yPos = 80;
        int count = 0;
        float leftMargin = 0;
        float topMargin = 0;

        string[] FontNameList ={
            "Trebuchet MS", //0
            "Book Antiqua", //1
            "MS Reference Sans Serif" ,//2
            "Courier New" ,//3
            "Lucida Console", //4
            "Comic Sans MS", //5
            "Arial",//6
            "Times New Roman",//7              
            " Verdana",//8
            "MS Outlook"//9
        };

        string fontName = "Times New Roman";
        Font arial_Narrow8R, arial_Narrow8B, arial_Narrow9R, arial_Narrow9B, arial_Narrow10R, arial_Narrow10B, arial_Narrow7R;
        Graphics g;
        private void CalcuateMargin(PrintPageEventArgs e)
        {
            arial_Narrow8R = new Font(fontName, 8, FontStyle.Regular);
            arial_Narrow8B = new Font(fontName, 8, FontStyle.Bold);
            arial_Narrow9R = new Font(fontName, 9, FontStyle.Regular);
            arial_Narrow9B = new Font(fontName, 9, FontStyle.Bold);
            arial_Narrow10R = new Font(fontName, 10, FontStyle.Regular);
            arial_Narrow10B = new Font(fontName, 10, FontStyle.Bold);
            arial_Narrow7R = new Font(fontName, 7, FontStyle.Regular);
            g = e.Graphics;
            leftMargin = 0;
            yPos = yPos + 15;
        }
        private void CalcuateMarginRegular(PrintPageEventArgs e)
        {
            arial_Narrow8R = new Font(fontName, 8, FontStyle.Regular);
            arial_Narrow8B = new Font(fontName, 8, FontStyle.Regular);
            arial_Narrow9R = new Font(fontName, 9, FontStyle.Regular);
            arial_Narrow9B = new Font(fontName, 9, FontStyle.Regular);
            arial_Narrow10R = new Font(fontName, 10, FontStyle.Regular);
            arial_Narrow10B = new Font(fontName, 10, FontStyle.Regular);
            arial_Narrow7R = new Font(fontName, 7, FontStyle.Regular);
            g = e.Graphics;
            leftMargin = 0;
            // topMargin = 50 + e.MarginBounds.Top;
            // yPos = topMargin + (count * verdana10Font.GetHeight(g));
            yPos = yPos + 15;
        }

        private void PrintData(object sender, PrintPageEventArgs e)
        {
            try
            {

                Image myimg = Code128Rendering.MakeBarcodeImage(nationalid, int.Parse("2"), true);
                //Image newImage = Image.FromFile(@"\\100.43.0.38\e$\ALL PROJECT\BloodBank(Angular)\publish\Images\logo.png");

                //// Create rectangle for displaying image.
                Rectangle LogoImage = new Rectangle(20, 50, 150, 70);
                Rectangle barcode = new Rectangle(200, 50, 150, 70);

                //// Draw image to screen.
                e.Graphics.DrawImage(myimg, barcode);
                CalcuateMargin(e);

                e.Graphics.DrawString(" * " + patno + " * ", arial_Narrow9B, Brushes.Black, 230, 121,
                    new StringFormat());
                CalcuateMargin(e);

                // e.Graphics.DrawImage(newImage, LogoImage);
                //CalcuateMargin(e);

                e.Graphics.DrawString(arabicname, arial_Narrow9B, Brushes.Black, 230, 132, new StringFormat());
                CalcuateMargin(e);

                e.Graphics.DrawString(patname, arial_Narrow9B, Brushes.Black, 200, 142, new StringFormat());
                CalcuateMargin(e);

                e.Graphics.DrawString(gender, arial_Narrow9B, Brushes.Black, 220, 154, new StringFormat());
                CalcuateMargin(e);

                e.Graphics.DrawString(age + "Y", arial_Narrow9B, Brushes.Black, 263, 154, new StringFormat());
                CalcuateMargin(e);

                e.Graphics.DrawString(nationality, arial_Narrow9B, Brushes.Black, 295, 154, new StringFormat());
                CalcuateMargin(e);

                e.Graphics.DrawString(nationalid, arial_Narrow9B, Brushes.Black, 370, 70, new StringFormat());
                CalcuateMarginRegular(e);

                e.Graphics.DrawString("BB EPS# " + episodeno, arial_Narrow9B, Brushes.Black, 375, 85,
                    new StringFormat());
                CalcuateMarginRegular(e);

                e.Graphics.DrawString(arrivaldate, arial_Narrow9B, Brushes.Black, 375, 105, new StringFormat());
                CalcuateMarginRegular(e);

            }
            catch (Exception ex)
            {
                err.SetServerErrorLog(ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    Session["T_ENTRY_USER"] == null ? "" : Session["T_ENTRY_USER"].ToString(), ex.Message);
            }
        }
    }
}