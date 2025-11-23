using AutoMapper;
using Azure;
using BurgerStore.Domain.Entities;
using BurgerStore.Dtos.UserDtos;
using BurgerStore.Services.UserService.Abstractions;
using BurgerStore.Shared.CustomExceptions.UserExceptions;
using BurgerStore.Shared.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace BurgerStore.Services.UserService.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public UserService(IMapper mapper, UserManager<User> userManager, ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<CustomResponse> DeleteUserAsync(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null) return new CustomResponse("User not found");
                var result = await _userManager.DeleteAsync(user);
                if(!result.Succeeded) return new CustomResponse(result.Errors.Select(x => x.Description));
                return new CustomResponse();
            }
            catch (UserDataException ex)
            {
                throw new UserDataException(ex.Message);

            }
            catch(UserNotFoundException ex)
            {
                throw new UserNotFoundException(ex.Message);
            }
        }

        public async Task<CustomResponse> GetAllUsersAsync()
        {
            try
            {
                var response = new CustomResponse<List<UserDto>>();
                var users = await _userManager.Users.ToListAsync();
                var userDtos = users.Select(user => _mapper.Map<UserDto>(user)).ToList();
                response.Result = userDtos;
                response.IsSuccessfull = true;
                
                return response;
            }
            catch (UserDataException ex)
            {
                throw new UserDataException(ex.Message);
            }
        }

        public async Task<CustomResponse<UserDto>> GetUsersByIdAsync(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null) return new CustomResponse<UserDto>("User not found");
                var userDto = _mapper.Map<UserDto>(user);
                return new CustomResponse<UserDto>(userDto);
            }
            catch (UserDataException ex)
            {
                throw new UserDataException(ex.Message);
            }
        }

        public async Task<CustomResponse<LogInUserResponseDto>> LoginUserAsync(LoginUserRequestDto request)
        {
            try
            {
                if(string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password)) 
                    throw new UserDataException("Username or password cannot be empty");

                var user = await _userManager.FindByNameAsync(request.Username);
                if (user == null) return new CustomResponse<LogInUserResponseDto>() { IsSuccessfull = false, Errors = new List<string>() { "User does not exist" } };
                
                var isValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);
                if (!isValidPassword) return new CustomResponse<LogInUserResponseDto>() { IsSuccessfull = false, Errors = new List<string>() { "Invalid password" } };

                var token = await _tokenService.GenereteTokenAsync(user);
                return new CustomResponse<LogInUserResponseDto>(new LogInUserResponseDto
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ValidTo = token.ValidTo.AddDays(1)
                });
            }
            catch (UserDataException ex)
            {
                throw new UserDataException(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CustomResponse<RegisterUserResponseDto>> RegisterUserAsync(RegisterUserRequestDto request)
        {
            try
            {
                if(string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.Email))
                    throw new UserDataException("Username, password or email cannot be empty");

                UserDto userDto = new UserDto
                {
                    UserName = request.Username,
                    Email = request.Email
                };
                var result = await _userManager.CreateAsync(userDto, request.Password);

                if(!result.Succeeded) return new(result.Errors.Select(x => x.Description));

                return new(new RegisterUserResponseDto
                {
                    Id = userDto.Id,
                    Email = userDto.Email,
                    Username = userDto.UserName
                });
            }
            catch (UserDataException ex)
            {
                throw new UserDataException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CustomResponse<UpdateUserDto>> UpdateUserAsync(string id, UpdateUserDto updatedUser)
        {
            try
            {
                User user = await _userManager.FindByEmailAsync(id);
                if (user == null) return new CustomResponse<UpdateUserDto>("User not found");
                _mapper.Map(user, updatedUser);
                var result = await _userManager.UpdateAsync(user);
                var userDtoResult = _mapper.Map<UpdateUserDto>(user);
                if(!result.Succeeded) return new CustomResponse<UpdateUserDto>(result.Errors.Select(x => x.Description));

                return new CustomResponse<UpdateUserDto>(userDtoResult);
            }   
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
