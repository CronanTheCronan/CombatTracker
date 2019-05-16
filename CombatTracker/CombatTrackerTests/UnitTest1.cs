using Microsoft.VisualStudio.TestTools.UnitTesting;
using CombatTracker.Helpers;
using CombatTracker.Dtos;
using CombatTracker.Models;
using AutoMapper;

namespace CombatTrackerTests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IMapper _mapper;

        public UnitTest1(IMapper mapper)
        {
            _mapper = mapper;
        }
        [TestMethod]
        public void TestMethod1()
        {
            var hero = new Heroes();
            var heroToCreate = new HeroToCreateDto
            {
                Name = "Burriticus",
                ArmorClass = 22,
                CurrentHp = 30,
                MaxHp = 30,
                Condition1 = null,
                Condition2 = null,
                Condition3 = null,
                Condition4 = null
            };
            var mappedHero = _mapper.Map<HeroesExtended>(heroToCreate);
        }
    }
}
