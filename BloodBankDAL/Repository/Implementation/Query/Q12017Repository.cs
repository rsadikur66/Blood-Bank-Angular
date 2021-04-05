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
    public class Q12017Repository:IQ12017
    {
        private readonly Q12017 obj = new Q12017();
        public Q12017Repository(Q12017 _obj)
        {
            obj = _obj;
        }
        public DataTable GetAllData(string REQUEST_NO, string lang)
        {
            var data = new DataTable();
            
            try
            {
                data = this.obj.GetAllData(REQUEST_NO, lang);
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