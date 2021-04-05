using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Repository.Interface.Transaction;
using BloodBankDAL.Repository.Query.Transaction;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    public class T12003Repository:IT12003
    {
        private readonly T12003 obj = new T12003();
        public T12003Repository(T12003 _obj) : base()
        {
            obj = _obj;
        }

        public DataTable GetHospitalListData()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetHospitalListData();
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var data = obj.GetHospitalListData();
            //return data;
        }

        public DataTable GetProductWithUnitNo(string unitNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetProductWithUnitNo(unitNo);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var data = obj.GetProductWithUnitNo(unitNo);
            //return data;
        }
        
        public DataTable GetProductListData(string unitNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetProductListData(unitNo);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return dt;
            //var data = obj.GetProductListData(unitNo);
            //return data;
        }

    }
}