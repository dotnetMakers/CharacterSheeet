using CharacterSheeet.Dcc;
using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;
using System.Collections.Generic;

namespace CharacterSheeet.Core;

internal class DccHalflingSheet : Sheet
{
    private Halfling _character;

    public DccHalflingSheet(Halfling character)
        : base(GenerateLayouts(character))
    {
        _character = character;
    }

    private static IEnumerable<MicroLayout> GenerateLayouts(Halfling character)
    {
        return new MicroLayout[]
        {
            GeneratePage1(character),
            GeneratePage2(character),
        };
    }

    private static MicroLayout GeneratePage2(Halfling character)
    {
        var layout = new AbsoluteLayout(480, 800);
        layout.BackgroundColor = Color.White;

        var weapons = new WeaponsListLayout(5, 5, 230, 150, character);
        var treasure = new TreasureListLayout(weapons.Left, weapons.Bottom, weapons.Width, 250, character);

        var equipment = new EquipmentListLayout(245, 5, 230, 300, character);
        var armor = new ArmorListLayout(equipment.Left, equipment.Bottom, equipment.Width, 100, character);

        var abilities = new HalflingAbilitiesLayout(5, treasure.Bottom + 10, 470, 150);
        var notes = new ItemListLayout("Notes", 5, abilities.Bottom, 470, 800 - abilities.Bottom - 10);

        layout.Controls.Add(weapons, treasure, equipment, armor, abilities, notes);

        return layout;
    }

    private static MicroLayout GeneratePage1(Halfling character)
    {
        var layout = new AbsoluteLayout(480, 800);
        layout.BackgroundColor = Color.White;

        var attributesTop = 350;

        var smallFont = new Font8x16();
        var medFont = new Font12x20();
        var largeFont = new Font16x24();

        // title block
        layout.Controls.Add(
            new Label(0, 0, 480, 28)
            {
                TextColor = Color.White,
                BackColor = Color.Black,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Font = largeFont,
                Text = $"LEVEL {character.Level} {character.Class.ToUpper()}"
            });

        layout.Controls.Add(
            new Label(5, 30, 240, 12)
            {
                TextColor = Color.Black,
                BackColor = Color.Transparent,
                Font = medFont,
                Text = $"Name: {character.Name}"
            });
        layout.Controls.Add(
            new Label(240, 30, 230, 12)
            {
                TextColor = Color.Black,
                BackColor = Color.Transparent,
                HorizontalAlignment = HorizontalAlignment.Right,
                Font = medFont,
                Text = $"Align: {character.Alignment}"
            });

        layout.Controls.Add(
            new Label(5, 55, 240, 12)
            {
                TextColor = Color.Black,
                BackColor = Color.Transparent,
                Font = medFont,
                Text = $"Title: {character.Title}"
            });
        layout.Controls.Add(
            new Label(240, 55, 230, 12)
            {
                TextColor = Color.Black,
                BackColor = Color.Transparent,
                HorizontalAlignment = HorizontalAlignment.Right,
                Font = medFont,
                Text = $"Speed: {character.Speed + character.Armor.SpeedPenalty}"
            });

        layout.Controls.Add(
            new Label(5, 80, 240, 12)
            {
                TextColor = Color.Black,
                BackColor = Color.Transparent,
                Font = medFont,
                Text = $"Occupation: {character.Occcupation}"
            });
        layout.Controls.Add(
            new Label(240, 80, 230, 12)
            {
                TextColor = Color.Black,
                BackColor = Color.Transparent,
                HorizontalAlignment = HorizontalAlignment.Right,
                Font = medFont,
                Text = $"XP: {character.XP}"
            });


        layout.Controls.Add(new ArmorClassLayout(5, 170, character));
        layout.Controls.Add(new HitPointLayout(125, 170, character));

        layout.Controls.Add(new CombatBasicsLayout(260, 140, character));



        layout.Controls.Add(new SaveCollectionLayout(220, attributesTop + 65, character));

        layout.Controls.Add(new SimpleValueLayout("Lucky Roll", character.LuckyRoll, 220, 65 * 4 + attributesTop));

        // combat
        layout.Controls.Add(new CombatModifiersLayout(350, attributesTop, character));

        // attribute blocks
        layout.Controls.Add(new AttributeCollectionLayout(5, attributesTop, character));

        layout.Controls.Add(new SimpleValueLayout("Languages", string.Join(',', character.Languages), 220, 65 * 5 + attributesTop, 250));

        var logo = Image.LoadFromResource("CharacterSheeet.Core.Assets.dcc-logo.bmp");
        layout.Controls.Add(new Picture(10, 740, logo.Width, logo.Height, logo));

        return layout;
    }
}
