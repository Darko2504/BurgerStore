using BurgerStore.Domain.Enums;

namespace BurgerStore.Dtos.BurgerDtos
{
    public class BurgerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string UserId { get; set; }
        public int? OrderId { get; set; }
        public List<IngredientsEnum> Ingredients { get; set; }
    }
}
