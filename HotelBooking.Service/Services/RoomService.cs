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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository = new RoomRepository();
        private readonly IMapper mapper;
        public RoomService()
        {

        }
        public RoomService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async ValueTask<Response<RoomDto>> AddRoomAsync(RoomDto roomDto)
        {
            var room = roomRepository.SelectAllAsync()
            .FirstOrDefault(x => x.Status == roomDto.Status);
            if (room is null)
            {
                var newRoom = mapper.Map<Room>(roomRepository);
                var newResult = await roomRepository.InsertRoomAsync(newRoom);
                var mappedRoom = mapper.Map<RoomDto>(newResult);

                return new Response<RoomDto>()
                {
                    StatusCode = 200,
                    Message = "Success",
                    Value = mappedRoom
                };
            }
            return new Response<RoomDto>()
            {
                StatusCode = 403,
                Message = "Category is alredy exists!",
                Value = null
            };
        }

        public async ValueTask<Response<bool>> DeleteRoomAsync(int id)
        {
            var room = await roomRepository.SelectRoomAsync(id);
            if (room is null)
            {
                return new Response<bool>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = false
                };
            }
            await roomRepository.DeleteRoomAsync(id);
            return new Response<bool>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = true
            };
        }

        public async ValueTask<Response<List<RoomDto>>> GetAllRoomAsync()
        {
            var room = roomRepository.SelectAllAsync();
            var mappedRoom = mapper.Map<List<RoomDto>>(room);
            return new Response<List<RoomDto>>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = mappedRoom
            };
        }

        public async ValueTask<Response<RoomDto>> GetRoomByIdAsync(int id)
        {
            var room = await roomRepository.SelectRoomAsync(id);
            if (room is null)
            {
                return new Response<RoomDto>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = null
                };
            }
            var mappedRoom = mapper.Map<RoomDto>(room);
            return new Response<RoomDto>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = mappedRoom
            };
        }

        public async ValueTask<Response<RoomDto>> ModifyRoomAsync(int id, RoomDto roomDto)
        {
            var room = await roomRepository.SelectRoomAsync(id);
            if (room is null)
            {
                return new Response<RoomDto>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = null
                };
            }
            room.Desription = roomDto.Desription;
            room.Status = roomDto.Status;
            room.Capacity = roomDto.Capacity;
            room.Price = roomDto.Price;
            room.Type = roomDto.Type;
            room.Hotel = roomDto.Hotel;
            room.UpdatedAt = DateTime.Now;

            await roomRepository.UpdateRoomAsync(room);
            var mappedRoom = mapper.Map<RoomDto>(room);

            return new Response<RoomDto>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = mappedRoom
            };
        }
    }
}
