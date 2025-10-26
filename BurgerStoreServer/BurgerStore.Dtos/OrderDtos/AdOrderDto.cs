namespace BurgerStore.Dtos.OrderDtos
{
    public class AdOrderDto
    {
        public string AdressTo { get; set; }
        public string? Description { get; set; }
        public int OrderPrice { get; set; }
        public List<AddBurgerDto> Burgers { get; set; }
    }
}
