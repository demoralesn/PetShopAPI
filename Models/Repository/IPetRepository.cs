namespace PetShopAPI.Models.Repository
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetPetList();

        Task<Pet> GetPetById(int id);

        Task RemovePet(Pet pet);

        Task<Pet> AddPet(Pet pet);

        Task UpdatePet(Pet pet);

        Task<List<Pet>> GetPetListWithRace();
    }
}
