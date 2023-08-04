using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Videoteka.Models;

namespace Videoteka.DTOs
{
    public class KupacDto
    {

        public int Id { get; set; }
        public string Ime { get; set; }
        public bool PrimaObavjestenja { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public byte TipClanstvaId { get; set; }
        public byte TipKupcaId { get; set; }
    }
}