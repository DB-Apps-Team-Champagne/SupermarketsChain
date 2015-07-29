namespace SuperMarketChain.Data.Utils
{
    using System;
    using System.Xml.Linq;
    using System.Linq;
    using Model;

    public static class LoadExpences
    {
        public static void Load()
        {
            var context = new SupermarketChainContext();
            XDocument doc = XDocument.Load("../../../Expences.xml");

            var vendorExpenses = from vendor in doc.Descendants("vendor")
                select new
                {
                    vendorName = vendor.Attribute("name").Value,
                    expences = vendor.Elements("expenses")
                };

            foreach (var v in vendorExpenses)
            {
                var vendor = context.Vendors.Where(ven => ven.VendorName == v.vendorName).First();

                foreach (var e in v.expences)
                {
                    DateTime dt = DateTime.Parse(e.Attribute("month").Value);
                    decimal amount = Decimal.Parse(e.Value);
                    context.Expences.Add(new Expence
                    {
                        Vendor = vendor,
                        Amount = amount,
                        Date = dt
                    });
                }
            }
            context.SaveChanges();
        }
    }
}
