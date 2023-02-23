using HotelBooking.Domain.Common;

namespace HotelBooking.Domain.Entities;

public class Hotel : Auditable
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Phone { get; set; }
}


