namespace CombatTracker.Dtos
{
    public class HeroToCreateDto
    {
        public string Name { get; set; }
        public int HeroId { get; set; }
        public int ArmorClass { get; set; }
        public int CurrentHp { get; set; }
        public int MaxHp { get; set; }
        public int? Condition1 { get; set; }
        public int? Condition2 { get; set; }
        public int? Condition3 { get; set; }
        public int? Condition4 { get; set; }
        public int CreatedBy { get; set; }
    }
}
