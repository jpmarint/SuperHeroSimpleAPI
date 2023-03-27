using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero newHero)
        {
            _context.SuperHeroes.Add(newHero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return null;
            }
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return null;
            }
            return hero;
        }

        public async Task<List<SuperHero>?> UpdateHero(SuperHero updatedHero)
        {
            var hero = await _context.SuperHeroes.FindAsync(updatedHero.Id);
            if (hero == null)
            {
                return null;
            }

            hero.FirstName = updatedHero.FirstName;
            hero.LastName = updatedHero.LastName;
            hero.Name = updatedHero.Name;
            hero.Place = updatedHero.Place;

            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
