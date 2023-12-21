using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopAPI.Models;
using PetShopAPI.Models.DTO;
using PetShopAPI.Models.Repository;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPetRepository _petRepository;

        public PetController(IMapper mapper, IPetRepository petRepository)
        {
            _mapper = mapper;
            _petRepository = petRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Thread.Sleep(2000);
                var petList = await _petRepository.GetPetList();
                var petDtoList = _mapper.Map<IEnumerable<PetDTO>>(petList);

                return Ok(petDtoList);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    try
        //    {
        //        Thread.Sleep(2000);
        //        var petDetails = await _context.Pets.FindAsync(id);

        //        var petDto = _mapper.Map<PetDTO>(petDetails);

        //        if (petDetails != null)
        //        {
        //            return Ok(petDto);
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"{ex.Message}");
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePet(int id)
        //{
        //    try
        //    {
        //        Thread.Sleep(2000);

        //        var petCheck = await _context.Pets.FindAsync(id);

        //        if (petCheck != null)
        //        {
        //            _context.Pets.Remove(petCheck);
        //            await _context.SaveChangesAsync();

        //            return Ok();
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"{ex.Message}");
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddPet(PetDTO petDto)
        //{
        //    try
        //    {
        //        var pet = _mapper.Map<Pet>(petDto);
        //        pet.CreationDate = DateTime.Now;
        //        _context.Add(pet);
        //        await _context.SaveChangesAsync();
        //        var petSaved = _mapper.Map<PetDTO>(pet);

        //        return CreatedAtAction("Get", new { id = pet.Id }, petSaved);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"{ex.Message}");
        //    }
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> EditPet(int id, PetDTO petDto)
        //{
        //    try
        //    {
        //        if (id != petDto.Id)
        //        {
        //            return BadRequest();
        //        }
        //        else
        //        {
        //            var pet = _mapper.Map<Pet>(petDto);
        //            _context.Update(pet);
        //            await _context.SaveChangesAsync();
        //            return NoContent();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"{ex.Message}");
        //    }
        //}
    }
}
