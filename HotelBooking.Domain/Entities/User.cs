﻿using HotelBooking.Domain.Common;

namespace HotelBooking.Domain.Entities;

public class User : Auditable
{
    public int FirstName { get; set; }
    public int LastName { get; set; }
    public string Username { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string CardNumber { get; set; }
    public decimal CardMoney { get; set; }
}
