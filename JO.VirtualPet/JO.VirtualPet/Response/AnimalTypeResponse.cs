using JO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JO.VirtualPet.Response
{
    public class AnimalTypeResponse : BaseResponse
    {
        public AnimalType AnimalType { get; set; }
    }
}
