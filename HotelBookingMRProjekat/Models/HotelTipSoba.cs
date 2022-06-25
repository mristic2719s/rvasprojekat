using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelBookingMRProjekat.Models
{
    public class HotelTipSoba
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Naziv tipa sobe je neophodan!")]
        [Display(Name = "Naziv tipa sobe")]
        public string NazivTipaSobe { get; set; }
        [Required(ErrorMessage = "Pansion tipa sobe je neophodan!")]
        [Display(Name = "Pansion tipa sobe")]
        public string PansionTipaSobe { get; set; }

    }
}