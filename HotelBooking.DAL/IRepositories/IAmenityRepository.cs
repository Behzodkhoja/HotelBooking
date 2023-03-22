using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DAL.IRepositories
{
    public interface IAmenityRepository
    {
        ValueTask<Amenity> InsertAmenityAsync(Amenity amenity);
        ValueTask<Amenity> UpdateAmenityAsync(Amenity amenity);
        ValueTask<bool> DeleteAmenityAsync(int id);
        ValueTask<Amenity> SelectAmenityAsync(int id);
        IQueryable<Amenity> SelectAllAsync();
    }
}
