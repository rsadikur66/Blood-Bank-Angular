using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    public interface IT12241
    {
        DataTable GridResultVirology(string UnitNoFrom, string UnitNoTo,string lang, string siteCode);
        DataTable DocEmpCode(string usercode);
        DataTable GetUnitPopUpData();
        bool updateVirologyResults(string unitNo,string siteCode);
        bool InsertT12223(string unitNo, string sitecode);



    }
}
