using System.ComponentModel.DataAnnotations.Schema;
using webAppDemos.Entities.Abstracts;

namespace webAppDemos.Entities.Concretes
{
    public class User : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 

        public User() { }

        public User(long id, string email, string password) {
            this.Id = id;
            this.Email = email;
            this.Password = password;
        }
    }
}
