using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VIdly.Dtos;
using VIdly.Models;

namespace VIdly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>()
                          .ForMember(c => c.id, opt => opt.Ignore());
            Mapper.CreateMap<MembershipType, MembershipTypeDto>(); 

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>()
                          .ForMember(m => m.id, opt => opt.Ignore());
            Mapper.CreateMap<Genre, GenreDto>();


        }
    }
}