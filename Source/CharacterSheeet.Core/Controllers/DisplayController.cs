using CharacterSheeet.Dcc;
using Meadow.Foundation.Graphics.MicroLayout;
using Meadow.Peripherals.Displays;
using Meadow.Units;

namespace CharacterSheeet.Core;

public class DisplayController
{
    private readonly DisplayScreen _screen;
    private readonly Sheet _sheet;

    public DisplayController(
        IPixelDisplay? display,
        RotationType displayRotation,
        Temperature.UnitType unit)
    {
        _screen = new DisplayScreen(display);

        var character = CharacterGenerator.GenerateHalfling();
        _sheet = new DccHalflingSheet(character);
        var page = _sheet.CurrentPage;

        _screen.Controls.Add(page);
    }

    public void NextPage()
    {
        var page = _sheet.NextPage();
        if (page != null)
        {
            _screen.BeginUpdate();
            _screen.Controls.Clear();
            _screen.Controls.Add(page);
            _screen.EndUpdate();
        }
    }

    public void PreviousPage()
    {
        var page = _sheet.PreviousPage();
        if (page != null)
        {
            _screen.BeginUpdate();
            _screen.Controls.Clear();
            _screen.Controls.Add(page);
            _screen.EndUpdate();
        }
    }
}