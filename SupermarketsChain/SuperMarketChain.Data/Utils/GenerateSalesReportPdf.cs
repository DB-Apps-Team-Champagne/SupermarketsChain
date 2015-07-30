namespace SuperMarketChain.Data.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.html.simpleparser;
    using Data;

    public static class GenerateSaleReportsPdf
    {

        public static void Generate(SupermarketChainContext context, DateTime startDate, DateTime endDate)
        {
            var saleReports = context.SaleReports
                .Where(sl => sl.SaleTime >= startDate && sl.SaleTime <= endDate)
                .Select(sl => new
                {
                    ProductName = sl.Product.ProductName,
                    Quantity = sl.Quantity,
                    UnitPrice = sl.Product.Price,
                    Locaion = sl.Product.Vendor.VendorName,
                    SaleTime = sl.SaleTime
                });

            var saleReportsByDate = new Dictionary<DateTime, HashSet<SaleReportInfo>>();

            foreach (var sl in saleReports)
            {
                var date = sl.SaleTime.Date;
                if (saleReportsByDate.ContainsKey(date))
                {
                    saleReportsByDate[date].Add(new SaleReportInfo(sl.ProductName, sl.Quantity, sl.UnitPrice, sl.Locaion));
                }
                else
                {
                    var hashSet = new HashSet<SaleReportInfo>()
                    {
                        new SaleReportInfo(sl.ProductName, sl.Quantity, sl.UnitPrice, sl.Locaion)
                    };
                    saleReportsByDate.Add(date, hashSet);
                }
            }

            var orderedByDate = saleReportsByDate.OrderBy(sl => sl.Key);

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("../../../SalesReport.pdf", FileMode.Create));

            doc.Open();

            var table = new PdfPTable(5);
            table.WidthPercentage = 100;


            Font boldFont = new Font(Font.FontFamily.TIMES_ROMAN, 15, Font.BOLD);
            var header = new PdfPCell(new Phrase("Aggregated Sales Report", boldFont));

            header.Colspan = 5;
            header.HorizontalAlignment = 1;
            table.AddCell(header);

            foreach (var sl in orderedByDate)
            {
                var dateCell = new PdfPCell(new Phrase(string.Format("{0:dd-MMM-yyyy}", sl.Key)));
                dateCell.Colspan = 5;
                dateCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                table.AddCell(dateCell);

                var h1 = new PdfPCell(new Phrase("Product"));
                h1.BackgroundColor = BaseColor.GRAY;
                table.AddCell(h1);

                h1 = new PdfPCell(new Phrase("Quantity"));
                h1.BackgroundColor = BaseColor.GRAY;
                table.AddCell(h1);

                h1 = new PdfPCell(new Phrase("Unit Price"));
                h1.BackgroundColor = BaseColor.GRAY;
                table.AddCell(h1);

                h1 = new PdfPCell(new Phrase("Location"));
                h1.BackgroundColor = BaseColor.GRAY;
                table.AddCell(h1);

                h1 = new PdfPCell(new Phrase("Sum"));
                h1.BackgroundColor = BaseColor.GRAY;
                table.AddCell(h1);

                foreach (var slr in sl.Value)
                {
                    table.AddCell(new PdfPCell(new Phrase(slr.ProductName)));
                    table.AddCell(new PdfPCell(new Phrase(slr.Quantity.ToString())));
                    table.AddCell(new PdfPCell(new Phrase(slr.UnitPrice.ToString())));
                    table.AddCell(new PdfPCell(new Phrase(slr.Location)));
                    table.AddCell(new PdfPCell(new Phrase(slr.Sum.ToString())));
                }
                string msg = string.Format("Total sum for {0}:", (string.Format("{0:dd-MMM-yyyy}", sl.Key)));
                var msgCell = new PdfPCell(new Phrase(msg));
                msgCell.Colspan = 4;
                msgCell.HorizontalAlignment = 2;
                table.AddCell(msgCell);


                var sum = sl.Value.Sum(s => s.Sum);
                table.AddCell(new PdfPCell(new Phrase(sum.ToString())));

            }

            doc.Add(table);
            doc.Close();
        }

        private class SaleReportInfo
        {
            public SaleReportInfo(string productName, double quantity, decimal unitPrice, string Location)
            {
                this.ProductName = productName;
                this.Quantity = quantity;
                this.UnitPrice = unitPrice;
                this.Location = Location;
                this.Sum = unitPrice * (decimal)quantity;
            }

            public string ProductName { get; set; }

            public double Quantity { get; set; }

            public decimal UnitPrice { get; set; }

            public string Location { get; set; }

            public decimal Sum { get; set; }
        }
    }
}
