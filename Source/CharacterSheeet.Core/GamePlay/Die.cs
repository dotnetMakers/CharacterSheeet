namespace CharacterSheeet.Dcc;

public static class Extensions
{
    public static string ToRomanNumeral(this int i)
    {
        return i switch
        {
            1 => "I",
            2 => "II",
            3 => "III",
            4 => "IV",
            5 => "V",
            6 => "VI",
            7 => "VII",
            8 => "VIII",
            9 => "IX",
            10 => "X",
            _ => i.ToString()
        };
    }
}

public class MissileWeapon : Item
{
    public Die Damage { get; set; }

    public string ToString(int attackBonus, int damageBonus)
    {
        var d = new Die(Damage.Count, Damage.Sides, Damage.Bonus + damageBonus);

        return $"{Name} {attackBonus:+#;-#;+0} ({d}) ";
    }
}

public class MeleeWeapon : Item
{
    public Die Damage { get; set; }

    public string ToString(int attackBonus, int damageBonus)
    {
        var d = new Die(Damage.Count, Damage.Sides, Damage.Bonus + damageBonus);

        return $"{Name} {attackBonus:+#;-#;+0} ({d}) ";
    }
}

public class Armor : Item
{
    public int ACBonus { get; set; }
    public int CheckPenalty { get; set; }
    public int SpeedPenalty { get; set; }
    public Die FumbleDie { get; set; }
}

public class Item
{
    public string Name { get; set; }
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
