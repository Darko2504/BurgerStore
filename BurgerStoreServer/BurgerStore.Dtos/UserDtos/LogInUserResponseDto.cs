namespace BurgerStore.Dtos.UserDtos
{
    public class LogInUserResponseDto
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
