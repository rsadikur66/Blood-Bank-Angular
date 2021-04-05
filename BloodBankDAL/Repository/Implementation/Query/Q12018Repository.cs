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
    public class Q12018Repository:IQ12018
    {
        private readonly Q12018 obj = new Q12018();
        public Q12018Repository(Q12018 _obj)
        {
            obj = _obj;
        }
        public Q12018Repository()
        {

        }
        public DataTable GetFirstGrid(string unitNo)
        {
            var data = new DataTable();

            try
            {
                data = obj.GetFirstGrid(unitNo);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }
        public DataTable GetSecondGrid(string unitNo)
        {
            var data = new DataTable();

            try
            {
                data = obj.GetSecondGrid(unitNo);
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