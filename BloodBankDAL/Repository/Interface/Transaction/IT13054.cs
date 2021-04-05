using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Transaction
{
   public interface IT13054
   {
       DataTable test();
       DataTable GetModelData(string lang); 
   }
}
