using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DAL.IRepositories
{
    public interface IUserRepository
    {
        ValueTask<User> InsertUserAsync(User user);
        ValueTask<User> UpdateUserAsync(User user);
        ValueTask<bool> DeleteUserAsync(int id);
        ValueTask<User> SelectUserAsync(int id);
        IQueryable<User> SelectAllAsync();
    }
}
