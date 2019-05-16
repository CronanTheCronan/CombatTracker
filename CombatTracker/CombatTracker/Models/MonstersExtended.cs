using System;
using System.Collections.Generic;

namespace CombatTracker.Models
{
    public partial class MonstersExtended
    {
        public int Id { get; set; }
        public int MonsterId { get; set; }
        public int ArmorClass { get; set; }
        public int CurrentHp { get; set; }
        public int MaxHp { get; set; }
        public int? Condition1 { get; set; }
        public int? Condition2 { get; set; }
        public int? Condition3 { get; set; }
        public int? Condition4 { get; set; }
        public int CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public virtual Conditions Condition1Navigation { get; set; }
        public virtual Conditions Condition2Navigation { get; set; }
        public virtual Conditions Condition3Navigation { get; set; }
        public virtual Conditions Condition4Navigation { get; set; }
        public virtual Users CreatedByUserNavigation { get; set; }
        public virtual Users LastModifiedByNavigation { get; set; }
        public virtual Monsters Monster { get; set; }
    }
}
