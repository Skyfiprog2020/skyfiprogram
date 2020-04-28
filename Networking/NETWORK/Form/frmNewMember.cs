using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NETWORK
{
    public partial class frmNewMember : Form
    {

        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsDefaultBranch ClsDefaultBranch1 = new ClsDefaultBranch();
        ClsValidation ClsValidation1 = new ClsValidation();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsSaveNMData ClsSaveNMData1 = new ClsSaveNMData();

        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand, mycommand1;

        public static TextBox glbltxtDocNum, glbltxtControlNo, glbltxtMasterCode;
        public static MaskedTextBox glbltxtTDate;
        public static ComboBox glblcboControlNo;
        string sqlstatement, sqlstatement1, networkcode;
        public frmNewMember()
        {
            InitializeComponent();
        }
        private void frmNewMember_Load(object sender, EventArgs e)
        {
            global();
            buildcboControlNo();
            PermissionLoad();
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file");
                this.Close();
            }
        }
        private void PermissionLoad()
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                ClsAutoNumber1.VoucherAutoNum("NM");
                txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                ClsGetSomething1.ClsGetDefaultDate();
                txtTDate.Text = ClsGetSomething1.plsdefdate;
                AutoNum();
            }
        }
        private void AutoNum()
        {
            ClsAutoNumber1.CustomerNameAdd();
            txtControlNo.Text = (ClsAutoNumber1.plsnumber);
        }
        private void global()
        {
            glbltxtDocNum = txtDocNum; 
            glbltxtTDate = txtTDate;
            glbltxtControlNo = txtControlNo;
            glbltxtMasterCode = txtMasterCode;
            glblcboControlNo = cboControlNo;
        }
        private void buildcboControlNo()
        {
            cboControlNo.DataSource = null;
            ClsBuildComboBox1.ARLControlNo.Clear();
            ClsBuildComboBox1.ClsBuildControlno();
            this.cboControlNo.DataSource = (ClsBuildComboBox1.ARLControlNo);
            this.cboControlNo.DisplayMember = "Display";
            this.cboControlNo.ValueMember = "Value";
            this.cboControlNo.SelectedValue = "";
        }
        private void ConnectionOpen()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionOpen();
            if (new Clsexist().RecordExists(ref myconnection, "SELECT CustName FROM tblCustomer WHERE CustName ='" + txtCustname.Text + "'"))
            {
                myconnection.Close();
                MessageBox.Show("Customer Name already exist", "GL");
                txtCustname.Focus();
            }
            else if (string.IsNullOrEmpty(txtCustname.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                txtCustname.Focus();
            }
            else if (string.IsNullOrEmpty(txtContactNo.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                txtContactNo.Focus();
            }
            else if (string.IsNullOrEmpty(txtContactPerson.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                txtContactPerson.Focus();
            }
            else if (string.IsNullOrEmpty(txtTIN.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                txtTIN.Focus();
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                txtAddress.Focus();
            }
            else if (string.IsNullOrEmpty(txtTIN.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                txtTIN.Focus();
            }
            else
            {
                SaveData();
            }
        }
        private void cboControlNo_Validating_1(object sender, CancelEventArgs e)
        {
            if (cboControlNo.SelectedValue == null || cboControlNo.Text == "")
            {
                MessageBox.Show("Please Select Information", "Error Selection");
                cboControlNo.Focus();
            }
            else
            {
                ClsGetSomething1.GetCustomerNo(cboControlNo.SelectedValue.ToString());
                txtUplineMasterCode1.Text = ClsGetSomething1.strCustmerCode;
            }
        }
        private void nextfieldenter2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

        }
        private void nextfieldenter1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
            else if ((e.KeyCode.Equals(Keys.Up)) || (e.KeyCode.Equals(Keys.Left)))
            {
                SendKeys.Send("+{TAB}");
            }
            else if ((e.KeyCode.Equals(Keys.Down)) || (e.KeyCode.Equals(Keys.Right)))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void SaveData()
        { 
            try
                {
                    AutoNum();
                    ClsAutoNumber1.VoucherAutoNum("NM");
                    txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                    ConnectionOpen();
                    sqlstatement = "INSERT INTO tblCustomer (ControlNo, CustName, ContactNo, ContactPerson, TIN, Address, Active, CNCode) ";
                    sqlstatement += "Values (@_ControlNo, @_CustName, @_ContactNo, @_ContactPerson, @_TIN, @_Address, @_Active, @_CNCode) ";
                    sqlstatement1 = "INSERT INTO tblMain1 (IC, DocNum, Voucher, UserCode, TDate, ControlNo, UplineCode, NetWorkingCode, Remarks, DE, CNCode, Void) ";
                    sqlstatement1 += "Values (@_IC, @_DocNum, @_Voucher, @_UserCode, @_TDate, @_ControlNo, @_UplineCode, @_NetWorkingCode, @_Remarks, @_DE, @_CNCode, @_Void) ";
                    
                    mycommand = new SqlCommand(sqlstatement, myconnection);
                    mycommand.Parameters.Add("_ControlNo", SqlDbType.Char).Value = txtControlNo.Text;
                    mycommand.Parameters.Add("_CustName", SqlDbType.VarChar).Value = txtCustname.Text;
                    mycommand.Parameters.Add("_ContactNo", SqlDbType.VarChar).Value = txtContactNo.Text;
                    mycommand.Parameters.Add("_ContactPerson", SqlDbType.VarChar).Value = txtContactPerson.Text;
                    mycommand.Parameters.Add("_TIN", SqlDbType.VarChar).Value = txtTIN.Text;
                    mycommand.Parameters.Add("_Address", SqlDbType.VarChar).Value = txtAddress.Text;
                    mycommand.Parameters.Add("_Active", SqlDbType.Bit).Value = 1;
                    mycommand.Parameters.Add("_CNCode", SqlDbType.Char).Value = "01";
                    mycommand.ExecuteNonQuery();

                    saveinfo();
                    myconnection.Close();
                    
                    AutoNum();
                    clearData();
                    MessageBox.Show("Saved");
                    ClsAutoNumber1.VoucherAutoNum("NM");
                    txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                    buildcboControlNo();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
        }
        private void clearData()
        {
            txtCustname.Text = "";
            txtContactNo.Text = "";
            txtContactPerson.Text = "";
            txtAddress.Text = "";
            txtTIN.Text = "";
            txtUplineMasterCode.Text = "";
            txtMasterCode.Text = "";
            txtUplineMasterCode.Text = "";
        }

        private void saveinfo()
        {
            string uplineCode;
            ClsGetSomething1.GetCode(cboControlNo.SelectedValue.ToString());
            uplineCode = ClsGetSomething1.strUplineMasterCode;
            if (txtUplineMasterCode1.Text == uplineCode)
            {
                ClsSaveNMData1.save3();
            }
            else
            {
                saveinfo1();
            }
        }
        private void saveinfo1()
        {
            if(cboControlNo.SelectedValue.ToString() == "0000000")
            {
                ClsSaveNMData1.save1();
            }
            else
            {
                ClsSaveNMData1.save2();
            }
        }
        
    }
}
