using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Interface.Transaction;
using GenCode128;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Transaction
{
    public class T12204Controller : Controller
    {
        // GET: T12204
        PrintDocument printDoc;
        private IT12204 repository;
        private IError err;
        public T12204Controller(IT12204 ObjectIRepository,IError errRepo)
        {
            repository = ObjectIRepository;
            err = errRepo;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GatCompStatusData(string d)
        {
            try
            {
                var data = repository.GatCompStatusData(Session["T_LANG"].ToString(), d);
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
        public ActionResult GetBedUsedData(string id)
        {
            try
            {
                var data = repository.GetBedUsedData(Session["T_LANG"].ToString(), id);
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
        public ActionResult GetPatDetails(string patNo,string patId)
        {
            try
            {
                var data = repository.GetPatDetails(Session["T_LANG"].ToString(), Session["T_SITE_CODE"].ToString(), patNo, patId);
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
        public ActionResult GetReson_AcStatus(int bagWet)
        {
            try
            {
                var data = repository.GetReson_AcStatus(Session["T_LANG"].ToString(), bagWet);
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
        public ActionResult GetBed()
        {
            try
            {
                var data = repository.GetBed(Session["T_LANG"].ToString());
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
        public ActionResult GetDiscurtReason()
        {
            try
            {
                var data = repository.GetDiscurtReason(Session["T_LANG"].ToString());
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
        public ActionResult GetbodyMermt(string pat,string epst)
        {
            try
            {
                var data = repository.GetbodyMermt(pat, epst);
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
        public ActionResult GetQuestion(string pat, string epst)
        {
            try
            {
                var data = repository.GetQuestion(pat, epst);
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
        public ActionResult GetImages(string pat, string epst)
        {
            try
            {
                var data = repository.GetImages(pat, epst);
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
        public ActionResult getUnit_SegmNo()
        {
            try
            {
                var data = repository.getUnit_SegmNo();
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
        public ActionResult Getpin()
        {
            try
            {
                var data = repository.Getpin(Convert.ToString(Session["T_EMP_CODE"]));
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
        public ActionResult SaveData(CommonModel t12022)
        {
            try
            {
                Session["UnitNo"] = t12022.T_UNIT_NO;
                Session["Segment"] = t12022.T_SEGMENT_NO;
                Session["Pat_No"] = t12022.T_DONOR_PATNO;
                Session["Date"] = t12022.T_DATE;
                Session["Hou_Min"] = t12022.T_HOUR_MIN;
                var data = repository.SaveData(t12022);
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
        public ActionResult GetMaxBidStoreId()
        {
            try
            {
                var data = repository.GetMaxBidStoreId();
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
        public ActionResult GetComment(int phel)
        {
            try
            {
                var data = repository.GetComment(phel, Session["T_LANG"].ToString());
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
        public ActionResult Update(CommonModel t12022)
        {
            try
            {
                var data = repository.Update(t12022);
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
        public ActionResult GetComntT12328(int ple)
        {
            try
            {
                var data = repository.GetComntT12328(Session["T_LANG"].ToString(), ple);
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
        public ActionResult showDataFromT12022(string patNo,string epsort)
        {
            try
            {
                var data = repository.showDataFromT12022(Session["T_LANG"].ToString(), patNo, epsort);
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

        //showDataFromT12022

        // ============== for bar code print start ==========
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
            // topMargin = 50 + e.MarginBounds.Top;
            // yPos = topMargin + (count * verdana10Font.GetHeight(g));
            yPos = yPos + 15;
        }

        private void PrintData(object sender, PrintPageEventArgs e)
        {
            try
            {
                //System.Drawing.Font printFont = new System.Drawing.Font("IDAutomationHC39M", 9);
                //SolidBrush br = new SolidBrush(Color.Black);
                //e.Graphics.DrawString("01911218527", printFont, Brushes.Black, new RectangleF(5, 30, 180, 50));
                //dtT12204.Columns.Add("Pat_BarCode", typeof(Bitmap));
                Image myimg = Code128Rendering.MakeBarcodeImage(Convert.ToString(Session["UnitNo"]) , int.Parse("2"), true);
                //Image newImage = Image.FromFile(@"E:\ALL PROJECT\BloodBank(Angular)\BloodBank\fonts\10_04_2018_03_31_26.png");

                // Create rectangle for displaying image.
                Rectangle destRect = new Rectangle(50, 100, 144, 80);

                // Draw image to screen.
                e.Graphics.DrawImage(myimg, destRect);
                CalcuateMargin(e);
                e.Graphics.DrawString("BB "+ Session["Date"].ToString()+" "+ Session["Hou_Min"].ToString(), arial_Narrow9B, Brushes.Black, 62, 85, new StringFormat());
                e.Graphics.DrawString(" * "+ String.Join(" ", Session["UnitNo"].ToString().Reverse()) +" *", arial_Narrow9B, Brushes.Black, 77, 180, new StringFormat());
                e.Graphics.DrawString(Session["Segment"].ToString() + "   "+ Session["Pat_No"].ToString(), arial_Narrow9B, Brushes.Black, 62, 190, new StringFormat());
            }
            catch (Exception ex) { }
        }
        // ============== for bar code print end ==========
    }
}