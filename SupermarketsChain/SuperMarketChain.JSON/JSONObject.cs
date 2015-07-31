using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketChain.JSON
{
    public class JSONObject
    {
        public int productID { get; set; }

        public string productName { get; set; }

        public string vendorName { get; set; }

        public double quantitySold { get; set; }

        public double income { get; set; }
    }
}
