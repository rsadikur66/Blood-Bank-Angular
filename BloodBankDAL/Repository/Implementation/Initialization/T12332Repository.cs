using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface.Initialization;
using BloodBankDAL.Repository.Query.Initialization;

namespace BloodBankDAL.Repository.Implementation.Initialization
{
    public class T12332Repository:IT12332
    {
        private readonly T12332 obj = new T12332();

        public T12332Repository(T12332 _obj) : base()
        {
            obj = _obj;
        }

        public T12332Repository()
        {
        }
       
        public DataTable GetGridData(string unittype, string english, string local, string bag)
        {
            //var obj = this.obj.GetGridData(unittype, english, local, bag);
            //return obj;

            var data = new DataTable();

            try
            {
                data = this.obj.GetGridData(unittype, english, local, bag);
            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }

            return data;
        }

        public string Insert_T12332(t12073 t12073, string user)
        {
            //var Data = obj.Insert_T12332(t12073, user);
            //return Data;

            var data = "";

            try
            {
                data = obj.Insert_T12332(t12073, user);
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