using HotelBooking.Domain.Entities;
using HotelBooking.Service.DTOs;
using HotelBooking.Service.Helpers;

namespace HotelBooking.Service.Interfaces;

public interface IUserService
{
    ValueTask<Response<UserDto>> AddUserAsync(UserForCreationDto userForCreationDto);
    ValueTask<Response<UserDto>> ModifyUserAsync(int id, UserForCreationDto userForCreationDto);
    ValueTask<Response<bool>> DeleteUserAsync(int id);
    ValueTask<Response<UserDto>> GetUserByIdAsync(int id);
    ValueTask<Response<List<UserDto>>> GetAllUserAsync();
}


