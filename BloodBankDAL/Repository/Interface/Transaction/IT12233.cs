using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Transaction
{
   public interface IT12233
   {
       DataTable GetGridData(string unitno, string lang, string language);

       DataTable GetVerifyData(string lang);

        DataTable GetUnitData();

       string Insert_T13016(List<t12233> t12233, string user, string lang);
   }
}
