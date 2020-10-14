using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Service.Developer
{
    public interface IDeveloperService
    {
        Task<Database.Developer> Get(Guid id);
        Task<IEnumerable<Database.Developer>> GetAll();
        Task<Database.Developer> Post(Database.Developer developer);
        Task<Database.Developer> Put(Database.Developer developer);
        Task<bool> Delete(Guid id);
    }
}
