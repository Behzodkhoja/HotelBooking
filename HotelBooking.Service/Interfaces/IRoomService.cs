using HotelBooking.Domain.Entities;
using HotelBooking.Service.Helpers;

namespace HotelBooking.Service.Interfaces;

public interface IRoomService
{
    Task<GenericResponse<Room>> CreateAsync(Room room);
    Task<GenericResponse<Room>> UpdateAsync(long id, Room room);
    Task<GenericResponse<Room>> DeleteAsync(long id);
    Task<GenericResponse<List<Room>>> GetAllAsync(Predicate<Room> predicate);
    Task<GenericResponse<Room>> GetByIdAsync(long id);
}

