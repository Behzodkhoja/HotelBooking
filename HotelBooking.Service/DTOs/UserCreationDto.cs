namespace HotelBooking.Service.DTOs;

public class UserCreationDto
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; }
    public string CardNumber { get; set; }
    public decimal CardMoney { get; set; }
}


