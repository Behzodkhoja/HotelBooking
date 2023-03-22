using HotelBooking.Domain.Entities;
using HotelBooking.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Service.Interfaces
{
    public interface IUserDataService
    {
        Task<Response<UserData>> SearchUserAsync(String type);
    }
}
