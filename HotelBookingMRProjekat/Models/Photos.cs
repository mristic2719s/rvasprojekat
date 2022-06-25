using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelBookingMRProjekat.Models
{
    public class Photos
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Naziv fotografije je neophodan!")]
        [Display(Name = "Naziv fotografije")]
        public string Name { get; set; }

        public string ContentType { get; set; }
        public byte[] Data { get; set; }

        [Required(ErrorMessage = "Soba je neophodna!")]
        [Display(Name = "Hotel soba")]
        public int HotelSobaId { get; set; }

        public HotelSoba HotelSoba { get; set; }

    }
}