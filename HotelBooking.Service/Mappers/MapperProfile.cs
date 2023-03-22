using AutoMapper;
using HotelBooking.Domain.Entities;
using HotelBooking.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Service.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AmenityForCreationDto, Amenity>().ReverseMap();
            CreateMap<HotelForCreationDto, Hotel>().ReverseMap();
            CreateMap<ReservationForCreationDto, Reservation>().ReverseMap();
            CreateMap<RoomForCreationDto, Room>().ReverseMap();
            CreateMap<UserForCreationDto, User>().ReverseMap();
        }
    }
}

