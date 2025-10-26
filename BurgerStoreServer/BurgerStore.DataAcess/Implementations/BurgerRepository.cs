using BurgerStore.DataAcess.Abstractions;
using BurgerStore.DataAcess.DbContext;
using BurgerStore.Domain.Entities;

namespace BurgerStore.DataAcess.Implementations
{
    public class BurgerRepository : BaseRepository<Burger>, IBurgerRepository
    {
        private readonly BurgerAppDbContext _dbContext;
        public BurgerRepository(BurgerAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
