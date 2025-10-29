using AutoMapper;
using BurgerStore.Domain.Entities;
using BurgerStore.Dtos.BurgerDtos;
using BurgerStore.Dtos.OrderDtos;
using BurgerStore.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace BurgerStore.Mapperss.MapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, LoginUserRequestDto>().ReverseMap();
            CreateMap<User, UserOrderDto>().ReverseMap();
            CreateMap<User, RegisterUserRequestDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Burger, BurgerDto>().ReverseMap();
            CreateMap<Burger, AddBurgerDto>().ReverseMap();
            CreateMap<Burger, UpdateBurgerDto>().ReverseMap();
            CreateMap<Burger, AddBurgerDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, AddOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();

        }
    }
}
