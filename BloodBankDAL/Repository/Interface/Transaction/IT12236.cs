using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    using System.Data;

    using BloodBankDAL.Model;

    public interface IT12236
    {
        DataTable GetUnitNo(string T_UNIT_FROM, string T_UNIT_TO, string LANG);

        DataTable GetBloodGroupList(string LANG);

        DataTable CheckABOCode(string T_ABO_CODE, string T_UNIT_NO);

        string updateT12019(List<T12019> t12019,string T_CONFIRM_VERIFY_BY);
    }
}
