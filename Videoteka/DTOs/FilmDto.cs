using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Videoteka.Models;

namespace Videoteka.DTOs
{
    public class FilmDto
    {

        public int Id { get; set; }

        public string Ime { get; set; }

        public byte ZanrId { get; set; }

        public DateTime DatumUnosa { get; set; }

        public DateTime DatumIzdanja { get; set; }

        public int BrojNaStanju { get; set; }

        public int BrojDostupnih { get; set; }
    }
}