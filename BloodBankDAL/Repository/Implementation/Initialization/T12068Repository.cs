using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface.Initialization;
using BloodBankDAL.Repository.Query.Initialization;

namespace BloodBankDAL.Repository.Implementation.Initialization
{
    public class T12068Repository : IT12068
    {
        private readonly T12068 obj = new T12068();

        //private readonly CommonDAL obj = new Login();

        public T12068Repository(T12068 _obj) : base()
        {
            obj = _obj;
        }

        public T12068Repository()
        {
        }
        public DataTable GetAllGender(string language)
        {
            //var obj = this.obj.GetAllGender(language);//HttpContext.Current.Session["T_LANG"].ToString()
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetAllGender(language);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetQstHeadData(string language)
        {
            //var obj = this.obj.GetQstHeadData(language);
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetQstHeadData(language);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetFailData()
        {
            //var obj = this.obj.GetFailData();
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetFailData();
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetGridData(int PageIndex, int PageSize)
        {
            //var obj = this.obj.GetGridData(PageIndex, PageSize, HttpContext.Current.Session["T_LANG"].ToString());
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetGridData(PageIndex, PageSize, HttpContext.Current.Session["T_LANG"].ToString());
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }
        public DataTable GetGridData_Search(string searchValue, int PageIndex, int PageSize)
        {
            //var obj = this.obj.GetGridData_Search(searchValue, PageIndex, PageSize, HttpContext.Current.Session["T_LANG"].ToString());
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetGridData_Search(searchValue, PageIndex, PageSize, HttpContext.Current.Session["T_LANG"].ToString());
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetGridData_Count(string searchValue, int PageIndex, int PageSize)
        {
            //var obj = this.obj.GetGridData_Count(searchValue, PageIndex, PageSize, HttpContext.Current.Session["T_LANG"].ToString());
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetGridData_Count(searchValue, PageIndex, PageSize, HttpContext.Current.Session["T_LANG"].ToString());
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }
        public DataTable GetGridData_Search_Count(string searchValue, int PageIndex, int PageSize)
        {
            //var obj = this.obj.GetGridData_Search_Count(searchValue, PageIndex, PageSize, HttpContext.Current.Session["T_LANG"].ToString());
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetGridData_Search_Count(searchValue, PageIndex, PageSize, HttpContext.Current.Session["T_LANG"].ToString());
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }
        public string InsertT12068(t12068 t12068)
        {
            //string msg = "";
            //string user = HttpContext.Current.Session["T_ENTRY_USER"].ToString();
            //bool isInsert = false;
            //obj.BeginTransaction();
            //if (obj.InsertT12068(user, t12068.T_QNO, t12068.T_QHEAD_NO, t12068.T_LANG2_NAME, t12068.T_LANG1_NAME, t12068.T_QUS_WEIGHT, t12068.T_DISP_SEQ, t12068.T_DIFFERAL_DAY, t12068.T_SEX, t12068.T_IF_FAIL, t12068.T_EXP_ANS, t12068.T_ACTIVE))
            //{
            //    obj.CommitTransaction();
            //    msg = "s";
            //}
            //else
            //{
            //    obj.RollbackTransaction();
            //    msg = "f";
            //}

            //return msg;


            string msg = "";

            try
            {
                string user = HttpContext.Current.Session["T_ENTRY_USER"].ToString();
                bool isInsert = false;
                obj.BeginTransaction();
                if (obj.InsertT12068(user, t12068.T_QNO, t12068.T_QHEAD_NO, t12068.T_LANG2_NAME, t12068.T_LANG1_NAME, t12068.T_QUS_WEIGHT, t12068.T_DISP_SEQ, t12068.T_DIFFERAL_DAY, t12068.T_SEX, t12068.T_IF_FAIL, t12068.T_EXP_ANS, t12068.T_ACTIVE))
                {
                    obj.CommitTransaction();
                    msg = "s";
                }
                else
                {
                    obj.RollbackTransaction();
                    msg = "f";
                }
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return msg;
        }

        public string UpdateT12068(t12068 t12068)
        {
            //string msg = "";
            //string user = HttpContext.Current.Session["T_ENTRY_USER"].ToString();
            //bool isUpdate = false;
            //obj.BeginTransaction();
            //if (obj.UpdateT12068(user, t12068.T_QHEAD_NO, t12068.T_LANG2_NAME, t12068.T_LANG1_NAME, t12068.T_QUS_WEIGHT, t12068.T_DISP_SEQ, t12068.T_DIFFERAL_DAY, t12068.T_SEX, t12068.T_IF_FAIL, t12068.T_EXP_ANS, t12068.T_ACTIVE, t12068.T_QNO))
            //{
            //    obj.CommitTransaction();
            //    msg = "u";
            //}
            //else
            //{
            //    obj.RollbackTransaction();
            //    msg = "f";
            //}
            //return msg;



            string msg = "";

            try
            {
                string user = HttpContext.Current.Session["T_ENTRY_USER"].ToString();
                bool isUpdate = false;
                obj.BeginTransaction();
                if (obj.UpdateT12068(user, t12068.T_QHEAD_NO, t12068.T_LANG2_NAME, t12068.T_LANG1_NAME, t12068.T_QUS_WEIGHT, t12068.T_DISP_SEQ, t12068.T_DIFFERAL_DAY, t12068.T_SEX, t12068.T_IF_FAIL, t12068.T_EXP_ANS, t12068.T_ACTIVE, t12068.T_QNO))
                {
                    obj.CommitTransaction();
                    msg = "u";
                }
                else
                {
                    obj.RollbackTransaction();
                    msg = "f";
                }
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return msg;
        }

        public string DeleteT12068(t12068 t12068)
        {
            //string msg = "";
            //bool isDelete = false;
            //obj.BeginTransaction();
            //if (obj.DeleteT12068(t12068.T_QNO))
            //{
            //    obj.CommitTransaction();
            //    msg = "d";
            //}
            //else
            //{
            //    obj.RollbackTransaction();
            //    msg = "f";
            //}
            //return msg;



            string msg = "";

            try
            {
                bool isDelete = false;
                obj.BeginTransaction();
                if (obj.DeleteT12068(t12068.T_QNO))
                {
                    obj.CommitTransaction();
                    msg = "d";
                }
                else
                {
                    obj.RollbackTransaction();
                    msg = "f";
                }
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return msg;
        }

        public string InsertT12069(t12068 t12069)
        {
            //string msg = "";
            //string user = HttpContext.Current.Session["T_ENTRY_USER"].ToString();
            //bool isInsert = false;
            //obj.BeginTransaction();
            //if (obj.InsertT12069(user, t12069.T_QHEAD_NO, t12069.T_LANG2_NAME, t12069.T_LANG1_NAME))
            //{
            //    obj.CommitTransaction();
            //    msg = "s";
            //}
            //else
            //{
            //    obj.RollbackTransaction();
            //    msg = "f";
            //}
            //return msg;


            string msg = "";

            try
            {
                string user = HttpContext.Current.Session["T_ENTRY_USER"].ToString();
                bool isInsert = false;
                obj.BeginTransaction();
                if (obj.InsertT12069(user, t12069.T_QHEAD_NO, t12069.T_LANG2_NAME, t12069.T_LANG1_NAME))
                {
                    obj.CommitTransaction();
                    msg = "s";
                }
                else
                {
                    obj.RollbackTransaction();
                    msg = "f";
                }
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return msg;

        }
    }
}