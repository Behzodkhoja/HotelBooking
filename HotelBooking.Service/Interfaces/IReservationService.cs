using HotelBooking.Domain.Entities;
using HotelBooking.Service.Helpers;

namespace HotelBooking.Service.Interfaces;

public interface IReservationService
{
    Task<GenericResponse<Reservation>> CreateAsync(Reservation reservation);
    Task<GenericResponse<Reservation>> UpdateAsync(long id, Reservation reservation);
    Task<GenericResponse<Reservation>> DeleteAsync(long id);
    Task<GenericResponse<List<Reservation>>> GetAllAsync(Predicate<Reservation> predicate);
    Task<GenericResponse<Reservation>> GetByIdAsync(long id);
}


