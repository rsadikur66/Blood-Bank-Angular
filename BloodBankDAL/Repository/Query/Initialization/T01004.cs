using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BloodBankDAL.Model;

namespace BloodBankDAL.Repository.Query.Initialization
{
    public class T01004 : CommonDAL
    {
        public CommonDAL _commonDal = new CommonDAL();

        public DataTable GetGridData()
        {
            return Query("Select T_MSG_CODE,T_LANG1_MSG,T_LANG2_MSG from T01004");
        }

        public DataTable CheckExistOrNot(M01004 tM01004)
        {
            return Query($"Select * from T01004 where T_MSG_CODE = '{tM01004.T_MSG_CODE}'");
        }
        public bool insertData(M01004 tM01004,string user)
        {
            Command($"INSERT INTO T01004 ( T_ENTRY_USER,T_ENTRY_DATE,T_MSG_CODE,T_LANG1_MSG,T_LANG2_MSG) VALUES ('{user}',TRUNC(SYSDATE),'{tM01004.T_MSG_CODE}','{tM01004.T_LANG1_MSG}','{tM01004.T_LANG2_MSG}')");
            return true;
        }
        public bool updateData(M01004 tM01004,string user)
        {
             Command($"UPDATE T01004 SET T_UPD_USER='{user}',T_UPD_DATE=TRUNC(SYSDATE),T_LANG1_MSG='{tM01004.T_LANG1_MSG}',T_LANG2_MSG='{tM01004.T_LANG2_MSG}' WHERE T_MSG_CODE = '{tM01004.T_MSG_CODE}'");
            return true;
        }
    }
}