using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    public interface IT12264
    {
        DataTable GetDataWithRequestNo(string T_REQ_NO,  string siteCode,string empCode,string userName);

        string T12264updateT12067andT12065(M12264 t12264, string user, string siteCode);
    }
}
