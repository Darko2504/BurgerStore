using BurgerStore.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace BurgerStore.Services.UserService.Abstractions
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> GenereteTokenAsync(User user);
    }
}
