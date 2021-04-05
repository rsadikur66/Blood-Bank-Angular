using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Repository.Interface.Query;
using BloodBankDAL.Repository.Query.Query;

namespace BloodBankDAL.Repository.Implementation.Query
{
    public class Q12200Repository:IQ12200
    {
        private readonly Q12200 obj = new Q12200();

      public  Q12200Repository(Q12200 _obj)
        {
            obj = _obj;
        }
        public DataTable GetGridData(string dateParam)
        {
            var data = new DataTable();
            try
            {
                data = this.obj.GetGridData(dateParam);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
                throw;
            }
            return data;
        }

        public DataTable GetReportInfo()
        {
            var data = new DataTable();
            try
            {
                data = this.obj.GetReportInfo();
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
                throw;
            }
            return data;
        }

        public DataTable GetReportData()
        {
            var data = new DataTable();
            try
            {
                data = this.obj.GetReportData();
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
                throw;
            }
            return data;
        }
    }
}