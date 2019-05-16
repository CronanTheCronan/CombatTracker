using CombatTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CombatTracker.Repos
{
    public interface ICombatRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<IEnumerable<Heroes>> GetHeroes(int id);
        Task<Heroes> GetHeroById(int heroId);
        Task<HeroesExtended> GetHeroExtById(int heroId);
        Task<int> CreateHero(Heroes hero);
        Task<Heroes> CreateHeroExt(HeroesExtended hExt);

        Task<IEnumerable<Monsters>> GetMonsters(int id);
        Task<Monsters> GetMonsterById(int monsterId);
        Task<MonstersExtended> GetMonsterExtById(int monsterId);
        Task<int> CreateMonster(Monsters monster);
        Task<Monsters> CreateMonsterExt(MonstersExtended mExt);

        Task<bool> SaveAll();
    }
}
