using BurgerStore.Domain.Enums;

namespace BurgerStore.Dtos.BurgerDtos
{
    public class UpdateBurgerDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public List<IngredientsEnum> Ingredients { get; set; }
        public int? OrderId { get; set; }
    }
}
}
