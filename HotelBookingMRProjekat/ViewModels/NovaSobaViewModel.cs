using HotelBookingMRProjekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBookingMRProjekat.ViewModels
{
    public class NovaSobaViewModel
    {
        public HotelTipSoba HotelTipSoba { get; set; }
        public IEnumerable<HotelTipSoba> HotelTipSobe { get; set; }
        public HotelSoba HotelSoba { get; set; }
        public List<Photos> FotografijesViewModel { get; set; }
    }
}