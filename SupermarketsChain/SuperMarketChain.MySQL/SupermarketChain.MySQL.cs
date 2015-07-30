namespace SuperMarketChain.MySQL
{
    using MySql.Data.Entity;
    using System;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Linq;
    using SuperMarketChain.Model;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using MySql.Data.MySqlClient;

    [DbConfigurationType(typeof(MultipleDbConfiguration))]
    public class SupermarketChainMySQL : DbContext
    {
        public SupermarketChainMySQL()
            : base()
        {
        }

        // Constructor to use on a DbConnection that is already opened
        public SupermarketChainMySQL(string nameOrConnectionString)
            : base(MultipleDbConfiguration.GetMySqlConnection(nameOrConnectionString), true)
        {
 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


        public IDbSet<Measure> Measures { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<SaleReport> SaleReports { get; set; }

        public IDbSet<Expence> Expences { get; set; }
    }


    public class MultipleDbConfiguration : DbConfiguration
    {
        #region Constructors

        public MultipleDbConfiguration()
        {
            SetProviderServices(MySqlProviderInvariantName.ProviderName, new MySqlProviderServices());
        }

        #endregion Constructors

        #region Public methods

        public static DbConnection GetMySqlConnection(string connectionString)
        {
            var connectionFactory = new MySqlConnectionFactory();

            return connectionFactory.CreateConnection(connectionString);
        }

        #endregion Public methods
    }   
}