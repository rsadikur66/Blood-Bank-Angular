using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    using System.Data;

    using BloodBankDAL.Model;
    using BloodBankDAL.Repository.Interface.Transaction;
    using BloodBankDAL.Repository.Query.Transaction;
    public class T12236Repository : IT12236
    {
        private readonly T12236 obj = new T12236();
        public T12236Repository(T12236 _obj) : base()
        {
            obj = _obj;
        }

        public DataTable GetUnitNo(string T_UNIT_FROM, string T_UNIT_TO, string LANG)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetUnitNo(T_UNIT_FROM, T_UNIT_TO, LANG);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetUnitNo(T_UNIT_FROM, T_UNIT_TO, LANG);
            //return obj;
        }
        public DataTable GetBloodGroupList(string LANG)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.GetBloodGroupList(LANG);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.GetBloodGroupList(LANG);
            //return obj;
        }
        public DataTable CheckABOCode(string T_ABO_CODE, string T_UNIT_NO)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = this.obj.CheckABOCode(T_ABO_CODE, T_UNIT_NO);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
            //var obj = this.obj.CheckABOCode(T_ABO_CODE, T_UNIT_NO);
            //return obj;
        }

        public string updateT12019(List<T12019> t12019, string T_CONFIRM_VERIFY_BY)
        {
            string msg = "";
            string user = "2345";
            bool isUpdate = false;

           // DataTable dt = new DataTable();
            try
            {
                obj.BeginTransaction();
                for (int i = 0; i < t12019.Count; i++)
                {
                    if (this.obj.updateT12019(t12019[i].T_ABO_CODE, t12019[i].UnitFrom) && this.obj.updateT12075(t12019[i].UnitFrom, T_CONFIRM_VERIFY_BY))
                    {
                        isUpdate = true;
                    }
                }
                if (isUpdate)
                {
                    msg = "Data save successfully";
                    obj.CommitTransaction();
                }
                else
                {
                    msg = "Save failed";
                    obj.RollbackTransaction();
                }

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return msg;
            //obj.BeginTransaction();
            //for (int i = 0; i < t12019.Count; i++)
            //{
            //    if (this.obj.updateT12019(t12019[i].T_ABO_CODE, t12019[i].UnitFrom) && this.obj.updateT12075(t12019[i].UnitFrom, T_CONFIRM_VERIFY_BY))
            //    {
            //        isUpdate = true;
            //    }
            //}
            //if (isUpdate)
            //{
            //    msg = "Data save successfully";
            //    obj.CommitTransaction();
            //}
            //else
            //{
            //    msg = "Save failed";
            //    obj.RollbackTransaction();
            //}
            //return msg;

        }

    }
}