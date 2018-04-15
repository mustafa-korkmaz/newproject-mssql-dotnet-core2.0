using AutoMapper;

namespace Dal
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Models.Identity.ApplicationUser, Dto.ApplicationUser>();
            CreateMap<Dto.ApplicationUser, Models.Identity.ApplicationUser>();
        }
    }
}