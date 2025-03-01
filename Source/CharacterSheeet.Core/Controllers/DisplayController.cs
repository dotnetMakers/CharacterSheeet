using CharacterSheeet.Dcc;
using Meadow.Foundation.Graphics.MicroLayout;
using Meadow.Peripherals.Displays;
using Meadow.Units;

namespace CharacterSheeet.Core;

public class DisplayController
{
    private readonly DisplayScreen? screen;

    public DisplayController(
        IPixelDisplay? display,
        RotationType displayRotation,
        Temperature.UnitType unit)
    {
        screen = new DisplayScreen(display);

        var character = CharacterGenerator.GenerateHalfling();
        var sheet = new DccHalflingSheet(character);
        var page = sheet.CurrentPage;

        screen.Controls.Add(page);
    }
}