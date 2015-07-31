using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MySql.Data.MySqlClient;
using SuperMarketChain.MySQL;

namespace SuperMarketChain.Data.Utils
{
    public static class MySQL
    {
        public static string connectionString = "server=localhost;port=3306;database=supermarketchain;uid=root;";

        public static void CreateDBIfNonExistent()
        {
            
            // Create database if not exists
            using (SupermarketChainMySQL contextDB = new SupermarketChainMySQL(MySQL.connectionString))
            {
                contextDB.Database.CreateIfNotExists();
            }
        }

        public static void DisplayProductsCountInMssqlAndMysql(SupermarketChainContext context)
        {
            using (SupermarketChainMySQL contextMySQL = new SupermarketChainMySQL(MySQL.connectionString))
            {
                var prodsInMSSQL = context.Products.Count();
                var prodsInMySQL = contextMySQL.Products.Count();
                Console.WriteLine("Products in MSSQL: {0} items;\nProducts in MySQL: {1} items;", prodsInMSSQL, prodsInMySQL);
            }
        }

        public static void ImportVendorsFromMSSqlToMySQL(SupermarketChainContext context)
        {
            using(SupermarketChainMySQL contextMySQL = new SupermarketChainMySQL(MySQL.connectionString)) {

                using (var mySqlDBTransaction = contextMySQL.Database.BeginTransaction())
                {
                    try
                    {
                        var vendorsInMSSQL = context.Vendors.ToList();
                        var counter = 0;
                        foreach (var vendor in vendorsInMSSQL)
                        {
                            if (contextMySQL.Vendors.Where(v => v.VendorName.Equals(vendor.VendorName)).Any())
                            {
                                Console.WriteLine("{0} is present at the MySQL table and will not be added.", vendor.VendorName);
                            }
                            else
                            {
                                contextMySQL.Vendors.Add(new Model.Vendor { 
                                    VendorName = vendor.VendorName
                                });
                                Console.WriteLine("{0} is added to MySQL table.", vendor.VendorName);
                                counter++;
                            }
                        }
                        contextMySQL.SaveChanges();
                        mySqlDBTransaction.Commit();
                        Console.WriteLine("{0} vendors added to MySQL database", counter);
                    }
                    catch (Exception)
                    {
                        mySqlDBTransaction.Rollback();
                    } 
                }
                
            }
        }

        public static void ImportMeasuresFromMSSqlToMySQL(SupermarketChainContext context)
        {
            using (SupermarketChainMySQL contextMySQL = new SupermarketChainMySQL(MySQL.connectionString))
            {

                using (var mySqlDBTransaction = contextMySQL.Database.BeginTransaction())
                {
                    try
                    {
                        var measuresInMSSQL = context.Measures.ToList();
                        var counter = 0;
                        foreach (var measure in measuresInMSSQL)
                        {
                            if (contextMySQL.Measures.Where(m => m.MeasureName.Equals(measure.MeasureName)).Any())
                            {
                                Console.WriteLine("{0} is present at the MySQL table and will not be added.", measure.MeasureName);
                            }
                            else
                            {
                                contextMySQL.Measures.Add(new Model.Measure
                                {
                                    MeasureName = measure.MeasureName
                                });
                                Console.WriteLine("{0} is added to MySQL table.", measure.MeasureName);
                                counter++;
                            }
                        }
                        contextMySQL.SaveChanges();
                        mySqlDBTransaction.Commit();
                        Console.WriteLine("{0} measures added to MySQL database", counter);
                    }
                    catch (Exception)
                    {
                        mySqlDBTransaction.Rollback();
                    }
                }

            }
        }

        public static void ImportProductsFromMSSqlToMySQL(SupermarketChainContext context)
        {
            using (SupermarketChainMySQL contextMySQL = new SupermarketChainMySQL(MySQL.connectionString))
            {

                using (var mySqlDBTransaction = contextMySQL.Database.BeginTransaction())
                {
                    try
                    {
                        var productsInMSSQL = context.Products.ToList();
                        var counter = 0;
                        foreach (var product in productsInMSSQL)
                        {
                            if (contextMySQL.Products.Where(p => p.ProductName.Equals(product.ProductName)).Any())
                            {
                                Console.WriteLine("{0} is present at the MySQL table and will not be added.", product.ProductName);
                            }
                            else
                            {
                                contextMySQL.Products.Add(new Model.Product
                                {
                                    ProductName = product.ProductName,
                                    MeasureID = product.MeasureID,
                                    VendorId = product.VendorId,
                                    Price = product.Price
                                });
                                Console.WriteLine("{0} is added to MySQL table.", product.ProductName);
                                counter++;
                            }
                        }
                        contextMySQL.SaveChanges();
                        mySqlDBTransaction.Commit();
                        Console.WriteLine("{0} products added to MySQL database", counter);
                    }
                    catch (Exception)
                    {
                        mySqlDBTransaction.Rollback();
                    }
                }

            }
        }

