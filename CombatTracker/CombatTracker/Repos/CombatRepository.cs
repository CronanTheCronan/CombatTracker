using CombatTracker.Data;
using CombatTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CombatTracker.Repos
{
    public class CombatRepository : ICombatRepository
    {
        private readonly CombatTrackerContext _context;

        public CombatRepository(CombatTrackerContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Heroes>> GetHeroes(int id)
        {
            var heroes = await _context.Heroes.Include(e => e.HeroesExtended).Where(x => x.CreatedByUserId == id).ToListAsync();
            return heroes;
        }

        public async Task<Heroes> GetHeroById(int heroId)
        {
            var hero = await _context.Heroes.Include(e => e.HeroesExtended).FirstOrDefaultAsync(x => x.Id == heroId);
            return hero;
        }

        public async Task<HeroesExtended> GetHeroExtById(int heroId)
        {
            var heroExt = await _context.HeroesExtended.FirstOrDefaultAsync(x => x.HeroId == heroId);
            return heroExt;
        }

        public async Task<int> CreateHero(Heroes hero)
        {
            await _context.Heroes.AddAsync(hero);
            await _context.SaveChangesAsync();

            var createdHero = await _context.Heroes.FirstOrDefaultAsync(x => x.Name == hero.Name);
            return createdHero.Id;
        }

        public async Task<Heroes> CreateHeroExt(HeroesExtended hExt)
        {
            await _context.HeroesExtended.AddAsync(hExt);
            await _context.SaveChangesAsync();

            var createdHero = await _context.Heroes.Include(e => e.HeroesExtended).FirstOrDefaultAsync(x => x.Id == hExt.HeroId);
            return createdHero;
        }




        public async Task<IEnumerable<Monsters>> GetMonsters(int id)
        {
            var monsters = await _context.Monsters.Include(e => e.MonstersExtended).Where(x => x.CreatedByUser == id).ToListAsync();
            return monsters;
        }

        public async Task<Monsters> GetMonsterById(int monsterId)
        {
            var monster = await _context.Monsters.Include(e => e.MonstersExtended).FirstOrDefaultAsync(x => x.Id == monsterId);
            return monster;
        }

        public async Task<MonstersExtended> GetMonsterExtById(int monsterId)
        {
            var monsterExt = await _context.MonstersExtended.FirstOrDefaultAsync(x => x.MonsterId == monsterId);
            return monsterExt;
        }

        public async Task<int> CreateMonster(Monsters monster)
        {
            await _context.Monsters.AddAsync(monster);
            await _context.SaveChangesAsync();

            var createdMonster = await _context.Monsters.FirstOrDefaultAsync(x => x.Name == monster.Name);
            return createdMonster.Id;
        }

        public async Task<Monsters> CreateMonsterExt(MonstersExtended mExt)
        {
            await _context.MonstersExtended.AddAsync(mExt);
            await _context.SaveChangesAsync();

            var createdHero = await _context.Monsters.Include(e => e.MonstersExtended).FirstOrDefaultAsync(x => x.Id == mExt.MonsterId);
            return createdHero;
        }



        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
