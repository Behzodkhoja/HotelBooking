using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DAL.IRepositories
{
    public interface IReservationRepository
    {
        ValueTask<Reservation> InsertReservationAsync(Reservation reservation);
        ValueTask<Reservation> UpdateReservationAsync(Reservation reservation);
        ValueTask<bool> DeleteReservationAsync(int id);
        ValueTask<Reservation> SelectReservationAsync(int id);
        IQueryable<Reservation> SelectAllAsync();
    }
}
