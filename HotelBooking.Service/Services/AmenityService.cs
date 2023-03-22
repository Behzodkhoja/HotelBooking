using HotelBooking.DAL.IRepositories;
using HotelBooking.DAL.Repositories;
using HotelBooking.Domain.Entities;
using HotelBooking.Service.DTOs;
using HotelBooking.Service.Helpers;
using HotelBooking.Service.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HotelBooking.Service.Services;

public class AmenityService : IAmenityService
{
    private readonly IAmenityRepository amenityRepository = new AmenityRepository();
    public async ValueTask<Response<AmenityDto>> AddAmenityAsync(AmenityForCreationDto amenityForCreationDto)
    {

        var addedAmenity = await this.amenityRepository.InsertAmenityAsync(amenity);
        return new Response<Amenity>
        {
            StatusCode = 200,
            Message = "Success",
            Value = addedAmenity
        };
    }

    public ValueTask<Response<bool>> DeleteAmenityAsync(int id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Response<List<AmenityDto>>> GetAllAmenityAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<Response<AmenityDto>> GetAmenityByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Response<AmenityDto>> ModifyAmenityAsync(int id, AmenityForCreationDto amenityForCreationDto)
    {
        throw new NotImplementedException();
    }
}
