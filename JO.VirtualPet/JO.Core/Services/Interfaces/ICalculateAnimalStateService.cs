using JO.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace JO.Core.Services.Interfaces
{
    public interface ICalculateAnimalStateService
    {
        Animal ReCalculateAnimalState(Animal animal);
        List<Animal> ReCalculateAnimalState(List<Animal> animal);
    }
}
