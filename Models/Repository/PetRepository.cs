
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

        public async Task<Pet> GetPetById(int id)
        {
            return await _context.Pets.FindAsync(id);
        }

        public async Task RemovePet(Pet pet)
        {
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
        }

        public async Task<Pet> AddPet(Pet pet)
        {
            _context.Add(pet);
            await _context.SaveChangesAsync();

            return (pet);
        }

        public async Task UpdatePet(Pet pet)
        {
            var petCheck = await _context.Pets.FirstOrDefaultAsync(x => x.Id == pet.Id);

            if (petCheck != null)
            {
                petCheck.Name = pet.Name;
                petCheck.CreationDate = DateTime.Now;
                petCheck.Color = pet.Color;
                petCheck.Race = pet.Race;
                petCheck.Age = pet.Age;
                petCheck.Weight = pet.Weight;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Pet>> GetPetListWithRace()
        {
            return await _context.Pets.FromSql($"select a.Id,a.Name,b.Description AS Race,a.Color,a.Age,a.Weight,a.CreationDate from petshop..pets a inner join petshop..races b on a.Race=b.RaceId").ToListAsync();
        }
    }
}
