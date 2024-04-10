using BudgetManagement.Domain.Entities.User;
using AutoMapper;
using BudgetManagement.Api.DTO;
using Profile = BudgetManagement.Domain.Entities.User.Profile;

namespace BudgetManagement.Api.Mappings
{
    public class EntitiesToDtoMappingProfile : AutoMapper.Profile
    {
        public EntitiesToDtoMappingProfile()
        {
            CreateMap<Profile, ProfileDTO>().ReverseMap();
        }
    }
}
