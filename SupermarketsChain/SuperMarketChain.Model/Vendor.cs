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
        private ICollection<Expence> expenses;

        public Vendor()
        {
            this.products = new HashSet<Product>();
            this.expenses = new HashSet<Expence>();
        }
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string VendorName { get; set; }

        public virtual ICollection<Product> Products {
            get { return this.products; }
            set { this.products = value; }
        }

        public virtual ICollection<Expence> Expences 
        {
            get { return this.expenses; }
            set { this.expenses = value; }
        }
    }
}
