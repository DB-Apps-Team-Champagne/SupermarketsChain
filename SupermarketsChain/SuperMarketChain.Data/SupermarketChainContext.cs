namespace SuperMarketChain.Data
{
    using SuperMarketChain.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;

    public class SupermarketChainContext : DbContext
    {
        public SupermarketChainContext()
            : base("name=SupermarketChainContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SupermarketChainContext, Configuration>());
        }

        public IDbSet<Measure> Measures { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }
    }
}