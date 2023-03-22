using HotelBooking.Domain.Entities;
using HotelBooking.Service.DTOs;
using HotelBooking.Service.Helpers;

namespace HotelBooking.Service.Interfaces;

public interface IReservationService
{
    ValueTask<Response<ReservationDto>> AddReservationAsync(ReservationForCreationDto reservationForCreationDto);
    ValueTask<Response<ReservationDto>> ModifyReservationAsync(int id, ReservationForCreationDto reservationForCreationDto);
    ValueTask<Response<bool>> DeleteReservationAsync(int id);
    ValueTask<Response<ReservationDto>> GetReservationByIdAsync(int id);
    ValueTask<Response<List<ReservationDto>>> GetAllReservationAsync();
}


