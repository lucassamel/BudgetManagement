using BudgetManagement.Application.DTOs.Account;
using BudgetManagement.Application.DTOs.Outlay.Category;
using BudgetManagement.Application.DTOs.Outlay.Spent;
using BudgetManagement.Domain.Entities.Account;
using BudgetManagement.Domain.Entities.Outlay;

namespace BudgetManagement.Application.Mappings
{
    public class EntitiesToDtoMappingProfile: AutoMapper.Profile
    {
        public EntitiesToDtoMappingProfile()
        {
            CreateMap<Profile, ProfileDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap()                
                .ForMember(dest => dest.UserDTO, opt => opt.MapFrom(x => x.User))
                .ForMember(dest => dest.SpentsDTO, opt => opt.MapFrom(x => x.Spents));
            CreateMap<Category, CategoryPostDTO>().ReverseMap();
            CreateMap<Spent, SpentDTO>().ReverseMap();
            CreateMap<Spent, SpentPostDTO>().ReverseMap();
        }
    }
}
