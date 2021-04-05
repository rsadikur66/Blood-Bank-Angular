using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers.Transaction
{
    public class T12215Controller : Controller
    {
        // GET: T12215
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDeliveryManData()
        {
            try
            {
                var data = 0;
                //string l = Session["T_LANG"].ToString();
                //string site = Session["T_SITE_CODE"].ToString();
                //var data = repository.GetDeliveryManData();
               // string path = "C:/folder1/folder2/file.txt";
               // string lastFolderName = Path.GetFileName(Path.GetDirectoryName(path));
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(data);
                return Json(JSONString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult test()
        {
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Images"));
            FileInfo[] file = dir.GetFiles();
            ArrayList list = new ArrayList();
            foreach (FileInfo file2 in file)
            {
                if (file2.Extension == ".jpg" || file2.Extension == ".jpeg" || file2.Extension == ".gif" || file2.Extension == ".png")
                {
                    list.Add(file2);
                }
            }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(list);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
            // DataList1.DataSource = list;
            // DataList1.DataBind();
        }
    }
}