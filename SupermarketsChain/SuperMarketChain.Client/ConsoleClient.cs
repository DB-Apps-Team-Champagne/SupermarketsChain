using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketChain.Data;
using OracleToSQL;
using SuperMarketChain.Data.Utils;
using SuperMarketChain.MySQL;
using MySql.Data.MySqlClient;
using System.Data.SQLite;

namespace SuperMarketChain.Client
{
    class ConsoleClient
    {
        static void Main()
        {
            CreateSQLite();
            //var context = new SupermarketChainContext();

            //var mysqlContext = new SupermarketChainMySQL(SuperMarketChain.Data.Utils.MySQL.connectionString);

            //SuperMarketChain.Data.Utils.MySQL.CreateDBIfNonExistent();

            //SuperMarketChain.Data.Utils.MySQL.ImportVendorsFromMSSqlToMySQL(context);

            //SuperMarketChain.Data.Utils.MySQL.ImportMeasuresFromMSSqlToMySQL(context);

            //SuperMarketChain.Data.Utils.MySQL.ImportProductsFromMSSqlToMySQL(context);

            //SuperMarketChain.Data.Utils.MySQL.ImportSalesReportsFromMSSqlToMySQL(context);

            //SuperMarketChain.Data.Utils.MySQL.ImportExprencesFromMSSqlToMySQL(context);

            //Excel ex = new Excel();
            //ex.unZip();
            //ex.folderLoop();
            //ex.deleteFolder();

            //var productCount = context.Products.Count();

            //Console.WriteLine(productCount);

            //var prodFields = new String[] { "id", "vendorid", "productname", "measureid", "price" };

            //var prodData = OracleToSQL.OracleToSQL.GetProductTable("Barish", "admin", "admin", "PRODUCTS", prodFields);

            //var measFields = new String[] { "id", "measurename" };

            //var measData = OracleToSQL.OracleToSQL.GetMeasureTable("Barish", "admin", "admin", "Measures", measFields);

            //var vendorFields = new String[] { "id", "vendorname" };

            //var vendorData = OracleToSQL.OracleToSQL.GetVendorTable("Barish", "admin", "admin", "Vendors", vendorFields);

            //foreach (Vendor item in vendorData)
            //{
            //   Console.WriteLine(item.VendorName);
            //}
            //Console.WriteLine();

            //VendorsReport.GetVendorReport(new DateTime(2000, 10, 10), new DateTime(2016, 10, 10));

            //LoadExpences.Load();

            //GenerateSalesReportPdf.Generate(context, new DateTime(2000, 10, 10), new DateTime(2016, 10, 10));

        }
        private static void CreateSQLite()
        {
            SQLiteConnection.CreateFile("SQLiteDatabase.sqlite");
            SQLiteConnection m_dbConnection =
                    new SQLiteConnection("Data Source=SQLiteDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = "CREATE TABLE taxes (productname NVARCHAR(100), tax INT)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            var context = new SupermarketChainContext();

            var products = context.Products.Select(p => p.ProductName).Distinct();


            var r = new Random();
            foreach (var item in products)
            {
                string prodName = item;
                string insert = "insert into taxes (productname, tax) values ('" + prodName + "', '" + r.Next(10, 30) + "')";

                SQLiteCommand cmd = new SQLiteCommand(insert, m_dbConnection);
                cmd.ExecuteNonQuery();
            }

            string taxReader = "select * from taxes order by tax desc";
            SQLiteCommand readCommand = new SQLiteCommand(taxReader, m_dbConnection);
            SQLiteDataReader reader = readCommand.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["productName"] + "\tScore: " + reader["tax"] + "%");

            m_dbConnection.Close();
        }
    }
}
