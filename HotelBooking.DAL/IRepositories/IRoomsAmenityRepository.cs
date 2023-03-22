using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DAL.IRepositories
{
    public interface IRoomsAmenityRepository
    {
        ValueTask<RoomsAmenity> InsertRoomsAmenityAsync(RoomsAmenity roomsAmenity);
        ValueTask<RoomsAmenity> UpdateRoomsAmenityAsync(RoomsAmenity roomsAmenity);
        ValueTask<bool> DeleteRoomsAmenityAsync(int id);
        ValueTask<RoomsAmenity> SelectRoomsAmenityAsync(Predicate<RoomsAmenity> roomsAmenity);
        IQueryable<RoomsAmenity> SelectAllAsync();
    }
}
