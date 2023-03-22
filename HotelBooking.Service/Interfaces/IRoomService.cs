using HotelBooking.Domain.Entities;
using HotelBooking.Service.DTOs;
using HotelBooking.Service.Helpers;

namespace HotelBooking.Service.Interfaces;

public interface IRoomService
{
    ValueTask<Response<RoomDto>> AddRoomAsync(RoomForCreationDto roomForCreationDto);
    ValueTask<Response<RoomDto>> ModifyRoomAsync(int id, RoomForCreationDto roomForCreationDto);
    ValueTask<Response<bool>> DeleteRoomAsync(int id);
    ValueTask<Response<RoomDto>> GetRoomByIdAsync(int id);
    ValueTask<Response<List<RoomDto>>> GetAllRoomAsync();
}

