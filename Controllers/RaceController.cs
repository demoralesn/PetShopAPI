using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopAPI.Models.DTO;
using PetShopAPI.Models.Repository;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IMapper _mapper;

        public RaceController(IRaceRepository raceRepository, IMapper mapper) {
            _raceRepository = raceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRaces()
        {
            try
            {
                Thread.Sleep(2000);

                var racesList = await _raceRepository.GetRaceList();
                var racesDtoList = _mapper.Map<IEnumerable<RaceDTO>>(racesList);

                return Ok(racesDtoList);
            }
            catch (Exception ex) 
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
