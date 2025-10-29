using BurgerStore.Dtos.BurgerDtos;
using BurgerStore.Shared.Responses;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BurgerStore.Services.Abstractions
{
    public interface IBurgerService
    {
        Task<CustomResponse<List<BurgerDto>>> GetAllBurgers();
        Task<CustomResponse<BurgerDto>> GetBurgerById(int id);
        Task<CustomResponse<BurgerDto>> CreateBurger(string userId, AddBurgerDto addBurgerDto);
        Task<CustomResponse<BurgerDto>> UpdateBurger(string userId, int pizzaId,  UpdateBurgerDto updateBurgerDto);
        Task<CustomResponse> DeleteBurger(string userId, int burgerId);
    }
}
