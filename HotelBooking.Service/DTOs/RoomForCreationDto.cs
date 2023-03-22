using HotelBooking.Domain.Entities;

namespace HotelBooking.Service.DTOs;

public class RoomForCreationDto
{
    public Hotel Hotel { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public int Capacity { get; set; }
    public string Desription { get; set; }
}


