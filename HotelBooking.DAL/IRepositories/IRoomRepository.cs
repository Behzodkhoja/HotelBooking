using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DAL.IRepositories
{
    public interface IRoomRepository
    {
        ValueTask<Room> InsertRoomAsync(Room room);
        ValueTask<Room> UpdateRoomAsync(Room room);
        ValueTask<bool> DeleteRoomAsync(int id);
        ValueTask<Room> SelectRoomAsync(int id);
        IQueryable<Room> SelectAllAsync();
    }
}
