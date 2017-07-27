using JO.Core.Services;
using JO.VirtualPet.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JO.VirtualPet.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Login/{name}")]
        public UserResponse Login(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new UserResponse()
                {
                    IsSuccess = false,
                    Errors = { "name parameter is expected" }
                };
            }

            try
            {
                var user = _userService.Login(name);
                return new UserResponse()
                {
                    User = user
                };
            }
            catch (Exception ex)
            {
                var response = new UserResponse()
                {
                    IsSuccess = false,
                };

                response.Errors = GetErrors(ex, response.Errors);

                return response;
            }
        }

        // POST api/values
        [HttpPost("Register")]
        public UserResponse Register([FromBody]string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new UserResponse()
                {
                    IsSuccess = false,
                    Errors = { "name parameter is expected" }

                };
            }
            try
            {
                var user = _userService.Register(name);
                return new UserResponse()
                {
                    User = user
                };
            }
            catch (Exception ex)
            {
                var response =  new UserResponse()
                {
                    IsSuccess = false,
                };

                response.Errors = GetErrors(ex, response.Errors);

                return response;
            }
        }

        // PUT api/values/5
        [HttpPut("AddAnimal/{userId}")]
        public UserResponse AddAnimal(int? userId, [FromBody]int? animalId)
        {
            if (userId == null)
            {
                return new UserResponse()
                {
                    IsSuccess = false,
                    Errors = { "userId parameter is expected" }

                };
            }

            if (animalId == null)
            {
                return new UserResponse()
                {
                    IsSuccess = false,
                    Errors = { "animalId parameter is expected" }

                };
            }

            try
            {
                var user = _userService.AddAnimal(userId.Value, animalId.Value);
                return new UserResponse()
                {
                    User = user
                };
            }
            catch (Exception ex)
            {
                var response = new UserResponse()
                {
                    IsSuccess = false,
                };

                response.Errors = GetErrors(ex, response.Errors);

                return response;
            }
        }
    }
}
