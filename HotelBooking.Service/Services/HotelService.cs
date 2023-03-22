using HotelBooking.Service.DTOs;
using HotelBooking.Service.Helpers;
using HotelBooking.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Service.Services
{
    public class HotelService : IHotelService
    {
        public ValueTask<Response<HotelDto>> AddHotelAsync(HotelForCreationDto hotelForCreationDto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Response<bool>> DeleteHotelAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Response<List<HotelDto>>> GetAllHotelAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Response<HotelDto>> GetHotelByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Response<HotelDto>> ModifyHotelAsync(int id, HotelForCreationDto hotelForCreationDto)
        {
            throw new NotImplementedException();
        }
    }
}
