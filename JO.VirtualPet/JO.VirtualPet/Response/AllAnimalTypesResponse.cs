using JO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JO.VirtualPet.Response
{
    public class AllAnimalTypeResponse : BaseResponse
    {
        public List<AnimalType> AnimalTypeCollection { get; set; }
    }
}
