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
            animalRepository = _animalRepository;
        }

        public Animal ReCalculateAnimalState(Animal animal)
        {
            var currentDateTime = DateTime.Now;

            var timePassed = currentDateTime - animal.LastReCalculation;
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

            double numberOfTimesToDecreaseHunger;
            if (timePassed.TotalMinutes > 0)
            {
                numberOfTimesToDecreaseHunger = timePassed.TotalMinutes / animal.Type.Stats.HungerTickRate.TotalMinutes;
            }
            else
            {
                numberOfTimesToDecreaseHunger = 0;
            }

            animal.CurrentHunger = animal.CurrentHunger + animal.Type.Stats.HappinessDecreaseRate * numberOfTimesToDecreaseHappiness;

            _animalRepository.Update(animal);

            return animal;
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
