using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface.Initialization;

namespace BloodBank.Controllers.Initialization
{
    public class T12199Controller : Controller
    {
        private IT12199 repository;
        public T12199Controller(IT12199 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}