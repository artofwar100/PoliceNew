using AutoMapper;
using PoliceNew.Data.Entites;
using PoliceNew.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliceNew.AutoMapper
{
    public class OfficerProfil : Profile
    {
        public OfficerProfil()
        {
            CreateMap<Officers, OfficerDto>().ReverseMap();
            CreateMap<Officers, OfficerEditCreateDto>().ReverseMap();
        }
    }
}
