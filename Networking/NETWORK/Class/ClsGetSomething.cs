using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace NETWORK
{
    class ClsGetSomething
    {
        public string plsvarCAdress;
        public string plsvarCustNameAdress, plsTerm;
        public string plsdefdate;
        public string plsBeginDate;
        public string plsEndDate;
        public string plsVersionGo;
        public string plsVATRate;
        public string plsProcessTime;
        public string strMasterCode, strCustmerCode, strUplineMasterCode;
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public void ClsGetBranchAddress(string strCNCode)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                mycommand = new SqlCommand("SELECT CAddress FROM tblCompanyName WHERE CNCode='" + strCNCode + "'", myconnection);
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        plsvarCAdress = dr["CAddress"].ToString();
                    }
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

        
        public void ClsGetDefaultDate()
        {
            DateTime VarToday = DateTime.Today;
            plsdefdate = String.Format("{0:MM/dd/yyyy}", VarToday);
        }

   
        public void ClsGetSecureDate()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                mycommand = new SqlCommand("SELECT * FROM tblSecurityDate", myconnection);
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    DateTime dtBeginDate = Convert.ToDateTime(dr["BeginDate"].ToString());
                    DateTime dtEndDate = Convert.ToDateTime(dr["EndDate"].ToString());
                    plsBeginDate = String.Format("{0:MM/dd/yyyy}", dtBeginDate);
                    plsEndDate = String.Format("{0:MM/dd/yyyy}", dtEndDate);
                }
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

        public void ClsConfirmVersionNum()
        {
            try
            {
                string vnumdb;
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select VersionNum FROM tblCover", myconnection);
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    vnumdb = dr["VersionNum"].ToString();
                    if (vnumdb == "1")
                    {
                        plsVersionGo = "Yes";
                    }
                    else
                    {
                        plsVersionGo = "No";
                    }
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

        public void ClsGetCustData(string strControlNo)
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select Term, Address FROM tblCustomer WHERE ControlNo = '" + strControlNo + "'", myconnection);
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsTerm = dr["Term"].ToString();
                    plsvarCustNameAdress = dr["Address"].ToString();
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

   
        public void ClsGetVATRate()
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select VAT FROM tblVat", myconnection);
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsVATRate = (Convert.ToDouble(dr["VAT"]) + 1).ToString();

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


        public void ClsGetMachineProcessTime(string strMachineCode)
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select ProcessTime FROM tblMachine WHERE MachineCode = '" + strMachineCode + "'", myconnection);
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsProcessTime = dr["ProcessTime"].ToString();
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
        public void GetCode(string varControlNo)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT * FROM tblMain1 WHERE ControlNo = '" + varControlNo + "' ", myconnection);
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    strMasterCode = dr["NetWorkingCode"].ToString();
                    strUplineMasterCode = dr["ControlNo"].ToString();
                }
                myconnection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error \r\n" + ex.ToString());
            }
        }
        public void GetCustomerNo(string varControlNo)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT * FROM tblCustomer WHERE ControlNo = '" + varControlNo + "' ", myconnection);
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    strCustmerCode = dr["ControlNo"].ToString();
                }
                myconnection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error \r\n" + ex.ToString());
            }
        }
    }
}
