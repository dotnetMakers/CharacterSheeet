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
            2 => new HalflingCombatBasics
            {
                AttackModifier = 2,
                CritDie = new Die(8),
                CritTable = 3,
                ActionDice = [new Die(20)],
                ReflexSaveModifier = 1,
                FortitudeSaveModifier = 1,
                WillpowerSaveModifier = 1,
                SneakAndHideModifier = +5
            },
            3 => new HalflingCombatBasics
            {
                AttackModifier = 2,
                CritDie = new Die(10),
                CritTable = 3,
                ActionDice = [new Die(20)],
                ReflexSaveModifier = 2,
                FortitudeSaveModifier = 1,
                WillpowerSaveModifier = 2,
                SneakAndHideModifier = +7
            },
            4 => new HalflingCombatBasics
            {
                AttackModifier = 3,
                CritDie = new Die(10),
                CritTable = 3,
                ActionDice = [new Die(20)],
                ReflexSaveModifier = 2,
                FortitudeSaveModifier = 2,
                WillpowerSaveModifier = 2,
                SneakAndHideModifier = +8
            },
            5 => new HalflingCombatBasics
            {
                AttackModifier = 4,
                CritDie = new Die(12),
                CritTable = 3,
                ActionDice = [new Die(20)],
                ReflexSaveModifier = 3,
                FortitudeSaveModifier = 2,
                WillpowerSaveModifier = 3,
                SneakAndHideModifier = +9
            },
            6 => new HalflingCombatBasics
            {
                AttackModifier = 5,
                CritDie = new Die(12),
                CritTable = 3,
                ActionDice = [new Die(20), new Die(14)],
                ReflexSaveModifier = 4,
                FortitudeSaveModifier = 2,
                WillpowerSaveModifier = 4,
                SneakAndHideModifier = +11
            },
            7 => new HalflingCombatBasics
            {
                AttackModifier = 5,
                CritDie = new Die(14),
                CritTable = 3,
                ActionDice = [new Die(20), new Die(16)],
                ReflexSaveModifier = 4,
                FortitudeSaveModifier = 3,
                WillpowerSaveModifier = 4,
                SneakAndHideModifier = +12
            },
            8 => new HalflingCombatBasics
            {
                AttackModifier = 6,
                CritDie = new Die(14),
                CritTable = 3,
                ActionDice = [new Die(20), new Die(20)],
                ReflexSaveModifier = 5,
                FortitudeSaveModifier = 3,
                WillpowerSaveModifier = 5,
                SneakAndHideModifier = +13
            },
            9 => new HalflingCombatBasics
            {
                AttackModifier = 7,
                CritDie = new Die(16),
                CritTable = 3,
                ActionDice = [new Die(20), new Die(20)],
                ReflexSaveModifier = 5,
                FortitudeSaveModifier = 3,
                WillpowerSaveModifier = 5,
                SneakAndHideModifier = +14
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
