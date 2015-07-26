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
        private ICollection<Product> products;

        public Vendor()
        {
            this.products = new HashSet<Product>();
        }
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string VendorName { get; set; }

        public virtual ICollection<Product> Products {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
