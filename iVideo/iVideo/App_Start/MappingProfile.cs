﻿using AutoMapper;
using iVideo.Dtos;
using iVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iVideo.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerEditDto>();
            Mapper.CreateMap<CustomerEditDto, Customer>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<Rental, RentalDto>();
        }
    }
}