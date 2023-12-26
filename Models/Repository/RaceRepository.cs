
using Microsoft.EntityFrameworkCore;

namespace PetShopAPI.Models.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDbContext _context;

        public RaceRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Race>> GetRaceList()
        {
            return await _context.Races.ToListAsync();
        }
    }
}