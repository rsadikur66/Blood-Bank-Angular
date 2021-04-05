using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using BloodBankDAL.Repository.Interface.Initialization;
using BloodBankDAL.Repository.Query.Initialization;

namespace BloodBankDAL.Repository.Implementation.Initialization
{
    public class T12337Repository : IT12337
    {
        private readonly T12337 obj = new T12337();
        public T12337Repository(T12337 _obj)
        {
            obj = _obj;
        }
        public T12337Repository()
        {

        }

        public DataTable GetZoneList(string lang)
        {
            //var data = obj.GetZoneList(lang);
            //return data;

            var data = new DataTable();

            try
            {
                data = obj.GetZoneList(lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;

        }
        public DataTable GetBankTypeList(string lang)
        {
            //var data = obj.GetBankTypeList(lang);
            //return data;

            var data = new DataTable();

            try
            {
                data = obj.GetBankTypeList(lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }
        public DataTable GetSiteList(string lang)
        {
            //var data = obj.GetSiteList(lang);
            //return data;

            var data = new DataTable();

            try
            {
                data = obj.GetSiteList(lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetGridListData()
        {
            //var data = obj.GetGridListData();
            //return data;

            var data = new DataTable();

            try
            {
                data = obj.GetGridListData();
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public string InsertToT12337(M12337 t12337, string user, string siteCode)
        {
            //string msg = "";
            //var dt = obj.CheckExistOrNot(t12337);
            //obj.BeginTransaction();
            //if (dt.Rows.Count == 0)
            //{
            //    if (obj.InsertToT12337(t12337, user, siteCode))
            //    {
            //        obj.CommitTransaction();
            //        msg = "Data Saved Successfully";
            //    }
            //    else
            //    {
            //        obj.RollbackTransaction();
            //        msg = "Data Not Saved";
            //    }
            //}
            //else if(dt.Rows.Count > 0)
            //{
            //    if (obj.UpdateToT12337(t12337, user, siteCode))
            //    {
            //        obj.CommitTransaction();
            //        msg = "Data Updated Successfully";
            //    }
            //    else
            //    {
            //        obj.RollbackTransaction();
            //        msg = "Data Not Updated";
            //    }
            //}

            //return msg;



            string msg = "";

            try
            {
                var dt = obj.CheckExistOrNot(t12337);
                obj.BeginTransaction();
                if (dt.Rows.Count == 0)
                {
                    if (obj.InsertToT12337(t12337, user, siteCode))
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
                else if (dt.Rows.Count > 0)
                {
                    if (obj.UpdateToT12337(t12337, user, siteCode))
                    {
                        obj.CommitTransaction();
                        msg = "Data Updated Successfully";
                    }
                    else
                    {
                        obj.RollbackTransaction();
                        msg = "Data Not Updated";
                    }
                }
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return msg;
        }


        //public string UpdateToT12337(M12337 t12337, string user, string siteCode)
        //{
        //    string msg = "";
        //    var dt = obj.CheckExistOrNot(t12337);
        //    obj.BeginTransaction();
        //    if (dt.Rows.Count > 0)
        //    {
        //        if (obj.UpdateToT12337(t12337, user, siteCode))
        //        {
        //            obj.CommitTransaction();
        //            msg = "Data Updated Successfully";
        //        }
        //        else
        //        {
        //            obj.RollbackTransaction();
        //            msg = "Data Not Updated";
        //        }
        //    }
            
        //    return msg;
        //}
    }
}