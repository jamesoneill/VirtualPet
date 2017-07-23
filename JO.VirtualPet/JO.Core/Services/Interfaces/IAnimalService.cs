using JO.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace JO.Core.Services.Interfaces
{
    public interface IAnimalService
    {
        Animal Create(string name, int typeId);
    }
}
