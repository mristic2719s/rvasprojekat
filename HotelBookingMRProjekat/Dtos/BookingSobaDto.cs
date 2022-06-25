using HotelBookingMRProjekat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelBookingMRProjekat.Dtos
{
    public class BookingSobaDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Datum ostajanja Od je neophodan!")]
        public DateTime OstajanjeOd { get; set; }


        [Required(ErrorMessage = "Datum ostajanja Do je neophodan!")]
        public DateTime OstajanjeDo { get; set; }


        [Required(ErrorMessage = "Gost je neophodan!")]
        public string ApplicationUserId { get; set; }

        [Required(ErrorMessage = "Hotel soba je neophodna!")]
        public int HotelSobaId { get; set; }

        public HotelSoba HotelSoba { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}