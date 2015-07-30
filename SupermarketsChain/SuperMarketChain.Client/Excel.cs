using System.Linq;
using ICSharpCode.SharpZipLib.Zip;
using System.Collections;
using System;
using System.IO;
using System.IO.Compression;
using System.Data.OleDb;
using SuperMarketChain.Data;
using SuperMarketChain.Model;

namespace SuperMarketChain.Client
{
    public class Excel
    {

        private string folderPath = @"../..\..\Excel";

        public void folderLoop()
        {

            String[] arr = new String[1];
            arr[0] = this.folderPath;
            foreach (string path in arr)
            {
                if (File.Exists(path))
                {
                    // This path is a file
                    ProcessFile(path);
                }
                else if (Directory.Exists(path))
                {
                    // This path is a directory
                    ProcessDirectory(path);
                }
                else
                {
                    Console.WriteLine("{0} is not a valid file or directory.", path);
                }
            }
        }

        public void unZip()
        {
            string zipFileName = @"..\..\..\Sample-Sales-Reports.zip"; // change
            var targetDir = @"..\..\..\Excel";
            FastZip fastZip = new FastZip();
            string fileFilter = null;

            // Will always overwrite if target filenames already exist
            fastZip.ExtractZip(zipFileName, targetDir, fileFilter);

        }

        DateTime date;

        private void readExcell(string path)
        {
            decimal decNumber;
            double doubNumber;
            var context = new SupermarketChainContext();

            string title = "";
            bool isTitle = false;
            bool isProd = false;
            string conString =
                               @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";" +
                               @"Extended Properties='Excel 8.0;HDR=Yes;'";

            using (OleDbConnection connection = new OleDbConnection(conString))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [Sales$]", connection);
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        using (OleDbDataReader dr = command.ExecuteReader())
                        {
                            isTitle = false;
                            isProd = false;
                            int counter = 0;
                            while (dr.Read())
                            {

                                var row1Col0 = dr[counter];
                                var row1Col1 = dr[counter + 1];
                                var row1Col2 = dr[counter + 2];
                                var row1Col3 = dr[counter + 3];

                                if (isTitle == false)
                                {

                                    title = dr[counter].ToString();
                                    isTitle = true;
                                    if (vendorExist(dr[counter].ToString(), context) == false)
                                    {
                                        context.Vendors.Add(new Vendor
                                        {
                                            VendorName = title
                                        });
                                        context.SaveChanges();
                                    }


                                    continue;
                                }
                                else if (dr[counter].ToString() == "Total sum:")
                                {

                                    continue;
                                }
                                if (isProd == false)
                                {
                                    isProd = true;
                                    continue;
                                }


                                Decimal.TryParse(dr[counter + 2].ToString(), out decNumber);
                                int id = vendorId(title, context);
                                if (productExist(dr[counter].ToString(), decNumber, id) == false)
                                {
                                    context.Products.Add(new Product
                                    {
                                        ProductName = dr[counter].ToString(),
                                        MeasureID = 1,
                                        Price = decNumber,
                                        VendorId = id
                                    });
                                }
                                Double.TryParse(dr[counter + 1].ToString(), out doubNumber);
                                if (saleExist(productId(dr[counter].ToString(), context), doubNumber, date, id) == false)
                                {
                                    context.SaleReports.Add(new SaleReport
                                    {
                                        ProductId = productId(dr[counter].ToString(), context),
                                        Quantity = doubNumber,
                                        SaleTime = date,
                                        VendorId = id
                                    });
                                }
                                context.SaveChanges();
                            }
                        }
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }

        }



        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory. 
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory. 
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {

                date = Convert.ToDateTime(subdirectory.Substring(subdirectory.LastIndexOf('\\') + 1));
                ProcessDirectory(subdirectory);

            }
        }

        // Insert logic for processing found files here. 
        public void ProcessFile(string path)
        {
            readExcell(path);

        }

        private int vendorId(string title, SupermarketChainContext cont)
        {
            var names = cont.Vendors.Where(v => v.VendorName == title).Select(v => v.ID);

            foreach (var item in names)
            {
                return item;
            }
            return 0;
        }

        private int productId(string title, SupermarketChainContext cont)
        {
            var names = cont.Products.Where(v => v.ProductName == title).Select(v => v.Id);

            foreach (var item in names)
            {
                return item;
            }
            return 0;
        }

        private bool vendorExist(string title, SupermarketChainContext cont)
        {
            return cont.Vendors.Any(v => v.VendorName == title);
        }
        private bool productExist(string name, decimal price, int vendId)
        {
            var cont = new SupermarketChainContext();
            return cont.Products.Any(p => p.ProductName == name && Decimal.Equals(p.Price, price) && p.VendorId == vendId);
        }
        private bool saleExist(int productId, double quantity, DateTime time, int vendId)
        {
            var cont = new SupermarketChainContext();
            return cont.SaleReports.Any(s => s.ProductId == productId && s.Quantity == quantity && s.VendorId == vendId && DateTime.Compare(s.SaleTime, time) == 0);
        }

        public void deleteFolder()
        {
            Directory.Delete(this.folderPath, true);
        }
    }

}
