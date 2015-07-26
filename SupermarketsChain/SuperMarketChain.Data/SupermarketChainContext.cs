namespace SuperMarketChain.Data
{
    using SuperMarketChain.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class SupermarketChainContext : DbContext
    {
        public SupermarketChainContext()
            : base("name=SupermarketChainContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SupermarketChainContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public IDbSet<Measure> Measures { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<SaleReport> SaleReports { get; set; }
    }
}