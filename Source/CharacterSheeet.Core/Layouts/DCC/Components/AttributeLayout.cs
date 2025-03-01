using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class AttributeLayout : AbsoluteLayout
{
    Label _nameLabel;
    Label _modifierLabel;
    Label _valueLabel;
    Box _valueBox;

    public AttributeLayout(string name, int left, int top)
        : base(left, top, 210, 60)
    {
        var smallFont = new Font12x16();
        var largeFont = new Font16x24();

        _nameLabel = new Label(0, 0, 150, this.Height / 2)
        {
            BackColor = Color.Black,
            TextColor = Color.White,
            Font = smallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Left,
            Text = name
        };
        _modifierLabel = new Label(0, _nameLabel.Bottom, _nameLabel.Width, this.Height - _nameLabel.Height)
        {
            BackColor = Color.White,
            TextColor = Color.Black,
            Font = smallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Left,
            Text = $"modifier: +1"
        };
        _valueBox = new Box(_nameLabel.Right, 0, this.Width - _nameLabel.Width, this.Height)
        {
            ForeColor = Color.Black,
            IsFilled = false
        };
        _valueLabel = new Label(_valueBox.Left + 2, _valueBox.Top + 2, _valueBox.Width - 4, _valueBox.Height - 4)
        {
            BackColor = Color.White,
            TextColor = Color.Black,
            Font = largeFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = $"14"
        };

        this.Controls.Add(_nameLabel, _modifierLabel, _valueBox, _valueLabel);
    }
}
