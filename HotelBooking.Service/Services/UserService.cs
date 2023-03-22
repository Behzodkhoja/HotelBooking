using HotelBooking.Service.DTOs;
using HotelBooking.Service.Helpers;
using HotelBooking.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Service.Services
{
    public class UserService : IUserService
    {
        public ValueTask<Response<UserDto>> AddUserAsync(UserForCreationDto userForCreationDto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Response<bool>> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Response<List<UserDto>>> GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Response<UserDto>> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Response<UserDto>> ModifyUserAsync(int id, UserForCreationDto userForCreationDto)
        {
            throw new NotImplementedException();
        }
    }
}
