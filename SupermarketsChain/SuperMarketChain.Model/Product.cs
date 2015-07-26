using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SuperMarketChain.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string ProductName { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        public int MeasureID { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual Vendor Vendor { get; set; }

        public virtual Measure Measure { get; set; }
    }
}
