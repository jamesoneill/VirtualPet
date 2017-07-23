﻿// <auto-generated />
using JO.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace JO.Data.Migrations
{
    [DbContext(typeof(VirtualPetContext))]
    partial class VirtualPetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-preview2-25794");

            modelBuilder.Entity("JO.Data.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnimalTypeId");

                    b.Property<double>("CurrentHappiness");

                    b.Property<double>("CurrentHunger");

                    b.Property<DateTime>("LastReCalculation");

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.HasKey("AnimalId");

                    b.HasIndex("AnimalTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("JO.Data.AnimalStats", b =>
                {
                    b.Property<int>("AnimalStatsId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("HappinessDecreaseRate");

                    b.Property<double>("HappinessIncreaseRate");

                    b.Property<TimeSpan>("HappinessTickRate");

                    b.Property<double>("HungerDecreaseRate");

                    b.Property<double>("HungerIncreaseRate");

                    b.Property<TimeSpan>("HungerTickRate");

                    b.Property<double>("MaxHappiness");

                    b.Property<double>("MaxHunger");

                    b.Property<double>("MinHappiness");

                    b.Property<double>("MinHunger");

                    b.HasKey("AnimalStatsId");

                    b.ToTable("AnimalStats");
                });

            modelBuilder.Entity("JO.Data.AnimalType", b =>
                {
                    b.Property<int>("AnimalTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AnimalStatId");

                    b.Property<int?>("StatsAnimalStatsId");

                    b.Property<string>("Type");

                    b.HasKey("AnimalTypeId");

                    b.HasIndex("StatsAnimalStatsId");

                    b.ToTable("AnimalTypes");
                });

            modelBuilder.Entity("JO.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JO.Data.Animal", b =>
                {
                    b.HasOne("JO.Data.AnimalType", "Type")
                        .WithMany()
                        .HasForeignKey("AnimalTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JO.Data.User")
                        .WithMany("Animals")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("JO.Data.AnimalType", b =>
                {
                    b.HasOne("JO.Data.AnimalStats", "Stats")
                        .WithMany()
                        .HasForeignKey("StatsAnimalStatsId");
                });
#pragma warning restore 612, 618
        }
    }
}
