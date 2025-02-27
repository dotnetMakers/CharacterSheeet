using System;
using System.Threading.Tasks;
using CharacterSheeet.Core.Contracts;

namespace CharacterSheeet.Core;

public class InputController
{
    public event EventHandler? UnitDownRequested;
    public event EventHandler? UnitUpRequested;

    public InputController(ICharacterSheeetHardware platform)
    {
        if (platform.LeftButton is { } ub)
        {
            ub.PressStarted += (s, e) => UnitDownRequested?.Invoke(this, EventArgs.Empty);
        }
        if (platform.RightButton is { } db)
        {
            db.PressStarted += (s, e) => UnitDownRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
