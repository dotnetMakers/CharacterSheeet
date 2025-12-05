using Meadow.Foundation.Graphics.MicroLayout;
using System.Collections.Generic;

namespace CharacterSheeet.Core;

internal class Sheet
{
    private readonly List<ILayout> _layouts = new();

    public int CurrentPageIndex { get; private set; }

    public Sheet(IEnumerable<ILayout> layouts)
    {
        _layouts.AddRange(layouts);
    }

    public ILayout CurrentPage => _layouts[CurrentPageIndex];

    public ILayout? NextPage()
    {
        if (CurrentPageIndex >= _layouts.Count - 1)
        {
            CurrentPageIndex = _layouts.Count - 1;
            return null;
        }
        CurrentPageIndex++;
        return _layouts[CurrentPageIndex];
    }

    public ILayout? PreviousPage()
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