using CharacterSheeet.Dcc;
using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class WeaponsListLayout : ItemListLayout
{
    private readonly Label[] _weaponLabels;

    public WeaponsListLayout(int left, int top, int width, int height, Character character)
        : base("Weapons", left, top, width, height)
    {
        _weaponLabels = new Label[character.Weapons.Length];

        var i = 0;
        var y = 30;

        var bonus = character.GetCombatModifiers();

        foreach (var weapon in character.Weapons)
        {
            _weaponLabels[i] = new Label(3, y, this.Width, 20)
            {
                TextColor = Color.Black,
                BackgroundColor = Color.Transparent,
                Font = LayoutConstants.XXSmallFont,
                HorizontalAlignment = HorizontalAlignment.Left,
                Text = weapon is MeleeWeapon
                    ? weapon.ToString(bonus.MeleeAttack, bonus.MeleeDamage)
                    : weapon.ToString(bonus.MissileAttack, bonus.MissileDamage)
            };

            Controls.Add(_weaponLabels[i]);
            i++;
            y += 20;
        }
    }
}
