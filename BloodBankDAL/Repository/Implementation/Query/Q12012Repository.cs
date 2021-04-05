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
    public class Q12012Repository : IQ12012
    {
        private readonly Q12012 obj = new Q12012();
        public Q12012Repository(Q12012 _obj)
        {
            obj = _obj;
        }
        public Q12012Repository()
        {

        }
        public DataTable getAllXMatchData(string lang, string site, string req)
        {
            //var obj = this.obj.getAllXMatchData(lang, site, req);
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.getAllXMatchData(lang, site, req);
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