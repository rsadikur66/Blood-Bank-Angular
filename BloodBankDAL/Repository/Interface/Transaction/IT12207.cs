using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    public interface IT12207
    {
        DataTable GetRefHospital(string siteCode, string lang);

        DataTable GetBlood(string lang);

        DataTable GetProduct(string lang);
        DataTable GetGridDataForTransfusion(string siteCode);

        string Insert_T12207(t12207 t12207, string user, string siteCode);
        string BloodReceiveFromTransfusion(string del, string blNo, string user,string siteCode);
    }
}
