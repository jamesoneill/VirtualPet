using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JO.Core;
using JO.Data;

namespace JO.VirtualPet.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IRepository<User> _userRepository;

        public ValuesController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var user = new User()
            {
                Name = "jamie",
            };

            _userRepository.Insert(user);


            return Ok(_userRepository.Table.ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
