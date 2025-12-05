using CharacterSheeet.Core;
using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;
using System.Collections.Generic;

namespace CharacterSheeet.Dcc;

internal class DccHalflingSheet : Sheet
{
    private readonly Halfling _character;
    public ArmorClassLayout ArmorClass { get; private set; }
    public HitPointLayout HitPoints { get; private set; }
    public AttributeCollectionLayout Attributes { get; private set; }

    public DccHalflingSheet(Halfling character)
        : base(GenerateLayouts(character, out var ac, out var hp, out var attr))
    {
        _character = character;
        ArmorClass = ac;
        HitPoints = hp;
        Attributes = attr;
    }

    private static IEnumerable<ILayout> GenerateLayouts(Halfling character,
        out ArmorClassLayout armorClass, out HitPointLayout hitPoints, out AttributeCollectionLayout attributes)
    {
        var page1 = GeneratePage1(character, out armorClass, out hitPoints, out attributes);
        return new ILayout[]
        {
            page1,
            GeneratePage2(character),
        };
    }

    private static ILayout GeneratePage2(Halfling character)
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

    private static ILayout GeneratePage1(Halfling character,
        out ArmorClassLayout armorClass, out HitPointLayout hitPoints, out AttributeCollectionLayout attributes)
    {
        var layout = new AbsoluteLayout(480, 800);
        layout.BackgroundColor = Color.White;

        var attributesTop = 350;

        // title block
        layout.Controls.Add(
            new Label(0, 0, 480, 28)
            {
                TextColor = Color.White,
                BackgroundColor = Color.Black,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Font = LayoutConstants.LargeFont,
                Text = $"LEVEL {character.Level} {character.Class.ToUpper()}"
            });

        layout.Controls.Add(
            new Label(5, 30, 240, 12)
            {
                TextColor = Color.Black,
                BackgroundColor = Color.Transparent,
                Font = LayoutConstants.MediumFont,
                Text = $"Name: {character.Name}"
            });
        layout.Controls.Add(
            new Label(240, 30, 230, 12)
            {
                TextColor = Color.Black,
                BackgroundColor = Color.Transparent,
                HorizontalAlignment = HorizontalAlignment.Right,
                Font = LayoutConstants.MediumFont,
                Text = $"Align: {character.Alignment}"
            });

        layout.Controls.Add(
            new Label(5, 55, 240, 12)
            {
                TextColor = Color.Black,
                BackgroundColor = Color.Transparent,
                Font = LayoutConstants.MediumFont,
                Text = $"Title: {character.Title}"
            });
        layout.Controls.Add(
            new Label(240, 55, 230, 12)
            {
                TextColor = Color.Black,
                BackgroundColor = Color.Transparent,
                HorizontalAlignment = HorizontalAlignment.Right,
                Font = LayoutConstants.MediumFont,
                Text = $"Speed: {character.Speed + character.Armor.SpeedPenalty}"
            });

        layout.Controls.Add(
            new Label(5, 80, 240, 12)
            {
                TextColor = Color.Black,
                BackgroundColor = Color.Transparent,
                Font = LayoutConstants.MediumFont,
                Text = $"Occupation: {character.Occcupation}"
            });
        layout.Controls.Add(
            new Label(240, 80, 230, 12)
            {
                TextColor = Color.Black,
                BackgroundColor = Color.Transparent,
                HorizontalAlignment = HorizontalAlignment.Right,
                Font = LayoutConstants.MediumFont,
                Text = $"XP: {character.XP}"
            });


        // Selectable controls with indices:
        // 0 = Armor Class
        // 1 = Hit Points
        // 2-7 = Attributes (Str, Agi, Sta, Per, Lck, Int)
        armorClass = new ArmorClassLayout(5, 170, character, selectionIndex: 0);
        hitPoints = new HitPointLayout(125, 170, character, selectionIndex: 1);

        layout.Controls.Add(armorClass);
        layout.Controls.Add(hitPoints);

        layout.Controls.Add(new CombatBasicsLayout(260, 140, character));

        layout.Controls.Add(new SaveCollectionLayout(223, attributesTop + LayoutConstants.AttributeBlockHeight, character));

        layout.Controls.Add(new SimpleValueLayout("Lucky Roll", character.LuckyRoll, 223, LayoutConstants.AttributeBlockHeight * 4 + attributesTop));

        // combat
        layout.Controls.Add(new CombatModifiersLayout(350, attributesTop, character));

        // attribute blocks (selection indices 2-7)
        attributes = new AttributeCollectionLayout(5, attributesTop, character, startingSelectionIndex: 2);
        layout.Controls.Add(attributes);

        layout.Controls.Add(new SimpleValueLayout("Languages", string.Join(',', character.Languages), 223, LayoutConstants.AttributeBlockHeight * 5 + attributesTop, 250));

        var logo = Image.LoadFromResource("CharacterSheeet.Core.Assets.dcc-logo.bmp");
        layout.Controls.Add(new Picture(10, 740, logo.Width, logo.Height, logo));

        return layout;
    }
}
