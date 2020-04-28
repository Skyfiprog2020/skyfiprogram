using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SampleSystem
{
    public partial class frmReport : Form
    {
        ClsConnection ClsConnection1 = new ClsConnection();
        SqlConnection myconnection;
        SqlCommand mycommand;

        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            cboReportPrint();
        }
        private void cboReportPrint()
        {
            cboPrint.DisplayMember = "Text";
            cboPrint.ValueMember = "Value";

            var items = new[]
            {
             new {Text = "List of Information", Value = "01"}
            };

            cboPrint.DataSource = items;
            cboPrint.SelectedValue = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboPrint.SelectedValue == null  )
            {
                MessageBox.Show("Please Select to Print");
                cboPrint.Focus();
            }
            else
            {
                if (cboPrint.SelectedValue.ToString() == "01")
                {
                    PreviewAR();
                }
            }
        
        }
        private void PreviewAR()
        {
            ClsConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsConnection1.plsMyConMSSQL);
            myconnection.Open();
            string sqlstatement = "SELECT * FROM ViewInfo ORDER BY LastName";
            SqlDataAdapter SqlDAViewBookAR = new SqlDataAdapter(sqlstatement, myconnection);
            DataTable DataTable1 = new DataTable();
            SqlDAViewBookAR.Fill(DataTable1);
            myconnection.Close();

            if (DataTable1.Rows.Count == 0)
            {
                MessageBox.Show("No data found");
                return;
            }

            CRInfo objRpt = new CRInfo();
            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            objRpt.Refresh();
        }
    }
}
