using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyperMarketChain.Model
{
    public class Product
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public string ProductName { get; set; }

        public int MeasureID { get; set; }

        public virtual Measure Measure { get; set; }

        public double Price { get; set; }
    }
}
