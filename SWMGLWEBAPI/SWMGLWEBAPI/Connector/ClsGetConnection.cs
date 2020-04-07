using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWMGLWEBAPI.Connector
{
  
    public class ClsGetConnection
    {
        // SqlConnection myconnectionMSSQL;
        public string plsMyConMSSQL;

        public void ClsGetConMSSQL()
        {
            //WINSERVER\SQLEXPRESS01
            //plsMyConMSSQL = "Server =  WINSERVER; Database = SWMGL_BE; User ID = server2008; Password = Mssqlone1; Trusted_Connection = False;";
            //plsMyConMSSQL = "Server =  WINSERVER\\SQLEXPRESS01; Database = SWMGL_BE; User ID = server2008; Password = Mssqlone1; Trusted_Connection = False;";
            plsMyConMSSQL = "Server =  skyfi.cjpyqlwr1j1x.ap-southeast-1.rds.amazonaws.com,1433; Database = SWMGL_BE; User ID = skyfi; Password = Skyfi2020; Trusted_Connection = False;";

        }

    }
}