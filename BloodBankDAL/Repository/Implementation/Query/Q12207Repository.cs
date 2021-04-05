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
    public class Q12207Repository:IQ12207
    {
        private readonly Q12207 obj = new Q12207();

        public Q12207Repository(Q12207 _obj)
        {
            obj = _obj;
        }
        public DataTable GetGridData()
        {
            var data = new DataTable();
            try
            {
                data = this.obj.GetGridData();
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