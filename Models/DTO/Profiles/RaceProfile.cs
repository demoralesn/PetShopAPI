using AutoMapper;

namespace PetShopAPI.Models.DTO.Profiles
{
    public class RaceProfile : Profile
    {
        public RaceProfile() 
        {
            CreateMap<Race, RaceDTO>();
            CreateMap<RaceDTO, Race>();
        }
    }
}
