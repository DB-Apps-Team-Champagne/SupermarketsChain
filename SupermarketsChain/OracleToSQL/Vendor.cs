using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleToSQL
{
    public class Vendor
    {
        public Vendor(int id, string vendorName)
        {
            this.Id = id;
            this.VendorName = vendorName;
        }

        public int Id { get; set; }

        public string VendorName { get; set; }
    }
}
