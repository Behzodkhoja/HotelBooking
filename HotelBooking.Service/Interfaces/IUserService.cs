using HotelBooking.Domain.Entities;
using HotelBooking.Service.Helpers;

namespace HotelBooking.Service.Interfaces;

public interface IUserService
{
    Task<GenericResponse<User>> CreateAsync(User user);
    Task<GenericResponse<User>> UpdateAsync(long id, User user);
    Task<GenericResponse<User>> DeleteAsync(long id);
    Task<GenericResponse<List<User>>> GetAllAsync(Predicate<User> predicate);
    Task<GenericResponse<User>> GetByIdAsync(long id);
}


