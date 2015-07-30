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

namespace SuperMarketChain.Client
{
    class ConsoleClient
    {
        static void Main()
        {
            var context = new SupermarketChainContext();

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

            GenerateSalesReportPdf.Generate(context, new DateTime(2000, 10, 10), new DateTime(2016, 10, 10));

        }
    }
}
