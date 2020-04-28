using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace NETWORK
{
    class ClsDgvView
    {
        SqlConnection myconnection;
        //SqlDataReader dr;
        SqlCommand mycommand;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        SqlDataReader SqlDataReader1;
        private BindingSource bindingSource = null;
        ClsDefaultBranch ClsDefaultBranch1 = new ClsDefaultBranch();

        //public void CreateColumn(DataGridView dgvDGV)
        //{
        //    //string sql = "SELECT DocNum, TDate, ControlNo, Remarks, RQStatusCode, CNCode FROM ViewRQSProcess ORDER BY DocNum";

        //    var ColDocNum = new DataGridViewTextBoxColumn();
        //    var ColTDate = new DataGridViewTextBoxColumn();
        //    var ColControlNo = new DataGridViewTextBoxColumn();
        //    var ColRemarks = new DataGridViewTextBoxColumn();
        //    var ColRQStatusCode = new DataGridViewTextBoxColumn();
        //    var ColCNCode = new DataGridViewTextBoxColumn();

        //    ColDocNum.HeaderText = "Number";
        //    ColDocNum.Name = "ColumnDocNum";
        //    ColDocNum.Width = 65;
        //    ColDocNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    ColTDate.HeaderText = "Date";
        //    ColTDate.Name = "ColumnTDate";
        //    ColTDate.Width = 86;
        //    ColTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    ColControlNo.HeaderText = "Name";
        //    ColControlNo.Name = "ColumnControlNo";
        //    ColControlNo.Width = 300;
        //    ColControlNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    ColRemarks.HeaderText = "Remarks";
        //    ColRemarks.Name = "ColumnRemarks";
        //    ColRemarks.Width = 300;
        //    ColRemarks.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //    ColRemarks.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    ColRQStatusCode.HeaderText = "Status";
        //    ColRQStatusCode.Name = "ColumnRQStatusCode";
        //    ColRQStatusCode.Width = 150;
        //    ColRQStatusCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    ColCNCode.HeaderText = "Branch";
        //    ColCNCode.Name = "ColumnCNCode";
        //    ColCNCode.Width = 150;
        //    ColCNCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    dgvDGV.Columns.AddRange(new DataGridViewColumn[] { ColDocNum, ColTDate, ColControlNo, ColRemarks, ColRQStatusCode, ColCNCode});

        //}

        public void LoadPending(DataGridView dgvDGV)
        {
            dgvDGV.DataSource = null;
            dgvDGV.Columns.Clear();
            string sql = "SELECT DocNum, ControlNo, TDate, Complaint, BloodPressure, Medication, Pending FROM ViewPendingAppointment ORDER BY DocNum";

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sql;
            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();

            bindingSource = new BindingSource();
            bindingSource.DataSource = DataTable1;

            //if (DataTable1.Rows.Count == 0)
            //{
            //    CreateColumn(dgvDGV);
            //    MessageBox.Show("No data found", "GL");
            //    return;
            //}

            //Adding  DocNum TextBox
            DataGridViewTextBoxColumn ColumnDocNum = new DataGridViewTextBoxColumn();
            ColumnDocNum.HeaderText = "Number";
            ColumnDocNum.Width = 70;
            ColumnDocNum.DataPropertyName = "DocNum";
            ColumnDocNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnDocNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnDocNum.Visible = true;
            dgvDGV.Columns.Add(ColumnDocNum);

            //Customer Data Source
            string selectQueryStringtblCustomer = "SELECT ControlNo, CustName FROM tblCustomer  ORDER BY CustName";
            SqlDataAdapter sqlDataAdaptertblCustomer = new SqlDataAdapter(selectQueryStringtblCustomer, myconnection);
            SqlCommandBuilder sqlCommandBuildertblCustomer = new SqlCommandBuilder(sqlDataAdaptertblCustomer);
            DataTable dataTabletblCustomer = new DataTable();
            sqlDataAdaptertblCustomer.Fill(dataTabletblCustomer);
            BindingSource bindingSourcetblCustomer = new BindingSource();
            bindingSourcetblCustomer.DataSource = dataTabletblCustomer;

            //Adding  ControlNo Combo
            DataGridViewComboBoxColumn ColumnControlNo = new DataGridViewComboBoxColumn();
            ColumnControlNo.DataPropertyName = "ControlNo";
            ColumnControlNo.HeaderText = "Name";
            ColumnControlNo.Width = 150;
            ColumnControlNo.DataSource = bindingSourcetblCustomer;
            ColumnControlNo.ValueMember = "ControlNo";
            ColumnControlNo.DisplayMember = "CustName";
            ColumnControlNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnControlNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnControlNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnControlNo.ReadOnly = true;
            dgvDGV.Columns.Add(ColumnControlNo);

            //Adding  TDate TextBox
            DataGridViewTextBoxColumn ColumnTDate = new DataGridViewTextBoxColumn();
            ColumnTDate.HeaderText = "Date";
            ColumnTDate.Width = 80;
            ColumnTDate.DataPropertyName = "TDate";
            ColumnTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnTDate.Visible = false;
            ColumnTDate.ReadOnly = true;
            dgvDGV.Columns.Add(ColumnTDate);

            //Adding  Complaint TextBox
            DataGridViewTextBoxColumn ColumnComplaint = new DataGridViewTextBoxColumn();
            ColumnComplaint.HeaderText = "Complaint";
            ColumnComplaint.Width = 150;
            ColumnComplaint.DataPropertyName = "Complaint";
            ColumnComplaint.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnComplaint.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnComplaint.ReadOnly = true;
            dgvDGV.Columns.Add(ColumnComplaint);

            //Adding  BloodPressure TextBox
            DataGridViewTextBoxColumn ColumnBloodPressure = new DataGridViewTextBoxColumn();
            ColumnBloodPressure.HeaderText = "Blood Pressure";
            ColumnBloodPressure.Width = 150;
            ColumnBloodPressure.DataPropertyName = "BloodPressure";
            ColumnBloodPressure.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBloodPressure.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnBloodPressure.ReadOnly = true;
            dgvDGV.Columns.Add(ColumnBloodPressure);

            //Adding  Medication TextBox
            DataGridViewTextBoxColumn ColumnMedication = new DataGridViewTextBoxColumn();
            ColumnMedication.HeaderText = "Medication";
            ColumnMedication.Width = 150;
            ColumnMedication.DataPropertyName = "Medication";
            ColumnMedication.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnMedication.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnMedication.ReadOnly = true;
            dgvDGV.Columns.Add(ColumnMedication);

            //Adding  Pending checkbox
            DataGridViewCheckBoxColumn ColumnPending = new DataGridViewCheckBoxColumn();
            ColumnPending.HeaderText = "Pending";
            ColumnPending.Width = 70;
            ColumnPending.DataPropertyName = "Pending";
            //ColumnPending.FalseValue = 0;
            ColumnPending.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnPending.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDGV.Columns.Add(ColumnPending);

            //Setting Data Source for DataGridView
            dgvDGV.DataSource = bindingSource;
            //dgv1.AutoResizeColumns();
            //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //this.WindowState = FormWindowState.Maximized;
            // dgv1.AllowUserToAddRows = false;
            //dgv1.Columns[2].Name = "ColumnStockNumber";
            //dgv1.Columns[3].DefaultCellStyle.Format = "N2";
            //dgv1.Columns[4].DefaultCellStyle.Format = "N2";
            //dgv1.Columns[5].DefaultCellStyle.Format = "N2";
            dgvDGV.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy";
        }

        public void LoadHistory(DataGridView dgvDGV, string strControlNo)
        {
            dgvDGV.DataSource = null;
            dgvDGV.Columns.Clear();
            string sql = "SELECT Voucher, TDate, Complaint, BloodPressure, Medication, Diagnose, ";
            sql +="Remarks, CAmount FROM ViewHistory WHERE ControlNo='"+strControlNo+"' ORDER BY TDate";

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sql;
            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();

            bindingSource = new BindingSource();
            bindingSource.DataSource = DataTable1;

            //if (DataTable1.Rows.Count == 0)
            //{
            //    CreateColumn(dgvDGV);
            //    MessageBox.Show("No data found", "GL");
            //    return;
            //}

            //Adding  Voucher TextBox
            DataGridViewTextBoxColumn ColumnVoucher = new DataGridViewTextBoxColumn();
            ColumnVoucher.HeaderText = "Type";
            ColumnVoucher.Width = 35;
            ColumnVoucher.DataPropertyName = "Voucher";
            ColumnVoucher.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnVoucher.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDGV.Columns.Add(ColumnVoucher);
          
            //Adding  TDate TextBox
            DataGridViewTextBoxColumn ColumnTDate = new DataGridViewTextBoxColumn();
            ColumnTDate.HeaderText = "Date";
            ColumnTDate.Width = 80;
            ColumnTDate.DataPropertyName = "TDate";
            ColumnTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnTDate.Visible = false;
            ColumnTDate.ReadOnly = true;
            dgvDGV.Columns.Add(ColumnTDate);

            //Adding  Complaint TextBox
            DataGridViewTextBoxColumn ColumnComplaint = new DataGridViewTextBoxColumn();
            ColumnComplaint.HeaderText = "Complaint";
            ColumnComplaint.Width = 150;
            ColumnComplaint.DataPropertyName = "Complaint";
            ColumnComplaint.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnComplaint.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDGV.Columns.Add(ColumnComplaint);

            //Adding  BloodPressure TextBox
            DataGridViewTextBoxColumn ColumnBloodPressure = new DataGridViewTextBoxColumn();
            ColumnBloodPressure.HeaderText = "Blood Pressure";
            ColumnBloodPressure.Width = 120;
            ColumnBloodPressure.DataPropertyName = "BloodPressure";
            ColumnBloodPressure.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBloodPressure.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDGV.Columns.Add(ColumnBloodPressure);

            //Adding  Medication TextBox
            DataGridViewTextBoxColumn ColumnMedication = new DataGridViewTextBoxColumn();
            ColumnMedication.HeaderText = "Medication";
            ColumnMedication.Width = 150;
            ColumnMedication.DataPropertyName = "Medication";
            ColumnMedication.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnMedication.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDGV.Columns.Add(ColumnMedication);

            //Adding  Diagnose TextBox
            DataGridViewTextBoxColumn ColumnDiagnose = new DataGridViewTextBoxColumn();
            ColumnDiagnose.HeaderText = "Diagnose";
            ColumnDiagnose.Width = 150;
            ColumnDiagnose.DataPropertyName = "Diagnose";
            ColumnDiagnose.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnDiagnose.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDGV.Columns.Add(ColumnDiagnose);

            //Adding  Remarks TextBox
            DataGridViewTextBoxColumn ColumnRemarks = new DataGridViewTextBoxColumn();
            ColumnRemarks.HeaderText = "Remarks";
            ColumnRemarks.Width = 150;
            ColumnRemarks.DataPropertyName = "Remarks";
            ColumnRemarks.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnRemarks.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDGV.Columns.Add(ColumnRemarks);

            //Adding  CAmount TextBox
            DataGridViewTextBoxColumn ColumnCAmount = new DataGridViewTextBoxColumn();
            ColumnCAmount.HeaderText = "Amount";
            ColumnCAmount.Width = 60;
            ColumnCAmount.DataPropertyName = "CAmount";
            ColumnCAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDGV.Columns.Add(ColumnCAmount);
            //Setting Data Source for DataGridView
            dgvDGV.DataSource = bindingSource;
            //dgv1.AutoResizeColumns();
            //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //this.WindowState = FormWindowState.Maximized;
            // dgv1.AllowUserToAddRows = false;
            //dgv1.Columns[2].Name = "ColumnStockNumber";
            //dgv1.Columns[3].DefaultCellStyle.Format = "N2";
            //dgv1.Columns[4].DefaultCellStyle.Format = "N2";
            dgvDGV.Columns[7].DefaultCellStyle.Format = "N2";
            dgvDGV.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy";
        }


        public void CreateColumn(DataGridView dgvDGV)
        {
            var varVoucher = new DataGridViewTextBoxColumn();
            var varTDate = new DataGridViewTextBoxColumn();
            var varComplaint = new DataGridViewTextBoxColumn();
            var varBloodPressure = new DataGridViewTextBoxColumn();
            var varMedication = new DataGridViewTextBoxColumn();
            var varDiagnose = new DataGridViewTextBoxColumn();
            var varRemarks = new DataGridViewTextBoxColumn();
            var varCAmount = new DataGridViewTextBoxColumn();

            varVoucher.HeaderText = "Type";
            varVoucher.Name = "Voucher";
            varVoucher.Width = 35;
            varVoucher.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            varTDate.HeaderText = "Date";
            varTDate.Name = "TDate";
            varTDate.Width = 80;
            varTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            varComplaint.HeaderText = "Complaint";
            varComplaint.Name = "Complaint";
            varComplaint.Width = 150;
            varComplaint.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            varBloodPressure.HeaderText = "Blood Pressure";
            varBloodPressure.Name = "BloodPressure";
            varBloodPressure.Width = 120;
            varBloodPressure.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            varMedication.HeaderText = "Medication";
            varMedication.Name = "Medication";
            varMedication.Width = 150;
            varMedication.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            varDiagnose.HeaderText = "Diagnose";
            varDiagnose.Name = "Diagnose";
            varDiagnose.Width = 150;
            varDiagnose.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            varRemarks.HeaderText = "Remarks";
            varRemarks.Name = "Remarks";
            varRemarks.Width = 150;
            varRemarks.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            varCAmount.HeaderText = "Amount";
            varCAmount.Name = "CAmount";
            varCAmount.Width = 60;
            varCAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //varDiagnose.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
            dgvDGV.Columns.AddRange(new DataGridViewColumn[] { varVoucher, varTDate, varComplaint, varBloodPressure, varMedication, varDiagnose, varRemarks, varCAmount });

        }

        public void LoadCollection(DataGridView dgvDGV, string strBeginDate, string strEndDate)
        {
            dgvDGV.DataSource = null;
            dgvDGV.Columns.Clear();
            string sql = "SELECT DocNum, TDate, ControlNo, CAmount FROM ViewCollection WHERE TDate ";
            sql += "BETWEEN '" + strBeginDate + "' And  '" + strEndDate + "' AND CNCode = '" + ClsDefaultBranch1.plsvardb + "'";

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sql;
            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();

            bindingSource = new BindingSource();
            bindingSource.DataSource = DataTable1;

            //if (DataTable1.Rows.Count == 0)
            //{
            //    CreateColumn(dgvDGV);
            //    MessageBox.Show("No data found", "GL");
            //    return;
            //}

            //Adding  Voucher TextBox
            //Adding  DocNum TextBox
            DataGridViewTextBoxColumn ColumnDocNum = new DataGridViewTextBoxColumn();
            ColumnDocNum.HeaderText = "Number";
            ColumnDocNum.Width = 70;
            ColumnDocNum.DataPropertyName = "DocNum";
            ColumnDocNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnDocNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnDocNum.Visible = true;
            dgvDGV.Columns.Add(ColumnDocNum);

            //Adding  TDate TextBox
            DataGridViewTextBoxColumn ColumnTDate = new DataGridViewTextBoxColumn();
            ColumnTDate.HeaderText = "Date";
            ColumnTDate.Width = 80;
            ColumnTDate.DataPropertyName = "TDate";
            ColumnTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnTDate.Visible = false;
            ColumnTDate.ReadOnly = true;
            dgvDGV.Columns.Add(ColumnTDate);

            //Customer Data Source
            string selectQueryStringtblCustomer = "SELECT ControlNo, CustName FROM tblCustomer  ORDER BY CustName";
            SqlDataAdapter sqlDataAdaptertblCustomer = new SqlDataAdapter(selectQueryStringtblCustomer, myconnection);
            SqlCommandBuilder sqlCommandBuildertblCustomer = new SqlCommandBuilder(sqlDataAdaptertblCustomer);
            DataTable dataTabletblCustomer = new DataTable();
            sqlDataAdaptertblCustomer.Fill(dataTabletblCustomer);
            BindingSource bindingSourcetblCustomer = new BindingSource();
            bindingSourcetblCustomer.DataSource = dataTabletblCustomer;

            //Adding  ControlNo Combo
            DataGridViewComboBoxColumn ColumnControlNo = new DataGridViewComboBoxColumn();
            ColumnControlNo.DataPropertyName = "ControlNo";
            ColumnControlNo.HeaderText = "Name";
            ColumnControlNo.Width = 400;
            ColumnControlNo.DataSource = bindingSourcetblCustomer;
            ColumnControlNo.ValueMember = "ControlNo";
            ColumnControlNo.DisplayMember = "CustName";
            ColumnControlNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnControlNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnControlNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnControlNo.ReadOnly = true;
            dgvDGV.Columns.Add(ColumnControlNo);

            //Adding  CAmount TextBox
            DataGridViewTextBoxColumn ColumnCAmount = new DataGridViewTextBoxColumn();
            ColumnCAmount.HeaderText = "Amount";
            ColumnCAmount.Width = 120;
            ColumnCAmount.DataPropertyName = "CAmount";
            ColumnCAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDGV.Columns.Add(ColumnCAmount);
            //Setting Data Source for DataGridView
            dgvDGV.DataSource = bindingSource;
            //dgv1.AutoResizeColumns();
            //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //this.WindowState = FormWindowState.Maximized;
            // dgv1.AllowUserToAddRows = false;
            //dgv1.Columns[2].Name = "ColumnStockNumber";
            //dgv1.Columns[3].DefaultCellStyle.Format = "N2";
            //dgv1.Columns[4].DefaultCellStyle.Format = "N2";
            dgvDGV.Columns[3].DefaultCellStyle.Format = "N2";
            dgvDGV.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy";
        }

    }
}
