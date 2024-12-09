using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using MasterConnection;
using MasterDebugLog;

namespace BakongClearingDispute
{
    public class BakongUploadReconFile
    {
        public string _USERID { get; set; }
        //MasterReportClass.masterreport_connect obj1 = new MasterReportClass.masterreport_connect();
        Oracle.ManagedDataAccess.Client.OracleConnection obj2 = new Oracle.ManagedDataAccess.Client.OracleConnection();
        Oracle.ManagedDataAccess.Client.OracleTransaction _trans;
        //MasterReportClass.master_debug _log = new MasterReportClass.master_debug();
        ATMSqlConnection _atmconn = new ATMSqlConnection();
        DebugLog _log = new DebugLog();
        public string _getmessage { get; set; }
        public void BakongUploadRecon(DataTable dt)
        {
            try
            {
                _atmconn.P_Connstring = "HKLDB1DBRW";
                string get_conn = _atmconn._getconnstring();

                using (var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(get_conn))
                {
                    connection.Open();
                    dt.Columns.Add("USERID");
                    //int[] ids = new int[dt.Rows.Count];
                    string[] ORIG_BANKS = new string[dt.Rows.Count];
                    string[] RECEIVED_BANKS = new string[dt.Rows.Count];
                    string[] ORIG_ACCTS = new string[dt.Rows.Count];
                    string[] RECEIVED_ACCTS = new string[dt.Rows.Count];
                    string[] TRN_DATES = new string[dt.Rows.Count];
                    string[] TRN_TIMES = new string[dt.Rows.Count];
                    string[] BSA_DATES = new string[dt.Rows.Count];
                    string[] CURRRENCYS = new string[dt.Rows.Count];
                    string[] TRN_AMOUNTS = new string[dt.Rows.Count];
                    string[] NOTES = new string[dt.Rows.Count];
                    string[] DESCRIPTIONS = new string[dt.Rows.Count];
                    string[] HASHS = new string[dt.Rows.Count];
                    string[] USERIDS = new string[dt.Rows.Count];

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        ORIG_BANKS[j] = Convert.ToString(dt.Rows[j]["ORIG_BANK"]);
                        RECEIVED_BANKS[j] = Convert.ToString(dt.Rows[j]["RECEIVED_BANK"]);
                        ORIG_ACCTS[j] = Convert.ToString(dt.Rows[j]["ORIG_ACCT"]);
                        RECEIVED_ACCTS[j] = Convert.ToString(dt.Rows[j]["RECEIVED_ACCT"]);
                        TRN_DATES[j] = Convert.ToString(dt.Rows[j]["TRN_DATE"]);
                        TRN_TIMES[j] = Convert.ToString(dt.Rows[j]["TRN_TIME"]);
                        BSA_DATES[j] = Convert.ToString(dt.Rows[j]["BSA_DATE"]);
                        CURRRENCYS[j] = Convert.ToString(dt.Rows[j]["CURRRENCY"]);
                        TRN_AMOUNTS[j] = Convert.ToString(dt.Rows[j]["TRN_AMOUNT"]);
                        NOTES[j] = Convert.ToString(dt.Rows[j]["NOTE"]);
                        DESCRIPTIONS[j] = Convert.ToString(dt.Rows[j]["DESCRIPTION"]);
                        HASHS[j] = Convert.ToString(dt.Rows[j]["HASH"]);
                        USERIDS[j] = Convert.ToString(dt.Rows[j]["USERID"]);
                        USERIDS[j] = _USERID;
                    }

                    OracleParameter P_ORIG_BANK = new OracleParameter();
                    P_ORIG_BANK.OracleDbType = OracleDbType.NVarchar2;
                    P_ORIG_BANK.Value = ORIG_BANKS;

                    OracleParameter P_RECEIVED_BANK = new OracleParameter();
                    P_RECEIVED_BANK.OracleDbType = OracleDbType.NVarchar2;
                    P_RECEIVED_BANK.Value = RECEIVED_BANKS;

                    OracleParameter P_ORIG_ACCT = new OracleParameter();
                    P_ORIG_ACCT.OracleDbType = OracleDbType.NVarchar2;
                    P_ORIG_ACCT.Value = ORIG_ACCTS;

                    OracleParameter P_RECEIVED_ACCT = new OracleParameter();
                    P_RECEIVED_ACCT.OracleDbType = OracleDbType.NVarchar2;
                    P_RECEIVED_ACCT.Value = RECEIVED_ACCTS;

                    OracleParameter P_TRN_DATE = new OracleParameter();
                    P_TRN_DATE.OracleDbType = OracleDbType.NVarchar2;
                    P_TRN_DATE.Value = TRN_DATES;

                    OracleParameter P_TRN_TIME = new OracleParameter();
                    P_TRN_TIME.OracleDbType = OracleDbType.NVarchar2;
                    P_TRN_TIME.Value = TRN_TIMES;

                    OracleParameter P_BSA_DATE = new OracleParameter();
                    P_BSA_DATE.OracleDbType = OracleDbType.NVarchar2;
                    P_BSA_DATE.Value = BSA_DATES;

                    OracleParameter P_CURRRENCY = new OracleParameter();
                    P_CURRRENCY.OracleDbType = OracleDbType.NVarchar2;
                    P_CURRRENCY.Value = CURRRENCYS;

                    OracleParameter P_TRN_AMOUNT = new OracleParameter();
                    P_TRN_AMOUNT.OracleDbType = OracleDbType.NVarchar2;
                    P_TRN_AMOUNT.Value = TRN_AMOUNTS;

                    OracleParameter P_NOTE = new OracleParameter();
                    P_NOTE.OracleDbType = OracleDbType.NVarchar2;
                    P_NOTE.Value = NOTES;

                    OracleParameter P_DESCRIPTION = new OracleParameter();
                    P_DESCRIPTION.OracleDbType = OracleDbType.NVarchar2;
                    P_DESCRIPTION.Value = DESCRIPTIONS;

                    OracleParameter P_HASH = new OracleParameter();
                    P_HASH.OracleDbType = OracleDbType.NVarchar2;
                    P_HASH.Value = HASHS;

                    OracleParameter P_USERID = new OracleParameter();
                    P_USERID.OracleDbType = OracleDbType.NVarchar2;
                    P_USERID.Value = USERIDS;

                    // create command and set properties  
                    //OracleCommand cmd = connection.CreateCommand();
                    String _getQuery = "HTB_PKG_BAKONG_CLEARING.PR_BAKONG_INSERT_TRANS";
                    Oracle.ManagedDataAccess.Client.OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand(_getQuery, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ArrayBindCount = ORIG_BANKS.Length;
                    cmd.Parameters.Add(P_ORIG_BANK);
                    cmd.Parameters.Add(P_RECEIVED_BANK);
                    cmd.Parameters.Add(P_ORIG_ACCT);
                    cmd.Parameters.Add(P_RECEIVED_ACCT);
                    cmd.Parameters.Add(P_TRN_DATE);
                    cmd.Parameters.Add(P_TRN_TIME);
                    cmd.Parameters.Add(P_BSA_DATE);
                    cmd.Parameters.Add(P_CURRRENCY);
                    cmd.Parameters.Add(P_TRN_AMOUNT);
                    cmd.Parameters.Add(P_NOTE);
                    cmd.Parameters.Add(P_DESCRIPTION);
                    cmd.Parameters.Add(P_HASH);
                    cmd.Parameters.Add(P_USERID);

                    cmd.ExecuteNonQuery();
                    _trans = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                    _getmessage = "1";
                }
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
        }
    }
}
