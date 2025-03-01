using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class HitPointLayout : AbsoluteLayout
{
    Label _staticLabel;
    Label _maxLabel;
    Label _valueLabel;
    Picture _graphic;

    public HitPointLayout(int left, int top)
        : base(left, top, 120, 150)
    {
        var smallFont = new Font12x16();
        var largeFont = new Font16x24();

        var img = Image.LoadFromResource("CharacterSheeet.Core.Assets.cup.bmp");

        _graphic = new Picture(15, 0, 90, 113, img);

        _staticLabel = new Label(0, 120, this.Width, 15)
        {
            BackColor = Color.White,
            TextColor = Color.Black,
            Font = smallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = "Hit Points"
        };
        _maxLabel = new Label(0, _staticLabel.Bottom, this.Width, 15)
        {
            BackColor = Color.White,
            TextColor = Color.Black,
            Font = smallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = "Max: 12"
        };
        _valueLabel = new Label(0, 50, this.Width, 15)
        {
            BackColor = Color.Transparent,
            TextColor = Color.Black,
            Font = largeFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = "10"
        };

        this.Controls.Add(_graphic, _staticLabel, _maxLabel, _valueLabel);
    }
}
