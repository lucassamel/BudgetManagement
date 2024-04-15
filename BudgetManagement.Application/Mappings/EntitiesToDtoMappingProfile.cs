using AutoMapper;
using BudgetManagement.Application.DTOs;
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
            CreateMap<BudgetManagement.Domain.Entities.User.Profile, ProfileDTO>().ReverseMap();
        }
    }
}
