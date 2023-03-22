using HotelBooking.Domain.Entities;
using HotelBooking.Service.DTOs;
using HotelBooking.Service.Helpers;

namespace HotelBooking.Service.Interfaces;

public interface IAmenityService
{
    ValueTask<Response<AmenityDto>> AddAmenityAsync(AmenityDto amenityDto);
    ValueTask<Response<AmenityDto>> ModifyAmenityAsync(int id, AmenityDto amenityDto);
    ValueTask<Response<bool>> DeleteAmenityAsync(int id);
    ValueTask<Response<AmenityDto>> GetAmenityByIdAsync(int id);
    ValueTask<Response<List<AmenityDto>>> GetAllAmenityAsync();   
}




