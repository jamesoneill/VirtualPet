using System;
using System.Collections.Generic;
using System.Text;

namespace JO.Data
{
    public class Animal : BaseEntity
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public double CurrentHunger { get; set; } = 0;
        public double CurrentHappiness { get; set; } = 0;
        public DateTime LastReCalculation { get; set; } = DateTime.Now;
        public int AnimalTypeId { get; set; }
        public AnimalType Type { get; set; }
    }
}
