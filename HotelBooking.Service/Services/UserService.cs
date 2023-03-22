using AutoMapper;
using HotelBooking.DAL.IRepositories;
using HotelBooking.DAL.Repositories;
using HotelBooking.Domain.Entities;
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
        private readonly IUserRepository userRepository = new UserRepository();
        private readonly IMapper mapper;
        public UserService()
        {

        }
        public UserService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public async ValueTask<Response<UserDto>> AddUserAsync(UserDto userDto)
        {

            var room = userRepository.SelectAllAsync()
            .FirstOrDefault(x => x.Username.ToLower() == userDto.Username.ToLower());
            if (room is null)
            {
                var newUser = mapper.Map<User>(userRepository);
                var newResult = await userRepository.InsertUserAsync(newUser);
                var mappedUser = mapper.Map<UserDto>(newResult);

                return new Response<UserDto>()
                {
                    StatusCode = 200,
                    Message = "Success",
                    Value = mappedUser
                };
            }
            return new Response<UserDto>()
            {
                StatusCode = 403,
                Message = "Category is alredy exists!",
                Value = null
            };
        }

        public async ValueTask<Response<bool>> DeleteUserAsync(int id)
        {
            var user = await userRepository.SelectUserAsync(id);
            if (user is null)
            {
                return new Response<bool>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = false
                };
            }
            await userRepository.DeleteUserAsync(id);
            return new Response<bool>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = true
            };
        }

        public async ValueTask<Response<List<UserDto>>> GetAllUserAsync()
        {
            var user = userRepository.SelectAllAsync();
            var mappedUser = mapper.Map<List<UserDto>>(user);
            return new Response<List<UserDto>>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = mappedUser
            };
        }

        public async ValueTask<Response<UserDto>> GetUserByIdAsync(int id)
        {
            var user = await userRepository.SelectUserAsync(id);
            if (user is null)
            {
                return new Response<UserDto>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = null
                };
            }
            var mappedUSer = mapper.Map<UserDto>(user);
            return new Response<UserDto>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = mappedUSer
            };
        }

        public async ValueTask<Response<UserDto>> ModifyUserAsync(int id, UserDto userDto)
        {
            var user = await userRepository.SelectUserAsync(id);
            if (user is null)
            {
                return new Response<UserDto>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = null
                };
            }
            user.LastName = userDto.LastName;
            user.FirstName = userDto.FirstName;
            user.Username = userDto.Username;
            user.Phone = userDto.Phone;
            user.Role = userDto.Role;
            user.UpdatedAt = DateTime.Now;
            

            await userRepository.UpdateUserAsync(user);
            var mappedRoom = mapper.Map<UserDto>(user);

            return new Response<UserDto>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = mappedRoom
            };
        }
    }
}
