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
using System.Collections;

namespace NETWORK
{
    public partial class frmUserPermission : Form
    {
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private SqlConnection myconnection;
        private BindingSource bindingSource = null;
        string sql;
        SqlCommand mycommand;
        SqlDataReader dr;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 
        
        public frmUserPermission()
        {
            InitializeComponent();
        }

        private void frmUserPermission_Load(object sender, EventArgs e)
        {
            buildgroupcode();
            cbogroupcode.Text = "";
        }
        
        private void cbogroupcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv1.DataSource = null;
            showpermission();
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                da.Update(dataTable);
                MessageBox.Show("Saved", "FMS");
            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }
        private void buildgroupcode()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT GroupCode, GroupName from tblGroup", myconnection);
                dr = mycommand.ExecuteReader();
                ArrayList T = new ArrayList();

                while (dr.Read())
                {
                    T.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
                }
                dr.Close();
                myconnection.Close();

                this.cbogroupcode.DataSource = T;
                this.cbogroupcode.DisplayMember = "Display";
                this.cbogroupcode.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                dr.Close();
                myconnection.Close();
            }
        }
        private void showpermission()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            sql = "SELECT GroupCode, ObjectName, RowNum FROM tblPermission WHERE GroupCode = '" + cbogroupcode.SelectedValue + "'";

            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);

            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            //Object Data Source
            string selectQueryStringcat = "SELECT ObjectName FROM tblobjects";

            SqlDataAdapter sqlDataAdaptercat = new SqlDataAdapter(selectQueryStringcat, myconnection);
            SqlCommandBuilder sqlCommandBuildergroup = new SqlCommandBuilder(sqlDataAdaptercat);

            DataTable dataTableItem = new DataTable();
            sqlDataAdaptercat.Fill(dataTableItem);
            BindingSource bindingSourcegroup = new BindingSource();
            bindingSourcegroup.DataSource = dataTableItem;

            //Adding  GroupCode TextBox
            DataGridViewTextBoxColumn ColumnGroupCode = new DataGridViewTextBoxColumn();
            ColumnGroupCode.HeaderText = "Group Code";

            //ColumnGroupCode.Width = 80;
            ColumnGroupCode.DataPropertyName = "GroupCode";
            ColumnGroupCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnGroupCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnGroupCode.Visible = false;
            dgv1.Columns.Add(ColumnGroupCode);

            //Adding  ObjectName Combo
            DataGridViewComboBoxColumn ColumnObjectName = new DataGridViewComboBoxColumn();
            ColumnObjectName.DataPropertyName = "ObjectName";
            ColumnObjectName.HeaderText = "Object Name";
            ColumnObjectName.Width = 324;
            ColumnObjectName.DataSource = bindingSourcegroup;
            ColumnObjectName.ValueMember = "ObjectName";
            ColumnObjectName.DisplayMember = "ObjectName";
            dgv1.Columns.Add(ColumnObjectName);

            //Adding  RowNum TextBox
            DataGridViewTextBoxColumn ColumnRowNum = new DataGridViewTextBoxColumn();
            ColumnRowNum.HeaderText = "RowNum";
            ColumnRowNum.DataPropertyName = "RowNum";
            ColumnRowNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnRowNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnRowNum.Visible = false;
            dgv1.Columns.Add(ColumnRowNum);

            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            myconnection.Close();
        }

       
    }
}
