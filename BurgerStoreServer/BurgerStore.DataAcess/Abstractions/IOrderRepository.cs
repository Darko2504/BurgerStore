using BurgerStore.Domain.Entities;

namespace BurgerStore.DataAcess.Abstractions
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<List<Order>> GetOrdersWithDetails();
    }
}
