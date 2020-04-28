using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace NETWORK
{
    public class ClsValidation
    {
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();

        public string plsoutdate;
        public string CheckNoTransact;
        public int CountData;

        public bool isNumeric(string val)
        {
            if (isInt(val) || isDouble(val))
                return true;
            else
                return false;
        }

        public bool isInt(string val)
        {
            int num;
            if (int.TryParse(val, out num))
                return false;
            else
                return true;
        }

        public bool isDouble(string val)
        {
            double num;
            if (double.TryParse(val, out num))
                return false;
            else
                return true;
        }

        public bool emptytxt(string val)
        {
            if (String.IsNullOrEmpty(val))
                return true;
            else
                return false;
        }

        public bool errordate(string val)
        {
            DateTime num;
            if (val == "  /  /")
                return false;
            if (Convert.ToInt16(val.Length) < 10)
                return true;
            else if (!DateTime.TryParse(val, out num))
                return true;
            else
                return false;
        }
        public void securedate(DateTime clsvartdate)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                {
                    mycommand = new SqlCommand("Select BeginDate, EndDate  FROM tblSecurityDate", myconnection);
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        string varstrbd = dr["BeginDate"].ToString();
                        string varstred = dr["EndDate"].ToString();
                        DateTime bd = DateTime.Parse(varstrbd);
                        DateTime ed = DateTime.Parse(varstred);
                        if (clsvartdate < bd || clsvartdate > ed)
                        {
                            plsoutdate = "Yes";
                        }
                        else
                        {
                            plsoutdate = "No";
                        }
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
                dr.Close();
                myconnection.Close();
            }
        }
        public bool DataExist1(string strTableName, string strFieldName, string strCNCode, string strValueFieldName, string strValueCNCode)
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            CheckNoTransact = string.Format("SELECT Count(*) FROM {0} WHERE {1}='" + strValueFieldName + "' AND {2}='" + strValueCNCode + "'", strTableName, strFieldName, strCNCode);
            SqlCommand com = new SqlCommand(CheckNoTransact, myconnection);
            CountData = int.Parse(com.ExecuteScalar().ToString());
            myconnection.Close();
            if (CountData > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
