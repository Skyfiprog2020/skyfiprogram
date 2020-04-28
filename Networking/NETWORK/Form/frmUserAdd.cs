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
using System.Security.Cryptography;

namespace NETWORK
{
    public partial class frmUserAdd : Form
    {
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmUserAdd()
        {
            InitializeComponent();
        }
        private void frmUserAdd_Load(object sender, EventArgs e)
        {

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            if (new Clsexist().RecordExists(ref myconnection, "SELECT Right([UserCode],4) AS NumberCode FROM tblUser ORDER BY Right([UserCode],4) ASC;"))
            {
                mycommand = new SqlCommand("SELECT TOP 1 Right([UserCode],4) AS NumberCode FROM tblUser ORDER BY Right([UserCode],4) DESC;", myconnection);
                dr = mycommand.ExecuteReader();
                showAutNum();

            }
            else
            {
                txtUserCode.Text = "0001";
                myconnection.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            if (new Clsexist().RecordExists(ref myconnection, "SELECT UserName FROM tblUser WHERE UserName ='" + txtUserName.Text + "'"))
            {
                myconnection.Close();
                MessageBox.Show("Account Name already exist", "GL");
                txtUserName.Focus();
            }
            else if (string.IsNullOrEmpty(txtUserName.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                txtUserName.Focus();
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                txtPassword.Focus();
            }
            else if (string.IsNullOrEmpty(txtVerify.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                txtVerify.Focus();
            }
            else if (txtPassword.Text != txtVerify.Text)
            {
                myconnection.Close();
                MessageBox.Show("Verify your password by retyping it to Verify Box", "GL");
                txtVerify.Focus();
            }
            else
            {
                string sqlstatement;
                sqlstatement = "INSERT INTO tblUser (UserCode, PWord, GroupCode, UserName) Values (@_UserCode, @_PWord, @_GroupCode, @_UserName)";
                mycommand = new SqlCommand(sqlstatement, myconnection);
                mycommand.Parameters.Add("_UserCode", SqlDbType.VarChar).Value = "A" + txtUserCode.Text;
                mycommand.Parameters.Add("_PWord", SqlDbType.VarChar).Value = getMd5Hash(txtPassword.Text);
                mycommand.Parameters.Add("_GroupCode", SqlDbType.VarChar).Value = "01";
                mycommand.Parameters.Add("_UserName", SqlDbType.VarChar).Value = txtUserName.Text;
                int n1 = mycommand.ExecuteNonQuery();

                mycommand = new SqlCommand("SELECT TOP 1 Right([UserCode],4) AS NumberCode FROM tblUser ORDER BY Right([UserCode],4) DESC;", myconnection);
                dr = mycommand.ExecuteReader();
                showdatainfo();
                dr.Close();
                myconnection.Close();

                txtUserName.Text = "";
                txtPassword.Text = "";
                txtVerify.Text = "";
                txtUserName.Focus();

            }
        }
        private void showdatainfo()
        {
            try
            {
                while (dr.Read())
                {
                    string no1;
                    int no2;
                    no1 = dr[0].ToString();
                    no2 = (int.Parse(no1)) + 1;

                    txtUserCode.Text = Convert.ToString(no2).PadLeft(4, '0');
                }
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
        private void showAutNum()
        {
            try
            {
                while (dr.Read())
                {
                    string no1;
                    int no2;
                    no1 = dr[0].ToString();
                    no2 = (int.Parse(no1)) + 1;
                    txtUserCode.Text = Convert.ToString(no2).PadLeft(4, '0');
                }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}
