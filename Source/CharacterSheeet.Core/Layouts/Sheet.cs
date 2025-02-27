using Meadow.Foundation.Graphics.MicroLayout;
using System.Collections.Generic;

namespace CharacterSheeet.Core;

internal class Sheet
{
    private List<MicroLayout> _layouts = new();

    public int CurrentPageIndex { get; private set; }

    public Sheet(IEnumerable<MicroLayout> layouts)
    {
        _layouts.AddRange(layouts);
    }

    public MicroLayout CurrentPage => _layouts[CurrentPageIndex];

    public MicroLayout? NextPage()
    {
        if (CurrentPageIndex >= _layouts.Count - 1)
        {
            CurrentPageIndex = _layouts.Count - 1;
            return null;
        }
        CurrentPageIndex++;
        return _layouts[CurrentPageIndex];
    }

    public MicroLayout? PreviousPage()
    {
        if (CurrentPageIndex <= 0)
        {
            CurrentPageIndex = 0;
            return null;
        }
        CurrentPageIndex--;
        return _layouts[CurrentPageIndex];
    }
}