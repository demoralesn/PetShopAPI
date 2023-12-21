
using Microsoft.EntityFrameworkCore;

namespace PetShopAPI.Models.Repository
{
    public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext _context;

        public PetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pet>> GetPetList()
        {
            return await _context.Pets.ToListAsync();
        }
    }
}
