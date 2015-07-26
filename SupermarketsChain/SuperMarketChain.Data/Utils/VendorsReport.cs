namespace SuperMarketChain.Data.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using SuperMarketChain.Data;

    public static class VendorsReport
    {
        public static void GetVendorReport(DateTime firstDate, DateTime secondDate){
            var context = new SupermarketChainContext();
            var reportData = new Dictionary<string, Dictionary<DateTime, decimal>>();

            var sales = context.SaleReports
                .Where(s => s.SaleTime >= firstDate && s.SaleTime <= secondDate)
                .Select(s => new
                {
                    Vendor = s.Vendor,
                    Date = s.SaleTime,
                    Quantity = s.Quantity,
                    Product = s.Product
                });

            foreach (var s in sales)
            {
                string vendorName = s.Vendor.VendorName;
                if (reportData.ContainsKey(vendorName))
                {
                    reportData[vendorName].Add(s.Date, (decimal)s.Quantity * s.Product.Price);
                }
                else
                {
                    var dic = new Dictionary<DateTime, Decimal>();
                    dic.Add(s.Date, (decimal)s.Quantity * s.Product.Price);
                    reportData.Add(vendorName, dic);
                }
            }

            var xmlReport = new XElement("sales");
            foreach (var r in reportData)
            {
                XElement sale = new XElement("sale",
                    new XAttribute("vendor", r.Key));
                for (int i = 0; i < r.Value.Keys.Count; i++)
			    {
			        sale.Add(new XElement("summary",
                        new XAttribute("date", r.Value.Keys.ElementAt(i).ToShortDateString()),
                        new XAttribute("sum", r.Value[r.Value.Keys.ElementAt(i)])));
			    }
                xmlReport.Add(sale);
            }
            xmlReport.Save("../../../SalesReport.xml");
            Console.WriteLine("XML Sales Report Created Check The Root Directory");
        }
    }
}
