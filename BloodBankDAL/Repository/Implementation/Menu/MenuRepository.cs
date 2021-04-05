using BloodBankDAL.Repository.Interface.Menu;
using BloodBankDAL.Repository.Query.Menus;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Implementation.Menu
{
    public class MenuRepository : IMenu
    {
        private MenuQuery obj = new MenuQuery();

        public MenuRepository(MenuQuery _obj)
        {
            obj = _obj;
        }
        public MenuRepository()
        {
        }
        public DataTable FormAuthorization(string T_FORM_CODE, string T_USER_ID, string T_ROLE_CODE)
        {
            var Data = obj.FormAuthorization(T_FORM_CODE, T_USER_ID, T_ROLE_CODE);
            return Data;
        }
        public bool FormAuth(string T_FORM_CODE, string T_EMP_CODE, string T_ROLE_CODE)
        {
            var Data = obj.FormAuth(T_FORM_CODE, T_EMP_CODE, T_ROLE_CODE);
            return Data;
        }
        public DataTable MenuData(string lang, string T_LINK_SEPERATION, string T_ROLE_CODE)
        {
            var Data = obj.MenuData(lang, T_LINK_SEPERATION, T_ROLE_CODE);
            if (lang == "1" && T_ROLE_CODE == "0121" && T_LINK_SEPERATION == "1")
            {
                Data.Rows[1]["T_LINK_TEXT"] = "T12213";
            }
            return Data;
        }
        public DataTable GetAllUserMsg(string LANGUAGE)
        {
            var Data = obj.GetAllUserMsg(LANGUAGE);
            return Data;
        }

        public string getServerName()
        {
            var data = obj.getServerName();
            return data;
        }
        //public DataTable Logout()
        //{
        //    string id = null;
        //    if (HttpContext.Current.Session["T_LOGIN_NAME"] != null)
        //    {
        //        var sessiondata = HttpContext.Current.Session["T_LOGIN_NAME"];
        //        id = HttpContext.Current.Session["T_LOGIN_NAME"].ToString();
        //        var data = obj.loginData(id);
        //        return data;
        //    }
        //}
        public string updateForm(string user, string form)
        {
            var Data = obj.updateForm(user, form);
            return Data;
        }
        public string LogoutT92(string emp)
        {
            var Data = obj.LogoutT92(emp);
            return Data;
        }
    }
}