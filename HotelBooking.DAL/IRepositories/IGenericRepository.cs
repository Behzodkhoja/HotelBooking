
using HotelBooking.Domain.Entities;

namespace HotelBooking.DAL.IRepositories;


public interface IGenericRepository<TResult>
{
    Task<TResult> CreateAsync(TResult value);
    Task<TResult> UpdateAsync( TResult value);
    Task<bool> DeleteAsync(long id);
    Task<TResult> GetByIdAsync(long id);
    //Task<List<TResult>> GetAllAsync(Predicate<Domain.Entities.Amenity> predicate);
    Task<List<TResult>> GetAllAsync(Predicate<TResult> predicate  = null);
    
}
