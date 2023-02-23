using HotelBooking.Domain.Entities;
using HotelBooking.Service.Helpers;

namespace HotelBooking.Service.Interfaces;

public interface IAmenityService
{
    Task<GenericResponse<Amenity>> CreateAsync(Amenity amenity);
    Task <GenericResponse<Amenity>> UpdateAsync(long id,Amenity amenity);
    Task <GenericResponse<Amenity>> DeleteAsync(long id);
    Task<GenericResponse<List<Amenity>>> GetAllAsync(Predicate<Amenity> predicate);
    Task<GenericResponse<Amenity>> GetByIdAsync(long id);
}




