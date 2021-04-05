using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BloodBankDAL.Repository.Interface.Menu;
using BloodBankDAL.Repository.Implementation.Menu;

namespace BloodBank.Models
{
    public class AuthorizeUserAccessLevel: AuthorizeAttribute
    {       
        public string UserRole { get; set; }

        private IMenu repo = new MenuRepository();
        protected override bool AuthorizeCore(HttpContextBase httpcontext)
        {    
            var request = httpcontext.Request;
            string action = request.RequestContext.RouteData.Values["action"].ToString();
            string User = String.Empty;
            string Role = "";
            if (HttpContext.Current.Session["T_EMP_CODE"] != null){User = HttpContext.Current.Session["T_EMP_CODE"].ToString();}
            if (HttpContext.Current.Session["T_ROLE_CODE"] != null) { Role = HttpContext.Current.Session["T_ROLE_CODE"].ToString(); }
            DataTable dt=repo.FormAuthorization(action, User, Role);           
            if (dt.Rows.Count > 0){return true;}else{return false;}
        }

    }
}