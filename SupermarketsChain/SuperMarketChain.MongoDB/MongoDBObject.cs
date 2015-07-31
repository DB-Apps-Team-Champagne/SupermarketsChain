using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketChain.MongoDB
{
    class MongoDBObject
    {

        public string Product { get; set; }

        public double Quantity { get; set; }

        public DateTime SaleTime { get; set; }

        public string Vendor { get; set; }

    }
}
