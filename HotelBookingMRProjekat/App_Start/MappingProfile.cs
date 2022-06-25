using AutoMapper;
using HotelBookingMRProjekat.Dtos;
using HotelBookingMRProjekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBookingMRProjekat.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            Mapper.CreateMap<HotelSoba, HotelSobaDto>();
            Mapper.CreateMap<HotelSobaDto, HotelSoba>();
            Mapper.CreateMap<HotelTipSoba, HotelTipSobaDto>();
            Mapper.CreateMap<HotelTipSobaDto, HotelTipSoba>();
            Mapper.CreateMap<BookingSoba, BookingSobaDto>();
            Mapper.CreateMap<BookingSobaDto, BookingSoba>();
        }
    }
}