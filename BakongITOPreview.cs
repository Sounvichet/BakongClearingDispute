using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using MasterConnection;
using MasterDebugLog;

namespace BakongClearingDispute
{
    public class BakongITOPreview
    {
        public string P_CCY { get; set; }
        public string P_SDATE { get; set; }
        public string P_EDATE { get; set; }
        Oracle.ManagedDataAccess.Client.OracleConnection obj2 = new Oracle.ManagedDataAccess.Client.OracleConnection();
        Oracle.ManagedDataAccess.Client.OracleTransaction _trans;
        //MasterReportClass.master_debug _log = new MasterReportClass.master_debug();
        ATMSqlConnection _atmconn = new ATMSqlConnection();
        DebugLog _log = new DebugLog();

        public DataTable _BAKONG_OBS_Settlement()
        {
            DataTable dt = new DataTable();
            try
            {
                _atmconn.P_Connstring = "HKLDB1DBRW";
                string _CBSconn = _atmconn._getconnstring();
                var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_CBSconn);
                connection.Open();

                Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand("HTB_PKG_BAKONG_CLEARING.PR_BAKONG_PRE_LIST", connection);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("P_CCY", OracleDbType.NVarchar2).Value = P_CCY;
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

        public DataTable _BAKONG_ITO_SMY()
        {
            DataTable dt = new DataTable();
            try
            {
                _atmconn.P_Connstring = "HKLDB1DBRW";
                string _CBSconn = _atmconn._getconnstring();
                var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_CBSconn);
                connection.Open();

                Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand("HTB_PKG_BAKONG_CLEARING.PR_BAKONG_ITO_SMY", connection);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("P_CCY", OracleDbType.NVarchar2).Value = P_CCY;
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

        public DataTable _BAKONG_NBC_SMY()
        {
            DataTable dt = new DataTable();
            try
            {
                _atmconn.P_Connstring = "HKLDB1DBRW";
                string _CBSconn = _atmconn._getconnstring();
                var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_CBSconn);
                connection.Open();

                Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand("HTB_PKG_BAKONG_CLEARING.PR_BAKONG_NBC_NET_AMOUNT", connection);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("P_CCY", OracleDbType.NVarchar2).Value = P_CCY;
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

        public DataTable _BAKONG_PG_SMY()
        {
            DataTable dt = new DataTable();
            try
            {
                _atmconn.P_Connstring = "HKLDB1DBRW";
                string _CBSconn = _atmconn._getconnstring();
                var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_CBSconn);
                connection.Open();

                Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand("HTB_PKG_BAKONG_CLEARING.PR_BAKONG_PG_SMY", connection);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("P_CCY", OracleDbType.NVarchar2).Value = P_CCY;
                //cmd1.Parameters.Add("P_SDATE", OracleDbType.NVarchar2).Value = P_SDATE;
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

    }
}
