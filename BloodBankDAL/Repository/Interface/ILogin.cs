using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BloodBankDAL.Repository.Interface
{
    public interface ILogin
    {
        DataTable GetLabelText(string T_FORM_NAME, string LANGUAGE);

        DataTable CheckLogin(string T_LOGIN_NAME, string T_PWD);
        string logT92(string userId);
    }
}
