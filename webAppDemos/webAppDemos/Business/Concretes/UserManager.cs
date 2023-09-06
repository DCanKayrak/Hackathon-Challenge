using Microsoft.EntityFrameworkCore;
using webAppDemos.Business.Abstracts;
using webAppDemos.Entities.Abstracts;
using webAppDemos.Entities.Concretes;
using webAppDemos.Models;
using webAppDemos.Repositories.Abstracts;
using webAppDemos.Repositories.Concretes;

namespace webAppDemos.Business.Concretes
{
    public class UserManager : IUserService
    {
        private readonly ApplicationContext _applicationContext;
        
        public UserManager(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public List<User> GetUsers()
        {
            return _applicationContext.Users.ToList();
        }

        public string CreateUser(CreateUserRequestDTO request)
        {
            User tempUser = new User();
            tempUser.Email = request.Email;
            tempUser.Password = request.Password;

            var tempEntity = _applicationContext.Entry(tempUser);
            tempEntity.State = EntityState.Added;
            _applicationContext.SaveChanges();
            
            return "Kayıt Başarılı!";
        }
    }
}
