namespace CharacterSheeet.Dcc;

public abstract class Weapon : Item
{
    public Die Damage { get; set; }

    public string ToString(int attackBonus, int damageBonus)
    {
        var d = new Die(Damage.Count, Damage.Sides, Damage.Bonus + damageBonus);

        return $"{Name} [{attackBonus:+#;-#;+0}/{d}] ";
    }
}

public class MissileWeapon : Weapon
{
}

public class MeleeWeapon : Weapon
{
}
