using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Initialization
{
   public interface IT12332
   {
       DataTable GetGridData(string unittype, string english, string local, string bag);
       string Insert_T12332(t12073 t12073, string user);
   }
}
