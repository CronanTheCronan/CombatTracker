using AutoMapper;
using CombatTracker.Dtos;
using CombatTracker.Models;
using CombatTracker.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CombatTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombatController : ControllerBase
    {
        private readonly ICombatRepository _repo;
        private readonly IMapper _mapper;

        public CombatController(ICombatRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //GetHeroes
        [HttpGet("GetHeroes")]
        public async Task<IActionResult> GetHeroes(int id)
        {
            var heroes = await _repo.GetHeroes(id);
            return Ok(heroes);
        }
        //GetHeroById
        [HttpGet("GetHeroById/{id}")]
        public async Task<IActionResult> GetHeroById(int id, int userId)
        {
            // TODO: Validate user


            var hero = await _repo.GetHeroById(id);
            return Ok(hero);
        }
        //CreateHero
        [HttpPost("CreateHero")]
        public async Task<IActionResult> CreateHero(HeroToCreateDto dto)
        {
            var mappedHero = _mapper.Map<HeroToCreateDto, Heroes>(dto);
            var heroId = await _repo.CreateHero(mappedHero);

            var mappedHeroExt = _mapper.Map<HeroToCreateDto, HeroesExtended>(dto);
            mappedHeroExt.HeroId = heroId;

            var heroCreated = await _repo.CreateHeroExt(mappedHeroExt);

            return Ok(heroCreated);
        }
        ////UpdateHero
        [HttpPut("UpdateHero")]
        public async Task<IActionResult> UpdateHero(HeroToUpdateDto dto)
        {
            var hero = await _repo.GetHeroById(dto.Id);

            _mapper.Map(dto, hero);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating hero {dto.Name} failed on save.");
        }
        //UpdateHero
        [HttpPut("UpdateHeroExtended")]
        public async Task<IActionResult> UpdateHeroExt(HeroExtToUpdateDto dto)
        {
            var heroExt = await _repo.GetHeroExtById(dto.HeroId);
            var hero = await _repo.GetHeroById(dto.HeroId);

            _mapper.Map(dto, heroExt);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating hero {hero.Name} failed on save.");
        }
        //DeleteHero
        [HttpDelete("DeleteHero")]
        public async Task<IActionResult> DeleteHero(HeroToDeleteDto dto)
        {
            //TODO - Validate that this user can delete this hero

            var heroExt = await _repo.GetHeroExtById(dto.HeroId);
            var hero = await _repo.GetHeroById(dto.HeroId);

            _repo.Delete(heroExt);
            _repo.Delete(hero);

            if(await _repo.SaveAll())
                return Ok();

            return BadRequest($"Failed to delete {hero.Name}");
        }

        //GetMonsters
        [HttpGet("GetMonsters")]
        public async Task<IActionResult> GetMonsters(int id)
        {
            var monsters = await _repo.GetMonsters(id);
            return Ok(monsters);
        }
        //GetMonsterById
        [HttpGet("GetMonsterById/{id}")]
        public async Task<IActionResult> GetMonsterById(int id, int userId)
        {
            // TODO: Validate user


            var monster = await _repo.GetMonsterById(id);
            return Ok(monster);
        }
        //CreateMonster
        [HttpPost("CreateMonster")]
        public async Task<IActionResult> CreateMonster(MonsterToCreateDto dto)
        {
            var mappedMonster = _mapper.Map<MonsterToCreateDto, Monsters>(dto);
            var monsterId = await _repo.CreateMonster(mappedMonster);

            var mappedMonsterExt = _mapper.Map<MonsterToCreateDto, MonstersExtended>(dto);
            mappedMonsterExt.MonsterId = monsterId;

            var monsterCreated = await _repo.CreateMonsterExt(mappedMonsterExt);

            return Ok(monsterCreated);
        }
        //UpdateMonster
        [HttpPut("UpdateMonster")]
        public async Task<IActionResult> UpdateMonster(MonsterToUpdateDto dto)
        {
            var monster = await _repo.GetMonsterById(dto.Id);

            _mapper.Map(dto, monster);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating hero {dto.Name} failed on save.");
        }
        //UpdateMonsterExt
        [HttpPut("UpdateMonsterExt")]
        public async Task<IActionResult> UpdateMonsterExt(MonsterExtToUpdateDto dto)
        {
            var monsterExt = await _repo.GetMonsterExtById(dto.MonsterId);
            var monster = await _repo.GetMonsterById(dto.MonsterId);

            _mapper.Map(dto, monsterExt);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating hero {monster.Name} failed on save.");
        }
        //DeleteMonster
        [HttpDelete("DeleteMonster")]
        public async Task<IActionResult> DeleteMonster(MonsterToDeleteDto dto)
        {
            //TODO - Validate that this user can delete this hero

            var monsterExt = await _repo.GetMonsterExtById(dto.MonsterId);
            var monster = await _repo.GetMonsterById(dto.MonsterId);

            _repo.Delete(monsterExt);
            _repo.Delete(monster);

            if (await _repo.SaveAll())
                return Ok();

            return BadRequest($"Failed to delete {monster.Name}");
        }
    }
}
