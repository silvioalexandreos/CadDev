using CadFuncionario;
using Database.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Service.User
{
    public class UserService : IUserService
    {

        private IUserRepository<Database.User> _user;
        public UserService(IUserRepository<Database.User> user)
        {
            _user = user;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _user.DeleteAsync(id);
        }

        public Task<Database.User> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Database.User>> GetAll()
        {
            return await _user.SelectAsync();
        }

        public async Task<Database.User> Login(string usuario, string senha)
        {
            return await _user.Login(usuario, senha);
        }

        public async Task<Database.User> Post(Database.User user)
        {
            return await _user.InsertAsync(user);
        }

        public async Task<Database.User> Put(Database.User user)
        {
            return await _user.UpdateAsync(user);
        }
    }
}
