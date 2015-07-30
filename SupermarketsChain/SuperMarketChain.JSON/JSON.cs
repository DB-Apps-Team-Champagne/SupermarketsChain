using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketChain.Model;
using SuperMarketChain.Data;
using System.Web.Script.Serialization;
using System.IO;

namespace SuperMarketChain.JSON
{
    class JSON
    {
        static void Main()
        {

            var context = new SupermarketChainContext();
            var productData = context.SaleReports.GroupBy(sl => sl.ProductId).Select(g => new
            {
                sum = g.Sum(p => p.Quantity),
                productID = g.Select(p => p.ProductId),
                productName = g.Select(p => p.Product.ProductName),
                price = g.Sum(p => p.Product.Price),
                vendor = g.Select(p => p.Vendor.VendorName)
            });



            foreach (var item in productData)
            {
                decimal decNumber;
                double sum = Double.Parse(item.price.ToString());
                double mult = sum * item.sum;
                JSONObject JO = new JSONObject();
                JO.productID = item.productID.ElementAt(0);
                JO.productName = item.productName.ElementAt(0);
                JO.quantitySold = item.sum;
                JO.income = mult;
                JO.vendorName = item.vendor.ElementAt(0);
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(JO);
                File.WriteAllText(@"..\..\..\Json-Reports\" + item.productID.ElementAt(0) + ".json", json);
                
            }
        }
    }
}
