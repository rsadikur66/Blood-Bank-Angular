using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Interface
{
    public interface IT12244 
    {
       DataTable getPatNo(string P_PAT_NO, string T_SITE_CODE);
        DataTable getQuestions(int type, string P_SEX, string P_PAT_NO);
       DataTable getConsent(int type);
       string insert(CommonModel t12017);
       string singleInsert(CommonModel t71);
         DataTable testPrint();
    }
}
