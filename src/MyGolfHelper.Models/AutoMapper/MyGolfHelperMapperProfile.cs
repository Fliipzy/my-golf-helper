using AutoMapper;
using MyGolfHelper.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Models.AutoMapper
{
    public class MyGolfHelperMapperProfile : Profile
    {
        public MyGolfHelperMapperProfile()
        {
            ConfigureMaps();
        }

        private void ConfigureMaps()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserUpdateRequestDto>()
                .ForMember(dest => dest.FirstName, cfg => cfg.MapFrom(src => src.Information.FirstName))
                .ForMember(dest => dest.LastName, cfg => cfg.MapFrom(src => src.Information.LastName))
                .ForMember(dest => dest.Email, cfg => cfg.MapFrom(src => src.Information.Email))
                .ForMember(dest => dest.PhoneNumber, cfg => cfg.MapFrom(src => src.Information.PhoneNumber))
                .ForMember(dest => dest.BirthDate, cfg => cfg.MapFrom(src => src.Information.BirthDate))
                .ReverseMap();
            CreateMap<UserInformation, UserInformationDto>().ReverseMap();
            CreateMap<UserInformation, UserUpdateRequestDto>().ReverseMap();
        }
    }
}
