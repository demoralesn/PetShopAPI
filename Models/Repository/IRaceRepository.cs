namespace PetShopAPI.Models.Repository
{
    public interface IRaceRepository
    {
        Task<List<Race>> GetRaceList();
    }
}
