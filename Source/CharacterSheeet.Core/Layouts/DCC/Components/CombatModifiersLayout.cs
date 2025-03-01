using CharacterSheeet.Dcc;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class CombatModifiersLayout : AbsoluteLayout
{
    private SimpleValueLayout _meleeA;
    private SimpleValueLayout _meleeD;
    private SimpleValueLayout _missileA;
    private SimpleValueLayout _missileD;

    public CombatModifiersLayout(int left, int top, Character character)
        : base(left, top, 120, 65 * 4)
    {
        var mods = character.GetCombatModifiers();

        _meleeA = new SimpleValueLayout("Melee Attack", $"{mods.MeleeAttack:+#;-#;+0}", left, top);
        _meleeD = new SimpleValueLayout("Melee Damage", $"{mods.MeleeDamage:+#;-#;+0}", left, top + 65);
        _missileA = new SimpleValueLayout("Missile Attack", $"{mods.MissileAttack:+#;-#;+0}", left, top + 65 * 2);
        _missileD = new SimpleValueLayout("Missile Damage", $"{mods.MissileDamage:+#;-#;+0}", left, top + 65 * 3);

        Controls.Add(_meleeA, _meleeD, _missileA, _missileD);

        character.PropertyChanged += (s, e) =>
        {
            switch (e.PropertyName)
            {
                case nameof(Character.Strength):
                case nameof(Character.Agility):
                    var mods = character.GetCombatModifiers();
                    Update(mods);
                    break;

            }
        };
    }

    private void Update((int MeleeAttack, int MeleeDamage, int MissileAttack, int MissileDamage) combatModifiers)
    {
        _meleeA.ValueText = $"{combatModifiers.MeleeAttack:+#;-#;+0}";
        _meleeD.ValueText = $"{combatModifiers.MeleeDamage:+#;-#;+0}";
        _missileA.ValueText = $"{combatModifiers.MissileAttack:+#;-#;+0}";
        _missileD.ValueText = $"{combatModifiers.MissileDamage:+#;-#;+0}";
    }
}
