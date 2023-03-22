using AutoMapper;
using HotelBooking.DAL.IRepositories;
using HotelBooking.DAL.Repositories;
using HotelBooking.Domain.Entities;
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
        private readonly IHotelRepository hotelRepository = new HotelRepository();
        private readonly IMapper mapper;
        public HotelService()
        {

        }
        public HotelService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public async ValueTask<Response<HotelDto>> AddHotelAsync(HotelDto hotelDto)
        {
            var hotel = hotelRepository.SelectAllAsync()
            .FirstOrDefault(x => x.Name.ToLower() == hotelDto.Name.ToLower());
            if (hotel is null)
            {
                var newhotel = mapper.Map<Hotel>(hotelDto);
                var newResult = await hotelRepository.InsertHotelAsync(newhotel);
                var mappedHotel = mapper.Map<HotelDto>(newResult);

                return new Response<HotelDto>()
                {
                    StatusCode = 200,
                    Message = "Success",
                    Value = mappedHotel
                };
            }
            return new Response<HotelDto>()
            {
                StatusCode = 403,
                Message = "Category is alredy exists!",
                Value = null
            };
        }

        public async ValueTask<Response<bool>> DeleteHotelAsync(int id)
        {
            var category = await hotelRepository.SelectHotelAsync(id);
            if (category is null)
            {
                return new Response<bool>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = false
                };
            }
            await hotelRepository.DeleteHotelAsync(id);
            return new Response<bool>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = true
            };
        }

        public async ValueTask<Response<List<HotelDto>>> GetAllHotelAsync()
        {
            var hotel = hotelRepository.SelectAllAsync();
            var mappedHotel = mapper.Map<List<HotelDto>>(hotel);
            return new Response<List<HotelDto>>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = mappedHotel
            };
        }

        public async ValueTask<Response<HotelDto>> GetHotelByIdAsync(int id)
        {
            var hotel = await hotelRepository.SelectHotelAsync(id);
            if (hotel is null)
            {
                return new Response<HotelDto>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = null
                };
            }
            var mappedhotel = mapper.Map<HotelDto>(hotel);
            return new Response<HotelDto>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = mappedhotel
            };
        }

        public async ValueTask<Response<HotelDto>> ModifyHotelAsync(int id, HotelDto hotelDto)
        {
            var hotel = await hotelRepository.SelectHotelAsync(id);
            if (hotel is null)
            {
                return new Response<HotelDto>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = null
                };
            }
            hotel.Name = hotelDto.Name;
            hotel.Street = hotelDto.Street;
            hotel.City = hotelDto.City;
            hotel.Country = hotelDto.Country;
            hotel.UpdatedAt = DateTime.Now;
            hotel.Phone = hotelDto.Phone;
            


            await hotelRepository.UpdateHotelAsync(hotel);
            var mappedAmenity = mapper.Map<HotelDto>(hotel);

            return new Response<HotelDto>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = mappedAmenity
            };
        }
    }
}
