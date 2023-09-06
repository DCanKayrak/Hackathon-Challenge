using webAppDemos.Entities.Concretes;
using webAppDemos.Models;

namespace webAppDemos.Business.Abstracts
{
    public interface IUserService
    {
        List<User> GetUsers();
        string CreateUser(CreateUserRequestDTO request);
    }
}
