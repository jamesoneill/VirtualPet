using JO.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using JO.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JO.Core.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IRepository<Animal> _animalRepository;
        private readonly IRepository<AnimalType> _animalTypeRepository;
        private readonly IRepository<AnimalStats> _animalStatsRepository;
        private readonly ICalculateAnimalStateService _calculateAnimalStateService;

        public AnimalService(IRepository<Animal> animalRepository,
                             IRepository<AnimalType> animalTypeRepository,
                             IRepository<AnimalStats> animalStatsRepository,
                             ICalculateAnimalStateService calculateAnimalStateService)
        {
            _animalRepository = animalRepository;
            _animalTypeRepository = animalTypeRepository;
            _animalStatsRepository = animalStatsRepository;
            _calculateAnimalStateService = calculateAnimalStateService;
        }

        public Animal CreateAnimal(string name, int typeId)
        {
            var animal = new Animal() {
                Name = name,
            };

            var animalType = _animalTypeRepository.Table.FirstOrDefault(m => m.AnimalTypeId == typeId);
            if(animalType == null)
            {
                throw new Exception("Animal type not found.");
            }
            
            animal.Type = animalType;

            _animalRepository.Insert(animal);

            animal = _animalRepository.Table.Include("Type")
                                      .Include("Type.Stats")
                                      .FirstOrDefault(m => m.AnimalId == animal.AnimalId);

            _calculateAnimalStateService.ReCalculateAnimalState(animal);

            return animal;
        }

        public Animal PetAnimal(int animalId)
        {
            var animal = _animalRepository.Table.Include("Type")
                                                .Include("Type.Stats")
                                                .FirstOrDefault(m => m.AnimalId == animalId);

            if (animal == null)
            {
                throw new Exception("animal not found.");
            }

            _calculateAnimalStateService.PetAnimal(animal);

            return animal;
        }

        public Animal FeedAnimal(int animalId)
        {
            var animal = _animalRepository.Table.Include("Type")
                                                .Include("Type.Stats")
                                                .FirstOrDefault(m => m.AnimalId == animalId);

            if(animal == null)
            {
                throw new Exception("animal not found.");
            }

            _calculateAnimalStateService.FeedAnimal(animal);

            return animal;
        }

        public AnimalType CreateAnimalType(AnimalType animalType)
        {
            if(animalType.AnimalStatId == null)
            {
                throw new Exception("must have an animalStatsId.");
            }

            var animalStats = _animalStatsRepository.Table.FirstOrDefault(m => m.AnimalStatsId == animalType.AnimalStatId);

            if(animalStats == null)
            {
                throw new Exception("Animal Stats not found, try creating the stats first.");
            }

            animalType.Stats = animalStats;

            _animalTypeRepository.Insert(animalType);

            return _animalTypeRepository.Table.Include("Stats")
                                              .FirstOrDefault(m => m.AnimalTypeId == animalType.AnimalTypeId);
        }

        public AnimalStats CreateAnimalStats(AnimalStats animalStats)
        {
            _animalStatsRepository.Insert(animalStats);

            return _animalStatsRepository.Table.FirstOrDefault(m => m.AnimalStatsId == animalStats.AnimalStatsId);
        }

        public List<AnimalStats> GetAllAnimalStats()
        {
            return _animalStatsRepository.Table.ToList();
        }

        public AnimalStats GetAnimalStats(int id)
        {
            return _animalStatsRepository.Table.FirstOrDefault(m => m.AnimalStatsId == id);
        }

        public AnimalType GetAnimalType(int id)
        {
            return _animalTypeRepository.Table.Include("Stats").FirstOrDefault(m => m.AnimalTypeId == id);
        }

        public List<AnimalType> GetAllAnimalTypes()
        {
            return _animalTypeRepository.Table.Include("Stats").ToList();
        }
    }
}
