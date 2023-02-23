using HotelBooking.DAL.IRepositories;
using HotelBooking.DAL.Repositories;
using HotelBooking.Domain.Entities;
using HotelBooking.Service.DTOs;
using HotelBooking.Service.Helpers;
using HotelBooking.Service.Interfaces;

namespace HotelBooking.Service.Services;

public class HotelService : IHotelService
{
    private readonly IGenericRepository<Hotel> hotelRepository;
    private long id = 1;
    public HotelService()
    {
        hotelRepository = new GenericRepository<Hotel>();
    }
    public async Task<GenericResponse<Hotel>> CreateAsync(HotelCreationDto hotel)
    {
        var models = await this.hotelRepository.GetAllAsync();
        var model = models.FirstOrDefault(x => x.Name == hotel.Name);

        if (model is not null)
        {
            return new GenericResponse<Hotel>
            {
                StatusCode = 404,
                Message = "This category is already exists",
                Value = null,
            };
        }
        var mappedModel = new Hotel()
        {
            Name = hotel.Name,
            Id= id++,
            CreatedAt = DateTime.UtcNow,
        };
        await hotelRepository.CreateAsync(mappedModel);

        return new GenericResponse<Hotel>
        {
            StatusCode = 200,
            Message = "New category created",
            Value = mappedModel
        };
    }

  
    public async Task<GenericResponse<Hotel>> DeleteAsync(long id)
    {
        var model = await this.hotelRepository.GetByIdAsync(id);
        if (model is null)
        {
            return new GenericResponse<Hotel>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null
            };
        }
        await this.hotelRepository.DeleteAsync(model.Id);

        return new GenericResponse<Hotel>
        {
            StatusCode = 200,
            Message = "Successfully deleted )",
            Value = model,
        };
    }

    public async Task<GenericResponse<List<Hotel>>> GetAllAsync(Predicate<Hotel> predicate)
    {
        var models = await hotelRepository.GetAllAsync(predicate);
        if (models is null)
        {
            return new GenericResponse<List<Hotel>>
            {
                StatusCode = 404,
                Message = "Empty",
                Value = null,
            };
        }
        return new GenericResponse<List<Hotel>>
        {
            StatusCode = 200,
            Message = "Ok )",
            Value = models
        };
    }

    public async Task<GenericResponse<Hotel>> GetByIdAsync(long id)
    {
        var model = await this.hotelRepository.GetByIdAsync(id);

        if (model is null)
        {
            return new GenericResponse<Hotel>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null,
            };
        }

        return new GenericResponse<Hotel>
        {
            StatusCode = 200,
            Message = "Ok )",
            Value = model,

        };
    }

    public async Task<GenericResponse<Hotel>> UpdateAsync(long id, HotelCreationDto hotel)
    {
        var model = await this.hotelRepository.GetByIdAsync(id);

        if (model is null)
        {
            return new GenericResponse<Hotel>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null,
            };
        }

        var mappedmodel = new Hotel()
        {
            Id=id++,
            CreatedAt = model.CreatedAt,
            Name = model.Name,
            UpdatedAt = DateTime.UtcNow

        };

        var res = await this.hotelRepository.UpdateAsync(mappedmodel);

        return new GenericResponse<Hotel>
        {
            StatusCode = 200,
            Message = "Successfully updated )",
            Value = mappedmodel,
        };
    }
}


