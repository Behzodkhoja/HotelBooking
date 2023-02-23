using HotelBooking.Domain.Common;

namespace HotelBooking.Domain.Entities;

public class User : Auditable
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string CardNumber { get; set; }
    public decimal CardMoney { get; set; }
}
