using HotelBooking.Domain.Entities;
using HotelBooking.Service.DTOs;
using HotelBooking.Service.Helpers;

namespace HotelBooking.Service.Interfaces;

public interface IHotelService
{
    Task<GenericResponse<Hotel>> CreateAsync(HotelCreationDto hotel);
    Task<GenericResponse<Hotel>> UpdateAsync(long id, HotelCreationDto hotel);
    Task<GenericResponse<Hotel>> DeleteAsync(long id);
    Task<GenericResponse<List<Hotel>>> GetAllAsync(Predicate<Hotel> predicate );
    Task<GenericResponse<Hotel>> GetByIdAsync(long id);
}

