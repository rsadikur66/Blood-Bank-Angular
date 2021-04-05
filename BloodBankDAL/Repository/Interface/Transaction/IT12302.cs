using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface.Transaction
{
    public interface IT12302
    {
        DataTable reqList(string lang, string site, string req);
        DataTable reqDet(string lang, string site, string req);
        DataTable bgList(string lang, string code);
        DataTable techList(string site, string code);
        DataTable antTypAutoList(string lang, string code, string type);
        DataTable antTypFinalList(string lang, string code,string type);
        DataTable antiList();
        DataTable dctList(string lang);
        DataTable getbgByControl(string lang, string P_ANTI_A, string P_ANTI_B, string P_ANTI_D, string P_CONTROL);
        DataTable getbgByControl6(string lang, string P_ANTI_A, string P_ANTI_B, string P_ANTI_D, string P_CONTROL, string P_ACELL, string P_BCELL);
        DataTable checkBg(string P_PAT_NO, string lang);
        DataTable checkT_SC(string P_PAT_NO, string site);
        int chkDoctor(string P_EMP_CODE, string P_SITE_CODE);

        DataTable unitList(string P_PAT_NO, string P_SITE_CODE, string P_PHENO, string P_REQUISITION, string P_ABO_CODE,
            string P_UNIT_NO, string P_REQUEST_NO, string lang);

        string insert(T12013 t12013, List<T12256> t12256);
        DataTable getUserId(string site, string emp,string lang);
        DataTable checkBlood(string patId);
    }
}
