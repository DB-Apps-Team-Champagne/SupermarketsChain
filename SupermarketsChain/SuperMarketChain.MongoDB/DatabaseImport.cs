using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketChain.Data;
using SuperMarketChain.Model;


namespace SuperMarketChain.MongoDB
{
    class DatabaseImport
    {
        static void Main()
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("Reports");

            var saleReports = db.GetCollection<MongoDBObject>("SalesByProductReports");

            var context = new SupermarketChainContext();
            var reports = context.SaleReports.Select(s => new
            {
                s.Product.ProductName,
                s.Quantity,
                s.SaleTime,
                s.Vendor.VendorName
            });

            foreach (var item in reports)
            {
                saleReports.Insert(new MongoDBObject()
                {
                   Product = item.ProductName,
                   Quantity = item.Quantity,
                   SaleTime = item.SaleTime,
                   Vendor = item.VendorName
                });
            }


            
        }
    }
}
