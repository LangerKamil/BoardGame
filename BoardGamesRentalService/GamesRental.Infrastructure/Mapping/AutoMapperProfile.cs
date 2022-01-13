using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GamesRental.Infrastructure.DTOs;
using GamesRental.Infrastructure.Models;

namespace GamesRental.Infrastructure.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Rental,RentalDTO>();
            CreateMap<Customer,CustomerDTO>();
            CreateMap<Game,GameDTO>();

            CreateMap<RentalDTO, Rental>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<GameDTO, Game>();
        }
    }
}
