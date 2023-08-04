using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videoteka.DTOs;
using Videoteka.Models;

namespace Videoteka.App_Start
{
    public class MappingProfile: Profile
    {

        public MappingProfile() {

            Mapper.CreateMap<Kupac, KupacDto>();
            Mapper.CreateMap<KupacDto, Kupac>();
            Mapper.CreateMap<Film, FilmDto>();
            Mapper.CreateMap<FilmDto, Film>();
        }

    }
}