﻿using Microsoft.EntityFrameworkCore;
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

        public void ExplicitLoading()
        {
            Users.Include(m => m.Animals).ThenInclude(m => m.Type).ThenInclude(m => m.Stats);

            Animals.Include(m => m.Type).ThenInclude(m => m.Stats);

            AnimalTypes.Include(m => m.Stats);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<AnimalStats> AnimalStats { get; set; }
    }
}
