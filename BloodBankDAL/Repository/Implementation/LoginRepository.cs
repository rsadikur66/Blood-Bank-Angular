using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Query;

namespace BloodBankDAL.Repository.Implementation.Menu
{
    public class LoginRepository : ILogin
    {

        private readonly Login obj = new Login();
        //private readonly CommonDAL obj = new Login();

        public LoginRepository(Login _obj)
        {
            obj = _obj;
        }

        public LoginRepository()
        {
        }

        public DataTable GetLabelText(string T_FORM_NAME, string LANGUAGE)
        {
            var Data = obj.GetLabelText(T_FORM_NAME, LANGUAGE);
            return Data;
        }

        public DataTable CheckLogin(string T_LOGIN_NAME, string T_PWD)
        {
            var Data = obj.CheckLogin(T_LOGIN_NAME, T_PWD);
            return Data;
        }
        public string logT92(string userId)
        {
            var Data = obj.logT92(userId);
            return Data;
        }

    }
}
