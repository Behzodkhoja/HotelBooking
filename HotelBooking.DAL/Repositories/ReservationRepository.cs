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
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();
        public async ValueTask<bool> DeleteReservationAsync(int id)
        {
            Reservation entity =
                await this.appDbContext.Reservations.FirstOrDefaultAsync(reservation => reservation.Id.Equals(id));
            if (entity is null)
                return false;

            this.appDbContext.Reservations.Remove(entity);
            await this.appDbContext.SaveChangesAsync();
            return true;
        }

        public async ValueTask<Reservation> InsertReservationAsync(Reservation reservation)
        {
            EntityEntry<Reservation> entity = await this.appDbContext.Reservations.AddAsync(reservation);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public IQueryable<Reservation> SelectAllAsync() =>
            this.appDbContext.Reservations.Where(reservation => reservation.IsActive);

        public async ValueTask<Reservation> SelectReservationAsync(Predicate<Reservation> predicate) =>
             await this.appDbContext.Reservations.Where(reservation => reservation.IsActive).FirstOrDefaultAsync(reservation => predicate(reservation));

        public async ValueTask<Reservation> UpdateReservationAsync(Reservation reservation)
        {
            EntityEntry<Reservation> entity = this.appDbContext.Reservations.Update(reservation);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }
    }
}
