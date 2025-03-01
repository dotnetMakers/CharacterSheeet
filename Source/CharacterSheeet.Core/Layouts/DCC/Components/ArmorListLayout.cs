using CharacterSheeet.Dcc;
using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class ArmorListLayout : AbsoluteLayout
{
    private Label _titleLabel;
    private Label _armorLabel;
    private Label _checkLabel;
    private Label _fumbleLabel;
    private Box _boundsBox;

    public ArmorListLayout(int left, int top, int width, int height, Character character)
        : base(left, top, width, height)
    {
        var smallFont = new Font8x12();
        var largeFont = new Font12x16();

        _titleLabel = new Label(0, 0, this.Width, 30)
        {
            BackColor = Color.Black,
            TextColor = Color.White,
            Font = largeFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = "Armor"
        };

        _armorLabel = new Label(0, _titleLabel.Bottom, this.Width, 20)
        {
            BackColor = Color.White,
            TextColor = Color.Black,
            Font = smallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = "Padded (+1)"
        };

        _checkLabel = new Label(0, _armorLabel.Bottom, this.Width, 20)
        {
            BackColor = Color.White,
            TextColor = Color.Black,
            Font = smallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = "Check penalty (0)"
        };

        _fumbleLabel = new Label(0, _checkLabel.Bottom, this.Width, 20)
        {
            BackColor = Color.White,
            TextColor = Color.Black,
            Font = smallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = "Fumble die (d4)"
        };

        _boundsBox = new Box(0, 30, this.Width, this.Height - 30)
        {
            ForeColor = Color.Black,
            IsFilled = false
        };

        this.Controls.Add(_titleLabel, _armorLabel, _checkLabel, _fumbleLabel, _boundsBox);
    }
}
