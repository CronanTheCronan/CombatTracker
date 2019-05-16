using System;
using System.Collections.Generic;

namespace CombatTracker.Models
{
    public partial class Users
    {
        public Users()
        {
            Heroes = new HashSet<Heroes>();
            HeroesExtendedCreatedByNavigation = new HashSet<HeroesExtended>();
            HeroesExtendedLastModifiedByNavigation = new HashSet<HeroesExtended>();
            MonstersCreatedByUserNavigation = new HashSet<Monsters>();
            MonstersExtendedCreatedByUserNavigation = new HashSet<MonstersExtended>();
            MonstersExtendedLastModifiedByNavigation = new HashSet<MonstersExtended>();
            MonstersLastModifiedByNavigation = new HashSet<Monsters>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastLoggedIn { get; set; }

        public virtual ICollection<Heroes> Heroes { get; set; }
        public virtual ICollection<HeroesExtended> HeroesExtendedCreatedByNavigation { get; set; }
        public virtual ICollection<HeroesExtended> HeroesExtendedLastModifiedByNavigation { get; set; }
        public virtual ICollection<Monsters> MonstersCreatedByUserNavigation { get; set; }
        public virtual ICollection<MonstersExtended> MonstersExtendedCreatedByUserNavigation { get; set; }
        public virtual ICollection<MonstersExtended> MonstersExtendedLastModifiedByNavigation { get; set; }
        public virtual ICollection<Monsters> MonstersLastModifiedByNavigation { get; set; }
    }
}
