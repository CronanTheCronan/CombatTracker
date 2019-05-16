using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CombatTracker.Dtos
{
    public class HeroToDeleteDto
    {
        public int HeroId { get; set; }
        public int UserId { get; set; }
    }
}
