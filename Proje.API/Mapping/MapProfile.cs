using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje.API.DTOs;
using Proje.Core.Models;
using Proje.Core.Auth;

namespace Proje.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Kullanici, KullaniciDto>();
            CreateMap<KullaniciDto, Kullanici>();
            CreateMap<UserSignUpDto, Kullanici>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.eposta)); 
          
            CreateMap<Stok,StokDto>();
            CreateMap<StokDto,Stok>();

            CreateMap<Cari,CariDto>();
            CreateMap<CariDto,Cari>();

        }
    }
}