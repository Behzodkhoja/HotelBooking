using HotelBooking.DAL.IRepositories;
using HotelBooking.DAL.Repositories;
using HotelBooking.Domain.Entities;
using HotelBooking.Service.Helpers;
using HotelBooking.Service.Interfaces;

namespace HotelBooking.Service.Services;

public class UserService : IUserService
{
    private readonly IGenericRepository<User> userRepository;
    public UserService()
    {
        userRepository = new GenericRepository<User>();
    }
    public async Task<GenericResponse<User>> CreateAsync(User user)
    {
        var models = await this.userRepository.GetAllAsync();
        var model = models.FirstOrDefault(x => x.UserName == user.UserName);

        if (model is not null)
        {
            return new GenericResponse<User>
            {
                StatusCode = 404,
                Message = "This category is already exists",
                Value = null,
            };
        }
        var mappedModel = new User()
        {
            
            CreatedAt = DateTime.UtcNow,
            UserName= user.UserName,
            CardMoney= user.CardMoney,
            CardNumber= user.CardNumber,
            Password= user.Password,
            Role = user.Role,

        };
        await userRepository.CreateAsync(mappedModel);

        return new GenericResponse<User>
        {
            StatusCode = 200,
            Message = "New category created",
            Value = mappedModel
        };
    }

    public async Task<GenericResponse<User>> DeleteAsync(long id)
    {
        var model = await this.userRepository.GetByIdAsync(id);
        if (model is null)
        {
            return new GenericResponse<User>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null
            };
        }
        await this.userRepository.DeleteAsync(model.Id);

        return new GenericResponse<User>
        {
            StatusCode = 200,
            Message = "Successfully deleted )",
            Value = model,
        };
    }

    public async Task<GenericResponse<List<User>>> GetAllAsync(Predicate<User> predicate)
    {
        var models = await userRepository.GetAllAsync(predicate);
        if (models is null)
        {
            return new GenericResponse<List<User>>
            {
                StatusCode = 404,
                Message = "Empty",
                Value = null,
            };
        }
        return new GenericResponse<List<User>>
        {
            StatusCode = 200,
            Message = "Ok )",
            Value = models
        };
    }

    public async Task<GenericResponse<User>> GetByIdAsync(long id)
    {
        var model = await this.userRepository.GetByIdAsync(id);

        if (model is null)
        {
            return new GenericResponse<User>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null,
            };
        }

        return new GenericResponse<User>
        {
            StatusCode = 200,
            Message = "Ok )",
            Value = model,

        };
    }

    public async Task<GenericResponse<User>> UpdateAsync(long id, User user)
    {
        var model = await this.userRepository.GetByIdAsync(id);

        if (model is null)
        {
            return new GenericResponse<User>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null,
            };
        }

        var mappedmodel = new User()
        {
            CreatedAt = DateTime.UtcNow,
            UserName = user.UserName,
            CardMoney = user.CardMoney,
            CardNumber = user.CardNumber,
            Password = user.Password,
            Role = user.Role,
            UpdatedAt = DateTime.UtcNow,
            Id = user.Id,
        };
            
        var res = await this.userRepository.UpdateAsync(mappedmodel);

        return new GenericResponse<User>
        {
            StatusCode = 200,
            Message = "Successfully updated )",
            Value = mappedmodel,
        };

    }
}



