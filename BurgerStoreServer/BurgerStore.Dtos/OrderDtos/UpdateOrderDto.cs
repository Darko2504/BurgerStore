using BurgerStore.Domain.Entities;

namespace BurgerStore.Dtos.OrderDtos
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string AdressTo { get; set; }
        public string? Description { get; set; }
        public int OrderPrice { get; set; }
        public List<Burger> Burgers { get; set; }
    }
}
