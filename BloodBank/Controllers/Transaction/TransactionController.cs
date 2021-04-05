using BloodBank.Models;
using BloodBankDAL.Repository.Interface.Menu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers.Transaction
{
    public class TransactionController : Controller
    {
        // GET: T12204
        private IMenu repository;

        public TransactionController(IMenu ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult T12304()
        {
            return View();
        }

        public ActionResult T12204()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                dt = repository.FormAuthorization("T12204", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                return View();
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "Account");
            }
        }

        public ActionResult T12244()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                dt = repository.FormAuthorization("T12244", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        public ActionResult T12214()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                dt = repository.FormAuthorization("T12214", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }
        public ActionResult T12215()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                dt = repository.FormAuthorization("T12215", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }
        public ActionResult T12213()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                dt = repository.FormAuthorization("T12214", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        public ActionResult T12235()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                dt = repository.FormAuthorization("T12235", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        public ActionResult T12236()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                dt = repository.FormAuthorization("T12236", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }
        public ActionResult T12241()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                dt = repository.FormAuthorization("T12241", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        public ActionResult T12201()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                dt = repository.FormAuthorization("T12201", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        public ActionResult T12202()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                dt = repository.FormAuthorization("T12202", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        public ActionResult T12245()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                dt = repository.FormAuthorization("T12245", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }


        public ActionResult T13054()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                dt = repository.FormAuthorization("T12245", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        public ActionResult T12325()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                dt = repository.FormAuthorization("T12245", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        public ActionResult T12250()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                dt = repository.FormAuthorization("T12250", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }
        public ActionResult T12328()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12328", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }
        public ActionResult T12349()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12349", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }

        public ActionResult T12232()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12232", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }

        public ActionResult T12233()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12233", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }

        public ActionResult T12003()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12003", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }

        public ActionResult T12300()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12300", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12301()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12301", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }

        public ActionResult T12302()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12302", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }

        public ActionResult T12207()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12207", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }

        public ActionResult T12263()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12263", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12262()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12262", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }

        public ActionResult T06210()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T06210", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12309()
        {
            return View();
            //if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            //{
            //    bool res = repository.FormAuth("T12309", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            //    if (res) { return View(); }
            //    else { return RedirectToAction("Index", "Account"); }
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Account");
            //}

        }
        public ActionResult T12252()
        {
            return View();
            //if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            //{
            //    bool res = repository.FormAuth("T12309", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            //    if (res) { return View(); }
            //    else { return RedirectToAction("Index", "Account"); }
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Account");
            //}

        }
        public ActionResult T12239()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12239", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12346()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12346", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12318()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12318", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12317()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12317", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12366()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12366", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12322()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12322", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12253()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12253", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12256()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12256", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12258()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12258", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12330()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12330", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T13122()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T13122", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12319()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12319", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12327()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12327", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12200()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12200", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12287()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12287", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12320()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12320", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12254()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12254", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12326()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12326", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12306()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12306", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12264()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12264", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }

        public ActionResult T12265()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12265", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12266()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12266", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        public ActionResult T12091()
        {
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                bool res = repository.FormAuth("T12091", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
                if (res) { return View(); }
                else { return RedirectToAction("Index", "Account"); }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }

    }
}