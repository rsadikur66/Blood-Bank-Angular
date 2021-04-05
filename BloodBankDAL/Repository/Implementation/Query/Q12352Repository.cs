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
    public class Q12352Repository: IQ12352
    {
        private readonly Q12352 obj = new Q12352();
        public Q12352Repository(Q12352 _obj) : base()
        {
            obj = _obj;
        }
        public DataTable GetChartData(string productCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetChartData(productCode);

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return dt;
        }
    }
}