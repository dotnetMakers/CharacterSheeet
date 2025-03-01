using System;

namespace CharacterSheeet.Dcc;

public static class CharacterGenerator
{
    public static Halfling GenerateHalfling()
    {
        return new Halfling
        {
            Name = "Shorty",
            Occcupation = "Farmer",
            Alignment = "Lawful",
            Level = 1,
            XP = 10,
            MaxHitPoints = 5,
            Strength = 13,
            Agility = 11,
            Stamina = 10,
            Personality = 4,
            Luck = 9,
            Intelligence = 6
        };
    }
}

public class Halfling : Character
{
    public override int BaseSpeed => 20;
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

public class Die
{
    public int Count { get; set; } = 1;
    public int Sides { get; set; } = 6;
    public int Bonus { get; set; } = 0;

    public Die(int sides)
        : this(1, sides, 0)
    {
    }

    public Die(int count, int sides)
        : this(count, sides, 0)
    {
    }

    public Die(int count, int sides, int bonus)
    {
        Count = count;
        Sides = sides;
        Bonus = bonus;
    }

    public override string ToString()
    {
        if (Bonus != 0)
        {
            return $"{Count}d{Sides}{Bonus:+#;-#}";
        }
        return $"{Count}d{Sides}";
    }
}

public class HalflingCombatBasics : CombatBasics
{
    public int SneakAndHideModifier { get; set; }
}

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

public abstract class Character
{
    public virtual int BaseSpeed { get; } = 30;

    public string Name { get; set; }
    public abstract string Title { get; }
    public string Occcupation { get; set; }
    public string Class { get; set; }
    public string Alignment { get; set; }
    public int Speed => BaseSpeed; // todo: add armor, etc
    public int Level { get; set; }
    public int XP { get; set; }

    public int ArmorClass { get; set; }
    public int CurrentHitPoints { get; set; }
    public int MaxHitPoints { get; set; }

    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Stamina { get; set; }
    public int Personality { get; set; }
    public int Luck { get; set; }
    public int Intelligence { get; set; }

    public int InitiativeModifier { get; set; }

    public abstract CombatBasics GetCombatBasics();

    public (int Ref, int Fort, int Will) GetCalculatedSaves()
    {
        var basics = GetCombatBasics();
        return (
            basics.ReflexSaveModifier + GetAbilityModifier(Agility),
            basics.FortitudeSaveModifier + GetAbilityModifier(Stamina),
            basics.WillpowerSaveModifier + GetAbilityModifier(Personality));
    }

    public (int MeleeAttack, int meleeDamage, int MissileAttack, int MissileDamage) GetCombatModifiers()
    {
        var basics = GetCombatBasics();

        return (
            basics.AttackModifier + GetAbilityModifier(Strength),
            GetAbilityModifier(Strength),
            basics.AttackModifier + GetAbilityModifier(Agility),
            GetAbilityModifier(Agility)
            );
    }

    public int GetAbilityModifier(int abilityScore)
    {
        return abilityScore switch
        {
            3 => -3,
            4 or 5 => -2,
            >= 6 and <= 8 => -1,
            >= 9 and <= 12 => 0,
            >= 13 and <= 15 => 1,
            16 or 17 => 2,
            18 => 3,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
