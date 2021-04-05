using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodBankDAL.Repository.Interface.Initialization;
using BloodBankDAL.Repository.Query.Initialization;

namespace BloodBankDAL.Repository.Implementation.Initialization
{
    public class T12199Repository: IT12199
    {
        private readonly T12199 obj = new T12199();
        public T12199Repository(T12199 _obj)
        {
            obj = _obj;
        }
        public T12199Repository()
        {
        }
    }
}