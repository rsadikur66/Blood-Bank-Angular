using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Repository.Interface.Report;
using BloodBankDAL.Repository.Query.Report;

namespace BloodBankDAL.Repository.Implementation.Report
{
    public class R12016Repository:IR12016
    {
        private readonly R12016 obj = new R12016();
        public R12016Repository(R12016 _obj) : base()
        {
            obj = _obj;
        }
        public R12016Repository()
        {
        }
        public DataTable getUnit(string T_SITE_CODE)
        {
            //var Data = obj.getUnit(T_SITE_CODE);
            //return Data;

            var data = new DataTable();

            try
            {
                data = obj.getUnit(T_SITE_CODE);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }
        public DataTable getPRCode(string l, string from, string to)
        {
            //var Data = obj. getPRCode(l,from,to);
            //return Data;

            var data = new DataTable();

            try
            {
                data = obj.getPRCode(l, from, to);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }
        public DataTable getReport(string l, string from, string to, string prod)
        {
            //var Data = obj.getReport(l,from,to,prod);
            //return Data;

            var data = new DataTable();

            try
            {
                data = obj.getReport(l, from, to, prod);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }
    }
}