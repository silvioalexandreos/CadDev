using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Service.User
{
    public interface IUserService
    {
        Task<Database.User> Get(Guid id);
        Task<IEnumerable<Database.User>> GetAll();
        Task<Database.User> Post(Database.User user);
        Task<Database.User> Put(Database.User user);
        Task<bool> Delete(Guid id);

        Task<Database.User> Login(string usuario, string senha);
    }
}
