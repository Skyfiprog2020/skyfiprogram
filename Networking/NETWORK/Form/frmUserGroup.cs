﻿using System;
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
    public partial class frmUserGroup : Form
    {
        SqlConnection myconnection;
        // SqlDataReader dr;
        SqlCommand mycommand;
        //BindingSource dbind = new BindingSource();
        SqlDataAdapter da;
        DataSet dset;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 
        public frmUserGroup()
        {
            InitializeComponent();
        }

        private void frmUserGroup_Load(object sender, EventArgs e)
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            if (new Clsexist().RecordExists(ref myconnection, "SELECT GroupCode FROM tblgroup"))
            {
                da = new SqlDataAdapter("SELECT GroupCode + 1 from tblgroup ORDER BY GroupCode desc", myconnection);
                dset = new DataSet();
                da.Fill(dset, "GroupCode");

                DataView dv = new DataView(dset.Tables["GroupCode"]);
                txtgroupcode.Text = Convert.ToString(dv[0].Row[0]).PadLeft(2, '0');
                myconnection.Close();
            }
            else
            {
                txtgroupcode.Text = "01";
                myconnection.Close();
            }

        }

        private void txtsave_Click(object sender, EventArgs e)
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            if (new ClsValidation().emptytxt(txtgroupname.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "FMS");
                txtgroupname.Focus();
            }

            else if (new Clsexist().RecordExists(ref myconnection, "SELECT groupname FROM tblgroup WHERE groupname ='" + txtgroupname.Text + "'"))
            {
                myconnection.Close();
                MessageBox.Show("Duplicate entry", "FMS");
                txtgroupname.Focus();
            }

            else
            {
                string SqlDbstatement;
                SqlDbstatement = "INSERT INTO tblgroup (Groupcode, GroupName) Values (@_Groupcode, @_GroupName)";
                mycommand = new SqlCommand(SqlDbstatement, myconnection);
                mycommand.Parameters.Add("_GroupCode", SqlDbType.VarChar).Value = txtgroupcode.Text;
                mycommand.Parameters.Add("_GroupName", SqlDbType.VarChar).Value = txtgroupname.Text;
                int n0 = mycommand.ExecuteNonQuery();


                txtgroupname.Text = "";
                txtgroupname.Focus();

                da = new SqlDataAdapter("SELECT groupcode + 1 from tblgroup ORDER BY GroupCode desc", myconnection);
                dset = new DataSet();
                da.Fill(dset, "GroupCode");

                DataView dv = new DataView(dset.Tables["GroupCode"]);
                txtgroupcode.Text = Convert.ToString(dv[0].Row[0]).PadLeft(2, '0');
                myconnection.Close();
            }
        }

        private void txtclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}