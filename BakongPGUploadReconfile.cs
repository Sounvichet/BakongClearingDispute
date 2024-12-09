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
    public class BakongPGUploadReconfile
    {
        public string _USERID { get; set; }
        public string _getmessage { get; set; }
        Oracle.ManagedDataAccess.Client.OracleConnection obj2 = new Oracle.ManagedDataAccess.Client.OracleConnection();
        Oracle.ManagedDataAccess.Client.OracleTransaction _trans;
        //MasterReportClass.master_debug _log = new MasterReportClass.master_debug();
        ATMSqlConnection _atmconn = new ATMSqlConnection();
        DebugLog _log = new DebugLog();
        

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
                    string[] IDS = new string[dt.Rows.Count];
                    string[] SRC_ACCOUNTS = new string[dt.Rows.Count];
                    string[] DEST_ACCOUNTS = new string[dt.Rows.Count];
                    string[] CCYS = new string[dt.Rows.Count];
                    string[] AMOUNTS = new string[dt.Rows.Count];
                    string[] CREATED_TIMES = new string[dt.Rows.Count];
                    string[] LOCAL_TIMES = new string[dt.Rows.Count];
                    string[] BSA_DATES = new string[dt.Rows.Count];
                    string[] TRN_HASHS = new string[dt.Rows.Count];
                    string[] STATUSS = new string[dt.Rows.Count];
                    string[] SRC_ACC_TYPES = new string[dt.Rows.Count];
                    string[] DEST_ACC_TYPES = new string[dt.Rows.Count];
                    string[] SRC_BINS = new string[dt.Rows.Count];
                    string[] DEST_BINS = new string[dt.Rows.Count];
                    string[] DOMAINS = new string[dt.Rows.Count];
                    string[] TYPES = new string[dt.Rows.Count];
                    string[] USERIDS = new string[dt.Rows.Count];

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        IDS[j] = Convert.ToString(dt.Rows[j]["ID"]);
                        SRC_ACCOUNTS[j] = Convert.ToString(dt.Rows[j]["SRC_ACCOUNT"]);
                        DEST_ACCOUNTS[j] = Convert.ToString(dt.Rows[j]["DEST_ACCOUNT"]);
                        CCYS[j] = Convert.ToString(dt.Rows[j]["CCY"]);
                        AMOUNTS[j] = Convert.ToString(dt.Rows[j]["AMOUNT"]);
                        CREATED_TIMES[j] = Convert.ToString(dt.Rows[j]["CREATED_TIME"]);
                        LOCAL_TIMES[j] = Convert.ToString(dt.Rows[j]["LOCAL_TIME"]);
                        BSA_DATES[j] = Convert.ToString(dt.Rows[j]["BSA_DATE"]);
                        TRN_HASHS[j] = Convert.ToString(dt.Rows[j]["TRN_HASH"]);
                        STATUSS[j] = Convert.ToString(dt.Rows[j]["STATUS"]);
                        SRC_ACC_TYPES[j] = Convert.ToString(dt.Rows[j]["SRC_ACC_TYPE"]);
                        DEST_ACC_TYPES[j] = Convert.ToString(dt.Rows[j]["DEST_ACC_TYPE"]);
                        SRC_BINS[j] = Convert.ToString(dt.Rows[j]["SRC_BIN"]);
                        DEST_BINS[j] = Convert.ToString(dt.Rows[j]["DEST_BIN"]);
                        DOMAINS[j] = Convert.ToString(dt.Rows[j]["DOMAIN"]);
                        TYPES[j] = Convert.ToString(dt.Rows[j]["TYPE"]);


                        USERIDS[j] = _USERID;
                    }

                    OracleParameter P_ID = new OracleParameter();
                    P_ID.OracleDbType = OracleDbType.NVarchar2;
                    P_ID.Value = IDS;

                    OracleParameter P_SRC_ACCOUNT = new OracleParameter();
                    P_SRC_ACCOUNT.OracleDbType = OracleDbType.NVarchar2;
                    P_SRC_ACCOUNT.Value = SRC_ACCOUNTS;

                    OracleParameter P_DEST_ACCOUNT = new OracleParameter();
                    P_DEST_ACCOUNT.OracleDbType = OracleDbType.NVarchar2;
                    P_DEST_ACCOUNT.Value = DEST_ACCOUNTS;

                    OracleParameter P_CCY = new OracleParameter();
                    P_CCY.OracleDbType = OracleDbType.NVarchar2;
                    P_CCY.Value = CCYS;

                    OracleParameter P_AMOUNT = new OracleParameter();
                    P_AMOUNT.OracleDbType = OracleDbType.NVarchar2;
                    P_AMOUNT.Value = AMOUNTS;

                    OracleParameter P_CREATED_TIME = new OracleParameter();
                    P_CREATED_TIME.OracleDbType = OracleDbType.NVarchar2;
                    P_CREATED_TIME.Value = CREATED_TIMES;

                    OracleParameter P_LOCAL_TIME = new OracleParameter();
                    P_LOCAL_TIME.OracleDbType = OracleDbType.NVarchar2;
                    P_LOCAL_TIME.Value = LOCAL_TIMES;

                    OracleParameter P_BSA_DATE = new OracleParameter();
                    P_BSA_DATE.OracleDbType = OracleDbType.NVarchar2;
                    P_BSA_DATE.Value = BSA_DATES;

                    OracleParameter P_TRN_HASH = new OracleParameter();
                    P_TRN_HASH.OracleDbType = OracleDbType.NVarchar2;
                    P_TRN_HASH.Value = TRN_HASHS;

                    OracleParameter P_STATUS = new OracleParameter();
                    P_STATUS.OracleDbType = OracleDbType.NVarchar2;
                    P_STATUS.Value = STATUSS;

                    OracleParameter P_SRC_ACC_TYPE = new OracleParameter();
                    P_SRC_ACC_TYPE.OracleDbType = OracleDbType.NVarchar2;
                    P_SRC_ACC_TYPE.Value = SRC_ACC_TYPES;

                    OracleParameter P_DEST_ACC_TYPE = new OracleParameter();
                    P_DEST_ACC_TYPE.OracleDbType = OracleDbType.NVarchar2;
                    P_DEST_ACC_TYPE.Value = DEST_ACC_TYPES;

                    OracleParameter P_SRC_BIN = new OracleParameter();
                    P_SRC_BIN.OracleDbType = OracleDbType.NVarchar2;
                    P_SRC_BIN.Value = SRC_BINS;

                    OracleParameter P_DEST_BIN = new OracleParameter();
                    P_DEST_BIN.OracleDbType = OracleDbType.NVarchar2;
                    P_DEST_BIN.Value = DEST_BINS;

                    OracleParameter P_DOMAIN = new OracleParameter();
                    P_DOMAIN.OracleDbType = OracleDbType.NVarchar2;
                    P_DOMAIN.Value = DOMAINS;

                    OracleParameter P_TYPES = new OracleParameter();
                    P_TYPES.OracleDbType = OracleDbType.NVarchar2;
                    P_TYPES.Value = TYPES;

                    OracleParameter P_USERID = new OracleParameter();
                    P_USERID.OracleDbType = OracleDbType.NVarchar2;
                    P_USERID.Value = USERIDS;

                    // create command and set properties  
                    //OracleCommand cmd = connection.CreateCommand();
                    String _getQuery = "HTB_PKG_BAKONG_CLEARING.PR_BAKONG_PG_INSERT_TRNS";
                    Oracle.ManagedDataAccess.Client.OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand(_getQuery, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ArrayBindCount = IDS.Length;
                    cmd.Parameters.Add(P_ID);
                    cmd.Parameters.Add(P_SRC_ACCOUNT);
                    cmd.Parameters.Add(P_DEST_ACCOUNT);
                    cmd.Parameters.Add(P_CCY);
                    cmd.Parameters.Add(P_AMOUNT);
                    cmd.Parameters.Add(P_CREATED_TIME);
                    cmd.Parameters.Add(P_LOCAL_TIME);
                    cmd.Parameters.Add(P_BSA_DATE);
                    cmd.Parameters.Add(P_TRN_HASH);
                    cmd.Parameters.Add(P_STATUS);
                    cmd.Parameters.Add(P_SRC_ACC_TYPE);
                    cmd.Parameters.Add(P_DEST_ACC_TYPE);
                    cmd.Parameters.Add(P_SRC_BIN);
                    cmd.Parameters.Add(P_DEST_BIN);
                    cmd.Parameters.Add(P_DOMAIN);
                    cmd.Parameters.Add(P_TYPES);
                    cmd.Parameters.Add(P_USERID);

                    cmd.ExecuteNonQuery();
                    _trans = connection.BeginTransaction(IsolationLevel.ReadCommitted);

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
