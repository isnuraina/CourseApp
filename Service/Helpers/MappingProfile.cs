using AutoMapper;
using Domain.Entities;
using Service.DTOs.Education;
using Service.DTOs.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Education, EducationDto>().ForMember(dest=>
            dest.CreatedDate,opt=>opt.MapFrom(src=>src.CreatedDate.ToString("yyyy-MM-dd")));
            CreateMap<EducationCreateDto, Education>();
            CreateMap<EducationEditDto, Education>()
    .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<SettingCreateDto, Setting>();
        }
    }
}
