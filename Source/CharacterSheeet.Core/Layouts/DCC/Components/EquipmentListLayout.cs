using CharacterSheeet.Dcc;
using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class EquipmentListLayout : ItemListLayout
{
    private Label[] _itemLabels;

    public EquipmentListLayout(int left, int top, int width, int height, Character character)
        : base("Equipment", left, top, width, height)
    {
        var smallFont = new Font8x12();
        _itemLabels = new Label[character.Equipment.Length];

        var y = 30;

        for (var i = 0; i < _itemLabels.Length; i++)
        {
            _itemLabels[i] = new Label(3, y, this.Width, 20)
            {
                TextColor = Color.Black,
                BackColor = Color.Transparent,
                Font = smallFont,
                HorizontalAlignment = HorizontalAlignment.Left,
                Text = $"{character.Equipment[i].Quantity} {character.Equipment[i].Name}"
            };

            Controls.Add(_itemLabels[i]);
            y += 20;
        }

    }
}
