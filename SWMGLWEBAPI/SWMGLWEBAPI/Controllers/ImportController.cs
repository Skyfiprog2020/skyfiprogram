using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using SWMGLWEBAPI.Connector;
using SWMGLWEBAPI.Models;
namespace SWMGLWEBAPI.Controllers
{
    public class ImportController : ApiController
    {
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader dr;
        List<ClsModelsCustomer> ClsModelsCustomerMSSQL = new List<ClsModelsCustomer>();
        List<ClsModelsCurrentSalesman> ClsModelsCurrentSalesmanMSSQL = new List<ClsModelsCurrentSalesman>();
        List<ClsModelsReceiveList> ClsModelsReceiveListMSSQL = new List<ClsModelsReceiveList>();

        [HttpGet]
        [Route("API/SWMGLWEBAPI/Import/SalesmanCustomer")]
        public IEnumerable<ClsModelsCustomer> GetSalesmanCustomer(string strSMCode)
        {
            priGetSalesmanCustomer(strSMCode);
            return ClsModelsCustomerMSSQL;
        }

        private void priGetSalesmanCustomer(string strSMCode)
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("SELECT ControlNo, CustName FROM tblCustomer WHERE SMCode='"+strSMCode+"' ", myconnection);
            dr = mycommand.ExecuteReader();
            while (dr.Read())
            {
                ClsModelsCustomer ClsModelsCustomer1MSSQL = new ClsModelsCustomer
                {
                    ControlNo = dr["ControlNo"].ToString(),
                    CustName = dr["CustName"].ToString(),
                };
                ClsModelsCustomerMSSQL.Add(ClsModelsCustomer1MSSQL);
            }
            myconnection.Close();
        }

        [HttpGet]
        [Route("API/SWMGLWEBAPI/Import/CurrentSalesman")]
        public IEnumerable<ClsModelsCurrentSalesman> GetCurrentSalesman(string strSMDesc)
        {
            priGetCurrentSalesman(strSMDesc);
            return ClsModelsCurrentSalesmanMSSQL;
        }

        private void priGetCurrentSalesman(string strSMDesc)
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("SELECT SMCode, SMDesc FROM tblSalesman WHERE SMDesc='" + strSMDesc + "' ", myconnection);
            dr = mycommand.ExecuteReader();
            while (dr.Read())
            {
                ClsModelsCurrentSalesman ClsModelsCurrentSalesman1MSSQL = new ClsModelsCurrentSalesman
                {
                    SMCode = dr["SMCode"].ToString(),
                    SMDesc = dr["SMDesc"].ToString(),
                };
                ClsModelsCurrentSalesmanMSSQL.Add(ClsModelsCurrentSalesman1MSSQL);
            }
            myconnection.Close();
        }


        [HttpGet]
        [Route("API/SWMGLWEBAPI/Import/SalesmanReceivableList")]
        public IEnumerable<ClsModelsReceiveList> GetReceivableList(string strSMCode)
        {
            priGetReceivableList(strSMCode);
            return ClsModelsReceiveListMSSQL;
        }

        private void priGetReceivableList(string strSMCode)
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("SELECT MinDate, Refer, ControlNo, ReceiveBalance FROM ViewAppReceivableList WHERE SMCode='" + strSMCode + "' ", myconnection);
            dr = mycommand.ExecuteReader();
            while (dr.Read())
            {
                ClsModelsReceiveList ClsModelsReceiveList1MSSQL = new ClsModelsReceiveList
                {
                    MinDate = DateTime.Parse(dr["MinDate"].ToString()),
                    Refer = dr["Refer"].ToString(),
                    ControlNo = dr["ControlNo"].ToString(),
                    ReceiveBalance = double.Parse(dr["ReceiveBalance"].ToString()),
                };
                ClsModelsReceiveListMSSQL.Add(ClsModelsReceiveList1MSSQL);
            }
            myconnection.Close();
        }

    }
}
