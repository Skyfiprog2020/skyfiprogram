using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace NETWORK
{
    public partial class Form1 : Form
    {
        public static TextBox glbluc;
        public static TextBox glblgroupcode;
        public static TextBox glblservername;
        SqlConnection myconnection;
        SqlCommand mycommand;
        //BindingSource dbind = new BindingSource();
        SqlDataReader dr;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        public Form1()
        {
            InitializeComponent();
        }
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            okenter();
        }

        static string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        static bool verifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = getMd5Hash(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void okenter()
        {
            try
            {
                ClsGetSomething1.ClsConfirmVersionNum();
                usernameexist();
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();


                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    MessageBox.Show("Name is empty", "GL");
                    txtUserName.Focus();
                    myconnection.Close();
                }
                else if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Password is empty", "GL");
                    txtPassword.Focus();
                    myconnection.Close();
                }
                else if (string.IsNullOrEmpty(txtUserExist.Text))
                {
                    MessageBox.Show("User Name does not exist", "GL");
                    txtUserName.Focus();
                    myconnection.Close();
                }
                else if ((ClsGetSomething1.plsVersionGo) == "No")
                {
                    MessageBox.Show("New Version is available, please install", "GL");
                    this.Close();
                }

                else

                    if (verifyMd5Hash(txtPassword.Text, txtPasswordExist.Text))
                    {
                        this.Hide();
                        frmMain fm = new frmMain();
                        fm.Show();

                       

                    }
                    else
                    {
                        MessageBox.Show("Password is invalid", "GL");
                        txtPassword.Focus();
                    }

                myconnection.Close();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
               
            }
            finally
            {
                myconnection.Close();
            }
        }

        private void usernameexist()
        {
            try
            {
                txtUserExist.Clear();
                txtPasswordExist.Clear();
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                mycommand = new SqlCommand ("SELECT * FROM tblUser WHERE UserName='" + txtUserName.Text.Trim() + "'", myconnection);
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    txtUserExist.Text = dr["UserName"].ToString();
                    txtPasswordExist.Text = dr["PWord"].ToString();
                    txtGroupCode.Text = dr["GroupCode"].ToString();
                    txtUserCode.Text = dr["UserCode"].ToString();
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

       
        private void Form1_Load(object sender, EventArgs e)
        {
            glbluc = txtUserCode;
            glblgroupcode = txtGroupCode;
            glblservername = txtServerName;
        //    ncompany();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                okenter();
            }

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                okenter();
            }

        }

        private void cbConnectMode_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConnectMode.Checked)
            {
                txtServerName.Text = "1iexterminate.ddns.net";
            }
            else
            {
                txtServerName.Text = "WINSERVER";
                //txtServerName.Text = "WINSERVER\\MSSQLSERVER2012";

            }
        }
    }
}
