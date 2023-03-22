using HotelBooking.DAL.Configurations;
using HotelBooking.DAL.IRepositories;
using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DAL.Repositories
{
    public class RoomsAmenityRepository : IRoomsAmenityRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();
        public async ValueTask<bool> DeleteRoomsAmenityAsync(int id)
        {
            RoomsAmenity entity =
                 await this.appDbContext.RoomsAmenities.FirstOrDefaultAsync(roomsAmenity => roomsAmenity.Id.Equals(id));
            if (entity is null)
                return false;

            this.appDbContext.RoomsAmenities.Remove(entity);
            await this.appDbContext.SaveChangesAsync();
            return true;
        }

        public async ValueTask<RoomsAmenity> InsertRoomsAmenityAsync(RoomsAmenity roomsAmenity)
        {
            EntityEntry<RoomsAmenity> entity = await this.appDbContext.RoomsAmenities.AddAsync(roomsAmenity);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public IQueryable<RoomsAmenity> SelectAllAsync() =>
            this.appDbContext.RoomsAmenities.Where(roomsAmenity => roomsAmenity.IsActive);

        public async ValueTask<RoomsAmenity> SelectRoomsAmenityAsync(Predicate<RoomsAmenity> predicate) =>
           await this.appDbContext.RoomsAmenities.Where(roomsAmenity => roomsAmenity.IsActive).FirstOrDefaultAsync(reservation => predicate(reservation));


        public async ValueTask<RoomsAmenity> UpdateRoomsAmenityAsync(RoomsAmenity roomsAmenity)
        {
            EntityEntry<RoomsAmenity> entity = this.appDbContext.RoomsAmenities.Update(roomsAmenity);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }
    }
}
