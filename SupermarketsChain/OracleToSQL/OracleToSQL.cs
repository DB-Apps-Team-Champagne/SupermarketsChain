using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace OracleToSQL
{
    public static class OracleToSQL
    {
        public static void ReadTable(string host, string oraUser, string oraPass, string tableName, String[] fields) {
            string oradb = "Data Source=(DESCRIPTION="
             + "(ADDRESS=(PROTOCOL=TCP)(HOST="+ host + ")(PORT=1521))"
             + "(CONNECT_DATA=(SERVICE_NAME=XE)));"
             + "User Id=" + oraUser + ";Password=" + oraPass + ";";
            //string oradb = "Data Source=XE;User Id=" + oraUser + ";Password=" + oraPass + ";";

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select " + 
                string.Join(", ", fields) +
                " from " + tableName;

            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while(dr.Read()) {
                for (int i = 0; i < fields.Length; i++)
                {
                    if (dr.GetDataTypeName(i).Equals("Decimal"))
                    {
                        Console.WriteLine(dr.GetDecimal(i));
                    }
                    else
                    {
                        Console.WriteLine(dr.GetString(i));
                    }
                }
            }

            conn.Dispose();
        }
    }
}
