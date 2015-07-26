﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketChain.Model
{
    public class SaleReport
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public double Quantity { get; set; }

        public DateTime SaleTime { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public virtual Product Product { get; set; }
    }
}
