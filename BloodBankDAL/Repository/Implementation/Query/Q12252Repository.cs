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
    public class Q12252Repository:IQ12252
    {
        private readonly Q12252 obj = new Q12252();
        public Q12252Repository(Q12252 _obj)
        {
            obj = _obj;
        }
        public DataTable GetDataByUnitNo(string P_UNIT_NO)
        {
            var data = new DataTable();

            try
            {
                data = this.obj.GetDataByUnitNo(P_UNIT_NO);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return data;
        }
        public DataTable GetDataByDonor1(string P_DONOR_ID)
        {
            var data = new DataTable();

            try
            {
                data = this.obj.GetDataByDonor1(P_DONOR_ID);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return data;
        }
        public DataTable GetDataByDonor2(string P_DONOR_ID, string lang)
        {
            var data = new DataTable();

            try
            {
                data = this.obj.GetDataByDonor2(P_DONOR_ID, lang);
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