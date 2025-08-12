using AutoMapper;
using Domain.Entities;
using Service.DTOs.Account;
using Service.DTOs.Education;
using Service.DTOs.Group;
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
            CreateMap<GroupCreateDto, Group>().ForMember(dest=>dest.EducationId,opt=>opt.MapFrom(src=>src.EducationId));
            CreateMap<Group, GroupDto>().ForMember(dest => dest.EducationName, opt => opt.MapFrom(src => src.Education.Name)); ;
            CreateMap<RegisterDto, AppUser>();
        }
    }
}
