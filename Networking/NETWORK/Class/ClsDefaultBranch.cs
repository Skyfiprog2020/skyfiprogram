using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace NETWORK
{
    class ClsDefaultBranch
    {
        private SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        public string plsvardb;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public ClsDefaultBranch()
        {
          try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select CNCode from tblUser WHERE UserCode = '"+ Form1.glbluc.Text+"'", myconnection);
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsvardb = dr["CNCode"].ToString();
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
