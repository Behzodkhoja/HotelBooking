

namespace HotelBooking.Domain.Entities;

public class RoomsAmenity
{
    public long Id { get; set; }
    public Room Room { get; set; }
    public Amenity Amenity { get; set; }
}
