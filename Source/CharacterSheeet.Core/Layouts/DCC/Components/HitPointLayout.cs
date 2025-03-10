using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Dcc;

internal class HitPointLayout : AbsoluteLayout
{
    Label _staticLabel;
    Label _maxLabel;
    Label _valueLabel;
    Picture _graphic;

    public HitPointLayout(int left, int top, Character character)
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
            Text = $"Max: {character.MaxHitPoints}"
        };
        _valueLabel = new Label(20, 50, this.Width - 40, 25)
        {
            BackColor = Color.White,
            TextColor = Color.Black,
            Font = largeFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = character.CurrentHitPoints.ToString()
        };

        this.Controls.Add(_graphic, _staticLabel, _maxLabel, _valueLabel);

        character.PropertyChanged += (s, e) =>
        {
            switch (e.PropertyName)
            {
                case nameof(Character.MaxHitPoints):
                    _valueLabel.Text = $"Max: {character.MaxHitPoints}";
                    break;
                case nameof(Character.CurrentHitPoints):
                    _valueLabel.Text = character.CurrentHitPoints.ToString();
                    break;
            }
        };
    }
}
