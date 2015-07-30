namespace SuperMarketChain.Data.Utils
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using Model;

    public static class GenerateSalesReportPdf
    {
        public static void Generate(SupermarketChainContext context, DateTime startDate, DateTime endDate)
        {
            var saleReports = context.SaleReports
                .Where(sl => sl.SaleTime >= startDate && sl.SaleTime <= endDate)
                .Select(sl => new
                {
                    Productname = sl.Product.ProductName,
                    Quantity = sl.Quantity,
                    UnitPrice = sl.Product.Price,
                    Location = sl.Product.Vendor.VendorName,
                    SaleDate = sl.SaleTime
                });

            var groupedByDate = new Dictionary<DateTime, HashSet<SaleReportInfo>>();

            foreach (var i in saleReports)
            {
                if (groupedByDate.ContainsKey(i.SaleDate))
                {
                    groupedByDate[i.SaleDate].Add(new SaleReportInfo(i.Productname, i.Quantity, i.UnitPrice, i.Location));
                }
                else
                {
                    var saleReportsHashSet = new HashSet<SaleReportInfo>()
                    {
                        new SaleReportInfo(i.Productname, i.Quantity, i.UnitPrice, i.Location)
                    };
                    groupedByDate.Add(i.SaleDate, saleReportsHashSet);
                }
            }

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 35, 35, 70, 60);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("../../../SaleReports.pdf", FileMode.Create));

            doc.Open();

            PdfPTable table = new PdfPTable(5);
            float[] widths = new float[] { 100f, 100f, 100f, 100f, 100f };
            table.WidthPercentage = 100;

            PdfPCell header = new PdfPCell(new Phrase("Aggregated Sales Report"));
            header.Colspan = 5;
            header.HorizontalAlignment = 1;
            table.AddCell(header);

            foreach (var sl in groupedByDate)
            {
                var date = new PdfPCell(new Phrase(String.Format("{0:dd-MMM-yyyy}", sl.Key)));
                date.Colspan = 5;
                date.BackgroundColor = BaseColor.LIGHT_GRAY;
                table.AddCell(date);

                PdfPCell h1 = new PdfPCell(new Phrase("Product"));
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

                foreach (var s in sl.Value)
                {
                    table.AddCell(s.ProductName);
                    table.AddCell(s.Quantity.ToString());
                    table.AddCell(s.UnitPrice.ToString());
                    table.AddCell(s.Location);
                    table.AddCell(s.Sum.ToString());
                }

                var msg = new PdfPCell(new Phrase(string.Format("Total sum for {0}: ", String.Format("{0:dd-MMM-yyyy}", sl.Key))));
                msg.HorizontalAlignment = 2;
                msg.Colspan = 4;
                table.AddCell(msg);

                var totalSum = sl.Value.Sum(slr => slr.Sum);

                var totalSumCell = new PdfPCell(new Phrase(totalSum.ToString()));
                table.AddCell(totalSumCell);
            }

            doc.Add(table);
            doc.Close();
        }

        private class SaleReportInfo
        {
            public SaleReportInfo(string pName, double quantity, decimal unitPrice, string location)
            {
                this.ProductName = pName;
                this.Quantity = quantity;
                this.UnitPrice = unitPrice;
                this.Location = location;
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
