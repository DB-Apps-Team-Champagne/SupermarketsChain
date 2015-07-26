using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleToSQL
{
    public class Measure
    {
        public Measure(int id, string measureName)
        {
            this.Id = id;
            this.MeasureName = measureName;
        }

        public int Id { get; set; }

        public string MeasureName { get; set; }
    }
}
