using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleToSQL
{
    public class Product
    {
        public Product(int id, int vendorId, string productName, int measureId, decimal price)
        {
            this.Id = id;
            this.VendorId = vendorId;
            this.ProductName = productName;
            this.MeasureId = measureId;
            this.Price = price;
        }
        public int Id { get; set; }

        public int VendorId { get; set; }

        public string ProductName { get; set; }

        public int MeasureId { get; set; }

        public decimal Price { get; set; }
    }
}
