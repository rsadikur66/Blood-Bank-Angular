using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Transaction
{
   public interface IT12252
    {
        DataTable getGridData(string lang, string unitId);
        string SaveData(List<T12223> t23List, string welId);
        DataTable pickUpData(string fdate, string tdate,string Seq, string lang);
    }
}
