using System;
using System.Collections.Generic;

namespace CombatTracker.Models
{
    public partial class Monsters
    {
        public Monsters()
        {
            MonstersExtended = new HashSet<MonstersExtended>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public virtual Users CreatedByUserNavigation { get; set; }
        public virtual Users LastModifiedByNavigation { get; set; }
        public virtual ICollection<MonstersExtended> MonstersExtended { get; set; }
    }
}
