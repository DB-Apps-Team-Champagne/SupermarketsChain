using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SuperMarketChain.Model
{
    public class Vendor
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string VendorName { get; set; }
    }
}
