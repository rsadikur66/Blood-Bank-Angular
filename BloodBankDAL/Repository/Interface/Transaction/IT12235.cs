using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Transaction
{
   public interface IT12235
   {
        //For Unit From and Unit To Data
        DataTable GetUnitData(string siteCode);

       //For Blood Data
        DataTable GetBloodData(string language);

        //For Antibody Data
       DataTable GetAntibodyData();

       //For Dropdown Du Data
        DataTable GetDuData();

       //For Grid Data
        DataTable GetGridData(string language, string unitFrom, string unitTo);

       //For Get Verifid Data
       DataTable GetVerifidData(string entryUser, string empCode, string roleCode);

       string InsertT12220(List<t12220> t12235, string user, string lang);
        
    }
}   
