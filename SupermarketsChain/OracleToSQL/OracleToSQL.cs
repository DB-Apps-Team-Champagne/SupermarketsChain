using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using Oracle.DataAccess;
using System.Data;
using SuperMarketChain.Data;
using SuperMarketChain.Model;

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
                int id = Int32.Parse(dr[0].ToString());
                int vendorId = Int32.Parse(dr[1].ToString());
                string productName = dr[2].ToString();
                int measureId = Int32.Parse(dr[3].ToString());
                decimal price = Decimal.Parse(dr[4].ToString());

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
                int id = Int32.Parse(dr[0].ToString());
                string measureName = dr[1].ToString();

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
                int id = Int32.Parse(dr[0].ToString());
                string vendorName = dr[1].ToString();

                Vendor vendor = new Vendor(id, vendorName);

                vendors.Add(vendor);
            }

            conn.Dispose();

            return vendors;
        }

        public static string GetVendorName(string host, string oraUser, string oraPass, int vendorId)
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

            cmd.CommandText = "select vendorname from vendors where id = " + vendorId;

            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            string vendorName = "";

            while (dr.Read())
            {
                vendorName = dr[0].ToString();
            }

            conn.Dispose();

            return vendorName;
        }
        public static void UploadProductsToSQL(ICollection<Product> products, SupermarketChainContext context)
        {
            foreach (var product in products)
            {
                var vendorName = GetVendorName("EVGENI-PC", "admin", "1111", product.VendorId);
                var vendorId = context.Vendors.Where(v => v.VendorName.Equals(vendorName)).Select(v => v.ID).FirstOrDefault();
                var productSQL = new SuperMarketChain.Model.Product()
                {
                    VendorId = vendorId,
                    ProductName = product.ProductName,
                    MeasureID = product.MeasureId,
                    Price = product.Price
                };
                if (context.Products.Where(p => p.ProductName.Equals(productSQL.ProductName)).Count() == 0)
                {
                    context.Products.Add(productSQL);
                    Console.WriteLine("Product " + productSQL.ProductName + " will be uploaded to SQL db");
                }
                else
                {
                    Console.WriteLine("Product " + productSQL.ProductName + " is already in SQL db and will not be uploaded.");
                }
            }

            if (context.ChangeTracker.HasChanges())
            {
                context.SaveChanges();
            }
            
        }

        public static void UploadVendorsToSQL(ICollection<Vendor> vendors, SupermarketChainContext context)
        {
            foreach (var vendor in vendors)
            {
                var vendorSQL = new SuperMarketChain.Model.Vendor()
                {
                    VendorName = vendor.VendorName
                };

                if (context.Vendors.Where(v => v.VendorName.Equals(vendorSQL.VendorName)).Count() == 0)
                {
                    context.Vendors.Add(vendorSQL);
                    Console.WriteLine("Vendor " + vendorSQL.VendorName + " will be uploaded to SQL db." + vendorSQL.VendorName.Count());
                }
                else
                {
                    Console.WriteLine("Vendor " + vendorSQL.VendorName + "  is already in SQL db and will not be uploaded.");
                }
            }

            if (context.ChangeTracker.HasChanges())
            {
                context.SaveChanges();
            }
        }

        public static void UploadMeasuresToSQL(ICollection<Measure> measures, SupermarketChainContext context)
        {
            foreach (var measure in measures)
            {
                var measureSQL = new SuperMarketChain.Model.Measure()
                {
                    ID = measure.Id,
                    MeasureName = measure.MeasureName
                };

                if (context.Measures.Where(m => m.MeasureName.Equals(measureSQL.MeasureName)).Count() == 0)
                {
                    context.Measures.Add(measureSQL);
                    Console.WriteLine("Measure " + measureSQL.MeasureName + " will be uploaded to SQL db.");
                }
                else
                {
                    Console.WriteLine("Measure " + measureSQL.MeasureName + " is already in SQL db and will not be uploaded.");
                }
            }
            if (context.ChangeTracker.HasChanges())
            {
                context.SaveChanges();
            }
        }
    }
}
