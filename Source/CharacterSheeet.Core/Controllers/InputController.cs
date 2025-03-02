using CharacterSheeet.Core.Contracts;
using System;

namespace CharacterSheeet.Core;

public class InputController
{
    public event EventHandler? PreviousPageRequested;
    public event EventHandler? NextPageRequested;

    public event EventHandler? IncrementRequested;
    public event EventHandler? DecrementRequested;

    public event EventHandler? SelectRequested;

    public InputController(ICharacterSheeetHardware platform)
    {
        if (platform.LeftButton is { } lb)
        {
            lb.PressStarted += (s, e) => PreviousPageRequested?.Invoke(this, EventArgs.Empty);
        }
        if (platform.RightButton is { } rb)
        {
            rb.PressStarted += (s, e) => NextPageRequested?.Invoke(this, EventArgs.Empty);
        }
        if (platform.UpButton is { } ub)
        {
            ub.PressStarted += (s, e) => IncrementRequested?.Invoke(this, EventArgs.Empty);
        }
        if (platform.DownButton is { } db)
        {
            db.PressStarted += (s, e) => DecrementRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
