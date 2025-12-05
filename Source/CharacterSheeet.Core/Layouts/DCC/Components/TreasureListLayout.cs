using CharacterSheeet.Dcc;
using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class TreasureListLayout : ItemListLayout
{
    private readonly Label[] _itemLabels;

    public TreasureListLayout(int left, int top, int width, int height, Character character)
        : base("Treasure", left, top, width, height)
    {
        _itemLabels = new Label[character.Treasure.Length];

        var y = 30;

        for (var i = 0; i < _itemLabels.Length; i++)
        {
            _itemLabels[i] = new Label(3, y, this.Width, 20)
            {
                TextColor = Color.Black,
                BackgroundColor = Color.Transparent,
                Font = LayoutConstants.XXSmallFont,
                HorizontalAlignment = HorizontalAlignment.Left,
                Text = $"{character.Treasure[i].Quantity} {character.Treasure[i].Name}"
            };

            Controls.Add(_itemLabels[i]);
            y += 20;
        }
    }
}
