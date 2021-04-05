using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Interface.Transaction;
using BloodBankDAL.Repository.Query.Transaction;

namespace BloodBankDAL.Repository.Implementation.Transaction
{
    public class T12264Repository : IT12264
    {
        private readonly T12264 obj = new T12264();
        public T12264Repository(T12264 _obj) : base()
        {
            obj = _obj;
        }

        public DataTable GetDataWithRequestNo(string tReqNo, string siteCode,string empCode,string userName)
        {
            var data = obj.GetDataWithRequestNo(tReqNo, siteCode,empCode, userName);
            return data;
        }

        public string T12264updateT12067andT12065(M12264 t12264, string user, string siteCode)
        {
            string msg = "";
            try
            {
                obj.BeginTransaction();
                if (obj.T12264updateT12067(t12264, user ))
                {
                    if (obj.T12264updateT12065(t12264, user, siteCode))
                    {
                        obj.CommitTransaction();
                        msg = "Data updated Successfully";
                    }
                }
                else
                {
                    obj.RollbackTransaction();
                    msg = "Data Not Saved";
                }

            }
            catch (Exception e)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                obj.Log(m.ReflectedType.Name + "." + m.Name, "1", e.Message);
            }
            return msg;
        }
    }
}