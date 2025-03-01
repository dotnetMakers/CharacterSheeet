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

    private static IEnumerable<MicroLayout> GenerateLayouts(Character character)
    {
        return new MicroLayout[]
        {
            GeneratePage1(character)
        };
    }

    private static MicroLayout GeneratePage1(Character character)
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
                Text = "HALFLING"
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
                Text = $"Speed: {character.Speed}"
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
            new Label(5, 105, 240, 12)
            {
                TextColor = Color.Black,
                BackColor = Color.Transparent,
                Font = medFont,
                Text = $"Class: {character.Class}"
            });


        layout.Controls.Add(new ArmorClassLayout(5, 170, character.ArmorClass));
        layout.Controls.Add(new HitPointLayout(125, 170));

        layout.Controls.Add(new CombatBasicsLayout(260, 140));



        // save blocks
        layout.Controls.Add(new SaveLayout("Ref", "0", 220, 65 + attributesTop));
        layout.Controls.Add(new SaveLayout("Fort", "+1", 220, 65 * 2 + attributesTop));
        layout.Controls.Add(new SaveLayout("Will", "+2", 220, 65 * 3 + attributesTop));

        layout.Controls.Add(new SimpleValueLayout("Lucky Roll", "d4", 220, 65 * 4 + attributesTop));

        // combat
        layout.Controls.Add(new SimpleValueLayout("Melee Attack", "d16", 350, 0 + attributesTop));
        layout.Controls.Add(new SimpleValueLayout("Melee Damage", "d6+1", 350, 65 + attributesTop));
        layout.Controls.Add(new SimpleValueLayout("Missile Attack", "d20", 350, 65 * 2 + attributesTop));
        layout.Controls.Add(new SimpleValueLayout("Missile Damage", "d4", 350, 65 * 3 + attributesTop));


        // attribute blocks
        layout.Controls.Add(new AttributeLayout("Strength", 5, 0 + attributesTop));
        layout.Controls.Add(new AttributeLayout("Agility", 5, 65 + attributesTop));
        layout.Controls.Add(new AttributeLayout("Stamina", 5, 65 * 2 + attributesTop));
        layout.Controls.Add(new AttributeLayout("Personality", 5, 65 * 3 + attributesTop));
        layout.Controls.Add(new AttributeLayout("Luck", 5, 65 * 4 + attributesTop));
        layout.Controls.Add(new AttributeLayout("Intelligence", 5, 65 * 5 + attributesTop));

        layout.Controls.Add(new SimpleValueLayout("Languages", "common, halfling", 220, 65 * 5 + attributesTop, 250));

        var logo = Image.LoadFromResource("CharacterSheeet.Core.Assets.dcc-logo.bmp");
        layout.Controls.Add(new Picture(10, 740, logo.Width, logo.Height, logo));

        return layout;
    }
}
