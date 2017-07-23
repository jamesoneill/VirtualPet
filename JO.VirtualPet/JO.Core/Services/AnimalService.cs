using JO.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using JO.Data;

namespace JO.Core.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IRepository<Animal> _animalRepository;
        private readonly IRepository<AnimalType> _animalTypeRepository;

        public AnimalService(IRepository<Animal> animalRepository, IRepository<AnimalType> animalTypeRepository)
        {
            _animalRepository = animalRepository;
            _animalTypeRepository = animalTypeRepository;
        }

        public Animal Create(string name, int typeId)
        {
            var animal = new Animal() {
                Name = name,
            };

            var animalType = _animalTypeRepository.GetById(typeId);
            if(animalType == null)
            {
                throw new Exception("Animal type not found");
            }
            
            animal.Type = animalType;

            _animalRepository.Insert(animal);

            return _animalRepository.GetById(animal.AnimalId);
        }
    }
}
