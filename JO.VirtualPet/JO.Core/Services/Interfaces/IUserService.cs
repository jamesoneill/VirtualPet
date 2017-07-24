using JO.Data;

namespace JO.Core.Services
{
    public interface IUserService
    {
        //Temporary some actual authentication would need to be implemented.
        User Login(string name);
        User Register(string name);
        User AddAnimal(int userId, int animalId);
        User PetAnimal(int userId, int animalId);
        User FeedAnimal(int userId, int animalId);
    }
}