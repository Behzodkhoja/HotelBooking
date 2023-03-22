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
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();
        public async ValueTask<bool> DeleteRoomAsync(int id)
        {
            Room entity =
                 await this.appDbContext.Rooms.FirstOrDefaultAsync(rooms => rooms.Id.Equals(id));
            if (entity is null)
                return false;

            this.appDbContext.Rooms.Remove(entity);
            await this.appDbContext.SaveChangesAsync();
            return true;
        }

        public async ValueTask<Room> InsertRoomAsync(Room room)
        {
            EntityEntry<Room> entity = await this.appDbContext.Rooms.AddAsync(room);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public IQueryable<Room> SelectAllAsync() =>
            this.appDbContext.Rooms.Where(rooms => rooms.IsActive);

        public async ValueTask<Room> SelectRoomAsync(Predicate<Room> predicate) =>
            await this.appDbContext.Rooms.Where(rooms => rooms.IsActive).FirstOrDefaultAsync(rooms => predicate(rooms));

        public async ValueTask<Room> UpdateRoomAsync(Room room)
        {
            EntityEntry<Room> entity = this.appDbContext.Rooms.Update(room);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }
    }
}
