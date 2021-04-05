using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Initialization
{
   public interface IT01009
   {
       DataTable GetAllUserData(string siteCode);
   }
}
