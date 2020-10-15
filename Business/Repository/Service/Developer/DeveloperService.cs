using Database.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Service.Developer
{
    public class DeveloperService : IDeveloperService
    {
        private IRepository<Database.Developer> _repository;
        public DeveloperService(IRepository<Database.Developer> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Database.Developer> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Database.Developer>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<Database.Developer> Post(Database.Developer developer)
        {
            return await _repository.InsertAsync(developer);
        }

        public async Task<Database.Developer> Put(Database.Developer developer)
        {
            return await _repository.UpdateAsync(developer);
        }
    }
}
