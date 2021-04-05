using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;
using BloodBankDAL.Repository.Query.Initialization;


namespace BloodBankDAL.Repository.Interface.Initialization
{
    public interface IT12011
    {
        DataTable GetGridData(string lang);
        string Insert_T12011(t12011 t12011, string user);

    }
}
