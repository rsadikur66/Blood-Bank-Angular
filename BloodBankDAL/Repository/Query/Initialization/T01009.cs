using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Initialization
{
    public class T01009 : CommonDAL
    {
        public DataTable GetAllUserData(string siteCode)
        {
            return Query($"SELECT T_EMP_CODE,t_login_name,t_pwd,T_USER_NAME,T_X_DEPT_CODE,(SELECT T_LANG2_NAME FROM T02042 WHERE T_LOC_CODE=t01009.T_X_DEPT_CODE)T_X_DEPT_NAME,T_ROLE_CODE,(SELECT t01007.T_ROLE_NAME FROM t01007 WHERE T01007.T_ROLE_CODE=T01009.T_ROLE_CODE) ROLE_NAME,T_USER_LANG,T_MACH_RESTR,T_PH_EXT,T_MOBILE_NO,T_NTNLTY_ID,T_SITE_CODE,T_HOSPITAL_CODE,T_ACTIVE_FLAG FROM t01009 WHERE T_SITE_CODE ={siteCode}");
        }
    }
}
