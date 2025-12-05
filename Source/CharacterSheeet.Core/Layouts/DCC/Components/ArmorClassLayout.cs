using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Dcc;

internal class ArmorClassLayout : AbsoluteLayout
{
    private readonly Character _character;

    private readonly Label _armorLabel;
    private readonly Label _classLabel;
    private readonly Label _valueLabel;
    private readonly Picture _shield;

    /// <summary>
    /// Gets the value label for selection management
    /// </summary>
    public Label ValueLabel => _valueLabel;

    public ArmorClassLayout(int left, int top, Character character, int selectionIndex = -1)
        : base(left, top, 120, 150)
    {
        var smallFont = new Font12x16();
        var largeFont = new Font16x24();

        var img = Image.LoadFromResource("CharacterSheeet.Core.Assets.shield.bmp");

        _shield = new Picture(15, 0, 90, 113, img);

        _armorLabel = new Label(0, 120, this.Width, 15)
        {
            BackgroundColor = Color.White,
            TextColor = Color.Black,
            Font = smallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = "Armor"
        };
        _classLabel = new Label(0, _armorLabel.Bottom, this.Width, 15)
        {
            BackgroundColor = Color.White,
            TextColor = Color.Black,
            Font = smallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = "Class"
        };
        _valueLabel = new Label((this.Width - 50) / 2, 50, 50, 28)
        {
            BackgroundColor = Color.White,
            TextColor = Color.Black,
            Font = largeFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = character.ArmorClass.ToString(),
            IsSelectable = selectionIndex >= 0,
            SelectionIndex = selectionIndex
        };

        this.Controls.Add(_shield, _armorLabel, _classLabel, _valueLabel);

        _character = character;

        character.PropertyChanged += (s, e) =>
        {
            switch (e.PropertyName)
            {
                case nameof(Character.ArmorClass):
                    _valueLabel.Text = character.ArmorClass.ToString();
                    break;
            }
        };
    }

    /// <summary>
    /// Increments the armor class value (currently read-only, calculated from stats)
    /// </summary>
    public void IncrementValue()
    {
        // AC is calculated, so this would need to modify underlying stats
        // For now, we'll leave this as read-only
    }

    /// <summary>
    /// Decrements the armor class value (currently read-only, calculated from stats)
    /// </summary>
    public void DecrementValue()
    {
        // AC is calculated, so this would need to modify underlying stats
        // For now, we'll leave this as read-only
    }
}
