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
    public partial class frmUserMembership : Form
    {
        private SqlDataAdapter da;
        private SqlConnection myconnection;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        string sql;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();

        public frmUserMembership()
        {
            InitializeComponent();
        }
        private void frmUserMembership_Load(object sender, EventArgs e)
        {
            LoadMemberShip();
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                da.Update(dataTable);
                MessageBox.Show("Saved", "GL");

            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }
        private void LoadMemberShip()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);

            sql = "SELECT UserCode, UserName, GroupCode, CNCode FROM tblUser";

            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);

            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            //GroupCode Data Source
            string selectQueryStringgroup = "SELECT GroupCode,GroupName FROM tblgroup";
            SqlDataAdapter sqlDataAdaptergroup = new SqlDataAdapter(selectQueryStringgroup, myconnection);
            SqlCommandBuilder sqlCommandBuildergroup = new SqlCommandBuilder(sqlDataAdaptergroup);

            DataTable dataTableItem = new DataTable();
            sqlDataAdaptergroup.Fill(dataTableItem);
            BindingSource bindingSourcegroup = new BindingSource();
            bindingSourcegroup.DataSource = dataTableItem;

            //Adding  UserCode TextBox
            DataGridViewTextBoxColumn ColumnUserCode = new DataGridViewTextBoxColumn();
            ColumnUserCode.Visible = false;
            ColumnUserCode.HeaderText = "User Code";
            ColumnUserCode.Width = 80;
            ColumnUserCode.DataPropertyName = "UserCode";
            dgv1.Columns.Add(ColumnUserCode);

            //Adding  UserName TextBox
            DataGridViewTextBoxColumn ColumnUserName = new DataGridViewTextBoxColumn();
            ColumnUserName.ReadOnly = true;
            ColumnUserName.HeaderText = "User";
            ColumnUserName.Width = 200;
            ColumnUserName.DataPropertyName = "UserName";
            dgv1.Columns.Add(ColumnUserName);

            //Adding  Group Combo
            DataGridViewComboBoxColumn ColumnGroup = new DataGridViewComboBoxColumn();
            ColumnGroup.DataPropertyName = "GroupCode";
            ColumnGroup.HeaderText = "Group";
            ColumnGroup.Width = 200;
            ColumnGroup.DataSource = bindingSourcegroup;
            ColumnGroup.ValueMember = "GroupCode";
            ColumnGroup.DisplayMember = "GroupName";
            dgv1.Columns.Add(ColumnGroup);

            //CNCode Data Source
            string selectQueryStringgroup1 = "SELECT CNCode, CName FROM tblCompanyName";
            SqlDataAdapter sqlDataAdaptergroup1 = new SqlDataAdapter(selectQueryStringgroup1, myconnection);
            SqlCommandBuilder sqlCommandBuildergroup1 = new SqlCommandBuilder(sqlDataAdaptergroup1);

            DataTable dataTableItem1 = new DataTable();
            sqlDataAdaptergroup1.Fill(dataTableItem1);
            BindingSource bindingSourcegroup1 = new BindingSource();
            bindingSourcegroup1.DataSource = dataTableItem1;

            //Adding  CNCode Combo
            DataGridViewComboBoxColumn ColumnCNCode = new DataGridViewComboBoxColumn();
            ColumnCNCode.DataPropertyName = "CNCode";
            ColumnCNCode.HeaderText = "Branch";
            ColumnCNCode.Width = 200;
            ColumnCNCode.DataSource = bindingSourcegroup1;
            ColumnCNCode.ValueMember = "CNCode";
            ColumnCNCode.DisplayMember = "CName";
            dgv1.Columns.Add(ColumnCNCode);

            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            dgv1.AutoResizeColumns();
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv1.AllowUserToAddRows = false;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
