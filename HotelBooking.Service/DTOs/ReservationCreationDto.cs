using HotelBooking.Domain.Entities;

namespace HotelBooking.Service.DTOs;

public class ReservationCreationDto
{
    public User User { get; set; }
    public Room Room { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Note { get; set; }
    public decimal Payment { get; set; }
    public string PaymentType { get; set; }
    public string Status { get; set; }
    public DateTime ChackIn { get; set; }
    public DateTime ChackOut { get; set; }
}

