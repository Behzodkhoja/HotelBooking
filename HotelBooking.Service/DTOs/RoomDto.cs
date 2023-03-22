using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Service.DTOs
{
    public class RoomDto
    {
        public Hotel Hotel { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public string Desription { get; set; }
    }
}
