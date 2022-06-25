using HotelBookingMRProjekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBookingMRProjekat.ViewModels
{
    public class HotelBookingSobaViewModel
    {
        public BookingSoba BookingSoba { get; set; }
        public List<BookingSoba> Bookingi { get; set; }
        public IQueryable<BookingSoba> BookingiKorisnici { get; set; }
        public string UserId { get; set; }
        public List<HotelSoba> HotelSobe { get; set; }
        public List<ApplicationUser> ApplicationUseri { get; set; }
        public IQueryable<ApplicationUser> ApplicationUseriLinq { get; set; }
        public ApplicationUser Korisnik { get; set; }
    }
}