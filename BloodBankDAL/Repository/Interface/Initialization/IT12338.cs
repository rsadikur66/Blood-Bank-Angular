using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Initialization
{
    public interface IT12338
    {
        DataTable GetCentralBankList(string lang);
        DataTable GetTransfusionsList(string bankCode);
        string InsertToT12338(M12338 t12338, string user);
    }
}
