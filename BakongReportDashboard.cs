using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using System.Data;
using MasterConnection;
using MasterDebugLog;
namespace BakongClearingDispute
{
  public class BakongReportDashboard
    {
        public string P_SDATE { get; set; }
        public string P_EDATE { get; set; }
        public string get_message { get; set; }
        //MasterReportClass.masterreport_connect obj1 = new MasterReportClass.masterreport_connect();
        Oracle.ManagedDataAccess.Client.OracleConnection obj2 = new Oracle.ManagedDataAccess.Client.OracleConnection();
        Oracle.ManagedDataAccess.Client.OracleTransaction _trans;
        //MasterReportClass.master_debug _log = new MasterReportClass.master_debug();
        ATMSqlConnection _atmconn = new ATMSqlConnection();
        DebugLog _log = new DebugLog();
        XmlReadSqlScript _rsql = new XmlReadSqlScript();
        SqlCommand cmd = new SqlCommand();
        SqlConnection sqlc = new SqlConnection();
        public DataTable _BAKONG_TOTAL_TRANS()
        {
            DataTable dt = new DataTable();
            try
            {
                _atmconn.P_Connstring = "HKLDB1DBRW";
                string get_conn = _atmconn._getconnstring();

                string _get_sql_st = _rsql.SQL_SCRIPT("BAKONG_TOTAL_TRANS");
                var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(get_conn);
                connection.Open();

                Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(_get_sql_st, connection);
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.Add("SDATE", OracleDbType.NVarchar2).Value = P_SDATE;
                cmd1.Parameters.Add("EDATE", OracleDbType.NVarchar2).Value = P_EDATE;
                //cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
                //OracleDataAdapter da = new OracleDataAdapter(cmd);
                da1.Fill(dt);

            }
            catch (Exception ex)
            {
                _log.logfile(ex);
            }
            finally
            {
                obj2.Close();
                obj2.Dispose();
                //obj2..ClearPool(obj2);
            }
            return dt;
        }



        public DataTable _BAKONG_PG_VERIFY_NBC()
        {
            DataTable dt = new DataTable();
            try
            {
                _atmconn.P_Connstring = "HKLDB1DBRW";
                string _CBSconn = _atmconn._getconnstring();
                var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_CBSconn);
                connection.Open();

                Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand("HTB_PKG_BAKONG_REPORT.PR_BAKONG_PG_VERIFY_NBC_RPT", connection);
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
            }
            finally
            {
                obj2.Close();
                obj2.Dispose();
                Oracle.ManagedDataAccess.Client.OracleConnection.ClearAllPools();
            }
            return dt;
        }


        public DataTable _BAKONG_RECON_NOST_LIAB()
        {
            DataTable dt = new DataTable();
            try
            {
                _atmconn.P_Connstring = "HKLDB1DBRW";
                string _CBSconn = _atmconn._getconnstring();
                var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_CBSconn);
                connection.Open();

                Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand("HTB_PKG_BAKONG_REPORT.PR_BAKONG_RECON_NOST_LIAB", connection);
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
            }
            finally
            {
                obj2.Close();
                obj2.Dispose();
                Oracle.ManagedDataAccess.Client.OracleConnection.ClearAllPools();
            }
            return dt;
        }

        public DataTable _BAKONG_NBC_MISMATCH_VS_GL()
        {
            DataTable dt = new DataTable();
            try
            {
                _atmconn.P_Connstring = "HKLDB1DBRW";
                string _CBSconn = _atmconn._getconnstring();
                var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_CBSconn);
                connection.Open();

                Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand("HTB_PKG_BAKONG_REPORT.PR_BAKONG_NBC_MISMATCH_GL", connection);
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
            }
            finally
            {
                obj2.Close();
                obj2.Dispose();
                Oracle.ManagedDataAccess.Client.OracleConnection.ClearAllPools();
            }
            return dt;
        }

        public DataTable _BAKONG_PG_MISMATCH_VS_GL()
        {
            DataTable dt = new DataTable();
            try
            {
                _atmconn.P_Connstring = "HKLDB1DBRW";
                string _CBSconn = _atmconn._getconnstring();
                var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_CBSconn);
                connection.Open();

                Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand("HTB_PKG_BAKONG_REPORT.PR_BAKONG_NBC_MISMATCH_GL", connection);
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
            }
            finally
            {
                obj2.Close();
                obj2.Dispose();
                Oracle.ManagedDataAccess.Client.OracleConnection.ClearAllPools();
            }
            return dt;
        }


        public DataTable _Bakong_report_list_DDL()
        {
            DataTable dt = new DataTable();
            try
            {
                _atmconn._command_Stored("PR_BAKONG_REPORT_DDL", ref cmd);
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                _log.logfile(ex);
                get_message = ex.Message;
            }

            finally
            {
                sqlc.Close();
                sqlc.Dispose();
                SqlConnection.ClearPool(sqlc);
            }
            return dt;

        }
    }
}
