using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using BloodBankDAL.Repository.Query.Initialization;

namespace BloodBankDAL.Repository.Interface.Initialization
{
    public interface IT12132
    {
        DataTable GetGridData();
        DataTable GetAllFormCodeData();
        string SaveData(M12132 t12132, string lang, string user);
    }
}
