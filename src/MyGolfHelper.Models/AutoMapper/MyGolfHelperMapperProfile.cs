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
            CreateMap<UserInformation, UserInformationDto>().ReverseMap();
        }
    }
}
