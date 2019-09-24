using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppMovie.Dtos;
using WebAppMovie.Models;

namespace WebAppMovie.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to DTO
            Mapper.CreateMap<Customer, CustomerDto>();


            // DTO to Domain
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}