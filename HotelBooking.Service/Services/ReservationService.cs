using AutoMapper;
using HotelBooking.DAL.IRepositories;
using HotelBooking.DAL.Repositories;
using HotelBooking.Domain.Entities;
using HotelBooking.Service.DTOs;
using HotelBooking.Service.Helpers;
using HotelBooking.Service.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Service.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository reservationRepository = new ReservationRepository();
        private readonly IMapper mapper;
        public ReservationService()
        {

        }
        public ReservationService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public async ValueTask<Response<ReservationDto>> AddReservationAsync(ReservationDto reservationDto)
        {
            var reservation = reservationRepository.SelectAllAsync()
            .FirstOrDefault(x => x.User == reservationDto.User);
            if (reservation is null)
            {
                var newhotel = mapper.Map<Reservation>(reservationDto);
                var newResult = await reservationRepository.InsertReservationAsync(newhotel);
                var mappedHotel = mapper.Map<ReservationDto>(newResult);

                return new Response<ReservationDto>()
                {
                    StatusCode = 200,
                    Message = "Success",
                    Value = mappedHotel
                };
            }
            return new Response<ReservationDto>()
            {
                StatusCode = 403,
                Message = "Category is alredy exists!",
                Value = null
            };
        }

        public async ValueTask<Response<bool>> DeleteReservationAsync(int id)
        {
            var reservation = await reservationRepository.SelectReservationAsync(id);
            if (reservation is null)
            {
                return new Response<bool>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = false
                };
            }
            await reservationRepository.DeleteReservationAsync(id);
            return new Response<bool>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = true
            };
        }

        public  async ValueTask<Response<List<ReservationDto>>> GetAllReservationAsync()
        {
            var reservation = reservationRepository.SelectAllAsync();
            var mappedReservation = mapper.Map<List<ReservationDto>>(reservation);
            return new Response<List<ReservationDto>>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = mappedReservation
            };
        }

        public async ValueTask<Response<ReservationDto>> GetReservationByIdAsync(int id)
        {
            var reservation = await reservationRepository.SelectReservationAsync(id);
            if (reservation is null)
            {
                return new Response<ReservationDto>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = null
                };
            }
            var mappedReservation = mapper.Map<ReservationDto>(reservation);
            return new Response<ReservationDto>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = mappedReservation
            };
        }

        public async ValueTask<Response<ReservationDto>> ModifyReservationAsync(int id, ReservationDto reservationDto)
        {
            var reservation = await reservationRepository.SelectReservationAsync(id);
            if (reservation is null)
            {
                return new Response<ReservationDto>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = null
                };
            }
            reservation.LastName = reservationDto.LastName;
            reservation.FirstName = reservationDto.FirstName;
            reservation.Room = reservationDto.Room;
            reservation.Note = reservation.Note;
            reservation.Payment = reservationDto.Payment;
            reservation.PaymentType = reservationDto.PaymentType;
            reservation.User = reservationDto.User;
            reservation.ChackIn = DateTime.Now;
            
            await reservationRepository.UpdateReservationAsync(reservation);
            var mappedReservation = mapper.Map<ReservationDto>(reservation);

            return new Response<ReservationDto>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = mappedReservation
            };
        }
    }
}



