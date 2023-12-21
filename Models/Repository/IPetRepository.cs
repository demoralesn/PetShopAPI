namespace PetShopAPI.Models.Repository
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetPetList();
    }
}
