using AutoMapper;
using HotelBooking.DAL.IRepositories;
using HotelBooking.DAL.Repositories;
using HotelBooking.Domain.Entities;
using HotelBooking.Service.DTOs;
using HotelBooking.Service.Helpers;
using HotelBooking.Service.Interfaces;

namespace HotelBooking.Service.Services;

public class AmenityService : IAmenityService
{
    private readonly IAmenityRepository amenityRepository = new AmenityRepository();
    private readonly IMapper mapper;

    public AmenityService()
    {

    }
    public AmenityService(IMapper mapper)
    {
        this.mapper = mapper;
    }
    public async ValueTask<Response<AmenityDto>> AddAmenityAsync(AmenityDto amenityDto)
    {
        var amenity = amenityRepository.SelectAllAsync()
            .FirstOrDefault(x => x.Name.ToLower() == amenityDto.Name.ToLower());
        if (amenity is null)
        {
            var newAmentity = mapper.Map<Amenity>(amenityDto);
            var newResult = await amenityRepository.InsertAmenityAsync(newAmentity);
            var mappedAmentity = mapper.Map<AmenityDto>(newResult);

            return new Response<AmenityDto>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = mappedAmentity
            };
        }
        return new Response<AmenityDto>()
        {
            StatusCode = 403,
            Message = "Category is alredy exists!",
            Value = null
        };
    }

    public async ValueTask<Response<bool>> DeleteAmenityAsync(int id)
    {
        var category = await amenityRepository.SelectAmenityAsync(id);
        if (category is null)
        {
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "NOT FOUND",
                Value = false
            };
        }
        await amenityRepository.DeleteAmenityAsync(id);
        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = true
        };
    }

    public async ValueTask<Response<List<AmenityDto>>> GetAllAmenityAsync()
    {
        var amenity = amenityRepository.SelectAllAsync();
        var mappedAmenity = mapper.Map<List<AmenityDto>>(amenity);
        return new Response<List<AmenityDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedAmenity
        };
    }

    public async ValueTask<Response<AmenityDto>> GetAmenityByIdAsync(int id)
    {
        var amenity = await amenityRepository.SelectAmenityAsync(id);
        if (amenity is null)
        {
            return new Response<AmenityDto>()
            {
                StatusCode = 404,
                Message = "NOT FOUND",
                Value = null
            };
        }
        var mappedAmenity = mapper.Map<AmenityDto>(amenity);
        return new Response<AmenityDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedAmenity
        };
    }

    public async ValueTask<Response<AmenityDto>> ModifyAmenityAsync(int id, AmenityDto amenityDto)
    {
        var amenity = await amenityRepository.SelectAmenityAsync(id);
        if (amenity is null)
        {
            return new Response<AmenityDto>()
            {
                StatusCode = 404,
                Message = "NOT FOUND",
                Value = null
            };
        }
        amenity.Name = amenityDto.Name;
        amenity.UpdatedAt = DateTime.Now;
        
        await amenityRepository.UpdateAmenityAsync(amenity);
        var mappedAmenity = mapper.Map<AmenityDto>(amenity);

        return new Response<AmenityDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedAmenity
        };
        

    }
}
