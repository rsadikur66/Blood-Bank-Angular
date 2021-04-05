using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BloodBankDAL.Repository.Query.Transaction
{
    public class T13054:CommonDAL
    {
        public DataTable test()
        {
            return Query("select * from (select t_pat_no, rownum r from t03001) t where r<20000");
        }

        public DataTable GetModelData(string lang)
        {
            return Query($"SELECT T_MODEL_CODE  ,T13050.T_LANG{lang}_NAME  || ' - '|| T13049.T_LANG{lang}_NAME ||' - '|| T13004.T_LANG{lang}_NAME ANALYZER_MODEL FROM T13049,T13050,T13004 WHERE T13049.T_ANALYZER_ID = T13050.T_ANALYZER_ID AND T13004.T_WS_CODE = T13050.T_WS_CODE AND T13004.T_WS_CODE = '22'");
        }
    }
}