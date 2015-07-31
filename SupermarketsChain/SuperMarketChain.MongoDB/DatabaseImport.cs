using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketChain.Data;
using SuperMarketChain.Model;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.Operations;
using MongoDB.Bson;
using ExtensionsMethods;
using System.IO;
using System.Web.Script.Serialization;

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

            
            var serializer = new JavaScriptSerializer();
            string[] filePaths = Directory.GetFiles(@"..\..\..\Json-Reports");
            foreach (var item in filePaths)
            {
                var des = serializer.Deserialize<SuperMarketChain.JSON.JSONObject>(System.IO.File.ReadAllText(item));
               
                saleReports.Insert(new MongoDBObject()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ProductID = des.productID,
                    ProductName = des.productName,
                    income = des.income,
                    QuantitySold = des.quantitySold,
                    Vendor = des.vendorName
                });

            }
        
            
        }
    }
}
