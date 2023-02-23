using HotelBooking.DAL.IRepositories;
using HotelBooking.DAL.Repositories;
using HotelBooking.Domain.Entities;
using HotelBooking.Service.Helpers;
using HotelBooking.Service.Interfaces;

namespace HotelBooking.Service.Services;

public class AmenityService : IAmenityService
{

    private readonly IGenericRepository<Amenity> amenityRepository;
    public AmenityService()
    {
        amenityRepository = new GenericRepository<Amenity>();
    }

    public async Task<GenericResponse<Amenity>> CreateAsync(Amenity amenity)
    {

        var models = await this.amenityRepository.GetAllAsync();
        var model = models.FirstOrDefault(x => x.Name == amenity.Name);

        if (model is not null)
        {
            return new GenericResponse<Amenity>
            {
                StatusCode = 404,
                Message = "This category is already exists",
                Value = null,
            };
        }
        var mappedModel = new Amenity()
        {
            Name = amenity.Name,
            Id = amenity.Id,
            CreatedAt = DateTime.UtcNow,
        };
        await amenityRepository.CreateAsync(mappedModel);

        return new GenericResponse<Amenity>
        {
            StatusCode = 200,
            Message = "New category created",
            Value = mappedModel
        };
    }
    public async Task<GenericResponse<Amenity>> DeleteAsync(long id)
    {
        var model = await this.amenityRepository.GetByIdAsync(id);
        if (model is null)
        {
            return new GenericResponse<Amenity>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null
            };
        }
        await this.amenityRepository.DeleteAsync(model.Id);

        return new GenericResponse<Amenity>
        {
            StatusCode = 200,
            Message = "Successfully deleted )",
            Value = model,
        };
    }
    public async Task<GenericResponse<List<Amenity>>> GetAllAsync(Predicate<Amenity> predicate)
    {
        var models = await amenityRepository.GetAllAsync(predicate);
        if (models is null)
        {
            return new GenericResponse<List<Amenity>>
            {
                StatusCode = 404,
                Message = "Empty",
                Value = null,
            };
        }
        return new GenericResponse<List<Amenity>>
        {
            StatusCode = 200,
            Message = "Ok )",
            Value = models
        };
    }
    public async Task<GenericResponse<Amenity>> GetByIdAsync(long id)
    {
        var model = await this.amenityRepository.GetByIdAsync(id);

        if (model is null)
        {
            return new GenericResponse<Amenity>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null,
            };
        }

        return new GenericResponse<Amenity>
        {
            StatusCode = 200,
            Message = "Ok )",
            Value = model,

        };
    }
    public async Task<GenericResponse<Amenity>> UpdateAsync(long id, Amenity amenity)
    {
        var model = await this.amenityRepository.GetByIdAsync(id);

        if (model is null)
        {
            return new GenericResponse<Amenity>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null,
            };
        }

        var mappedmodel = new Amenity()
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            Name = model.Name,
            UpdatedAt = DateTime.UtcNow
            
        };

        var res = await this.amenityRepository.UpdateAsync(mappedmodel);

        return new GenericResponse<Amenity>
        {
            StatusCode = 200,
            Message = "Successfully updated )",
            Value = mappedmodel,
        };
    }

}




    
    

    








