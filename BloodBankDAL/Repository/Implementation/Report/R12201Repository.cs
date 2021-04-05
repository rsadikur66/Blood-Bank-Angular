using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Repository.Interface.Report;
using BloodBankDAL.Repository.Query.Report;

namespace BloodBankDAL.Repository.Implementation.Report
{
    public class R12201Repository:RI12201
    {
        private readonly R12201 obj = new R12201();
        public R12201Repository(R12201 _obj) : base()
        {
            obj = _obj;
        }

        public string GetArabicName(string patNo)
        {
            //var obj = this.obj.GetArabicName(patNo);
            //return obj;

            var data = "";

            try
            {
                data = this.obj.GetArabicName(patNo);
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