using CharacterSheeet.Dcc;

namespace CharacterSheeet.Core;

internal class EquipmentListLayout : ItemListLayout
{
    public EquipmentListLayout(int left, int top, int width, int height, Character character)
        : base("Equipment", left, top, width, height)
    {
    }
}
