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
    public class ReservationService : IReservationService
    {
        public ValueTask<Response<ReservationDto>> AddReservationAsync(ReservationForCreationDto reservationForCreationDto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Response<bool>> DeleteReservationAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Response<List<ReservationDto>>> GetAllReservationAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Response<ReservationDto>> GetReservationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Response<ReservationDto>> ModifyReservationAsync(int id, ReservationForCreationDto reservationForCreationDto)
        {
            throw new NotImplementedException();
        }
    }
}
