using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface.Transaction;
using BloodBankDAL.Repository.Query.Transaction;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    public class T12245Repository : IT12245
    {
        private readonly T12245 obj = new T12245();

        public T12245Repository(T12245 _obj) : base()
        {
            obj = _obj;
        }

        public DataTable GetCentrifugeList(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetCentrifugeList(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetCentrifugeList(lang);
            //return Data;
        }
        public DataTable GetProgramList(string lang)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetProgramList(lang);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;

            //var Data = obj.GetProgramList(lang);
            //return Data;
        }

        public DataTable GetGridDataList(string UnitNo,string donationDate,string segmentNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetGridDataList(UnitNo, donationDate, segmentNo);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;

            //var Data = obj.GetGridDataList(UnitNo, donationDate, segmentNo);
            //return Data;
        }
        public DataTable GetSegment(string UnitNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetSegment(UnitNo);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;

            //var Data = obj.GetSegment(UnitNo);
            //return Data;
        }

        public DataTable CheckUnitNo(string UnitNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.CheckUnitNo(UnitNo);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.CheckUnitNo(UnitNo);
            //return Data;
        }
        public DataTable SecondGetGridDataList(string UnitNo,string user)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.SecondGetGridDataList(UnitNo, user);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.SecondGetGridDataList(UnitNo, user);
            //return Data;
        }

        public DataTable GetMessagesList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetMessagesList();

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var Data = obj.GetMessagesList();
            //return Data;
        }

        //public DataTable GetGridDataList()
        //{
        //    var Data = obj.GetGridDataList();
        //    return Data;
        //}



        public string Insert(string user,t12135 T12135)
        {
           
            string msg = "";
            try
            {
                obj.BeginTransaction();
                if (obj.Insert(user, T12135))
                {
                    obj.CommitTransaction();
                    msg = "Data Saved Successfully";
                }
                else
                {
                    obj.RollbackTransaction();
                    msg = "Data Not Saved";
                }

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            //obj.BeginTransaction();
            //if (obj.Insert(user, T12135))
            //{
            //    obj.CommitTransaction();
            //    msg = "Data Saved Successfully";
            //}
            //else
            //{
            //    obj.RollbackTransaction();
            //    msg = "Data Not Saved";
            //}
            return msg;
        }
        public bool UpdateT12135(string UnitNo)
        {
            string user = HttpContext.Current.Session["T_EMP_CODE"].ToString();
            string msg = "";
            try
            {
                obj.BeginTransaction();
                if (obj.UpdateT12135(user, UnitNo))
                {
                    obj.CommitTransaction();
                    msg = "Data updated Successfully";
                }
                else
                {
                    obj.RollbackTransaction();
                    msg = "Data Not Saved";
                }

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            //obj.BeginTransaction();
            //if (obj.UpdateT12135(user, UnitNo))
            //{
            //    obj.CommitTransaction();
            //    msg = "Data updated Successfully";
            //}
            //else
            //{
            //    obj.RollbackTransaction();
            //    msg = "Data Not Saved";
            //}
            return true;
        }
        public string DeleteRowData(string T_UNIT_NO, string T_PRODUCT_CODE)
        {
            string msg = "";
            bool isDelete = false;
            try
            {
                obj.BeginTransaction();
                if (obj.DeleteRowData(T_UNIT_NO, T_PRODUCT_CODE))
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

            //obj.BeginTransaction();
            //if (obj.DeleteRowData(T_UNIT_NO,T_PRODUCT_CODE))
            //{
            //    obj.CommitTransaction();
            //    msg = "d";
            //}
            //else
            //{
            //    obj.RollbackTransaction();
            //    msg = "f";
            //}
            return msg;
        }
    }
}