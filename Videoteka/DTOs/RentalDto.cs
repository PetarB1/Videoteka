using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videoteka.DTOs
{
    public class RentalDto
    {
        public  int  KupacId { get; set; }
        public  List<int> FilmIds { get; set; }
    }
}