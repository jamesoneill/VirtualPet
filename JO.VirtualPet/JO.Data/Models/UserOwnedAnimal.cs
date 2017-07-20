using System;
using System.Collections.Generic;
using System.Text;

namespace JO.Data
{
    public class UserOwnedAnimal
    {
        public int UserOwnedAnimalId { get; set; }
        public string Name { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
