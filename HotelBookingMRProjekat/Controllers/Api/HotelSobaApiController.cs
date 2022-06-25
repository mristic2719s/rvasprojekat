using AutoMapper;
using HotelBookingMRProjekat.Dtos;
using HotelBookingMRProjekat.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelBookingMRProjekat.Controllers.Api
{
    public class HotelSobaApiController : ApiController
    {
        private ApplicationDbContext _context;

        public HotelSobaApiController()
        {
            _context = new ApplicationDbContext();
        }

        // Putanja GET /api/hotelsobaapi
        public IHttpActionResult GetHotelSobas()
        {
            var hotelSobaDtos = _context.HotelSobaBaza.Include(c => c.HotelTipSoba).ToList().Select(Mapper.Map<HotelSoba, HotelSobaDto>);

            return Ok(hotelSobaDtos);

        }

        // Get /api/hotelsobe/1
        [HttpGet]
        public IHttpActionResult GetHotelSoba(int id)
        {
            var hotelsoba = _context.HotelSobaBaza.SingleOrDefault(c => c.Id == id);

            if (hotelsoba == null)
                return NotFound();

            return Ok(Mapper.Map<HotelSoba, HotelSobaDto>(hotelsoba));
        }

        // Kreiranje hotel sobe /api/hotelsobe POST
        [HttpPost]
        public IHttpActionResult NapraviHotelSobu(HotelSobaDto hotelSobaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

      
            else
            {
                var hotelSoba = Mapper.Map<HotelSobaDto, HotelSoba>(hotelSobaDto);

                _context.HotelSobaBaza.Add(hotelSoba);
                _context.SaveChanges();

                hotelSobaDto.Id = hotelSoba.Id;

                return Created(new Uri(Request.RequestUri + "/" + hotelSoba.Id), hotelSobaDto);
            }
        }


        // Update hotel soba /api/hotelsobe/1
        [HttpPut]
        public void UpdateHotelSoba(int id, HotelSobaDto hotelSobaDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
        
                var hotelSobaInDb = _context.HotelSobaBaza.SingleOrDefault(c => c.Id == id);

                if(hotelSobaInDb == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                

                Mapper.Map(hotelSobaDto, hotelSobaInDb);
                

                _context.SaveChanges();
            
        }

        //Delete /api/hotelsobe/1
        [HttpDelete]
        public void DeleteHotelSoba(int id)
        {
            var hotelSobaInDb = _context.HotelSobaBaza.SingleOrDefault(c => c.Id == id);

            if (hotelSobaInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.HotelSobaBaza.Remove(hotelSobaInDb);
            _context.SaveChanges();


        }

    }
}
