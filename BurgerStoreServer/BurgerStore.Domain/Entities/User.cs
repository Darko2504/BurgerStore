using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace BurgerStore.Domain.Entities
{
    public class User : IdentityUser
    {
        public bool FirstLogIn { get; set; }
        [JsonIgnore]
        public List<Order> Orders { get; set; } = new();
        [JsonIgnore]
        public List<Burger> Burgers { get; set; } = new();
    }
}
