using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Initialization
{
    public interface IT12033
    {
        DataTable GetGridData();

        string Insert_T12033(t12033 t12033, string user);
    }
}