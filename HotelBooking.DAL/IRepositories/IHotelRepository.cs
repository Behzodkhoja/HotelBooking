using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DAL.IRepositories
{
    public interface IHotelRepository
    {
        ValueTask<Hotel> InsertHotelAsync(Hotel hotel);
        ValueTask<Hotel> UpdateHotelAsync(Hotel hotel);
        ValueTask<bool> DeleteHotelAsync(int id);
        ValueTask<Hotel> SelectHotelAsync(Predicate<Hotel> hotel);
        IQueryable<Hotel> SelectAllAsync();
    }
}
