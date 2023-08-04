using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class Kupac
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Unesite ime kupca.")]
        public string Ime { get; set; }
        public bool PrimaObavjestenja { get; set; }

        [Display(Name ="Datum rodjenja")]
        [Required(ErrorMessage = "Unesite datum rođenja.")]
        public DateTime DatumRodjenja { get; set; }
        [Display(Name = "Tip clanstva")]
        public TipClanstva TipClanstva { get; set; }

        [Required(ErrorMessage = "Unesite tip članstva.")]
        [Display(Name ="Tip clanstva")]
        public byte TipClanstvaId { get; set; }

        public TipKupca TipKupca { get; set; }

        [Display(Name = "Tip kupca")]
        [Required(ErrorMessage = "Unesite tip kupca.")]
        public byte TipKupcaId { get; set; }
    }
}