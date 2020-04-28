using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace NETWORK
{
    class ClsGetConnection
    {
        //SqlConnection myconnectionMSSQL;
        public string plsMyConMSSQL;

        public void ClsGetConMSSQL()
        {
            plsMyConMSSQL = "Server = '"+Form1.glblservername.Text+"'; Database = NETWORK_BE; User ID = server2008; Password = Mssqlone1; Trusted_Connection = False;";
            //plsMyConMSSQL = "Server = '"+Form1.glblservername.Text+"'; Database = AVAREDEMO_BE; User ID = server2008; Password = Mssqlone1; Trusted_Connection = False;";

            //myconnectionMSSQL = new SqlConnection(plsMyConMSSQL);
        }
    }
}
