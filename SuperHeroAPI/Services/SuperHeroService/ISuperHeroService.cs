using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero?> GetSingleHero(int id);
        Task<List<SuperHero>> AddHero(SuperHero newHero);
        Task<List<SuperHero>?> UpdateHero(SuperHero updatedHero);
        Task<List<SuperHero>?> DeleteHero(int id);
    }
}
