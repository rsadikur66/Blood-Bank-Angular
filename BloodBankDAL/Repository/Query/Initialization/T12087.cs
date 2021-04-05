using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Initialization
{
    public class T12087 :CommonDAL
    {
        public DataTable GetGridData()
        {
            return Query($"SELECT T_VITAL_CODE,T_NORML_VALUE, T_MIN_VALUE,T_MAX_VALUE,T_VTL_SIGNS FROM T02087 ORDER BY T_VITAL_CODE ASC");
        }
        public DataTable GetGridDataChild(string T_VITAL_CODE,string lang)
        {
            return Query($"SELECT T02087.T_VITAL_CODE,  T02087.T_NORML_VALUE,  T02087.T_MIN_VALUE,  T02087.T_MAX_VALUE,  T02087.T_VTL_SIGNS,  T12137.T_RES_CODE,  T12137.T_LANG{lang}_NAME T_LANG_NAME,  T12137.T_VITAL_CODE FROM T12137 INNER JOIN T02087 ON T12137.T_VITAL_CODE   =T02087.T_VITAL_CODE WHERE T02087.T_VITAL_CODE='{T_VITAL_CODE}' ORDER BY T02087.T_VITAL_CODE ASC");
        }

        public string Update_T12087(List<t12087> t12087, List<M12087> M12087, string user, string lang)
        {
            string msg = "";
            int count = 0;
            BeginTransaction();
            foreach (var list1 in t12087)
            {
                if (Command(
                    $"UPDATE T02087 SET T_UPD_USER='{user}',T_UPD_DATE=TRUNC(SYSDATE),T_MIN_VALUE='{list1.T_MIN_VALUE}',T_MAX_VALUE='{list1.T_MAX_VALUE}',T_NORML_VALUE='{list1.T_NORML_VALUE}' WHERE T_VITAL_CODE='{list1.T_VITAL_CODE}'"))
                    foreach (var list2 in M12087)
                    {
                        if (list1.T_VITAL_CODE == list2.T_VITAL_CODE)
                        {
                            if (Command(
                                $"UPDATE T12137 SET T_UPD_USER = '{user}', T_UPD_DATE = TRUNC(SYSDATE), T_LANG{lang}_NAME='{list2.T_LANG_NAME}' WHERE T_VITAL_CODE = '{list1.T_VITAL_CODE}'AND T_RES_CODE = '{list2.T_RES_CODE}'")
                            ) ;
                        }
                    }
                count = 1;
            }
            if(count==1)
            {
                CommitTransaction();
                msg = "N0041";
            }
            else
            {
                RollbackTransaction();
                msg = "N0072";
            }
            return msg;
        }
    }
}




//UPDATE T12137 SET T_UPD_USER = '{user}', T_UPD_DATE = TRUNC(SYSDATE), T_LANG{lang}_NAME='{M12087.T_LANG_NAME}' WHERE T_VITAL_CODE = '{list1.T_VITAL_CODE}'AND T_RES_CODE = '{M12087.T_RES_CODE}'