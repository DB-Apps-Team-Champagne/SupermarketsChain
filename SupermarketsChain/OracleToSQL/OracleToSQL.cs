using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using Oracle.DataAccess;
using System.Data;

namespace OracleToSQL
{
    public static class OracleToSQL
    {
        public static ICollection<Product> GetProductTable(string host, string oraUser, string oraPass, string tableName, String[] fields) {
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

            ICollection<Product> products = new HashSet<Product>();

            while(dr.Read()) {
                int id = dr.GetInt32(0);
                int vendorId = dr.GetInt32(1);
                string productName = dr.GetString(2);
                int measureId = dr.GetInt32(3);
                decimal price = dr.GetDecimal(4);

                Product product = new Product(id, vendorId, productName, measureId, price);

                products.Add(product);
            }

            conn.Dispose();

            return products;
        }

        public static ICollection<Measure> GetMeasureTable(string host, string oraUser, string oraPass, string tableName, String[] fields)
        {
            string oradb = "Data Source=(DESCRIPTION="
             + "(ADDRESS=(PROTOCOL=TCP)(HOST=" + host + ")(PORT=1521))"
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

            ICollection<Measure> measures = new HashSet<Measure>();

            while (dr.Read())
            {
                int id = dr.GetInt32(0);
                string measureName = dr.GetString(1);

                Measure measure = new Measure(id, measureName);

                measures.Add(measure);
            }

            conn.Dispose();

            return measures;
        }

        public static ICollection<Vendor> GetVendorTable(string host, string oraUser, string oraPass, string tableName, String[] fields)
        {
            string oradb = "Data Source=(DESCRIPTION="
             + "(ADDRESS=(PROTOCOL=TCP)(HOST=" + host + ")(PORT=1521))"
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

            ICollection<Vendor> vendors = new HashSet<Vendor>();

            while (dr.Read())
            {
                int id = dr.GetInt32(0);
                string vendorName = dr.GetString(1);

                Vendor vendor = new Vendor(id, vendorName);

                vendors.Add(vendor);
            }

            conn.Dispose();

            return vendors;
        }
    }
}
