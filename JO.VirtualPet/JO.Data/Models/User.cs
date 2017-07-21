using JO.Core;
using System;
using System.Collections.Generic;

namespace JO.Data
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}
