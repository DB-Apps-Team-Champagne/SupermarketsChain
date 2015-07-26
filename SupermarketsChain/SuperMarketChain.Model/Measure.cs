using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SuperMarketChain.Model
{
    public class Measure
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string MeasureName { get; set; }
    }
}
