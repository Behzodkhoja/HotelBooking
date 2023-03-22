using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Service.DTOs
{
    public class UserDto
    {
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }

        
        public static explicit operator UserDto(User user)
        {
            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                Role = user.Role,
            };
        }



    }
}
