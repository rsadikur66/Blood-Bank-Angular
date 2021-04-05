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
    public class T01004Repository: IT01004
    {
        private readonly T01004 obj = new T01004();
        public T01004Repository(T01004 _obj)
        {
            obj = _obj;
        }
        public T01004Repository()
        {
        }

        public DataTable GetGridData()
        {
            //var data = obj.GetGridData();
            //return data;

            var data=new DataTable();

            try
            {
                data = obj.GetGridData();
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;

        }
        public string insertData(M01004 tM01004,string user)
        {
            //string msg = "";
            //var dt = obj.CheckExistOrNot(tM01004);
            //obj.BeginTransaction();
            //if (dt.Rows.Count == 0)
            //{
            //    if (obj.insertData(tM01004,user))
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
            //    if (obj.updateData(tM01004,user))
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


            string msg = "";

            try
            {
                var dt = obj.CheckExistOrNot(tM01004);
                obj.BeginTransaction();
                if (dt.Rows.Count == 0)
                {
                    if (obj.insertData(tM01004, user))
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
                    if (obj.updateData(tM01004, user))
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