using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DAL.Configurations
{
    public class AppDbContext:DbContext
    {
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomsAmenity> RoomsAmenities { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            string path = "Server = (localdb)\\MSSQLLocalDB;" +
                          "Database = HotelBooking" +
                          "Trusted_Connection = True";
            optionsBuilder.UseSqlServer(path);
        }
    }
}


