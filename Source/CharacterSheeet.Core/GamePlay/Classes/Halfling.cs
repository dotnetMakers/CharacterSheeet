namespace CharacterSheeet.Dcc;

public class Halfling : Character
{
    public override int BaseSpeed => 20;

    public string LuckyRoll { get; set; } = string.Empty;
    public override string Class => "Halfling";

    public override string Title
    {
        get
        {
            return Level switch
            {
                1 => "Wanderer",
                2 => "Explorer",
                3 => "Collector",
                4 => "Accumulator",
                _ => "Wise One"
            };
        }
    }

    public override CombatBasics GetCombatBasics()
    {
        return Level switch
        {
            1 => new HalflingCombatBasics
            {
                AttackModifier = 1,
                CritDie = new Die(8),
                CritTable = 3,
                ActionDice = [new Die(20)],
                ReflexSaveModifier = 1,
                FortitudeSaveModifier = 1,
                WillpowerSaveModifier = 1,
                SneakAndHideModifier = +3
            },
            _ => new HalflingCombatBasics // 10+
            {
                AttackModifier = 8,
                CritDie = new Die(16),
                CritTable = 3,
                ActionDice = [new Die(20), new Die(20)],
                ReflexSaveModifier = 6,
                FortitudeSaveModifier = 4,
                WillpowerSaveModifier = 6,
                SneakAndHideModifier = +15
            }
        };
    }
}
