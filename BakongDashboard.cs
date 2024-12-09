using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterReportClass;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using MasterDebugLog;
using MasterConnection;
using System.Data.SqlClient;

namespace BakongClearingDispute
{
    public class BakongDashboard
    {
        Oracle.ManagedDataAccess.Client.OracleConnection obj2 = new Oracle.ManagedDataAccess.Client.OracleConnection();
        Oracle.ManagedDataAccess.Client.OracleTransaction _trans;
        //MasterReportClass.master_debug _log = new MasterReportClass.master_debug();
        ATMSqlConnection _atmconn = new ATMSqlConnection();
        DebugLog _log = new DebugLog();
        SqlCommand cmd = new SqlCommand();
        SqlConnection sqlc = new SqlConnection();

        public string P_STTL_DATE { get; set; }
        public string P_STTL_CCY { get; set; }
        public string P_TOTAL_SETTLEMENT { get; set; }
        public string P_TOTAL_FEE { get; set; }
        public string P_DRCR_SETTLE { get; set; }
        public string P_DRCR_FEE { get; set; }
        public string _getmessage { get; set; }
        public string P_SDATE { get; set; }
        public string P_EDATE { get; set; }
        public string P_DATE { get; set; }

        public DataTable D_BAKONG_DDL(string USERID)
        {
            //------DDL = dropdownlist
            DataTable dt = new DataTable();
            try
            {
                _atmconn._command_Stored("PR_Bakong_Clearing_DDL", ref cmd); //Account_WebMenuAD
                cmd.Parameters.AddWithValue("@USERID", USERID);
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                _log.logfile(ex);
                _getmessage = ex.Message;
            }
            finally
            {
                sqlc.Close();
                sqlc.Dispose();
                SqlConnection.ClearPool(sqlc);
            }
            return dt;
        }

        public bool _add_bakong_OBS_settlement()
        {
            DataTable dt = new DataTable();
            try
            {
                int retval = 0;
                _atmconn.P_Connstring = "HKLDB1DBRW";
                string _CBSconn = _atmconn._getconnstring();
                var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_CBSconn);
                connection.Open();

                Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand("HTB_PKG_BAKONG_CLEARING.PR_ADD_BAKONG_OBS_STTL", connection);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("P_STTL_DATE", OracleDbType.NVarchar2).Value = P_STTL_DATE;
                cmd1.Parameters.Add("P_STTL_CCY", OracleDbType.NVarchar2).Value = P_STTL_CCY;
                cmd1.Parameters.Add("P_TOTAL_SETTLEMENT", OracleDbType.NVarchar2).Value = P_TOTAL_SETTLEMENT;
                //cmd1.Parameters.Add("P_TOTAL_FEE", OracleDbType.NVarchar2).Value = P_TOTAL_FEE;
                cmd1.Parameters.Add("P_DRCR_SETTL", OracleDbType.NVarchar2).Value = P_DRCR_SETTLE;
                //cmd1.Parameters.Add("P_DRCR_FEE", OracleDbType.NVarchar2).Value = P_DRCR_FEE;
                cmd1.Parameters.Add("P_retval", OracleDbType.NVarchar2, 10).Direction = ParameterDirection.Output;
                dt.Load(cmd1.ExecuteReader());

                retval = 1;
                // int retval = Convert.ToInt32(cmd1.Parameters["P_retval"].Value); //This will 1 or 0

                if (retval > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _log.logfile(ex);
                _getmessage = ex.Message;
                return false;
            }
            finally
            {
                obj2.Close();
                obj2.Dispose();
                Oracle.ManagedDataAccess.Client.OracleConnection.ClearAllPools();
            }
        }

        public DataTable _BAK_OBS_Settlement_bydate()
        {
            DataTable dt = new DataTable();
            try
            {
                _atmconn.P_Connstring = "HKLDB1DBRW";
                string _CBSconn = _atmconn._getconnstring();
                var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_CBSconn);
                connection.Open();

                Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand("HTB_PKG_BAKONG_CLEARING.PR_BAK_OBS_STTL_BYDATE", connection);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("P_SDATE", OracleDbType.NVarchar2).Value = P_SDATE;
                cmd1.Parameters.Add("P_EDATE", OracleDbType.NVarchar2).Value = P_EDATE;
                cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
                //OracleDataAdapter da = new OracleDataAdapter(cmd);
                da1.Fill(dt);

            }
            catch (Exception ex)
            {
                _log.logfile(ex);
                _getmessage = ex.Message;
            }
            finally
            {
                obj2.Close();
                obj2.Dispose();
                Oracle.ManagedDataAccess.Client.OracleConnection.ClearAllPools();
            }
            return dt;
        }

        public DataTable _BAK_OBS_pre_check()
        {
            DataTable dt = new DataTable();
            try
            {
                _atmconn.P_Connstring = "HKLDB1DBRW";
                string _CBSconn = _atmconn._getconnstring();
                var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_CBSconn);
                connection.Open();

                Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand("HTB_PKG_BAKONG_CLEARING.PR_OBS_PRE_CHECK", connection);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("P_CCY", OracleDbType.NVarchar2).Value = P_STTL_CCY;
                cmd1.Parameters.Add("P_DATE", OracleDbType.NVarchar2).Value = P_DATE;
                cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
                //OracleDataAdapter da = new OracleDataAdapter(cmd);
                da1.Fill(dt);

            }
            catch (Exception ex)
            {
                _log.logfile(ex);
                _getmessage = ex.Message;
            }
            finally
            {
                obj2.Close();
                obj2.Dispose();
                Oracle.ManagedDataAccess.Client.OracleConnection.ClearAllPools();
            }
            return dt;
        }

        public DataTable _BAKONG_OBS_Settlement()
        {
            DataTable dt = new DataTable();
            try
            {
                _atmconn.P_Connstring = "HKLDB1DBRW";
                string _CBSconn = _atmconn._getconnstring();
                var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_CBSconn);
                connection.Open();

                Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand("HTB_PKG_BAKONG_CLEARING.PR_BAK_OBS_Settlement", connection);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("P_CCY", OracleDbType.NVarchar2).Value = P_STTL_CCY;
                cmd1.Parameters.Add("P_SDATE", OracleDbType.NVarchar2).Value = P_SDATE;
                cmd1.Parameters.Add("P_EDATE", OracleDbType.NVarchar2).Value = P_EDATE;
                cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
                //OracleDataAdapter da = new OracleDataAdapter(cmd);
                da1.Fill(dt);

            }
            catch (Exception ex)
            {
                _log.logfile(ex);
                _getmessage = ex.Message;
            }
            finally
            {
                obj2.Close();
                obj2.Dispose();
                Oracle.ManagedDataAccess.Client.OracleConnection.ClearAllPools();
            }
            return dt;
        }


    }
}
