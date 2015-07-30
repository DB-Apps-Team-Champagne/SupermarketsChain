using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketChain.Data;
using OracleToSQL;
using SuperMarketChain.Data.Utils;

namespace SuperMarketChain.Client
{
    class ConsoleClient
    {
        static void Main()
        {
            Excel ex = new Excel();
            ex.unZip();
            ex.folderLoop();
            ex.deleteFolder();

            var context = new SupermarketChainContext();

            var productCount = context.Products.Count();

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

        }
    }
}
