using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class HalflingAbilitiesLayout : AbsoluteLayout
{
    private Label _titleLabel;
    private Box _boundsBox;

    public HalflingAbilitiesLayout(int left, int top, int width, int height)
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
            Text = "Halfling Abilities"
        };

        _boundsBox = new Box(0, 30, this.Width, this.Height - 30)
        {
            ForeColor = Color.Black,
            IsFilled = false
        };

        Controls.Add(_titleLabel, _boundsBox);
    }
}
