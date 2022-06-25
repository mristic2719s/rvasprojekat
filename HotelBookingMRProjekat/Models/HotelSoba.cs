using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelBookingMRProjekat.Models
{
    public class HotelSoba
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Naziv sobe je neophodan!")]
        [StringLength(255)]
        [Display(Name = "Naziv sobe")]
        public string NazivSobe { get; set; }

        [Required(ErrorMessage = "Cena po danu je neophodna!")]
        [Display(Name = "Cena po danu")]
        public decimal CenaPoDanu  { get; set; }

        [Required(ErrorMessage = "Tip sobe je neophodan!")]
        [Display(Name = "Tip sobe")]
        public int HotelTipSobaID { get; set; }

        public HotelTipSoba HotelTipSoba { get; set; }




    }
}