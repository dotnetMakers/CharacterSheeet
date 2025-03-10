using CharacterSheeet.Dcc;
using Meadow;
using Meadow.Foundation.Graphics.MicroLayout;
using Meadow.Peripherals.Displays;

namespace CharacterSheeet.Core;

public class DisplayController
{
    private readonly DisplayScreen _screen;
    private readonly Sheet _sheet;

    public DisplayController(
        IPixelDisplay? display,
        RotationType displayRotation,
        Character character)
    {
        _screen = new DisplayScreen(display)
        {
            BackgroundColor = Color.White
        };

        _sheet = new TestSheet();
        //        _sheet = new DccHalflingSheet(character as Halfling);
        var page = _sheet.CurrentPage;

        Resolver.Log.Info($"Showing initial page of {_sheet.GetType().Name}...");

        _screen.Controls.Add(page);
    }

    public void NextPage()
    {
        Resolver.Log.Info("Request next page...");

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
        Resolver.Log.Info("Request previous page...");

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