using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace NETWORK
{
    class ClsAutoNumber
    {
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader dr;
        public string plsnumber;
        ClsDefaultBranch ClsDefaultBranch1 = new ClsDefaultBranch();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public void CustomerNameAdd()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (new Clsexist().RecordExists(ref myconnection, "SELECT Top 1 ControlNo FROM tblCustomer WHERE CNCode ='" + (ClsDefaultBranch1.plsvardb) + "'"))
                {
                    mycommand = new SqlCommand("SELECT Top 1 ControlNo FROM tblCustomer WHERE CNCode='" + (ClsDefaultBranch1.plsvardb) + "' ORDER BY ControlNo DESC", myconnection);
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        string no1;
                        int no2;
                        no1 = dr[0].ToString();
                        no2 = (int.Parse(no1)) + 1;
                        plsnumber = Convert.ToString(no2).PadLeft(7, '0');
                    }
                }
                else
                {
                    plsnumber = "0000001";
                }
                if (plsnumber == "0000001")
                {
                    myconnection.Close();
                }
                else
                {
                    dr.Close();
                    myconnection.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                //dr.Close();
                myconnection.Close();
            }
        }


         public void VoucherAutoNum(string argvoucher)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (new Clsexist().RecordExists(ref myconnection, "SELECT Top 1 DocNum FROM tblMain1 WHERE CNCode='" + (ClsDefaultBranch1.plsvardb) + "' AND Voucher ='" + argvoucher + "' AND (ISNUMERIC(DocNum) = 1)"))
                {
                    mycommand = new SqlCommand("SELECT Top 1 DocNum FROM tblMain1 WHERE CNCode='" + (ClsDefaultBranch1.plsvardb) + "' AND Voucher = '" + argvoucher + "' AND (ISNUMERIC(DocNum) = 1) ORDER BY DocNum DESC", myconnection);
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        string no1 = null;
                        int no2;
                        no1 = dr["DocNum"].ToString();
                        no2 = (int.Parse(no1)) + 1;
                        plsnumber = Convert.ToString(no2).PadLeft(7, '0');
                    }
                }
                else
                {
                    plsnumber = "0000001";
                }
                if (plsnumber == "0000001")
                {
                    myconnection.Close();
                }
                else
                {
                    dr.Close();
                    myconnection.Close();
                }
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                //dr.Close();
                myconnection.Close();
            }
        }


         public void VoucherLatestNum(string argvoucher, string varCNCode)
         {
             try
             {
                 ClsGetConnection1.ClsGetConMSSQL();
                 myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                 myconnection.Open();
                 mycommand = new SqlCommand("SELECT Top 1 DocNum FROM tblMain1 WHERE  Voucher = '" + argvoucher + "' AND CNCode='"+varCNCode+"' ORDER BY DocNum DESC", myconnection);
                 dr = mycommand.ExecuteReader();
                 while (dr.Read())
                 {
                     plsnumber = dr["DocNum"].ToString();
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
                 //dr.Close();
                 myconnection.Close();
             }
         }

         

    }
}
