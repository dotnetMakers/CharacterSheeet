using CharacterSheeet.Dcc;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class CombatModifiersLayout : AbsoluteLayout
{
    private readonly SimpleValueLayout _meleeA;
    private readonly SimpleValueLayout _meleeD;
    private readonly SimpleValueLayout _missileA;
    private readonly SimpleValueLayout _missileD;

    public CombatModifiersLayout(int left, int top, Character character)
        : base(left, top, 120, 65 * 4)
    {
        var mods = character.GetCombatModifiers();

        _meleeA = new SimpleValueLayout("Melee Attack", $"{mods.MeleeAttack:+#;-#;+0}", 0, 0);
        _meleeD = new SimpleValueLayout("Melee Damage", $"{mods.MeleeDamage:+#;-#;+0}", 0, LayoutConstants.AttributeBlockHeight);
        _missileA = new SimpleValueLayout("Missile Attack", $"{mods.MissileAttack:+#;-#;+0}", 0, LayoutConstants.AttributeBlockHeight * 2);
        _missileD = new SimpleValueLayout("Missile Damage", $"{mods.MissileDamage:+#;-#;+0}", 0, LayoutConstants.AttributeBlockHeight * 3);

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
