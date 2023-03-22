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
        public ValueTask<Response<RoomDto>> AddRoomAsync(RoomForCreationDto roomForCreationDto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Response<bool>> DeleteRoomAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Response<List<RoomDto>>> GetAllRoomAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Response<RoomDto>> GetRoomByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Response<RoomDto>> ModifyRoomAsync(int id, RoomForCreationDto roomForCreationDto)
        {
            throw new NotImplementedException();
        }
    }
}
