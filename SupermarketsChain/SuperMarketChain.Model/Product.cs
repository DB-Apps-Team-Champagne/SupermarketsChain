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

        [Required]
        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        [MaxLength(20)]
        public string ProductName { get; set; }

        [Required]
        public int MeasureID { get; set; }

        public virtual Measure Measure { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
