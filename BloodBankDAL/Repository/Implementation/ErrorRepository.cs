using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Query;

namespace BloodBankDAL.Repository.Implementation.Menu
{
   public class ErrorRepository : CommonDAL, IError
    {

        public string SetServerErrorLog(string controller, string action, string user, string message)
        {
            return setServerErrorLog(controller, action, user, message);
        }


    }
}
