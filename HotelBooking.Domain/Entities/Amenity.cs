

using HotelBooking.Domain.Common;

namespace HotelBooking.Domain.Entities;

public class Amenity:Auditable
{
    public long Id { get; set; }
    public string Name { get; set; }
}
