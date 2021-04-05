using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Web;

namespace BloodBankDAL.Repository
{
    // using FastReport.DevComponents.DotNetBar;

    public class CommonDAL
    {
        private OracleTransaction _oracleTransaction;
        readonly OracleConnection _oracleConnection = new OracleConnection(ConfigurationManager.ConnectionStrings["OrclCon"].ConnectionString);

        public void BeginTransaction()
        {
            if (_oracleConnection.State != ConnectionState.Open)
                _oracleConnection.Open();
            _oracleTransaction = _oracleConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _oracleTransaction.Commit();
        }

        public void RollbackTransaction()
        {
            _oracleTransaction.Rollback();
        }
        public DataTable ExecuteSelectProcedure(String procedureName)
        {
            var oracleConnection = new OracleConnection(ConfigurationManager.ConnectionStrings["OrclCon"].ConnectionString);
            var oracleCommand = new OracleCommand
            {
                Connection = oracleConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = procedureName
            };
            oracleCommand.Parameters.Add("P_RECORDSET", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            var oracleDataAdapter = new OracleDataAdapter(oracleCommand);
            var dataTable = new DataTable();
            oracleDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public Boolean ExecuteIProcedure(String procedureName, OracleParameter[] parameters)
        {
            var oracleConnection = new OracleConnection(ConfigurationManager.ConnectionStrings["OrclCon"].ConnectionString);
            var procedureOutput = new List<string>();
            var oracleCommand = new OracleCommand
            {
                Connection = oracleConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = procedureName
            };
            oracleCommand.Parameters.AddRange(parameters);
            // OracleConnection.
            //var outputParameters = new[]
            //{
            // new OracleParameter("ProcedureResult", OracleDbType.NVarchar2, 100, null, ParameterDirection.Output),
            //};
            //oracleCommand.Parameters.AddRange(outputParameters);
            oracleCommand.ExecuteNonQuery();
            // procedureOutput.AddRange(from op in 1 select op.Value.ToString());
            return Convert.ToBoolean(Convert.ToInt16(0));
        }

        public DataTable ExecuteSelectProcedure(String procedureName, OracleParameter[] parameters)
        {
            var oracleConnection = new OracleConnection(ConfigurationManager.ConnectionStrings["OrclCon"].ConnectionString);
            var oracleCommand = new OracleCommand
            {
                Connection = oracleConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = procedureName
            };
            oracleCommand.Parameters.AddRange(parameters);
            oracleCommand.Parameters.Add("P_RECORDSET", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            var oracleDataAdapter = new OracleDataAdapter(oracleCommand);
            var dataTable = new DataTable();
            oracleDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public Boolean ExecuteProcedure(String procedureName, OracleParameter[] parameters)
        {
            var procedureOutput = new List<string>();
            var oracleCommand = new OracleCommand
            {
                Connection = _oracleConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = procedureName
            };
            oracleCommand.Parameters.AddRange(parameters);

            var outputParameters = new[]
            {
                new OracleParameter("ProcedureResult", OracleDbType.NVarchar2, 100, null, ParameterDirection.Output)
            };
            oracleCommand.Parameters.AddRange(outputParameters);
            _oracleConnection.Open();
            oracleCommand.ExecuteNonQuery();
            //_oracleConnection.Dispose();
            _oracleConnection.Close();
            procedureOutput.AddRange(from op in outputParameters select op.Value.ToString());
            return Convert.ToBoolean(Convert.ToInt16(procedureOutput[0]));
        }

        public Boolean ExecuteProcedureForGrid(String procedureName, OracleParameter[] parameters)
        {
            var procedureOutput = new List<string>();
            var oracleCommand = new OracleCommand
            {
                Connection = _oracleConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = procedureName
            };
            oracleCommand.Parameters.AddRange(parameters);

            var outputParameters = new[]
            {
                new OracleParameter("ProcedureResult", OracleDbType.NVarchar2, 100, null, ParameterDirection.Output)
            };
            oracleCommand.Parameters.AddRange(outputParameters);
            _oracleConnection.Open();
            oracleCommand.ExecuteNonQuery();
            _oracleConnection.Close();
            procedureOutput.AddRange(from op in outputParameters select op.Value.ToString());
            return Convert.ToBoolean(Convert.ToInt16(procedureOutput[0]));
        }

        public DataTable ExecuteSelectWithoutParam(String procedureName)
        {
            var oracleConnection = new OracleConnection(ConfigurationManager.ConnectionStrings["OrclCon"].ConnectionString);
            var oracleCommand = new OracleCommand
            {
                Connection = oracleConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = procedureName
            };
            oracleCommand.Parameters.Add("P_RECORDSET", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            var oracleDataAdapter = new OracleDataAdapter(oracleCommand);
            var dataTable = new DataTable();
            oracleDataAdapter.Fill(dataTable);
            return dataTable;
        }

        //public String GetIPAddress()
        //{
        //    var context = System.Web.HttpContext.Current;
        //    var ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        //    if (string.IsNullOrEmpty(ipAddress)) return context.Request.ServerVariables["REMOTE_ADDR"];
        //    var addresses = ipAddress.Split(',');
        //    return addresses.Length != 0 ? addresses[0] : context.Request.ServerVariables["REMOTE_ADDR"];
        //}

        public void LogError(String T_ERROR_MESSAGE)
        {
            var oracleConnection = new OracleConnection(ConfigurationManager.ConnectionStrings["OrclCon"].ConnectionString);
            var oracleCommand = new OracleCommand
            {
                Connection = oracleConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "T11111_INSERT"
            };
            oracleConnection.Open();
            oracleCommand.ExecuteNonQuery();
            oracleCommand.Dispose();
            oracleConnection.Close();
            oracleConnection.Dispose();
        }
        public DataTable Query(string query)
        {
            var oracleConnection = new OracleConnection(ConfigurationManager.ConnectionStrings["OrclCon"].ConnectionString);
            var oracleCommand = new OracleCommand
            {
                Connection = oracleConnection,
                CommandText = query
            };
            var oracleDataAdapter = new OracleDataAdapter(oracleCommand);
            var dataTable = new DataTable();

            oracleDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public bool Command(string command)
        {
            if (_oracleConnection.State != ConnectionState.Open)
                _oracleConnection.Open();
            var oracleCommand = new OracleCommand
            {
                Connection = _oracleConnection,
                CommandText = command
            };
            return oracleCommand.ExecuteNonQuery() > 0;
        }

        //public DataTable LoginQuery(string query, string T_LOGIN_NAME, string T_PWD)
        //{
        //    var oracleConnection = new OracleConnection(ConfigurationManager.ConnectionStrings["OrclCon"].ConnectionString);
        //    var oracleCommand = new OracleCommand
        //    {
        //        Connection = oracleConnection,
        //        CommandText = query
        //    };
        //    oracleCommand.Parameters.Add(new OracleParameter("T_LOGIN_NAME", T_LOGIN_NAME));
        //    oracleCommand.Parameters.Add(new OracleParameter("T_PWD", T_PWD));
        //    var oracleDataAdapter = new OracleDataAdapter(oracleCommand);
        //    var dataTable = new DataTable();
        //    oracleDataAdapter.Fill(dataTable);
        //    return dataTable;
        //}


        OracleCommand comm = new OracleCommand();

        OracleDataAdapter adp = new OracleDataAdapter();

        public OracleConnection OracleConnection => _oracleConnection;

        public DataTable GetLabelData(string T_FORM_CODE, string T_LABEL_NAME)
        {
            return Query($"SELECT T_CONTROL_TEXT_LANG1 T_LANG1_TEXT,T_CONTROL_TEXT_LANG2 T_LANG2_TEXT FROM T12132 WHERE T_FORM_NAME = '{T_FORM_CODE}' AND T_CONTROL_NAME = '{T_LABEL_NAME}'");
        }

        //public bool UpdateT01200(string T_UPD_USER, string T_FORM_CODE, string T_LABEL_NAME, string T_LANG1_TEXT, string T_LANG2_TEXT)
        //{
        //    return Command($"UPDATE T01200 SET T_UPD_USER = '{T_UPD_USER}', T_UPD_DATE = TRUNC(SYSDATE), T_LANG1_TEXT = '{T_LANG1_TEXT}', T_LANG2_TEXT = '{T_LANG2_TEXT}' WHERE T_FORM_CODE = '{T_FORM_CODE}' AND T_LABEL_NAME = '{T_LABEL_NAME}'");
        //}

        public DataTable GetLink(double T_LINK_SEPERATION, string T_ROLE_CODE, string LANGUAGE, string T_USER_CODE)
        {
            return Query($"select T01011.T_EMP_CODE,T_{LANGUAGE}_NAME LINK_LABEL,T_LINK_TEXT,T01199.T_LINK_TEXT   from T01011 left outer join T01009 on T01009.T_EMP_CODE = T01011.T_EMP_CODE left outer join T01199 on T01011.T_FORM_CODE =T01199.T_FORM_CODE where T01199.T_LINK_TEXT IS NOT NULL AND T01199.T_LINK_SEPERATION = {T_LINK_SEPERATION} AND T01199.T_ROLE_CODE = '{T_ROLE_CODE}' AND T01009.T_EMP_CODE = '{T_USER_CODE}' AND T01199.T_INACTIVE_FLAG  IS NULL group by T01011.T_EMP_CODE,T_{LANGUAGE}_NAME,  T_LINK_TEXT,T01199.T_LINK_LABEL_ID ORDER BY T01199.T_LINK_LABEL_ID");
        }

        public DataTable GetUserPermission(string T_FORM_CODE, string T_USER_CODE)
        {
            return Query($"SELECT * FROM T01011 WHERE T_FORM_CODE = '{T_FORM_CODE}' AND T_USER_CODE = '{T_USER_CODE}'");
        }

        public DataTable GetAllRole(string LANGUAGE)
        {
            return Query($"SELECT T_ROLE_CODE, T_{LANGUAGE}_NAME ROLE_NAME FROM T01007 ORDER BY T_{LANGUAGE}_NAME");
        }

        public DataTable GetRolePermission(string T_FORM_CODE, string T_ROLE_CODE)
        {
            return Query($"SELECT * FROM T01008 WHERE T_FORM_CODE = '{T_FORM_CODE}' AND T_ROLE_CODE = '{T_ROLE_CODE}'");
        }

        public DataTable GetFormData(string T_FORM_CODE, string LANGUAGE)
        {
            return Query($"SELECT T_{LANGUAGE}_NAME FORM_TITLE, T_FORM_CODE, T_VERSION_NO FROM T01003 WHERE T_REPORT_FLAG IS NULL AND T_FORM_CODE = '{T_FORM_CODE}'");
        }

        public string GetReportVersion(string T_FORM_CODE)
        {
            var dtReportVersion = Query($"SELECT T_VERSION_NO FROM T01003 WHERE T_REPORT_FLAG = 1 AND T_FORM_CODE = '{T_FORM_CODE.ToLower()}'");
            return dtReportVersion.Rows.Count > 0 ? dtReportVersion.Rows[0][0].ToString() : string.Empty;
        }

        public DataTable GetLabelText(string T_FORM_NAME, string LANGUAGE)
        {
            return Query($"SELECT T_CONTROL_NAME, T_CONTROL_TEXT_LANG{LANGUAGE} T_CONTROL_TEXT FROM T12132 WHERE T_FORM_NAME = '{T_FORM_NAME}'");
        }

        public string GetUserMsg(string T_MSG_CODE, string LANGUAGE)
        {
            return Query($"SELECT T_MSG_CODE ||' : '||T_LANG{LANGUAGE}_MSG MSG FROM T01004 WHERE T_MSG_CODE = '{T_MSG_CODE}'").Rows[0][0].ToString();
        }
        public DataTable GetAllUserMsg(string LANGUAGE)
        {
            return Query($"SELECT T_MSG_CODE, T_MSG_CODE ||' : '||T_LANG{LANGUAGE}_MSG MSG FROM T01004 WHERE T_ACTV_STTS ='1'");
        }

        public DataTable GetAllZone(string LANGUAGE)
        {
            return Query($"SELECT T_ZONE_CODE, T_{LANGUAGE}_NAME ZONE_NAME FROM T02064 ORDER BY T_SL_NO");
        }

        public DataTable GetAllZoneWithoutKSA(string LANGUAGE)
        {
            return Query($"SELECT T_ZONE_CODE, T_{LANGUAGE}_NAME ZONE_NAME FROM T02064 WHERE T_ZONE_CODE <> '22' ORDER BY T_SL_NO");
        }

        public DataTable GetZoneByRole(string T_ROLE_CODE, string T_EMP_CODE, string LANGUAGE)
        {
            return Query($"SELECT T_ZONE_CODE, T_{LANGUAGE}_NAME ZONE_NAME FROM T02064 WHERE T_ZONE_CODE IN (SELECT T_ZONE_CODE FROM T01009 WHERE T_ACTIVE_FLAG = '1' AND T_EMP_CODE = '{T_EMP_CODE}' AND T_ROLE_CODE = '{T_ROLE_CODE}') ORDER BY T_SL_NO");
        }

        public string GetZoneCodeBySite(string T_SITE_CODE)
        {
            return Query($"SELECT T_ZONE_CODE FROM T02065 WHERE T_SITE_CODE = '{T_SITE_CODE}'").Rows[0][0].ToString();
        }

        public string GetSiteName(string T_SITE_CODE, string LANGUAGE)
        {
            return Query($"SELECT T_{LANGUAGE}_NAME FROM T02065 WHERE T_SITE_CODE = '{T_SITE_CODE}'").Rows[0][0].ToString();
        }

        public string GetZoneNameBySite(string T_SITE_CODE, string LANGUAGE)
        {
            return Query($"SELECT T_{LANGUAGE}_NAME FROM T02064 WHERE T_ZONE_CODE = (SELECT T_ZONE_CODE FROM T02065 WHERE T_SITE_CODE = '{T_SITE_CODE}')").Rows[0][0].ToString();
        }

        public DataTable GetAllSiteByZone(string T_ZONE_CODE, string LANGUAGE)
        {
            return Query($"SELECT T02065.*, T02065.T_LANG{LANGUAGE}_NAME SITE_NAME, T02017.T_{LANGUAGE}_NAME STATUS_NAME FROM T02017, T02065 WHERE T02017.T_STATUS_CODE = T02065.T_SITE_STATUS AND T02065.T_ZONE_CODE = '{T_ZONE_CODE}' ORDER BY T02065.T_{LANGUAGE}_NAME");
        }

        public DataTable GetAllActiveSiteByZone(string T_ZONE_CODE, string LANGUAGE)
        {
            return Query($"SELECT T_SITE_CODE, T_LANG{LANGUAGE}_NAME SITE_NAME FROM T02065 WHERE T_SITE_STATUS = '3' AND T_ZONE_CODE = '{T_ZONE_CODE}' ORDER BY T_{LANGUAGE}_NAME");
        }

        public DataTable GetAllNonMudiriaSiteByZone(string T_ZONE_CODE, string LANGUAGE)
        {
            return Query($"SELECT T_SITE_CODE, T_LANG{LANGUAGE}_NAME SITE_NAME FROM T02065 WHERE T_ZONE_CODE = '{T_ZONE_CODE}' AND T_SITE_STATUS = '3' AND T_MUDIRIA IS NULL ORDER BY 2");
        }

        public DataTable GetAllNationality(string LANGUAGE)
        {
            return Query($"SELECT T_NTNLTY_CODE, T_LANG{LANGUAGE}_NAME T_NTNLTY FROM T02003 ORDER BY 1");
        }

        public DataTable GetAllReligion(string LANGUAGE)
        {
            return Query($"SELECT T_RLGN_CODE, T_LANG{LANGUAGE}_NAME T_RLGN_NAME FROM T02005 ORDER BY 1");
        }

        public DataTable GetAllGender(string LANGUAGE)
        {
            return Query($"SELECT T_SEX_CODE, T_LANG{LANGUAGE}_NAME T_GENDER FROM T02006 ORDER BY 1");
        }

        public DataTable GetAllMrtlStatus(string LANGUAGE)
        {
            return Query($"SELECT T_MRTL_STATUS_CODE, T_LANG{LANGUAGE}_NAME T_MRTL_STATUS FROM T02007 ORDER BY 1");
        }

        public DataTable GetAllDiagnosis(string LANGUAGE)
        {
            return Query($"SELECT T_DIAGNOSIS_CODE, T_LANG{LANGUAGE}_NAME T_DIAGNOSIS FROM T02074 ORDER BY 2");
        }

        public DataTable GetAssignedSites(string T_DOCTOR_CODE, string LANGUAGE)
        {
            return Query($"SELECT T_SITE_CODE, T_LANG{LANGUAGE}_NAME SITE_NAME FROM T02065 WHERE T_SITE_CODE IN (SELECT T_SITE_CODE FROM T02019 WHERE T_DOCTOR_CODE = '{T_DOCTOR_CODE}')");
        }
        public DataTable WithBlankRow(DataTable dt)
        {
            DataRow dr=dt.NewRow();
            dr[0] = "";
            dr[1] = "";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        //---------------------------------Log-----------------------------
        public void BeginTransaction_open()
        {
            if (_oracleConnection.State != ConnectionState.Open)
                _oracleConnection.Open();

        }
        public void BeginTransaction_close()
        {
            _oracleTransaction.Commit();
            if (_oracleConnection.State != ConnectionState.Closed)
                _oracleConnection.Close();

        }
        public bool Log(string P_METHOD_NAME,string P_MSG_TYP_ID, string P_MSG)
        {
            bool isInsert = false;
            BeginTransaction();
            if (Command($"INSERT INTO T13010 (T_ENTRY_DATE, T_ENTRY_USER, T_FORM_CODE, T_METHOD_NAME, T_MSG_TYP_ID,T_MSG) VALUES (SYSTIMESTAMP,'{HttpContext.Current.Session["T_EMP_CODE"]}', '{HttpContext.Current.Session["FORM_CODE"]}','{P_METHOD_NAME}','{P_MSG_TYP_ID}','{P_MSG}' )"))
            {
                BeginTransaction_close();
                isInsert = true;
            }
            else
            {
                RollbackTransaction();
                isInsert = false;
                
            }
            return isInsert;
        }

        public string getServerName()
        {
            var conn = ConfigurationManager.ConnectionStrings["OrclCon"].ConnectionString;
            return conn;
        }
        public string updateForm(string user, string form)
        {
            string str = "OK";
            try
            {
                Command(Query($"SELECT T_FORM FROM T12120 WHERE T_ENTRY_USER='{user}'").Rows.Count > 0 ? $"UPDATE T12120 SET T_FORM='{form}' WHERE T_ENTRY_USER='{user}'" : $"INSERT INTO T12120 (T_FORM,T_ENTRY_USER) VALUES('{form}','{user}')");
            }
            catch (Exception e)
            {
                str = e.Message;
            }
            return str;

        }
        public string setServerErrorLog(string controller, string action, string user, string message)
        {
            string str = "OK";
            try
            {
                DataTable dt = Query($"SELECT T_FORM FROM T12120 WHERE T_ENTRY_USER='{user}'");
                string form = dt.Rows.Count > 0 ? dt.Rows[0]["T_FORM"].ToString() : "";
                string T_ID = Query($"SELECT NVL(MAX(T_ID),0)+1 T_ID FROM T12119").Rows[0]["T_ID"].ToString();
                Command($"INSERT INTO T12119(T_ID,T_CONTROLLER,T_ACTION,T_FORM,T_MESSAGE,T_TYPE,T_ENTRY_USER,T_ENTRY_DATE) VALUES ({T_ID},'{controller}','{action}','{form}','{message}','s','{user}',SYSTIMESTAMP)");

            }
            catch (Exception e)
            {

                str = e.Message;
            }
            return str;

        }
        public string setClientErrorLog(string controller, string action, string message, string user, string source)
        {
            string str = "OK";
            try
            {
                DataTable dt = Query($"SELECT T_FORM FROM T12120 WHERE T_ENTRY_USER='{user}'");
                string form = dt.Rows.Count > 0 ? dt.Rows[0]["T_FORM"].ToString() : "";
                string T_ID = Query($"SELECT NVL(MAX(T_ID),0)+1 T_ID FROM T12119").Rows[0]["T_ID"].ToString();
                Command($"INSERT INTO T12119(T_ID,T_CONTROLLER,T_ACTION,T_FORM,T_MESSAGE,T_TYPE,T_ENTRY_USER,T_ENTRY_DATE,T_SOURCE) VALUES ({T_ID},'{controller}','{action}','{form}','{message}','c','{user}',SYSTIMESTAMP,'{source}')");

            }
            catch (Exception e)
            {

                str = e.Message;
            }
            return str;

        }
    }
}