using BloodBankDAL.Repository.Interface.Query;
using BloodBankDAL.Repository.Query.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BloodBankDAL.Repository.Implementation.Query
{
    public class Q12263Repository : IQ12263
    {
        private readonly Q12263 obj = new Q12263();
        public Q12263Repository(Q12263 _obj) : base()
        {
            obj = _obj;
        }
       public DataTable GetGridData(string siteCode, string referCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obj.GetGridData(siteCode, referCode);

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