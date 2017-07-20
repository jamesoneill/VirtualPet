using System;
using System.Collections.Generic;
using System.Text;

namespace JO.Data
{
    public class AnimalType
    {
        public int AnimalTypeId { get; set; }
        public string Type { get; set; } 
        public int MetricId { get; set; }
        public AnimalMetric Metric { get; set; }
    }
}
