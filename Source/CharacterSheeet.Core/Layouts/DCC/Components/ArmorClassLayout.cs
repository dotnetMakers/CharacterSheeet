using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Dcc;

internal class ArmorClassLayout : AbsoluteLayout
{
    private Character _character;

    Label _armorLabel;
    Label _classLabel;
    Label _valueLabel;
    Picture _shield;

    public ArmorClassLayout(int left, int top, Character character)
        : base(left, top, 120, 150)
    {
        var smallFont = new Font12x16();
        var largeFont = new Font16x24();

        var img = Image.LoadFromResource("CharacterSheeet.Core.Assets.shield.bmp");

        _shield = new Picture(15, 0, 90, 113, img);

        _armorLabel = new Label(0, 120, this.Width, 15)
        {
            BackColor = Color.White,
            TextColor = Color.Black,
            Font = smallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = "Armor"
        };
        _classLabel = new Label(0, _armorLabel.Bottom, this.Width, 15)
        {
            BackColor = Color.White,
            TextColor = Color.Black,
            Font = smallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = "Class"
        };
        _valueLabel = new Label(0, 50, this.Width, 15)
        {
            BackColor = Color.Transparent,
            TextColor = Color.Black,
            Font = largeFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = character.ArmorClass.ToString()
        };

        this.Controls.Add(_shield, _armorLabel, _classLabel, _valueLabel);

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
}
