using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;
using System.Data;

namespace NETWORK
{
    class ClsSaveNMData
    {

        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        ClsDefaultBranch ClsDefaultBranch1 = new ClsDefaultBranch();
        
        DateTime DT = DateTime.Now;
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand1;

        string sqlstatement1;
        private void ConnectionOpen()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
        }
        public void save1()
        {
            ConnectionOpen();
            sqlstatement1 = "INSERT INTO tblMain1 (IC, DocNum, Voucher, UserCode, TDate, ControlNo, UplineCode, NetWorkingCode, Remarks, DE, CNCode, Void) ";
            sqlstatement1 += "Values (@_IC, @_DocNum, @_Voucher, @_UserCode, @_TDate, @_ControlNo, @_UplineCode, @_NetWorkingCode, @_Remarks, @_DE, @_CNCode, @_Void) ";

            mycommand1 = new SqlCommand(sqlstatement1, myconnection);
            mycommand1.Parameters.Add("_IC", SqlDbType.VarChar).Value = "NM" + frmNewMember.glbltxtDocNum.Text + (ClsDefaultBranch1.plsvardb);
            mycommand1.Parameters.Add("_DocNum", SqlDbType.VarChar).Value = frmNewMember.glbltxtDocNum.Text;
            mycommand1.Parameters.Add("_Voucher", SqlDbType.VarChar).Value = "NM";
            mycommand1.Parameters.Add("_UserCode", SqlDbType.Char).Value = Form1.glbluc.Text;
            mycommand1.Parameters.Add("_TDate", SqlDbType.SmallDateTime).Value = frmNewMember.glbltxtTDate.Text;
            mycommand1.Parameters.Add("_ControlNo", SqlDbType.Char).Value = frmNewMember.glbltxtControlNo.Text;
            mycommand1.Parameters.Add("_UplineCode", SqlDbType.Char).Value = frmNewMember.glblcboControlNo.SelectedValue.ToString();
            mycommand1.Parameters.Add("_NetWorkingCode", SqlDbType.VarChar).Value = frmNewMember.glbltxtControlNo.Text;
            mycommand1.Parameters.Add("_Remarks", SqlDbType.VarChar).Value = "NA";
            mycommand1.Parameters.Add("_DE", SqlDbType.SmallDateTime).Value = DT;
            mycommand1.Parameters.Add("_CNCode", SqlDbType.Char).Value = "01";
            mycommand1.Parameters.Add("_Void", SqlDbType.Bit).Value = 1;
            mycommand1.ExecuteNonQuery();
            myconnection.Close();
        }
        public void save2()
        {
            ConnectionOpen();
            sqlstatement1 = "INSERT INTO tblMain1 (IC, DocNum, Voucher, UserCode, TDate, ControlNo, UplineCode, NetWorkingCode, Remarks, DE, CNCode, Void) ";
            sqlstatement1 += "Values (@_IC, @_DocNum, @_Voucher, @_UserCode, @_TDate, @_ControlNo, @_UplineCode, @_NetWorkingCode, @_Remarks, @_DE, @_CNCode, @_Void) ";

            mycommand1 = new SqlCommand(sqlstatement1, myconnection);
            mycommand1.Parameters.Add("_IC", SqlDbType.VarChar).Value = "NM" + frmNewMember.glbltxtDocNum.Text + (ClsDefaultBranch1.plsvardb);
            mycommand1.Parameters.Add("_DocNum", SqlDbType.VarChar).Value = frmNewMember.glbltxtDocNum.Text;
            mycommand1.Parameters.Add("_Voucher", SqlDbType.VarChar).Value = "NM";
            mycommand1.Parameters.Add("_UserCode", SqlDbType.Char).Value = Form1.glbluc.Text;
            mycommand1.Parameters.Add("_TDate", SqlDbType.SmallDateTime).Value = frmNewMember.glbltxtTDate.Text;
            mycommand1.Parameters.Add("_ControlNo", SqlDbType.Char).Value = frmNewMember.glbltxtControlNo.Text;
            mycommand1.Parameters.Add("_UplineCode", SqlDbType.Char).Value = frmNewMember.glblcboControlNo.SelectedValue.ToString();
            mycommand1.Parameters.Add("_NetWorkingCode", SqlDbType.VarChar).Value = frmNewMember.glblcboControlNo.SelectedValue.ToString() + frmNewMember.glbltxtControlNo.Text;
            mycommand1.Parameters.Add("_Remarks", SqlDbType.VarChar).Value = "NA";
            mycommand1.Parameters.Add("_DE", SqlDbType.SmallDateTime).Value = DT;
            mycommand1.Parameters.Add("_CNCode", SqlDbType.Char).Value = "01";
            mycommand1.Parameters.Add("_Void", SqlDbType.Bit).Value = 1;
            mycommand1.ExecuteNonQuery();
            myconnection.Close();
        }
        public void save3()
        {
            ClsGetSomething1.GetCode(frmNewMember.glblcboControlNo.SelectedValue.ToString());
            frmNewMember.glbltxtMasterCode.Text = ClsGetSomething1.strMasterCode;

            ConnectionOpen();
            sqlstatement1 = "INSERT INTO tblMain1 (IC, DocNum, Voucher, UserCode, TDate, ControlNo, UplineCode, NetWorkingCode, Remarks, DE, CNCode, Void) ";
            sqlstatement1 += "Values (@_IC, @_DocNum, @_Voucher, @_UserCode, @_TDate, @_ControlNo, @_UplineCode, @_NetWorkingCode, @_Remarks, @_DE, @_CNCode, @_Void) ";

            mycommand1 = new SqlCommand(sqlstatement1, myconnection);
            mycommand1.Parameters.Add("_IC", SqlDbType.VarChar).Value = "NM" + frmNewMember.glbltxtDocNum.Text +(ClsDefaultBranch1.plsvardb);
            mycommand1.Parameters.Add("_DocNum", SqlDbType.VarChar).Value = frmNewMember.glbltxtDocNum.Text;
            mycommand1.Parameters.Add("_Voucher", SqlDbType.VarChar).Value = "NM";
            mycommand1.Parameters.Add("_UserCode", SqlDbType.Char).Value = Form1.glbluc.Text;
            mycommand1.Parameters.Add("_TDate", SqlDbType.SmallDateTime).Value = frmNewMember.glbltxtTDate.Text;
            mycommand1.Parameters.Add("_ControlNo", SqlDbType.Char).Value = frmNewMember.glbltxtControlNo.Text;
            mycommand1.Parameters.Add("_UplineCode", SqlDbType.Char).Value = frmNewMember.glblcboControlNo.SelectedValue.ToString();
            mycommand1.Parameters.Add("_NetWorkingCode", SqlDbType.VarChar).Value = frmNewMember.glbltxtMasterCode.Text + frmNewMember.glbltxtControlNo.Text;
            mycommand1.Parameters.Add("_Remarks", SqlDbType.VarChar).Value = "NA";
            mycommand1.Parameters.Add("_DE", SqlDbType.SmallDateTime).Value = DT;
            mycommand1.Parameters.Add("_CNCode", SqlDbType.Char).Value = "01";
            mycommand1.Parameters.Add("_Void", SqlDbType.Bit).Value = 1;
            mycommand1.ExecuteNonQuery();
        }

    }
}
