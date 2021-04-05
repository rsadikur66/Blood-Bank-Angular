using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    public interface IT12309
    {
        DataTable GetUnitData();
        DataTable GetProductDetails(string unitNo, string prodCode, string lang);
        string SaveData(M12309 t12309,string user,string siteCode);
    }
}
