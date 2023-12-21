using AutoMapper;

namespace PetShopAPI.Models.DTO.Profiles
{
    public class PetProfile : Profile
    {
        public PetProfile() {
            CreateMap<Pet, PetDTO>();
            CreateMap<PetDTO, Pet>();
                
        }
    }
}
