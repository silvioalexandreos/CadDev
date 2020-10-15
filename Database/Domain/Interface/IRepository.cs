using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Interface
{
    public interface IRepository<T> where T : Person
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
    }
}
