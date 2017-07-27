using JO.Core.Services;
using JO.Core.Services.Interfaces;
using JO.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace JO.Tests
{
    [TestClass]
    public class CalculateAnimalStateService_Test
    {
        private Mock<IRepository<Animal>> _animalRepository;
        private ICalculateAnimalStateService _calculateAnimalStateService;

        [TestInitialize()]
        public void Initialize()
        {
            _animalRepository = new Mock<IRepository<Animal>>();
            _calculateAnimalStateService = new CalculateAnimalStateService(_animalRepository.Object);
        }

        [TestMethod]
        public void CalculateAnimalStateService_FeedAnimal()
        {
            var animal = new Animal()
            {
                AnimalId = 1,
                CurrentHappiness = 0,
                CurrentHunger = 0,
                Name = "Herman",
                LastReCalculation = DateTime.Now,
                AnimalTypeId = 1,
                Type = new AnimalType()
                {
                    AnimalTypeId = 1,
                    Type = "Super Tortoise",
                    AnimalStatId = 1,
                    Stats = new AnimalStats()
                    {
                        AnimalStatsId = 1,
                    }
                }       
            };
            animal.LastReCalculation = DateTime.Now + animal.Type.Stats.HungerTickRate;  //This is to force recalculation not to happen.
            _calculateAnimalStateService.FeedAnimal(animal);

            Assert.AreEqual(animal.CurrentHunger, animal.Type.Stats.HungerDecreaseRate);
        }

        [TestMethod]
        public void CalculateAnimalStateService_PetAnimal()
        {
            var animal = new Animal()
            {
                AnimalId = 1,
                CurrentHappiness = 0,
                CurrentHunger = 0,
                Name = "Herman",
                LastReCalculation = DateTime.Now,
                AnimalTypeId = 1,
                Type = new AnimalType()
                {
                    AnimalTypeId = 1,
                    Type = "Super Tortoise",
                    AnimalStatId = 1,
                    Stats = new AnimalStats()
                    {
                        AnimalStatsId = 1,
                    }
                }
            };

            animal.LastReCalculation = DateTime.Now + animal.Type.Stats.HappinessTickRate;  //This is to force recalculation not to happen.

            _calculateAnimalStateService.PetAnimal(animal);

            Assert.AreEqual(animal.CurrentHappiness, animal.Type.Stats.HappinessIncreaseRate);
        }

        [TestMethod]
        public void CalculateAnimalStateService_ReCalculateAnimalStateHappiness()
        {
            var animal = new Animal()
            {
                AnimalId = 1,
                CurrentHappiness = 0,
                CurrentHunger = 0,
                Name = "Herman",
                LastReCalculation = DateTime.Now,
                AnimalTypeId = 1,
                Type = new AnimalType()
                {
                    AnimalTypeId = 1,
                    Type = "Super Tortoise",
                    AnimalStatId = 1,
                    Stats = new AnimalStats()
                    {
                        AnimalStatsId = 1,
                    }
                }
            };

            animal.LastReCalculation = DateTime.Now - animal.Type.Stats.HappinessTickRate;

            _calculateAnimalStateService.ReCalculateAnimalState(animal);
            //Math Ceil is used to raound the number to the nearest whole number to account for the time it takes
            //for the ReCalculateAnimalState to sample the current time.
            Assert.AreEqual(Math.Ceiling(animal.CurrentHappiness), animal.Type.Stats.HappinessDecreaseRate);
        }


        [TestMethod]
        public void CalculateAnimalStateService_ReCalculateAnimalStateHunger()
        {
            var animal = new Animal()
            {
                AnimalId = 1,
                CurrentHappiness = 0,
                CurrentHunger = 0,
                Name = "Herman",
                LastReCalculation = DateTime.Now,
                AnimalTypeId = 1,
                Type = new AnimalType()
                {
                    AnimalTypeId = 1,
                    Type = "Super Tortoise",
                    AnimalStatId = 1,
                    Stats = new AnimalStats()
                    {
                        AnimalStatsId = 1,
                    }
                }
            };

            animal.LastReCalculation = DateTime.Now - animal.Type.Stats.HungerTickRate;

            _calculateAnimalStateService.ReCalculateAnimalState(animal);
            //Math Floor is used to raound the number to the nearest whole number to account for the time it takes
            //for the ReCalculateAnimalState to sample the current time.
            Assert.AreEqual(Math.Floor(animal.CurrentHunger), animal.Type.Stats.HungerIncreaseRate);
        }
    }
}
