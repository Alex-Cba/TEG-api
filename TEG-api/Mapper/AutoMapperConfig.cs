using AutoMapper;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using TEG_api.Common.DTOs;
using TEG_api.Common.Models;

namespace TEG_api.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            /* Examples */
            /*
            --SIMPLE

            CreateMap<Person, PersonDTO>().ReverseMap(); 

            --COMPLICATED 1 

            CreateMap<User, UserDetails>()
               .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => RegisterDate))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Organization.Name))
                .ReverseMap(); 

             --COMPLICATED 2

            CreateMap<Organization, OrganizationDTO>()
                 .ForMember(dest => dest.OrganizationContact, opt => opt.MapFrom(src => src.ContactType))
                 .ReverseMap()
                 .ForMember(dest => dest.ContactType, opt => opt.MapFrom(src => src.OrganizationContact));

            -- Suffering is Fun

            CreateMap<BillDetailsDTO, BillDetails>()
                   .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location.Lat))
                   .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location.Lng))
                   .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.Street))
                   .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode))
                   .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                   .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
                   .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                   .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.Address.CityId)).ReverseMap(); 
            */

            /*User*/
            CreateMap<User, UserDTO>().ReverseMap();

            /*Player*/
            CreateMap<Player, PlayerDTO>().ReverseMap();

            /*Mission*/
            CreateMap<Mission, MissionDTO>().ReverseMap();

            /*Match*/
            CreateMap<Match, MatchDTO>().ReverseMap();

            /*Map*/
            CreateMap<Map, MapDTO>().ReverseMap();

            /*Dice*/
            CreateMap<Dice, DiceDTO>().ReverseMap();

            /*Configuration*/
            CreateMap<Configuration, ConfigurationDTO>().ReverseMap();
        }
    }
}
