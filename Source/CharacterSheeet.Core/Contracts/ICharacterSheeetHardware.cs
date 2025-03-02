using Meadow.Peripherals.Displays;
using Meadow.Peripherals.Sensors.Buttons;

namespace CharacterSheeet.Core.Contracts;

public interface ICharacterSheeetHardware
{
    // basic hardware
    IButton? LeftButton { get; }
    IButton? RightButton { get; }
    IButton? UpButton { get; }
    IButton? DownButton { get; }

    // complex hardware
    IPixelDisplay? Display { get; }
    RotationType DisplayRotation { get; }

    // platform-dependent services
    INetworkController NetworkController { get; }
}