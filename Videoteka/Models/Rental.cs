using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class Rental
    {
        public int Id { get; set; }
        [Required]
        public  Kupac Kupac { get; set; }
        [Required]
        public Film Film { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}