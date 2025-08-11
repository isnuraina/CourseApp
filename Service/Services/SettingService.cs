using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Repository.Repositories.Interfaces;
using Service.DTOs.Setting;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;

        public SettingService(ISettingRepository settingRepository, IMapper mapper)
        {
            _settingRepository = settingRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(SettingCreateDto model)
        {
            if (await _settingRepository.GetCountAsync()>=1)
            {
                throw new BadHttpRequestException("Setting count must be less than 1");
            }
            await _settingRepository.CreateAsync(_mapper.Map<Setting>(model));
        }
    }
}
