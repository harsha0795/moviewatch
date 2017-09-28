﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using moviewatch.DTO;
using moviewatch.Models;

namespace moviewatch.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieDTO, Movie>();
            Mapper.CreateMap<MemberShip, MemberShipDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();
        }
    }
}