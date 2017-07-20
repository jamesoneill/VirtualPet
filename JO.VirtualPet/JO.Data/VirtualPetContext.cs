using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JO.Data
{
    public class VirtualPetContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./VirtualPet.db");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserOwnedAnimal> UserOwnedAnimals { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<AnimalMetric> AnimalMetrics { get; set; }
    }
}
