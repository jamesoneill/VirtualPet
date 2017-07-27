using System;
using Microsoft.AspNetCore.Mvc;
using JO.Data;
using JO.Core.Services.Interfaces;
using JO.VirtualPet.Response;

namespace JO.VirtualPet.Controllers
{
    [Route("api/v1/[controller]")]
    public class AnimalTypeController : BaseController
    {
        private readonly IAnimalService _animalService;

        public AnimalTypeController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet("{Id}")]
        public AnimalTypeResponse Get(int? id)
        {
            if (!id.HasValue)
            {
                return new AnimalTypeResponse()
                {
                    IsSuccess = false,
                    Errors = { "Id parameter is expected" }
                };
            }

            try
            {
                var animalType = _animalService.GetAnimalType(id.Value);

                return new AnimalTypeResponse()
                {
                    AnimalType = animalType
                };
            }
            catch (Exception ex)
            {
                var response = new AnimalTypeResponse()
                {
                    IsSuccess = false,
                };

                response.Errors = GetErrors(ex, response.Errors);

                return response;
            }
        }

        [HttpGet]
        public AllAnimalTypeResponse Get()
        {
            try
            {
                var animalTypeCollection = _animalService.GetAllAnimalTypes();

                return new AllAnimalTypeResponse()
                {
                    AnimalTypeCollection = animalTypeCollection
                };
            }
            catch (Exception ex)
            {
                var response = new AllAnimalTypeResponse()
                {
                    IsSuccess = false,
                };

                response.Errors = GetErrors(ex, response.Errors);

                return response;
            }
        }

        // POST api/values
        [HttpPost("Create")]
        public AnimalTypeResponse Create([FromBody]AnimalType animalType)
        {
            if (animalType == null)
            {
                return new AnimalTypeResponse()
                {
                    IsSuccess = false,
                    Errors = { "animalType parameter is expected" }

                };
            }

            if (animalType.AnimalTypeId != null)
            {
                return new AnimalTypeResponse()
                {
                    IsSuccess = false,
                    Errors = { "animalTypeId must be null" }

                };
            }

            try
            {
                animalType = _animalService.CreateAnimalType(animalType);
                return new AnimalTypeResponse()
                {
                    AnimalType = animalType
                };
            }
            catch (Exception ex)
            {
                var response = new AnimalTypeResponse()
                {
                    IsSuccess = false,
                };

                response.Errors = GetErrors(ex, response.Errors);

                return response;
            }
        }
    }
}
