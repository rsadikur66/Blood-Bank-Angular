using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Initialization
{
   public interface IT12281
    {
        DataTable GetAllData(string lang);
        DataTable GetAllUnitData(string lang);
        string SaveData(M12281 t12281,string lang,string user);
    }
}
