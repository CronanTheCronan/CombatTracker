using System;
using System.Collections.Generic;

namespace CombatTracker.Models
{
    public partial class Heroes
    {
        public Heroes()
        {
            HeroesExtended = new HashSet<HeroesExtended>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public virtual Users CreatedByUser { get; set; }
        public virtual ICollection<HeroesExtended> HeroesExtended { get; set; }
    }
}
