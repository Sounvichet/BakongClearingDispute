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
    public class BakongPGNBCPortalUpload
    {
        public string _USERID { get; set; }
        public string _getmessage { get; set; }
        Oracle.ManagedDataAccess.Client.OracleConnection obj2 = new Oracle.ManagedDataAccess.Client.OracleConnection();
        Oracle.ManagedDataAccess.Client.OracleTransaction _trans;
        //MasterReportClass.master_debug _log = new MasterReportClass.master_debug();
        ATMSqlConnection _atmconn = new ATMSqlConnection();
        DebugLog _log = new DebugLog();


        public void Bakong_PGNBC_UploadRecon(DataTable dt)
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
                    string[] Trx_Hashs = new string[dt.Rows.Count];
                    string[] Entry_Dates = new string[dt.Rows.Count];
                    string[] From_Accounts = new string[dt.Rows.Count];
                    string[] To_Accounts = new string[dt.Rows.Count];
                    string[] CCYs = new string[dt.Rows.Count];
                    string[] Amounts = new string[dt.Rows.Count];
                    string[] Statuss = new string[dt.Rows.Count];
                    string[] Fees = new string[dt.Rows.Count];
                    string[] Taxs = new string[dt.Rows.Count];
                    string[] USERIDS = new string[dt.Rows.Count];

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        Trx_Hashs[j] = Convert.ToString(dt.Rows[j]["Trx_Hash"]);
                        Entry_Dates[j] = Convert.ToString(dt.Rows[j]["Entry_Date"]);
                        From_Accounts[j] = Convert.ToString(dt.Rows[j]["From_Account"]);
                        To_Accounts[j] = Convert.ToString(dt.Rows[j]["To_Account"]);
                        CCYs[j] = Convert.ToString(dt.Rows[j]["CCY"]);
                        Amounts[j] = Convert.ToString(dt.Rows[j]["Amount"]);
                        Statuss[j] = Convert.ToString(dt.Rows[j]["Status"]);
                        Fees[j] = Convert.ToString(dt.Rows[j]["Fee"]);
                        Taxs[j] = Convert.ToString(dt.Rows[j]["Tax"]);

                        USERIDS[j] = _USERID;
                    }

                    OracleParameter P_Trx_Hash = new OracleParameter();
                    P_Trx_Hash.OracleDbType = OracleDbType.NVarchar2;
                    P_Trx_Hash.Value = Trx_Hashs;

                    OracleParameter P_Entry_Date = new OracleParameter();
                    P_Entry_Date.OracleDbType = OracleDbType.NVarchar2;
                    P_Entry_Date.Value = Entry_Dates;

                    OracleParameter P_From_Account = new OracleParameter();
                    P_From_Account.OracleDbType = OracleDbType.NVarchar2;
                    P_From_Account.Value = From_Accounts;

                    OracleParameter P_To_Account = new OracleParameter();
                    P_To_Account.OracleDbType = OracleDbType.NVarchar2;
                    P_To_Account.Value = To_Accounts;

                    OracleParameter P_CCY = new OracleParameter();
                    P_CCY.OracleDbType = OracleDbType.NVarchar2;
                    P_CCY.Value = CCYs;

                    OracleParameter P_Amount = new OracleParameter();
                    P_Amount.OracleDbType = OracleDbType.NVarchar2;
                    P_Amount.Value = Amounts;

                    OracleParameter P_Status = new OracleParameter();
                    P_Status.OracleDbType = OracleDbType.NVarchar2;
                    P_Status.Value = Statuss;

                    OracleParameter P_Fee = new OracleParameter();
                    P_Fee.OracleDbType = OracleDbType.NVarchar2;
                    P_Fee.Value = Fees;

                    OracleParameter P_Tax = new OracleParameter();
                    P_Tax.OracleDbType = OracleDbType.NVarchar2;
                    P_Tax.Value = Taxs;

                    OracleParameter P_USERID = new OracleParameter();
                    P_USERID.OracleDbType = OracleDbType.NVarchar2;
                    P_USERID.Value = USERIDS;

                    // create command and set properties  
                    //OracleCommand cmd = connection.CreateCommand();
                    String _getQuery = "HTB_PKG_BAKONG_CLEARING.PR_BAKONG_PGNBC_INSERT_TRNS";
                    Oracle.ManagedDataAccess.Client.OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand(_getQuery, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ArrayBindCount = Trx_Hashs.Length;
                    cmd.Parameters.Add(P_Trx_Hash);
                    cmd.Parameters.Add(P_Entry_Date);
                    cmd.Parameters.Add(P_From_Account);
                    cmd.Parameters.Add(P_To_Account);
                    cmd.Parameters.Add(P_CCY);
                    cmd.Parameters.Add(P_Amount);
                    cmd.Parameters.Add(P_Status);
                    cmd.Parameters.Add(P_Fee);
                    cmd.Parameters.Add(P_Tax);
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
