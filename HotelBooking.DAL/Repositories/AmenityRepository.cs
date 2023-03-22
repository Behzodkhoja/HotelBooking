using HotelBooking.DAL.Configurations;
using HotelBooking.DAL.IRepositories;
using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HotelBooking.DAL.Repositories;

public class AmenityRepository : IAmenityRepository
{
    private readonly AppDbContext appDbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAmenityAsync(int id)
    {
        Amenity entity =
        await this.appDbContext.Amenities.FirstOrDefaultAsync(amenity => amenity.Id.Equals(id));
        if (entity is null)
            return false;

        this.appDbContext.Amenities.Remove(entity);
        await this.appDbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<Amenity> InsertAmenityAsync(Amenity amenity)
    {
        EntityEntry<Amenity> entity = await this.appDbContext.Amenities.AddAsync(amenity);
        await appDbContext.SaveChangesAsync();
        return entity.Entity;   
    }
    public async ValueTask<Amenity> UpdateAmenityAsync(Amenity amenity)
    {
        EntityEntry<Amenity> entity = this.appDbContext.Amenities.Update(amenity);
        await appDbContext.SaveChangesAsync();
        return entity.Entity;
    }
    public IQueryable<Amenity> SelectAllAsync() =>
        this.appDbContext.Amenities.Where(amenity => amenity.IsActive);
   
    public async ValueTask<Amenity> SelectAmenityAsync(Predicate<Amenity> predicate) =>
    await this.appDbContext.Amenities.Where(wallet => wallet.IsActive).FirstOrDefaultAsync(amenity => predicate(amenity));
}



