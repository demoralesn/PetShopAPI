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
        private readonly ILogger<PetController> _logger;

        public PetController(IMapper mapper, IPetRepository petRepository, ILogger<PetController> logger)
        {
            _mapper = mapper;
            _petRepository = petRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Thread.Sleep(2000);
                var petList = await _petRepository.GetPetList();
                var petDtoList = _mapper.Map<IEnumerable<PetDTO>>(petList);

                _logger.LogInformation("Get method called");
                return Ok(petDtoList);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error calling Get method");
                return BadRequest($"{ex.Message}");
            }
        }

        [Route("List")]
        [HttpGet]
        public async Task<IActionResult> GetPetListWithRace()
        {
            try
            {
                Thread.Sleep(2000);
                var petList = await _petRepository.GetPetListWithRace();
                var petDtoList = _mapper.Map<IEnumerable<PetDTO>>(petList);

                _logger.LogInformation("GetPetListWithRace method called");
                return Ok(petDtoList);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error calling GetPetListWithRace method");
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Thread.Sleep(2000);
                var petDetails = await _petRepository.GetPetById(id);

                if (petDetails != null)
                {
                    var petDto = _mapper.Map<PetDTO>(petDetails);

                    _logger.LogInformation("Get by Id method called");
                    return Ok(petDto);
                }
                else
                {
                    _logger.LogWarning("Id not found in Get by Id method");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error calling Get by Id method");
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            try
            {
                Thread.Sleep(2000);

                var petCheck = await _petRepository.GetPetById(id);

                if (petCheck != null)
                {
                    await _petRepository.RemovePet(petCheck);

                    _logger.LogInformation("Delete by Id method called");
                    return NoContent();
                }
                else
                {
                    _logger.LogWarning("Id not found in Delete by Id method");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error calling Delete by Id method");
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPet(PetDTO petDto)
        {
            try
            {
                var pet = _mapper.Map<Pet>(petDto);
                pet.CreationDate = DateTime.Now;

                pet = await _petRepository.AddPet(pet);

                var petSaved = _mapper.Map<PetDTO>(pet);

                _logger.LogInformation("Add new pet method called");
                return CreatedAtAction("Get", new { id = pet.PetId }, petSaved);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error calling Add new pet method");
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPet(int id, PetDTO petDto)
        {
            try
            {
                if (id != petDto.PetId)
                {
                    return BadRequest();
                }
                else
                {
                    var petCheck = await _petRepository.GetPetById(id);

                    if (petCheck != null)
                    {
                        var pet = _mapper.Map<Pet>(petDto);

                        await _petRepository.UpdatePet(pet);

                        _logger.LogInformation("Edit pet by Id method called");
                        return NoContent();
                    }
                    else
                    {
                        _logger.LogWarning("Id not found in Edit pet by Id method");
                        return NotFound();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error calling Edit pet by Id method");
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
