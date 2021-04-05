using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Initialization
{
    public interface IT12246
    {
        //For Blood Data
        DataTable GetBloodData(string language);

        //For product Data
        DataTable GetProductData(string language);

        DataTable GetGridData(string language, string productCode, string bloodGroup);

        string Insert_T12211(List<t12246> t12246, string p, string b, string user);
        

    }
}
