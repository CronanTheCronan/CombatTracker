using System;
using System.Collections.Generic;

namespace CombatTracker.Models
{
    public partial class Conditions
    {
        public Conditions()
        {
            HeroesExtendedCondition1Navigation = new HashSet<HeroesExtended>();
            HeroesExtendedCondition2Navigation = new HashSet<HeroesExtended>();
            HeroesExtendedCondition3Navigation = new HashSet<HeroesExtended>();
            HeroesExtendedCondition4Navigation = new HashSet<HeroesExtended>();
            MonstersExtendedCondition1Navigation = new HashSet<MonstersExtended>();
            MonstersExtendedCondition2Navigation = new HashSet<MonstersExtended>();
            MonstersExtendedCondition3Navigation = new HashSet<MonstersExtended>();
            MonstersExtendedCondition4Navigation = new HashSet<MonstersExtended>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<HeroesExtended> HeroesExtendedCondition1Navigation { get; set; }
        public virtual ICollection<HeroesExtended> HeroesExtendedCondition2Navigation { get; set; }
        public virtual ICollection<HeroesExtended> HeroesExtendedCondition3Navigation { get; set; }
        public virtual ICollection<HeroesExtended> HeroesExtendedCondition4Navigation { get; set; }
        public virtual ICollection<MonstersExtended> MonstersExtendedCondition1Navigation { get; set; }
        public virtual ICollection<MonstersExtended> MonstersExtendedCondition2Navigation { get; set; }
        public virtual ICollection<MonstersExtended> MonstersExtendedCondition3Navigation { get; set; }
        public virtual ICollection<MonstersExtended> MonstersExtendedCondition4Navigation { get; set; }
    }
}
