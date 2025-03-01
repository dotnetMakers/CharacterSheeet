using CharacterSheeet.Dcc;

namespace CharacterSheeet.Core;

internal class TreasureListLayout : ItemListLayout
{
    public TreasureListLayout(int left, int top, int width, int height, Character character)
        : base("Treasure", left, top, width, height)
    {
    }
}
