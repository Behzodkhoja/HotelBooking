using HotelBooking.DAL.Configurations;
using HotelBooking.DAL.IRepositories;
using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace HotelBooking.DAL.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly AppDbContext appDbContext = new AppDbContext();
    public async ValueTask<bool> DeleteHotelAsync(int id)
    {
        Hotel entity =
        await this.appDbContext.Hotels.FirstOrDefaultAsync(hotel => hotel.Id.Equals(id));
        if (entity is null)
            return false;

        this.appDbContext.Hotels.Remove(entity);
        await this.appDbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<Hotel> InsertHotelAsync(Hotel hotel)
    {
        EntityEntry<Hotel> entity = await this.appDbContext.Hotels.AddAsync(hotel);
        await appDbContext.SaveChangesAsync();
        return entity.Entity;
    }

    public IQueryable<Hotel> SelectAllAsync() =>
      this.appDbContext.Hotels.Where(hotel => hotel.IsActive);

    public async ValueTask<Hotel> SelectHotelAsync(Predicate<Hotel> predicate) =>
        await this.appDbContext.Hotels.Where(hotel => hotel.IsActive).FirstOrDefaultAsync(hotel => predicate(hotel));

    public async ValueTask<Hotel> SelectHotelAsync(int id) =>
        await appDbContext.Hotels.FirstOrDefaultAsync(s => s.Id.Equals(id));

    public async ValueTask<Hotel> UpdateHotelAsync(Hotel hotel)
    {
        EntityEntry<Hotel> entity = this.appDbContext.Hotels.Update(hotel);
        await appDbContext.SaveChangesAsync();
        return entity.Entity;
    }
}
