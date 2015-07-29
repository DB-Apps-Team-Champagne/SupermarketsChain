namespace SuperMarketChain.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Expence
    {
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
