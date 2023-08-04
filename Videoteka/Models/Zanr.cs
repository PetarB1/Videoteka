using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class Zanr
    {
        public byte Id { get; set; }
        [StringLength(100)]
       
        public string Ime { get; set; }
    }
}