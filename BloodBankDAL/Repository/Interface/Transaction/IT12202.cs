using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    public interface IT12202
    {
        DataTable getPatDetail(string P_PAT_NO,string P_NTNLTY_ID, string l, string T_SITE_CODE);
        DataTable getQues(string P_PAT_NO,string P_NTNLTY_ID,int P_REQUEST_ID, string l, string P_SEX);
        DataTable getValidation(string P_VITAL_CODE, decimal Value, string l);
        string insert(T12022 t12022,  string t, string u);
        int singleInsert(T12071 t71);
        DataTable GetUnitData(string unitNo);
    }
}
