using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BloodBankDAL.Repository.Interface.Menu
{
    public interface IMenu
    {
        DataTable FormAuthorization(string T_USER_ID, string T_FORM_CODE, string T_ROLE_CODE);
        bool FormAuth(string T_FORM_CODE, string T_EMP_CODE, string T_ROLE_CODE);
        DataTable MenuData(string language, string T_LINK_SEPERATION, string T_ROLE_CODE);
        DataTable GetAllUserMsg(string LANGUAGE);
        string getServerName();
        string updateForm(string user, string form);
        string LogoutT92(string emp);
        //DataTable Logout();
    }
}
