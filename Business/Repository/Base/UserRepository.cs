using CadFuncionario;
using Database;
using Database.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Base
{
    public class UserRepository<T> : IUserRepository<T> where T : User
    {
        protected readonly Connection _connection;
        private readonly DbSet<T> _dbset;

        public UserRepository(Connection connection)
        {
            _connection = connection;
            _dbset = _connection.Set<T>();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _dbset.SingleOrDefaultAsync(p => p.Id.Equals(id));

                if (result == null)
                    return false;

                _dbset.Remove(result);
                await _connection.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if (item.Id == new int())
                {
                    item.Id = new int();
                }
                item.Password = EasyEncryption.MD5.ComputeMD5Hash(item.Password);

                _dbset.Add(item);
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return item;
        }

        public async Task<bool> ExistAsync (Guid id)
        {
            return await _dbset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dbset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dbset.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dbset.SingleOrDefaultAsync(p => p.Username.Equals(item.Username));

                if (result == null)
                    return null;

                item.Password = EasyEncryption.MD5.ComputeMD5Hash(item.Password);
                _connection.Entry(result).CurrentValues.SetValues(item);
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }

        public async Task<T> Login(string usuario, string senha)
        {
            try
            {
                return await _dbset.SingleOrDefaultAsync(p => p.Username.Equals(usuario) && p.Password.Equals(senha));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
