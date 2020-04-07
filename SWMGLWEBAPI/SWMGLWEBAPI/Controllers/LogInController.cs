using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SWMGLWEBAPI.Connector;
using SWMGLWEBAPI.Models;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace SWMGLWEBAPI.Controllers
{
    public class LogInController : ApiController
    {
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        //ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        SqlConnection myconnection;
        //SqlCommand mycommand;
        //SqlCommand mycommandPWord;
        //private string pristrUserNameLog, pristrPWordLog;
        private string pristrPWordMsg;
        //[HttpPost]
        //[Route("API/SWM/PostUserLogin")]
        //public HttpResponseMessage Post([FromBody] ClsLoginXamarin ClsLoginXamarin1)
        //{

        //    pristrUserNameLog = ClsLoginXamarin1.UserNameLog;
        //    pristrPWordLog = ClsLoginXamarin1.PWordLog;
        //    var message = Request.CreateResponse(HttpStatusCode.Created, ClsLoginXamarin1);
        //    message.Headers.Location = new Uri(Request.RequestUri + ClsLoginXamarin1.UserNameLog.ToString());
        //    return message;
        //}

        [HttpGet]
        [Route("API/SWM/GetLoginResultSalesman")]
        public string GetLogResult(string pristrUserNameLog, string pristrPWordLog)
 
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            string CheckNoTransact = string.Format("SELECT Count(*) FROM tblSalesman WHERE SMDesc = '" + pristrUserNameLog + "'");
            SqlCommand com = new SqlCommand(CheckNoTransact, myconnection);
            int CountData = int.Parse(com.ExecuteScalar().ToString());

            string strDBPassword = string.Format("SELECT SMPWord FROM tblSalesman WHERE SMDesc = '" + pristrUserNameLog + "'");
            SqlCommand comPWord = new SqlCommand(strDBPassword, myconnection);
            string GetPWord = comPWord.ExecuteScalar().ToString();

            myconnection.Close();

            if (CountData > 0)
            {
                if (verifyMd5Hash(pristrPWordLog, GetPWord))
                {
                    pristrPWordMsg = "1";
                }
                else
                {
                    pristrPWordMsg = "2";
                }
                return pristrPWordMsg;
            }
            else
            {
                return "2";
            }
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
    }
}
