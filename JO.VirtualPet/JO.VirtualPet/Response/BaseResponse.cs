using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JO.VirtualPet.Response
{
    public class BaseResponse
    {
        public List<string> Errors { get; set; } = new List<string>();
        public bool IsSuccess { get; set; } = true;
    }
}
