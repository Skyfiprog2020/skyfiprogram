using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace NETWORK
{
    public partial class frmPatientDashBoard : Form
    {
        public static DataGridView glbldgv1Record;
        public static TextBox glbltxtDocNum, glbltxtControlNo;
        public static MaskedTextBox glbltxtTDate;
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        SqlConnection myconnection;
        SqlCommand mycommand;
        ClsDefaultBranch ClsDefaultBranch1 = new ClsDefaultBranch();
        ClsDgvView ClsDgvView1 = new ClsDgvView();
        public frmPatientDashBoard()
        {
            InitializeComponent();
        }

        private void frmPatientDashBoard_Load(object sender, EventArgs e)
        {
            glbldgv1Record = dgv1Record;
            glbltxtDocNum = txtDocNum;
            glbltxtTDate = txtTDate;
            glbltxtControlNo = txtControlNo;
        }

        private void nextfieldenter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (new ClsValidation().emptytxt(txtDiagnose.Text))
            {
                MessageBox.Show("Diagnose is empty", "NETWORK");
                txtDiagnose.Focus();
            }
            else if (new ClsValidation().emptytxt(txtRemarks.Text))
            {
                MessageBox.Show("Remarks is empty", "NETWORK");
                txtRemarks.Focus();
            }
            else
            {
                TransactSave();
            }
        }

        private void TransactSave()
        {
            try
            {
                string sqlstatement = "INSERT INTO tblMain1 (IC, DocNum, Voucher, UserCode, TDate, ControlNo, Remarks, CheckNo, ";
                sqlstatement += "CAmount, DE, CNCode, Complaint, BloodPressure, Medication, Diagnose) ";
                sqlstatement += "Values (@_IC, @_DocNum, @_Voucher, @_UserCode, @_TDate, @_ControlNo, @_Remarks, @_CheckNo, @_CAmount, ";
                sqlstatement += "@_DE, @_CNCode, @_Complaint, @_BloodPressure, @_Medication, @_Diagnose)";

                DateTime DT = DateTime.Now;
                ClsAutoNumber1.VoucherAutoNum("DG");
                txtDocNum.Text = (ClsAutoNumber1.plsnumber);

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                mycommand = new SqlCommand(sqlstatement, myconnection);
                mycommand.Parameters.Add("_IC", SqlDbType.VarChar).Value = "DG" + txtDocNum.Text + (ClsDefaultBranch1.plsvardb);
                mycommand.Parameters.Add("_DocNum", SqlDbType.VarChar).Value = txtDocNum.Text;
                mycommand.Parameters.Add("_Voucher", SqlDbType.VarChar).Value = "DG";
                mycommand.Parameters.Add("_UserCode", SqlDbType.VarChar).Value = Form1.glbluc.Text;
                mycommand.Parameters.Add("_TDate", SqlDbType.DateTime).Value = txtTDate.Text;
                mycommand.Parameters.Add("_ControlNo", SqlDbType.VarChar).Value = txtControlNo.Text;
                mycommand.Parameters.Add("_Remarks", SqlDbType.VarChar).Value = txtRemarks.Text;
                mycommand.Parameters.Add("_CheckNo", SqlDbType.VarChar).Value = "NA";
                mycommand.Parameters.Add("_CAmount", SqlDbType.Decimal).Value = 0;
                mycommand.Parameters.Add("_DE", SqlDbType.DateTime).Value = DT;
                mycommand.Parameters.Add("_CNCode", SqlDbType.Char).Value = (ClsDefaultBranch1.plsvardb);
                mycommand.Parameters.Add("_Complaint", SqlDbType.VarChar).Value = "NA";
                mycommand.Parameters.Add("_BloodPressure", SqlDbType.VarChar).Value = "NA";
                mycommand.Parameters.Add("_Medication", SqlDbType.VarChar).Value = "NA";
                mycommand.Parameters.Add("_Diagnose", SqlDbType.VarChar).Value = txtDiagnose.Text;
                int n1 = mycommand.ExecuteNonQuery();
                myconnection.Close();

                ClsAutoNumber1.VoucherAutoNum("DG");
                txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                txtDiagnose.Clear();
                txtRemarks.Clear();
                ClsDgvView1.LoadHistory(frmPatientDashBoard.glbldgv1Record, txtControlNo.Text);

            }
            catch
            {
                MessageBox.Show("Error, please click OK", "GL");
            }
            finally
            {
                //               dr.Close();
                myconnection.Close();
            }
        }

    }
}
