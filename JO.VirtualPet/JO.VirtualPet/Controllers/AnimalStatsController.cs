using System;
using Microsoft.AspNetCore.Mvc;
using JO.Data;
using JO.Core.Services.Interfaces;
using JO.VirtualPet.Response;

namespace JO.VirtualPet.Controllers
{
    [Route("api/v1/[controller]")]
    public class AnimalStatsController : BaseController
    {
        private readonly IAnimalService _animalService;

        public AnimalStatsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet("{Id}")]
        public AnimalStatsReponse Get(int? id)
        {
            if (!id.HasValue)
            {
                return new AnimalStatsReponse()
                {
                    IsSuccess = false,
                    Errors = { "Id parameter is expected" }
                };
            }

            try
            {
                var animalStats = _animalService.GetAnimalStats(id.Value);

                return new AnimalStatsReponse()
                {
                    AnimalStats = animalStats
                };
            }
            catch (Exception ex)
            {
                var response = new AnimalStatsReponse()
                {
                    IsSuccess = false,
                };

                response.Errors = GetErrors(ex, response.Errors);

                return response;
            }
        }

        [HttpGet]
        public AllAnimalStatsResponse Get()
        {
            try
            {
                var animalStatsCollection = _animalService.GetAllAnimalStats();

                return new AllAnimalStatsResponse()
                {
                    AnimalStatsCollection = animalStatsCollection
                };
            }
            catch (Exception ex)
            {
                var response = new AllAnimalStatsResponse()
                {
                    IsSuccess = false,
                };

                response.Errors = GetErrors(ex, response.Errors);

                return response;
            }
        }

        // POST api/values
        [HttpPost("Create")]
        public AnimalStatsReponse Create([FromBody]AnimalStats animalStats)
        {
            if (animalStats == null)
            {
                return new AnimalStatsReponse()
                {
                    IsSuccess = false,
                    Errors = { "animalStats parameter is expected" }

                };
            }

            if (animalStats.AnimalStatsId == null)
            {
                return new AnimalStatsReponse()
                {
                    IsSuccess = false,
                    Errors = { "animalStatsId must be null" }

                };
            }

            try
            {
                animalStats = _animalService.CreateAnimalStats(animalStats);
                return new AnimalStatsReponse()
                {
                    AnimalStats = animalStats
                };
            }
            catch (Exception ex)
            {
                var response = new AnimalStatsReponse()
                {
                    IsSuccess = false,
                };

                response.Errors = GetErrors(ex, response.Errors);

                return response;
            }
        }
    }
}
