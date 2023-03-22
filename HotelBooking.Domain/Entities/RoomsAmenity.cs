

using HotelBooking.Domain.Common;

namespace HotelBooking.Domain.Entities;

public class RoomsAmenity:Auditable
{
    public long Id { get; set; }
    public Room Room { get; set; }
    public Amenity Amenity { get; set; }
}
