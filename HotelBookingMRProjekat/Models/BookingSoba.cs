using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelBookingMRProjekat.Models
{
    public class BookingSoba
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Datum ostajanja Od je neophodan!")]
        [Display(Name = "Datum od")]
        public DateTime OstajanjeOd { get; set; }


        [Required(ErrorMessage = "Datum ostajanja Do je neophodan!")]
        [GreaterThan("OstajanjeOd")]
        [Display(Name = "Datum do")]
        public DateTime OstajanjeDo { get; set; }


        [Required(ErrorMessage = "Gost je neophodan!")]
        [Display(Name = "Izaberite gosta")]
        public string ApplicationUserId { get; set; }

        [Required(ErrorMessage = "Hotel soba je neophodna!")]
        [Display(Name = "Izaberite naziv hotel sobe")]
        public int HotelSobaId { get; set; }


        public HotelSoba HotelSoba { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
}