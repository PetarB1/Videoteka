using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videoteka.Models;

namespace Videoteka.ViewModels
{
    public class KupacViewModel
    {
        public IEnumerable<TipClanstva> TipClanstvas { get; set; }
        public Kupac Kupac { get; set; }
        public IEnumerable<TipKupca> TipKupcas  { get; set; }
    }
}