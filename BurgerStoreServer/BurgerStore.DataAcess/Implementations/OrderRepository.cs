using BurgerStore.DataAcess.Abstractions;
using BurgerStore.DataAcess.DbContext;
using BurgerStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace BurgerStore.DataAcess.Implementations
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly BurgerAppDbContext _dbContext;
        public OrderRepository(BurgerAppDbContext dbContext) : base(dbContext)
        {
         _dbContext = dbContext;
        }

        public Task<List<Order>> GetOrdersWithDetails()
        {
            var Orders = _dbContext.Order
                .Include(o => o.Burgers)
                .Include(o => o.User)
                .ToListAsync();

            return Orders;
        }
    }
}
