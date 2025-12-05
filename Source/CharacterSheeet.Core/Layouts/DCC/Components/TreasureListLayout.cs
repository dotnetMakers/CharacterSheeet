using CharacterSheeet.Dcc;
using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class TreasureListLayout : ItemListLayout
{
    private Label[] _itemLabels;

    public TreasureListLayout(int left, int top, int width, int height, Character character)
        : base("Treasure", left, top, width, height)
    {
        var smallFont = new Font8x12();
        _itemLabels = new Label[character.Treasure.Length];

        var y = 30;

        for (var i = 0; i < _itemLabels.Length; i++)
        {
            _itemLabels[i] = new Label(3, y, this.Width, 20)
            {
                TextColor = Color.Black,
                BackgroundColor =Color.Transparent,
                Font = smallFont,
                HorizontalAlignment = HorizontalAlignment.Left,
                Text = $"{character.Treasure[i].Quantity} {character.Treasure[i].Name}"
            };

            Controls.Add(_itemLabels[i]);
            y += 20;
        }
    }
}
