using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class TipClanstva
    {
        public byte Id { get; set; }
        public short Clanarina { get; set; }
        public byte TrajanjeMjeseci { get; set; }
        public byte Popust { get; set; }
        public string Naziv { get; set; }
    }
}