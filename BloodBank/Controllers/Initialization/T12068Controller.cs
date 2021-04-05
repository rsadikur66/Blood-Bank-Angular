using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface.Initialization;
using Newtonsoft.Json;

namespace BloodBank.Controllers.Initialization
{
    public class T12068Controller : Controller
    {
        private IT12068 repository;

        public T12068Controller(IT12068 ObjectIRepository)
        {
            repository = ObjectIRepository;
        }
        // GET: T12068
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAllGender()
        {
            var data = this.repository.GetAllGender(Convert.ToString(Session["T_LANG"].ToString()));
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(data);
            return Json(JSONString, JsonRequestBehavior.AllowGet);

            //return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetQstHeadData()
        {
            var headdata = this.repository.GetQstHeadData(Convert.ToString(Session["T_LANG"].ToString()));
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(headdata);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetFailData()
        {
            var faildata = this.repository.GetFailData();
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(faildata);
            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult InsertT12068(t12068 t12068)
        {
            var data = repository.InsertT12068(t12068);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateT12068(t12068 t12068)
        {
            var data = repository.UpdateT12068(t12068);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteT12068(t12068 t12068)
        {
            var data = repository.DeleteT12068(t12068);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult InsertT12069(t12068 t12069)
        {
            var data = repository.InsertT12069(t12069);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetGridData()
        {
            try
            {
                //Datatable parameter
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                //paging parameter
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                //sorting parameter
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                //  var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                //filter parameter
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                Int32 PageIndex = 0;
                Int32 PageSize = 0;
                if (start == "0")
                {
                    PageIndex = 0;
                }
                else
                {
                    PageIndex = Convert.ToInt32(start) / Convert.ToInt32(length) + 0;
                }
                PageSize = Convert.ToInt32(length);
                List<t12068> allGridData = new List<t12068>();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                DataTable GridData = new DataTable();
                DataTable CountValue = new DataTable();
                // DataTable SearchValue = new DataTable();
                if (searchValue == "")
                {
                    GridData = repository.GetGridData(PageIndex, PageSize);
                    CountValue=repository.GetGridData_Count(searchValue, PageIndex, PageSize);
                }
                else
                {
                    GridData = repository.GetGridData_Search(searchValue, PageIndex, PageSize);
                    CountValue = repository.GetGridData_Search_Count(searchValue, PageIndex, PageSize);
                }
                IEnumerable v = (from DataRow row in GridData.Rows
                                 select new
                                 {
                                     T_QNO = row["T_QNO"],
                                     T_LANG2_NAME = row["T_LANG2_NAME"].ToString(),
                                     T_LANG1_NAME = row["T_LANG1_NAME"].ToString(),
                                     T_QHEAD_NO = row["T_QHEAD_NO"].ToString(),
                                     T_QHEAD = row["T_QHEAD"].ToString(),
                                     T_QUS_YES_COLOR = row["T_QUS_YES_COLOR"].ToString(),
                                     T_EXP_ANS = row["T_EXP_ANS"].ToString(),
                                     T_QUS_WEIGHT = row["T_QUS_WEIGHT"].ToString(),
                                     T_DISP_SEQ = row["T_DISP_SEQ"].ToString(),
                                     T_DIFFERAL_DAY = row["T_DIFFERAL_DAY"].ToString(),
                                     T_QUS_NO_COLOR = row["T_QUS_NO_COLOR"].ToString(),
                                     T_SEX = row["T_SEX"].ToString(),
                                     T_GENDER = row["T_GENDER"].ToString(),
                                     T_ACTION = row["T_ACTION"].ToString(),
                                     T_IF_FAIL = row["T_IF_FAIL"].ToString(),
                                     T_ACTIVE = row["T_ACTIVE"].ToString()
                                 }).ToList();
                //sort
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                //{
                //    //for make sort simpler we will add Syste.Linq.Dynamic reference
                //    //v = v; //.OrderBy(sortColumn + " " + sortColumnDir);
                //}

                recordsTotal = Convert.ToInt32(CountValue.Rows[0]["cval"]);//v.Count();
                                                     // allGridData = v;//v.Skip(skip).Take(pageSize).ToList();

                // return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = v }, JsonRequestBehavior.AllowGet);
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = v }, JsonRequestBehavior.AllowGet);
                // return Json(v,JsonRequestBehavior.AllowGet);
            }
            catch (Exception exc)
            {
                return Json(exc.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}