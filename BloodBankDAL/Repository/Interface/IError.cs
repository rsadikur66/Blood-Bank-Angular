using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BloodBankDAL.Repository.Interface
{
    public interface IError
    {
        string SetServerErrorLog(string controller, string action, string user, string message);

    }
}
