using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Query
{
    public interface IQ12252
    {
        DataTable GetDataByUnitNo(string P_UNIT_NO);
        DataTable GetDataByDonor1(string P_DONOR_ID);
        DataTable GetDataByDonor2(string P_DONOR_ID, string lang);
    }
}
