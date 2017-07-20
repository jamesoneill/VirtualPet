using System;
using System.Collections.Generic;
using System.Text;

namespace JO.Data
{
    public class AnimalMetric
    {
        public int AnimalMetricId { get; set; }
        public float HungerIncreaseRate { get; set; }
        public float HungerDecreaseRate { get; set; }
        public float HappinessIncreaseRate { get; set; }
        public float HappinessDecreaseRate { get; set; }
    }
}
