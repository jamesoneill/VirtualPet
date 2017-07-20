using System;
using System.Collections.Generic;

namespace JO.Data
{
    public class User
    {
        public int UserId { get; set; }
        public int Name { get; set; }
        public ICollection<UserOwnedAnimal> UserOwnedAnimals { get; set; }
    }
}
