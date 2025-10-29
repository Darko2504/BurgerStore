using AutoMapper;
using BurgerStore.DataAcess.Abstractions;
using BurgerStore.Domain.Entities;
using BurgerStore.Dtos.BurgerDtos;
using BurgerStore.Services.Abstractions;
using BurgerStore.Shared.Responses;

namespace BurgerStore.Services.Implementations
{
    public class BurgerService : IBurgerService
    {
        private readonly IMapper _mapper;
        private readonly IBurgerRepository _burgerRepository;
        public BurgerService(IMapper mapper, IBurgerRepository burgerRepository)
        {
            _mapper = mapper;
            _burgerRepository = burgerRepository;   
        }
        public async Task<CustomResponse<BurgerDto>> CreateBurger(string userId, AddBurgerDto addBurgerDto)
        {
            try
            {
                Burger burger = _mapper.Map<Burger>(addBurgerDto);
                burger.UserId = userId;
                await _burgerRepository.Add(burger);
                var burgerDtoResult = _mapper.Map<BurgerDto>(addBurgerDto);
                burgerDtoResult.UserId = burger.UserId;
                return new CustomResponse<BurgerDto>() { IsSuccessfull = true, Result = burgerDtoResult };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CustomResponse> DeleteBurger(string userId, int burgerId)
        {
            try
            {
                Burger burger = await _burgerRepository.GetByIdInt(burgerId);
                if (burger == null) return new CustomResponse("Burger not found");
                if (burger.UserId != userId) return new CustomResponse("You are not authorized to delete this burger");
                await _burgerRepository.Remove(burger);
                return new CustomResponse() {  IsSuccessfull = true };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CustomResponse<List<BurgerDto>>> GetAllBurgers()
        {
            try
            {
               List<Burger> burgers = await _burgerRepository.GetAll();
                List<BurgerDto> burgerDtos = _mapper.Map<List<BurgerDto>>(burgers);
                return new CustomResponse<List<BurgerDto>>() { IsSuccessfull = true, Result = burgerDtos };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CustomResponse<BurgerDto>> GetBurgerById(int id)
        {
           try
            {
                Burger burger = await _burgerRepository.GetByIdInt(id);
                if (burger == null) return new CustomResponse<BurgerDto>("Burger not found");
                BurgerDto burgerDto = _mapper.Map<BurgerDto>(burger);   
                return new CustomResponse<BurgerDto>() { IsSuccessfull = true, Result = burgerDto };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CustomResponse<BurgerDto>> UpdateBurger(string userId, int pizzaId, UpdateBurgerDto updateBurgerDto)
        {
            try
            {
                Burger burger = await _burgerRepository.GetByIdInt(pizzaId);
                if (burger == null) return new CustomResponse<BurgerDto>("Burger not found");
                if (burger.UserId != userId) return new CustomResponse<BurgerDto>("You are not authorized to update this burger");

                _mapper.Map(updateBurgerDto, burger);
                await _burgerRepository.Update(burger);
                BurgerDto burgerDtoResult = _mapper.Map<BurgerDto>(burger);
                return new CustomResponse<BurgerDto>() { IsSuccessfull = true, Result = burgerDtoResult };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
