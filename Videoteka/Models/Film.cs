using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Unesite ime filma.")]
        public string Ime { get; set; }
        public Zanr Zanr { get; set; }

        [Display(Name = "Zanr")]
        [Required(ErrorMessage = "Unesite zanr.")]
        public byte ZanrId { get; set; }

        [Required(ErrorMessage = "Unesite datum unosa.")]
        public DateTime DatumUnosa { get; set; }

        [Required(ErrorMessage = "Unesite datum izdanja.")]
        public DateTime DatumIzdanja { get; set; }

        [Required(ErrorMessage = "Unesite broj na stanju.")]
        public int BrojNaStanju { get; set; }

        [Required(ErrorMessage = "Unesite broj dostupnih filmova.")]
        public int BrojDostupnih { get; set; }
    }
}