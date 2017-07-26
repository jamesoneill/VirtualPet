using JO.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace JO.Core.Services.Interfaces
{
    public interface IAnimalService
    {
        Animal CreateAnimal(string name, int typeId);
        AnimalType CreateAnimalType(AnimalType animalType);
        AnimalStats CreateAnimalStats(AnimalStats animalStats);
        Animal PetAnimal(int animalId);
        Animal FeedAnimal(int animalId);
        List<AnimalStats> GetAllAnimalStats();
        AnimalStats GetAnimalStats(int id);
        List<AnimalType> GetAllAnimalTypes();
        AnimalType GetAnimalType(int id);
    }
}
