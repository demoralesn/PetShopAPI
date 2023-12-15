using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopAPI.Models;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PetController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Thread.Sleep(2000);
                var petList = await _context.Pets.ToListAsync();
                return Ok(petList);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Thread.Sleep(2000);
                var petDetails = await _context.Pets.FindAsync(id);
                
                if (petDetails != null) {
                    return Ok(petDetails);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePet(int id)
        {
            try
            {
                Thread.Sleep(2000);

                var petCheck = await _context.Pets.FindAsync(id);

                if (petCheck != null)
                {
                    _context.Pets.Remove(petCheck);
                    await _context.SaveChangesAsync();

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
