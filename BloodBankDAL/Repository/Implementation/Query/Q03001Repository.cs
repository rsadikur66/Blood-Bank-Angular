using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Repository.Interface.Query;
using BloodBankDAL.Repository.Query.Initialization;
using BloodBankDAL.Repository.Query.Query;

namespace BloodBankDAL.Repository.Implementation.Query
{
    public class Q03001Repository: IQ03001
    {
        private readonly Q03001 obj = new Q03001();
        public Q03001Repository(Q03001 _obj)
        {
            obj = _obj;
        }
        public DataTable GridData(int pageIndex, int pageSize, string lang)
        {
            //var obj = this.obj.GridData( pageIndex, pageSize,lang);
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GridData(pageIndex, pageSize, lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetPatientData_Search_Count(string searchValue, int pageIndex, int pageSize, string lang)
        {
            //var obj = this.obj.GetPatientData_Search_Count(searchValue,  pageIndex,  pageSize,lang);
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetPatientData_Search_Count(searchValue, pageIndex, pageSize, lang);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public DataTable GetPatientInfo_Search(string searchValue, int pageIndex, int pageSize, string lang)
        {
            //var obj = this.obj.GetPatientInfo_Search(searchValue, pageIndex, pageSize,lang);
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetPatientInfo_Search(searchValue, pageIndex, pageSize, lang);
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