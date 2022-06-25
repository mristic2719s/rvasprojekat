using HotelBookingMRProjekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBookingMRProjekat.ViewModels
{
    public class PhotosViewModel
    {
        public HotelSoba HotelSoba { get; set; }
        public Photos Photo { get; set; }
        public IEnumerable<Photos> Photos { get; set; }
        public List<HotelSoba> HotelSobe { get; set; }
    }
}