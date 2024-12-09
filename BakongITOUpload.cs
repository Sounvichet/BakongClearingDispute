using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterReportClass;
using Oracle.ManagedDataAccess.Client;
using System.Web.UI.WebControls;
using System.Data;
using MasterConnection;

namespace BakongClearingDispute
{
    public class BakongITOUpload
    {
        public string P_USERID { get; set; }
        ATMSqlConnection _atmconn = new ATMSqlConnection();
        Oracle.ManagedDataAccess.Client.OracleConnection obj2 = new Oracle.ManagedDataAccess.Client.OracleConnection();
        Oracle.ManagedDataAccess.Client.OracleTransaction _trans;
        MasterReportClass.master_debug _log = new MasterReportClass.master_debug();

        public void _BAKONG_PAYMENT_ITO_UPLOADS(GridView gv)
        {
            foreach (GridViewRow gvr in gv.Rows)
            {
                try
                {
                    _atmconn.P_Connstring = "HKLDB1DBRW";
                    string get_conn = _atmconn._getconnstring();
                    var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(get_conn);
                    connection.Open();
                    //obj2.ConnectionString = obj1.oracleconINH();
                    //obj2.Open();

                    Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand("HTB_PKG_BAKONG_CLEARING.PR_BAKONG_PAYMENT_PUSH_ITO", connection);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("P_CUR_NO", OracleDbType.NVarchar2).Value = gvr.Cells[1].Text.ToString();
                    cmd1.Parameters.Add("P_BRN", OracleDbType.NVarchar2).Value = gvr.Cells[2].Text.ToString();
                    cmd1.Parameters.Add("P_ACCT_NO", OracleDbType.NVarchar2).Value = gvr.Cells[3].Text.ToString();
                    cmd1.Parameters.Add("P_ACCT_BRN", OracleDbType.NVarchar2).Value = gvr.Cells[4].Text.ToString();
                    cmd1.Parameters.Add("P_DRCR", OracleDbType.NVarchar2).Value = gvr.Cells[5].Text.ToString();
                    cmd1.Parameters.Add("P_CCY", OracleDbType.NVarchar2).Value = gvr.Cells[6].Text.ToString();
                    cmd1.Parameters.Add("P_AMT", OracleDbType.NVarchar2).Value = gvr.Cells[7].Text.ToString();
                    cmd1.Parameters.Add("P_EX_RATE", OracleDbType.NVarchar2).Value = gvr.Cells[8].Text.ToString();
                    cmd1.Parameters.Add("P_AMT_LCY", OracleDbType.NVarchar2).Value = gvr.Cells[9].Text.ToString();
                    cmd1.Parameters.Add("P_COM_MIS", OracleDbType.NVarchar2).Value = gvr.Cells[10].Text.ToString();
                    cmd1.Parameters.Add("P_VAL_DATE", OracleDbType.NVarchar2).Value = gvr.Cells[11].Text.ToString();
                    cmd1.Parameters.Add("P_TRN_CODE", OracleDbType.NVarchar2).Value = gvr.Cells[12].Text.ToString();
                    cmd1.Parameters.Add("P_BATCH_NO", OracleDbType.NVarchar2).Value = gvr.Cells[13].Text.ToString();
                    cmd1.Parameters.Add("P_BATCH_DESC", OracleDbType.NVarchar2).Value = gvr.Cells[14].Text.ToString();
                    cmd1.Parameters.Add("P_OFFSET_ACCT", OracleDbType.NVarchar2).Value = gvr.Cells[15].Text.ToString();
                    cmd1.Parameters.Add("P_SOURCES", OracleDbType.NVarchar2).Value = gvr.Cells[16].Text.ToString();
                    cmd1.Parameters.Add("P_SOURCES_REF", OracleDbType.NVarchar2).Value = gvr.Cells[17].Text.ToString();
                    cmd1.Parameters.Add("P_TRN_NAME", OracleDbType.NVarchar2).Value = gvr.Cells[18].Text.ToString();
                    cmd1.Parameters.Add("P_USERID", OracleDbType.NVarchar2).Value = P_USERID;
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    _log.logfile(ex);
                    _log._messageError = ex.Message;
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
}
