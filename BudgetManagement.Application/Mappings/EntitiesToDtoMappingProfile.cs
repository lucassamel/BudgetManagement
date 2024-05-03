using AutoMapper;
using BudgetManagement.Application.DTOs;
using BudgetManagement.Application.DTOs.Outlay.Category;
using BudgetManagement.Application.DTOs.Outlay.Spent;
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
            CreateMap<CategoryDTO, Category>().ReverseMap()
                .ForMember(dest => dest.ProfileDTO, opt => opt.MapFrom(x => x.Profile))
                .ForMember(dest => dest.SpentsDTO, opt => opt.MapFrom(x => x.Spents));
            CreateMap<Category, CategoryPostDTO>().ReverseMap();
            CreateMap<Spent, SpentDTO>().ReverseMap();
            CreateMap<Spent, SpentPostDTO>().ReverseMap();
        }
    }
}
