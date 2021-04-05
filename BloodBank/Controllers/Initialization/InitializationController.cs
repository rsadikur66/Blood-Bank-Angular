using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface.Menu;

namespace BloodBank.Controllers.Initialization
{
    public class InitializationController : Controller
    {
        private IMenu repository;

        public InitializationController(IMenu ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        // GET: Initialization
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult T12068()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(Session["T_EMP_CODE"] as string) && !string.IsNullOrEmpty(Session["T_ROLE_CODE"] as string))
            {
                dt = repository.FormAuthorization("T12068", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
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
        public ActionResult T01004()
        {
            bool res = repository.FormAuth("T01004", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            if (res) { return View(); }
            else { return RedirectToAction("Index", "Account"); }

        }
        public ActionResult T12132()
        {
            bool res = repository.FormAuth("T12132", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            if (res) { return View(); }
            else { return RedirectToAction("Index", "Account"); }

        }
        public ActionResult T12199()
        {
            bool res = repository.FormAuth("T12199", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            if (res) { return View(); }
            else { return RedirectToAction("Index", "Account"); }

        }
        public ActionResult T12011()
        {
            bool res = repository.FormAuth("T12011", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            if (res) { return View(); }
            else { return RedirectToAction("Index", "Account"); }

        }
        public ActionResult T12033()
        {
            bool res = repository.FormAuth("T12033", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            if (res) { return View(); }
            else { return RedirectToAction("Index", "Account"); }
            //   return View();

        }

        public ActionResult T12081()
        {
            bool res = repository.FormAuth("T12081", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            if (res) { return View(); }
            else { return RedirectToAction("Index", "Account"); }
            //   return View();

        }
        public ActionResult T12087()
        {
            bool res = repository.FormAuth("T12087", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            if (res) { return View(); }
            else { return RedirectToAction("Index", "Account"); }
            //   return View();

        }
        public ActionResult T12028()
        {
            bool res = repository.FormAuth("T12028", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            if (res) { return View(); }
            else { return RedirectToAction("Index", "Account");}
            //   return View();

        }


        public ActionResult T12246()
        {
            bool res = repository.FormAuth("T12246", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            if (res) { return View(); }
            else { return RedirectToAction("Index", "Account"); }
            //   return View();

        }
        public ActionResult T12332()
        {
            bool res = repository.FormAuth("T12332", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            if (res) { return View(); }
            else { return RedirectToAction("Index", "Account"); }
            //   return View();

        }
        public ActionResult T12281()
        {
            bool res = repository.FormAuth("T12281", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            if (res) { return View(); }
            else { return RedirectToAction("Index", "Account"); }
            //   return View();

        }
        public ActionResult T12337()
        {
            bool res = repository.FormAuth("T12337", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            if (res) { return View(); }
            else { return RedirectToAction("Index", "Account"); }
            //   return View();
        }

        public ActionResult T12338()
        {
            bool res = repository.FormAuth("T12338", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            if (res) { return View(); }
            else { return RedirectToAction("Index", "Account"); }
            //   return View();
        }
        public ActionResult T01009()
        {
            bool res = repository.FormAuth("T01009", Session["T_EMP_CODE"].ToString(), Session["T_ROLE_CODE"].ToString());
            if (res) { return View(); }
            else { return RedirectToAction("Index", "Account"); }
            //   return View();
        }
        
    }
}