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
            CreateMap<User, NewUserRequestDto>().IncludeMembers(src => src.Information).ReverseMap();
            CreateMap<NewUserRequestDto, UserInformation>().ReverseMap();
            CreateMap<UserInformation, UserInformationDto>().ReverseMap();
            CreateMap<GolfCourse, GolfCourseDto>().ReverseMap();
            CreateMap<NewGolfCourseRequestDto, GolfCourse>();
            CreateMap<GolfClub, GolfClubDto>().ReverseMap();
        }
    }
}
