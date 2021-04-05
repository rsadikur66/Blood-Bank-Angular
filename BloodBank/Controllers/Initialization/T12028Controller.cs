using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface.Initialization;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Initialization
{
    public class T12028Controller : Controller
    {
        private IT12028 repository;
        public T12028Controller(IT12028 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        // GET: T12028
        public ActionResult Index()
        {
            return View();
        }

        


    }
}