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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();

        public async ValueTask<bool> DeleteUserAsync(int id)
        {
            User entity =
                await this.appDbContext.Users.FirstOrDefaultAsync(user => user.Id.Equals(id));
            if (entity is null)
                return false;

            this.appDbContext.Users.Remove(entity);
            await this.appDbContext.SaveChangesAsync();
            return true;
        }

        public async ValueTask<User> InsertUserAsync(User user)
        {
            EntityEntry<User> entity = await this.appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public IQueryable<User> SelectAllAsync() =>
             this.appDbContext.Users.Where(user => user.IsActive);



        public async ValueTask<User> SelectUserAsync(Predicate<User> predicate) =>
             await this.appDbContext.Users.Where(user => user.IsActive).FirstOrDefaultAsync(user => predicate(user));

        public async ValueTask<User> UpdateUserAsync(User user)
        {
            EntityEntry<User> entity = this.appDbContext.Users.Update(user);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }
    }   
}
