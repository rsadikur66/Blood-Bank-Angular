using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Transaction
{
   public interface IT12325
    {
        DataTable GetVirus(string lang,string user);
        DataTable GetResulDes(string toString, string value);
        DataTable CheckUnitNo(string unit);
        string SaveData(string un, List<M12325> vairusList, string T_EMP_CODE,string lang);
        DataTable GetUnitNo();
        DataTable GerVirusResult(string lang);
        DataTable GetAllData(string toString, string unitNo);
    }
}
