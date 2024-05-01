﻿using AutoMapper;
using BudgetManagement.Application.DTOs;
using BudgetManagement.Domain.Entities.Outlay;
using BudgetManagement.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Application.Mappings
{
    public class EntitiesToDtoMappingProfile: AutoMapper.Profile
    {
        public EntitiesToDtoMappingProfile()
        {
            CreateMap<Domain.Entities.User.Profile, ProfileDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap()
                .ForMember(dest => dest.Profile, opt => opt.MapFrom(x => x.ProfileDTO))
                .ForMember(dest => dest.Spents, opt => opt.MapFrom(x => x.SpentsDTO));
            CreateMap<Spent, SpentDTO>().ReverseMap();
        }
    }
}
