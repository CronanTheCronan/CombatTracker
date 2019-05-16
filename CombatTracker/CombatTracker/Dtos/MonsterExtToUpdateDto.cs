namespace CombatTracker.Dtos
{
    public class MonsterExtToUpdateDto
    {
        public int MonsterId { get; set; }
        public int ArmorClass { get; set; }
        public int CurrentHp { get; set; }
        public int MaxHp { get; set; }
        public int? Condition1 { get; set; }
        public int? Condition2 { get; set; }
        public int? Condition3 { get; set; }
        public int? Condition4 { get; set; }
        public int LastModifiedBy { get; set; }
    }
}
