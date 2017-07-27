using JO.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using JO.Data;

namespace JO.Core.Services
{
    public class CalculateAnimalStateService : ICalculateAnimalStateService
    {
        private readonly IRepository<Animal> _animalRepository;

        public CalculateAnimalStateService(IRepository<Animal> animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public Animal FeedAnimal(Animal animal)
        {
            animal.CurrentHunger = animal.CurrentHunger + animal.Type.Stats.HungerDecreaseRate;

            if (animal.CurrentHunger < animal.Type.Stats.MinHunger)
            {
                animal.CurrentHunger = animal.Type.Stats.MinHunger;
            }

            return ReCalculateAnimalState(animal);
        }

        public Animal PetAnimal(Animal animal)
        {
            animal.CurrentHappiness = animal.CurrentHappiness + animal.Type.Stats.HappinessIncreaseRate;

            if (animal.CurrentHappiness > animal.Type.Stats.MaxHappiness)
            {
                animal.CurrentHappiness = animal.Type.Stats.MaxHappiness;
            }

            return ReCalculateAnimalState(animal);
        }

        public Animal ReCalculateAnimalState(Animal animal)
        {
            var currentDateTime = DateTime.Now;

            var timePassed = currentDateTime - animal.LastReCalculation;

            ReCaluculateAnimalHappiness(animal, timePassed);

            ReCalculateAnimalHunger(animal, timePassed);

            animal.LastReCalculation = currentDateTime;

            _animalRepository.Update(animal);

            return animal;
        }

        private void ReCalculateAnimalHunger(Animal animal, TimeSpan timePassed)
        {
            double numberOfTimesToDecreaseHunger;

            if (timePassed.TotalMinutes > 0)
            {
                numberOfTimesToDecreaseHunger = timePassed.TotalMinutes / animal.Type.Stats.HungerTickRate.TotalMinutes;
            }
            else
            {
                numberOfTimesToDecreaseHunger = 0;
            }

            animal.CurrentHunger = animal.CurrentHunger + animal.Type.Stats.HungerIncreaseRate * numberOfTimesToDecreaseHunger;

            if (animal.CurrentHunger > animal.Type.Stats.MaxHunger)
            {
                animal.CurrentHunger = animal.Type.Stats.MaxHunger;
            }
        }

        private void ReCaluculateAnimalHappiness(Animal animal, TimeSpan timePassed)
        {
            double numberOfTimesToDecreaseHappiness;

            if (timePassed.TotalMinutes > 0)
            {
                numberOfTimesToDecreaseHappiness = timePassed.TotalMinutes / animal.Type.Stats.HappinessTickRate.TotalMinutes;
            }
            else
            {
                numberOfTimesToDecreaseHappiness = 0;
            }

            animal.CurrentHappiness = animal.CurrentHappiness + animal.Type.Stats.HappinessDecreaseRate * numberOfTimesToDecreaseHappiness;

            if (animal.CurrentHappiness < animal.Type.Stats.MinHappiness)
            {
                animal.CurrentHappiness = animal.Type.Stats.MinHappiness;
            }
        }

        public List<Animal> ReCalculateAnimalState(List<Animal> animals)
        {
            List<Animal> newAnimals = new List<Animal>();
            foreach(var animal in animals)
            {
                newAnimals.Add(ReCalculateAnimalState(animal));
            }

            return newAnimals;
        }
    }
}
