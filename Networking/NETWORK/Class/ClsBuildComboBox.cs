using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NETWORK
{
    class ClsBuildComboBox
    {
        public ArrayList ARLControlNo = new ArrayList();
        public ArrayList ARLControlNoOR = new ArrayList();
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        ClsDefaultBranch ClsDefaultBranch1 = new ClsDefaultBranch();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 
       

        public void ClsBuildControlno()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT ControlNo, CustName FROM tblCustomer WHERE Active = 1 ORDER by CustName ", myconnection);
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARLControlNo.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
                }
                dr.Close();
                myconnection.Close();
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

        public void ClsBuildControlnoOR()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT ControlNo, CustName FROM tblCustomer WHERE Active = 1 ORDER by CustName ", myconnection);
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARLControlNoOR.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
                }
                dr.Close();
                myconnection.Close();
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
    }
}
