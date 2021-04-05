using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Initialization
{
    public interface IT12087
    {
        DataTable GetGridData();

        DataTable GetGridDataChild(string viralCode, string lang);

        string Update_T12087(List<t12087> t12087, List<M12087> M12087, string user, string lang);
    }
}
