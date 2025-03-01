namespace CharacterSheeet.Dcc;

public class CombatBasics
{
    public int AttackModifier { get; set; }
    public Die[] ActionDice { get; set; }
    public int ReflexSaveModifier { get; set; }
    public int FortitudeSaveModifier { get; set; }
    public int WillpowerSaveModifier { get; set; }
    public Die CritDie { get; set; }
    public int CritTable { get; set; }
}
