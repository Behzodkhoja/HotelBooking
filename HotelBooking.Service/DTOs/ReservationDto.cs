using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Service.DTOs
{
    public class ReservationDto
    {
        public User User { get; set; }
        public Room Room { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Payment { get; set; }
        public string PaymentType { get; set; }
        public DateTime ChackIn { get; set; }
        public DateTime ChackOut { get; set; }
    }
}
       
       
