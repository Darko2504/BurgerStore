using BurgerStore.Dtos.UserDtos;
using BurgerStore.Shared.Responses;

namespace BurgerStore.Services.UserService.Abstractions
{
    public interface IUserService
    {
        Task<CustomResponse<RegisterUserResponseDto>> RegisterUserAsync(RegisterUserRequestDto request);
        Task<CustomResponse> GetAllUsersAsync();
        Task<CustomResponse<LogInUserResponseDto>> LoginUserAsync(LoginUserRequestDto request);
        Task<CustomResponse<UserDto>> GetUsersByIdAsync(string id);
        Task<CustomResponse<UpdateUserDto>> UpdateUserAsync(string id, UpdateUserDto updatedUser);
        Task<CustomResponse> DeleteUserAsync(string id);
    }
}