        public static void ImportSalesReportsFromMSSqlToMySQL(SupermarketChainContext context)
        {
            using (SupermarketChainMySQL contextMySQL = new SupermarketChainMySQL(MySQL.connectionString))
            {

                using (var mySqlDBTransaction = contextMySQL.Database.BeginTransaction())
                {
                    try
                    {
                        var salesReportsInMSSQL = context.SaleReports.ToList();
                        var counter = 0;
                        foreach (var saleReport in salesReportsInMSSQL)
                        {
                            if(saleExist(saleReport, contextMySQL))
                            {
                                Console.WriteLine("ID:{0}, Time:{1}, is present at the MySQL table and will not be added.", saleReport.Id, saleReport.SaleTime);
                            }
                            else
                            {
                                contextMySQL.SaleReports.Add(new Model.SaleReport
                                {
                                    ProductId = saleReport.ProductId,
                                    Quantity = saleReport.Quantity,
                                    SaleTime = saleReport.SaleTime,
                                    VendorId = saleReport.VendorId
                                });
                                Console.WriteLine("ID:{0}, Time:{1} is added to MySQL table.", saleReport.Id, saleReport.SaleTime);
                                counter++;
                            }
                        }
                        contextMySQL.SaveChanges();
                        mySqlDBTransaction.Commit();
                        Console.WriteLine("{0} salereports added to MySQL database", counter);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        mySqlDBTransaction.Rollback();
                    }
                }

            }
        }

        public static void ImportExprencesFromMSSqlToMySQL(SupermarketChainContext context)
        {
            using (SupermarketChainMySQL contextMySQL = new SupermarketChainMySQL(MySQL.connectionString))
            {

                using (var mySqlDBTransaction = contextMySQL.Database.BeginTransaction())
                {
                    try
                    {
                        var expencesInMSSQL = context.Expences.ToList();
                        var counter = 0;
                        foreach (var expence in expencesInMSSQL)
                        {
                            if (expenceExist(expence, contextMySQL))
                            {
                                Console.WriteLine("ID:{0}, Time:{1}, is present at the MySQL table and will not be added.", expence.Id, expence.Date);
                            }
                            else
                            {
                                contextMySQL.Expences.Add(new Model.Expence
                                {
                                    Amount = expence.Amount,
                                    Date = expence.Date,
                                    VendorId = expence.VendorId
                                });
                                Console.WriteLine("ID:{0}, Time:{1} is added to MySQL table.", expence.Id, expence.Date);
                                counter++;
                            }
                        }
                        contextMySQL.SaveChanges();
                        mySqlDBTransaction.Commit();
                        Console.WriteLine("{0} expences added to MySQL database", counter);
                    }
                    catch (Exception)
                    {
                        mySqlDBTransaction.Rollback();
                    }
                }

            }
            
        }

        private static bool saleExist(Model.SaleReport saleReport, SupermarketChainMySQL mysqlContext)
        {
            var cont = mysqlContext;

            var matches =  cont.SaleReports.Where(
                s => s.ProductId == saleReport.ProductId
                    && s.Quantity == saleReport.Quantity
                    && s.VendorId == saleReport.VendorId).ToList();
            foreach (var match in matches)
            {
                var matchTimeWithoutMileSeconds = match.SaleTime.AddMilliseconds(-match.SaleTime.Millisecond);
                var saleReportTimeWithoutMileSeconds = saleReport.SaleTime.AddMilliseconds(-saleReport.SaleTime.Millisecond);
                return matchTimeWithoutMileSeconds.Equals(saleReportTimeWithoutMileSeconds);
            }
            return false;        
        }

        private static bool expenceExist(Model.Expence expence, SupermarketChainMySQL mysqlContext)
        {
            var cont = mysqlContext;

            var matches = cont.Expences.Where(
                e => e.VendorId.Equals(expence.VendorId)
                    && e.Amount.Equals(expence.Amount)).ToList();

            foreach (var match in matches)
            {
                var matchTimeWithoutMileSeconds = match.Date.AddMilliseconds(-match.Date.Millisecond);
                var saleReportTimeWithoutMileSeconds = expence.Date.AddMilliseconds(-expence.Date.Millisecond);
                return matchTimeWithoutMileSeconds.Equals(saleReportTimeWithoutMileSeconds);
            }
            return false;
        }

    }
}
