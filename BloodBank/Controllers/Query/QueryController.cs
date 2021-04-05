using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Repository.Interface.Initialization;
using BloodBankDAL.Repository.Interface.Query;
using BloodBankDAL.Repository.Query.Query;

namespace BloodBank.Controllers.Query
{
    public class QueryController : Controller
    {
        // GET: Q03001

        //private IQ03001 repository;
        //public QueryController(IQ03001 ObjectIRepository)
        //{
        //    repository = ObjectIRepository;
        //}
        public ActionResult Q03001()
        {
            return View();
        }
        public ActionResult Q12025()
        {
            return View();
        }

        public ActionResult Q12012()
        {
            return View();
        }
        public ActionResult Q12018()
        {
            return View();
        }
        public ActionResult Q12200()
        {
            return View();
        }
        public ActionResult Q12252()
        {
            return View();
        }
        public ActionResult Q12017()
        {
            return View();
        }
        public ActionResult Q12207()
        {
            return View();
        }
        public ActionResult Q12263()
        {
            return View();
        }public ActionResult Q12352()
        {
            return View();
        }
        //[HttpPost]
        //public JsonResult GetGridviewData()
        //{

        //    try
        //    {
        //        //Datatable parameter
        //        var draw = Request.Form.GetValues("draw").FirstOrDefault();
        //        //paging parameter
        //        var start = Request.Form.GetValues("start").FirstOrDefault();
        //        var length = Request.Form.GetValues("length").FirstOrDefault();
        //        //sorting parameter
        //        var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
        //        var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
        //        //filter parameter
        //        var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

        //        Int32 PageIndex = 0;
        //        Int32 PageSize = 0;
        //        if (start == "0")
        //        {
        //            PageIndex = 0;
        //        }
        //        else
        //        {
        //            PageIndex = Convert.ToInt32(start) / Convert.ToInt32(length) + 1;
        //        }
        //        PageSize = Convert.ToInt32(length);
        //       // List<Q03001> allPatient = new List<Q03001>();
        //        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        //        int skip = start != null ? Convert.ToInt32(start) : 0;
        //        int recordsTotal = 0;
        //        DataTable GridData = new DataTable();
        //        DataTable CountValue = new DataTable();
        //        var lang = Session["T_LANG"].ToString().ToString();
        //        if (searchValue == "")
        //        {
        //            GridData = repository.GridData(PageIndex, PageSize, lang);
        //            CountValue = repository.GetPatientData_Search_Count(searchValue, PageIndex, PageSize, lang);
        //        }
        //        else
        //        {
        //            GridData = repository.GetPatientInfo_Search(searchValue, PageIndex, PageSize, lang);
        //            CountValue = repository.GetPatientData_Search_Count(searchValue, PageIndex, PageSize, lang);
        //        }
        //        IEnumerable v = (from DataRow row in GridData.Rows
        //                                 select new
        //                                 {
        //                                     RowNumber = Convert.ToInt32(row["RowNumber"]),
        //                                     T_PAT_NO = row["T_PAT_NO"].ToString(),
        //                                     PAT_NAME = row["PAT_NAME"].ToString(),
        //                                     RLGN = row["RLGN"].ToString(),
        //                                     GENDER = row["GENDER"].ToString(),
        //                                     T_NTNLTY_ID = row["T_NTNLTY_ID"].ToString(),
        //                                     NTNLTY = row["NTNLTY"].ToString(),
        //                                     YRS = row["YRS"].ToString(),
        //                                     MOS = row["MOS"].ToString(),
        //                                     MRTL_STATUS = row["MRTL_STATUS"].ToString()
        //                                 }).ToList().Take(10000);


        //        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
        //        {

        //        }

        //        recordsTotal = Convert.ToInt32(CountValue.Rows[0]["CVal"].ToString());//v.Count();
        //                                                                              //  allPatient = v.Take(pageSize).ToList();                                                                     

        //           return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = v }, JsonRequestBehavior.AllowGet);
        //       // return Json( JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception exc)
        //    {
        //        return Json(exc.Message, JsonRequestBehavior.AllowGet);
        //    }
        //}

    }
}