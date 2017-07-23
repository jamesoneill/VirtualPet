using JO.Data;

namespace JO.Core.Services
{
    public interface IUserService
    {
        User GetById(int id);
        //Temporary some actual authentication would need to be implemented.
        User Login(string name);
    }
}