namespace BurgerStore.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string AdressTo { get; set; }
        public string Description { get; set; }
        public int OrderPrice { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public List<Burger> Burgers { get; set; }
    }
}
