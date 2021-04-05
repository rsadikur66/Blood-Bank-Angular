using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Repository.Interface.Initialization;
using BloodBankDAL.Repository.Query.Initialization;

namespace BloodBankDAL.Repository.Implementation.Initialization
{
    public class T12028Repository:IT12028
    {
        private readonly T12028 obj = new T12028();
        public T12028Repository(T12028 _obj) : base()
        {
            obj = _obj;
        }
        
    }
}