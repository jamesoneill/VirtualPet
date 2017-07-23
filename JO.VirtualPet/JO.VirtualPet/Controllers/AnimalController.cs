﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JO.Data;
using JO.Core.Services.Interfaces;
using JO.VirtualPet.Response;

namespace JO.VirtualPet.Controllers
{
    [Route("api/v1/[controller]")]
    public class AnimalController : BaseController
    {
        private readonly IAnimalService _animalServcie;

        public AnimalController(IAnimalService animalService)
        {
            _animalServcie = animalService;
        }

        // POST api/values
        [HttpPost]
        public AnimalResponse Create([FromBody]string name, int? typeId)
        {

            if (string.IsNullOrEmpty(name))
            {
                return new AnimalResponse()
                {
                    IsSuccess = false,
                    Errors = { "name parameter is expected" }

                };
            }

            if (typeId == null)
            {
                return new AnimalResponse()
                {
                    IsSuccess = false,
                    Errors = { "typeId parameter is expected" }

                };
            }

            try
            {
                var animal = _animalServcie.Create(name, typeId.Value);
                return new AnimalResponse()
                {
                    Animal = animal
                };
            }
            catch (Exception ex)
            {
                var response = new AnimalResponse()
                {
                    IsSuccess = false,
                };

                response.Errors = GetErrors(ex, response.Errors);

                return response;
            }
        }

    }
}
