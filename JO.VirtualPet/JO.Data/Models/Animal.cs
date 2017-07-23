using JO.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace JO.Data
{
    public class Animal : BaseEntity
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public float CurrentHunger { get; set; } = 0;
        public float CurrentHappiness { get; set; } = 0;
        public int AnimalTypeId { get; set; }
        public AnimalType Type { get; set; }
    }
}
