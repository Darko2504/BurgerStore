namespace BurgerStore.Shared.CustomExceptions.BurgerExceptions
{
    public class BurgerNotFoundException : Exception
    {
        public BurgerNotFoundException(string message) : base(message)
        {

        }
    }
}
