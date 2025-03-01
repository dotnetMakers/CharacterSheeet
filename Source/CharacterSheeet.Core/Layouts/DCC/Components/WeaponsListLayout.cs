using CharacterSheeet.Dcc;

namespace CharacterSheeet.Core;

internal class WeaponsListLayout : ItemListLayout
{
    public WeaponsListLayout(int left, int top, int width, int height, Character character)
        : base("Weapons", left, top, width, height)
    {
    }
}
