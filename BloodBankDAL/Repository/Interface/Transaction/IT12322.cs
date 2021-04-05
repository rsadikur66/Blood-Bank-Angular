using BloodBankDAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Transaction
{
   public interface IT12322
   {
        DataTable GetProductList();
        DataTable GetReasonList(string lang);
        DataTable GetSingleUnit(string unit, string lang);
        string saveList(List<T12320> t23List, string user, string lang);
    }
}
