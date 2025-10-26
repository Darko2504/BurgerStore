using BurgerStore.DataAcess.Abstractions;
using BurgerStore.DataAcess.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BurgerStore.DataAcess.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly BurgerAppDbContext _dbContext;
        public BaseRepository(BurgerAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(T entity)
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                List<T> GetAll = await _dbContext.Set<T>().ToListAsync();
                return GetAll;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> GetById(string id)
        {
            try
            {
                return await _dbContext.Set<T>().FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> GetByIdInt(int id)
        {
            try
            {
                return await _dbContext.Set<T>().FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Remove(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();    
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            try
            {
                _dbContext.Set<T>().Update(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
