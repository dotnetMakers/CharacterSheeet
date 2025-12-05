using Meadow.Foundation.Graphics;

namespace CharacterSheeet.Dcc;

internal static class LayoutConstants
{
    public const int AttributeBlockHeight = 65;
    public static IFont XXSmallFont { get; } = new Font8x12();
    public static IFont XSmallFont { get; } = new Font8x16();
    public static IFont SmallFont { get; } = new Font12x16();
    public static IFont MediumFont { get; } = new Font12x20();
    public static IFont LargeFont { get; } = new Font16x24();
}
