using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Initialization
{
    public interface IT01004
    {
        DataTable GetGridData();
        string insertData(M01004 tM01004,string user);
       
    }
}
