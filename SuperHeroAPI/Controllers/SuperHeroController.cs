using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet()]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return Ok(await _superHeroService.GetAllHeroes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = await _superHeroService.GetSingleHero(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero newHero)
        {
            var result = await _superHeroService.AddHero(newHero);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero updatedHero)
        {
            var result = await _superHeroService.UpdateHero(updatedHero);
            if (result is null)
            {
                return NotFound("Hero with not found.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = await _superHeroService.DeleteHero(id);
            if (result is null)
            {
                return NotFound("Hero with not found.");
            }
            return Ok(result);
        }
    }
}
