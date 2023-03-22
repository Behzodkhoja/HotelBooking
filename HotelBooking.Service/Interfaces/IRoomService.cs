using HotelBooking.Domain.Entities;
using HotelBooking.Service.DTOs;
using HotelBooking.Service.Helpers;

namespace HotelBooking.Service.Interfaces;

public interface IRoomService
{
    ValueTask<Response<RoomDto>> AddRoomAsync(RoomDto roomDto);
    ValueTask<Response<RoomDto>> ModifyRoomAsync(int id, RoomDto roomDto);
    ValueTask<Response<bool>> DeleteRoomAsync(int id);
    ValueTask<Response<RoomDto>> GetRoomByIdAsync(int id);
    ValueTask<Response<List<RoomDto>>> GetAllRoomAsync();
}

