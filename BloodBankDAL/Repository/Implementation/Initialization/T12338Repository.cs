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
    public class T12338Repository : IT12338
    {
        private readonly T12338 obj = new T12338();

        public T12338Repository(T12338 _obj)
        {
            obj = _obj;
        }
        public T12338Repository()
        {

        }

        public DataTable GetCentralBankList(string lang)
        {
            //var data = obj.GetCentralBankList(lang);
            //return data;

            var data = new DataTable();

            try
            {
                data = obj.GetCentralBankList(lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }
        public DataTable GetTransfusionsList(string bankCode)
        {
            var data = new DataTable();
            try
            {
                data = obj.GetTransfusionsList(bankCode);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return data;
        }
        public string InsertToT12338(M12338 t12338, string user)
        {
            //string msg = "";
            //var dt = obj.CheckExistOrNot(t12338);
            //obj.BeginTransaction();
            //if (dt.Rows.Count == 0)
            //{
            //    if (obj.InsertToT12338(t12338, user))
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
            //else if (dt.Rows.Count > 0)
            //{
            //    if (obj.UpdateToT12338(t12338, user))
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
                var dt = obj.CheckExistOrNot(t12338);
                obj.BeginTransaction();
                if (dt.Rows.Count == 0)
                {
                    if (obj.InsertToT12338(t12338, user))
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
                    if (obj.UpdateToT12338(t12338, user))
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
    }
}