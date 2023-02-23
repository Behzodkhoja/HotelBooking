using HotelBooking.Domain.Common;

namespace HotelBooking.Domain.Entities;

public class Room : Auditable
{
    public Hotel Hotel { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public int Capacity { get; set; }
    public string Desription { get; set; }
}


