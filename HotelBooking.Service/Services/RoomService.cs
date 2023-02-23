using HotelBooking.DAL.IRepositories;
using HotelBooking.DAL.Repositories;
using HotelBooking.Domain.Entities;
using HotelBooking.Service.Helpers;
using HotelBooking.Service.Interfaces;

namespace HotelBooking.Service.Services;

public class RoomService : IRoomService
{
    private readonly IGenericRepository<Room> roomRepository;
    public RoomService()
    {
        roomRepository = new GenericRepository<Room>();
    }
    public async Task<GenericResponse<Room>> CreateAsync(Room room)
    {
        var models = await this.roomRepository.GetAllAsync();
        var model = models.FirstOrDefault(x => x.Id == room.Id);

        if (model is not null)
        {
            return new GenericResponse<Room>
            {
                StatusCode = 404,
                Message = "This category is already exists",
                Value = null,
            };
        }
        var mappedModel = new Room()
        {
            Id= room.Id,
            Price= room.Price,
            Status= room.Status,
            Type= room.Type,
            Capacity= room.Capacity,
            Desription= room.Desription,
            CreatedAt = DateTime.UtcNow,
            
        };
        await roomRepository.CreateAsync(mappedModel);

        return new GenericResponse<Room>
        {
            StatusCode = 200,
            Message = "New category created",
            Value = mappedModel
        };
    }

    public async Task<GenericResponse<Room>> DeleteAsync(long id)
    {
        var model = await this.roomRepository.GetByIdAsync(id);
        if (model is null)
        {
            return new GenericResponse<Room>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null
            };
        }
        await this.roomRepository.DeleteAsync(model.Id);

        return new GenericResponse<Room>
        {
            StatusCode = 200,
            Message = "Successfully deleted )",
            Value = model,
        };
    }

    public async Task<GenericResponse<List<Room>>> GetAllAsync(Predicate<Room> predicate)
    {
        var models = await roomRepository.GetAllAsync(predicate);
        if (models is null)
        {
            return new GenericResponse<List<Room>>
            {
                StatusCode = 404,
                Message = "Empty",
                Value = null,
            };
        }
        return new GenericResponse<List<Room>>
        {
            StatusCode = 200,
            Message = "Ok )",
            Value = models
        };
    }

    public async Task<GenericResponse<Room>> GetByIdAsync(long id)
    {
        var model = await this.roomRepository.GetByIdAsync(id);

        if (model is null)
        {
            return new GenericResponse<Room>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null,
            };
        }

        return new GenericResponse<Room>
        {
            StatusCode = 200,
            Message = "Ok )",
            Value = model,

        };
    }

    public async Task<GenericResponse<Room>> UpdateAsync(long id, Room room)
    {
        var model = await this.roomRepository.GetByIdAsync(id);

        if (model is null)
        {
            return new GenericResponse<Room>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null,
            };
        }

        var mappedmodel = new Room()
        {
            
            CreatedAt = room.CreatedAt,
            UpdatedAt = DateTime.UtcNow,
            Id = room.Id,
            Price = room.Price,
            Status = room.Status,
            Type = room.Type,
            Capacity = room.Capacity,
            Desription = room.Desription,
            
        };
            
        var res = await this.roomRepository.UpdateAsync(mappedmodel);

        return new GenericResponse<Room>
        {
            StatusCode = 200,
            Message = "Successfully updated )",
            Value = mappedmodel,
        };
    }
}
            



