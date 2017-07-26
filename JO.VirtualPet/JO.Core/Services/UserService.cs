using System;
using System.Collections.Generic;
using System.Text;
using JO.Data;
using System.Linq;
using JO.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JO.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Animal> _animalRepository;
        private readonly ICalculateAnimalStateService _calculateAnimalStateService;

        public UserService(IRepository<User> userRepository,
                           IRepository<Animal> animalRepository,
                           ICalculateAnimalStateService calculateAnimalStateService)
        {
            _userRepository = userRepository;
            _animalRepository = animalRepository;
            _calculateAnimalStateService = calculateAnimalStateService;
        }

        public User AddAnimal(int userId, int animalId)
        {
            var animal = _animalRepository.Table.SingleOrDefault(m => m.AnimalId == animalId);
            if(animal == null)
            {
                throw new Exception("Animal does not exist");
            }

            var user = _userRepository.Table.Include("Animals")
                                            .Include("Animals.Type")
                                            .Include("Animals.Type.Stats")
                                            .FirstOrDefault(m => m.UserId == userId);
            if(user == null)
            {
                throw new Exception("User does not exist");
            }

            if (user.Animals.Contains(animal))
            {
                throw new Exception("User already owns this animal");
            }

            user.Animals.Add(animal);

            _userRepository.Update(user);

            return user;
        }

        public User Login(string name)
        {
            var user = _userRepository.Table.Include("Animals")
                                            .Include("Animals.Type")
                                            .Include("Animals.Type.Stats")
                                            .FirstOrDefault(m => m.Name == name);

            if (user != null)
            {
                user.Animals = _calculateAnimalStateService.ReCalculateAnimalState(user.Animals.ToList());
                return user;
            }

            throw new Exception("User does not exist");
        }

        public User Register(string name)
        {
            var user = _userRepository.Table.Include("Animals")
                                            .Include("Animals.Type")
                                            .Include("Animals.Type.Stats")
                                            .FirstOrDefault(m => m.Name == name);

            if(user == null)
            {
                var userToInsert = new User() { Name = name };

                _userRepository.Insert(userToInsert);

                user = _userRepository.Table.Include("Animals")
                                            .Include("Animals.Type")
                                            .Include("Animals.Type.Stats")
                                            .FirstOrDefault(m => m.UserId == user.UserId);

                user.Animals = _calculateAnimalStateService.ReCalculateAnimalState(user.Animals.ToList());
                return user;
            }

            throw new Exception("Name is in use");
        }
    }
}
