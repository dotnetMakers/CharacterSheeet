using CharacterSheeet.Dcc;
using Meadow;
using Meadow.Foundation.Graphics.MicroLayout;
using Meadow.Peripherals.Displays;
using System.Linq;

namespace CharacterSheeet.Core;

public class DisplayController
{
    private readonly DisplayScreen _screen;
    private readonly Sheet _sheet;
    private readonly SelectionController _selectionController;
    private readonly DccHalflingSheet _dccSheet;

    public DisplayController(
        IPixelDisplay? display,
        RotationType displayRotation,
        Character character)
    {
        _screen = new DisplayScreen(display, displayRotation)
        {
            BackgroundColor = Color.White
        };

        _selectionController = new SelectionController();

        //_sheet = new TestSheet();
        _dccSheet = new DccHalflingSheet(character as Halfling);
        _sheet = _dccSheet;
        var page = _sheet.CurrentPage;

        Resolver.Log.Info($"Showing initial page of {_sheet.GetType().Name}...");

        _screen.Controls.Add(page);
        RegisterSelectablesForCurrentPage();
    }

    public void NextPage()
    {
        Resolver.Log.Info("Request next page...");

        var page = _sheet.NextPage();
        if (page != null)
        {
            Resolver.Log.Info("Page is not null.  Changing.");
            _selectionController.Clear();
            _screen.BeginUpdate();
            _screen.Invalidate();
            _screen.Controls.Clear();
            _screen.Controls.Add(page);
            _screen.EndUpdate();
            RegisterSelectablesForCurrentPage();
        }
        else
        {
            Resolver.Log.Info("Page is null.");
        }
    }

    public void PreviousPage()
    {
        Resolver.Log.Info("Request previous page...");

        var page = _sheet.PreviousPage();
        if (page != null)
        {
            _selectionController.Clear();
            _screen.BeginUpdate();
            _screen.Invalidate();
            _screen.Controls.Clear();
            _screen.Controls.Add(page);
            _screen.EndUpdate();
            RegisterSelectablesForCurrentPage();
        }
    }

    private void RegisterSelectablesForCurrentPage()
    {
        // Only register selectables for page 1 (character stats page)
        if (_sheet.CurrentPageIndex == 0 && _dccSheet != null)
        {
            _selectionController.Register(_dccSheet.ArmorClass.ValueLabel);
            _selectionController.Register(_dccSheet.HitPoints.ValueLabel);

            foreach (var attr in _dccSheet.Attributes.Attributes)
            {
                _selectionController.Register(attr.ValueLabel);
            }

            Resolver.Log.Info($"Registered {_selectionController.CurrentSelection} selectable controls");
        }
    }

    public void SelectNext()
    {
        Resolver.Log.Info("Select next");
        _selectionController.SelectNext();
    }

    public void SelectPrevious()
    {
        Resolver.Log.Info("Select previous");
        _selectionController.SelectPrevious();
    }

    public void ToggleActivation()
    {
        _selectionController.ToggleActivation();
    }

    public bool IsActivated => _selectionController.IsActivated;

    public void IncrementSelectedValue()
    {
        var selected = _selectionController.CurrentSelection;
        if (selected == null) return;

        // Find which component owns this label and call its increment method
        if (selected == _dccSheet.HitPoints.ValueLabel)
        {
            _dccSheet.HitPoints.IncrementValue();
        }
        else if (selected == _dccSheet.ArmorClass.ValueLabel)
        {
            _dccSheet.ArmorClass.IncrementValue();
        }
        else
        {
            // Check if it's an attribute
            var attribute = _dccSheet.Attributes.Attributes.FirstOrDefault(a => a.ValueLabel == selected);
            attribute?.IncrementValue();
        }
    }

    public void DecrementSelectedValue()
    {
        var selected = _selectionController.CurrentSelection;
        if (selected == null) return;

        // Find which component owns this label and call its decrement method
        if (selected == _dccSheet.HitPoints.ValueLabel)
        {
            _dccSheet.HitPoints.DecrementValue();
        }
        else if (selected == _dccSheet.ArmorClass.ValueLabel)
        {
            _dccSheet.ArmorClass.DecrementValue();
        }
        else
        {
            // Check if it's an attribute
            var attribute = _dccSheet.Attributes.Attributes.FirstOrDefault(a => a.ValueLabel == selected);
            attribute?.DecrementValue();
        }
    }
}