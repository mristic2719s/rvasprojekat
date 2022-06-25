using HotelBookingMRProjekat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelBookingMRProjekat.Dtos
{
    public class HotelSobaDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Naziv sobe je neophodan!")]
        [StringLength(255)]
        public string NazivSobe { get; set; }

        [Required(ErrorMessage = "Cena po danu je neophodna!")]
        public decimal CenaPoDanu { get; set; }

        [Required(ErrorMessage = "Tip sobe je neophodan!")]
        public int HotelTipSobaID { get; set; }

        public HotelTipSobaDto HotelTipSoba { get; set; }

    }
}