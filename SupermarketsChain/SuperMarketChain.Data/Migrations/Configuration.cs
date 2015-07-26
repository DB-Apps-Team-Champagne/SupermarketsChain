namespace SuperMarketChain.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Model;

    internal sealed class Configuration : DbMigrationsConfiguration<SuperMarketChain.Data.SupermarketChainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SuperMarketChain.Data.SupermarketChainContext";
        }

        protected override void Seed(SuperMarketChain.Data.SupermarketChainContext context)
        {
            if (context.Vendors.Count() == 0)
            {
                context.Vendors.Add(new Vendor
                {
                    VendorName = "Zagorka OOD"
                });

                context.Vendors.Add(new Vendor
                {
                    VendorName = "Pesho Birata Ltd"
                });

                context.Vendors.Add(new Vendor
                {
                    VendorName = "Kiro-Rocky ET"
                });
            }

            if (context.Measures.Count() == 0)
            {
                context.Measures.Add(new Measure
                {
                    MeasureName = "kg"
                });

                context.Measures.Add(new Measure
                {
                    MeasureName = "piece"
                });

                context.Measures.Add(new Measure
                {
                    MeasureName = "liter"
                });
            }

            if (context.Products.Count() == 0)
            {
                context.Products.Add(new Product
                {
                    MeasureID = 3,
                    VendorId = 2,
                    Price = 0.99m,
                    ProductName = "Bira (mnogo silna)"
                });

                context.Products.Add(new Product
                {
                    MeasureID = 3,
                    VendorId = 2,
                    Price = 0.49m,
                    ProductName = "Bira (mnogo slaba)"
                });

                context.Products.Add(new Product
                {
                    MeasureID = 3,
                    VendorId = 2,
                    Price = 0.39m,
                    ProductName = "Bira (bez alkohol)"
                });

                context.Products.Add(new Product
                {
                    MeasureID = 2,
                    VendorId = 3,
                    Price = 6.99m,
                    ProductName = "Vodka (mnogo silna)"
                });

                context.Products.Add(new Product
                {
                    MeasureID = 2,
                    VendorId = 3,
                    Price = 4.99m,
                    ProductName = "Vodka (mnogo slaba)"
                });

                context.Products.Add(new Product
                {
                    MeasureID = 2,
                    VendorId = 3,
                    Price = 14.99m,
                    ProductName = "Vodka smurt"
                });

                context.Products.Add(new Product
                {
                    MeasureID = 1,
                    VendorId = 4,
                    Price = 0.99m,
                    ProductName = "Shokolad"
                });

                context.Products.Add(new Product
                {
                    MeasureID = 1,
                    VendorId = 4,
                    Price = 0.49m,
                    ProductName = "Fafla"
                });

                context.Products.Add(new Product
                {
                    MeasureID = 3,
                    VendorId = 4,
                    Price = 1.49m,
                    ProductName = "Sok ot praskovi"
                });
            }
        }
    }
}
