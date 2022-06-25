using AutoMapper;
using HotelBookingMRProjekat.Dtos;
using HotelBookingMRProjekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace HotelBookingMRProjekat.Controllers.Api
{
    public class BookingSobaApiController : ApiController
    {
        private ApplicationDbContext _context;

        public BookingSobaApiController()
        {
            _context = new ApplicationDbContext();
        }

        // Putanja get/api/bookingsobaapi
        public IHttpActionResult GetHotelBookinzi()
        {
            var hotelBookingDtos = _context.BookingBaza.Include(c => c.ApplicationUser).Include(c => c.HotelSoba).ToList().Select(Mapper.Map<BookingSoba, BookingSobaDto>);

            return Ok(hotelBookingDtos);

        }


        // Kreiranje hotel bookinga /api/bookingsobaapi POST
        [HttpPost]
        public IHttpActionResult NapraviHotelBooking(BookingSobaDto hotelBookingSobaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var hotelBooking = Mapper.Map<BookingSobaDto, BookingSoba>(hotelBookingSobaDto);

                _context.BookingBaza.Add(hotelBooking);
                _context.SaveChanges();

                hotelBookingSobaDto.Id = hotelBooking.Id;

                return Ok(hotelBookingSobaDto);
            }
        }

        //Izbrisi /api/bookingsobaapi/1
        [HttpDelete]
        public void IzbrisiHotelBooking(int id)
        {
            var hotelBookingInDb = _context.BookingBaza.SingleOrDefault(c => c.Id == id);

            if (hotelBookingInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.BookingBaza.Remove(hotelBookingInDb);
            _context.SaveChanges();
        }

    }
}
