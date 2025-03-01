using CharacterSheeet.Core.Contracts;
using System;

namespace CharacterSheeet.Core;

public class InputController
{
    public event EventHandler? PreviousPageRequested;
    public event EventHandler? NextPageRequested;

    public InputController(ICharacterSheeetHardware platform)
    {
        if (platform.LeftButton is { } ub)
        {
            ub.PressStarted += (s, e) => PreviousPageRequested?.Invoke(this, EventArgs.Empty);
        }
        if (platform.RightButton is { } db)
        {
            db.PressStarted += (s, e) => NextPageRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
