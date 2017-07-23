using System;
using System.Collections.Generic;
using System.Text;

namespace JO.Data
{
    public class AnimalType : BaseEntity
    {
        public int AnimalTypeId { get; set; }
        public string Type { get; set; } 
        public int? AnimalStatId { get; set; }
        public AnimalStats Stats { get; set; }
    }
}
