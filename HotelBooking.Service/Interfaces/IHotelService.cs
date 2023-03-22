using HotelBooking.Domain.Entities;
using HotelBooking.Service.DTOs;
using HotelBooking.Service.Helpers;

namespace HotelBooking.Service.Interfaces;

public interface IHotelService
{
    ValueTask<Response<HotelDto>> AddHotelAsync(HotelForCreationDto hotelForCreationDto);
    ValueTask<Response<HotelDto>> ModifyHotelAsync(int id, HotelForCreationDto hotelForCreationDto);
    ValueTask<Response<bool>> DeleteHotelAsync(int id);
    ValueTask<Response<HotelDto>> GetHotelByIdAsync(int id);
    ValueTask<Response<List<HotelDto>>> GetAllHotelAsync();
}

