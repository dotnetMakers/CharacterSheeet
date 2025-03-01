using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class SimpleValueLayout : AbsoluteLayout
{
    private Label _nameLabel;
    private Label _valueLabel;
    private Box _boundsBox;

    public SimpleValueLayout(string name, string value, int left, int top, int width = 120)
        : base(left, top, width, 60)
    {
        var smallFont = new Font8x12();
        var largeFont = new Font12x16();

        _nameLabel = new Label(0, 0, this.Width, 30)
        {
            BackColor = Color.Black,
            TextColor = Color.White,
            Font = smallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = name
        };
        _valueLabel = new Label(0, 30, this.Width, this.Height - 30)
        {
            TextColor = Color.Black,
            BackColor = Color.Transparent,
            Font = largeFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = value
        };
        _boundsBox = new Box(0, 30, this.Width, this.Height - 30)
        {
            ForeColor = Color.Black,
            IsFilled = false
        };

        this.Controls.Add(_nameLabel, _valueLabel, _boundsBox);
    }

    public string ValueText
    {
        get => _valueLabel.Text;
        set => _valueLabel.Text = value;
    }
}
