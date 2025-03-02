using CharacterSheeet.Core;
using CharacterSheeet.Core.Contracts;
using Meadow.Devices;
using Meadow.Peripherals.Displays;
using Meadow.Peripherals.Sensors.Buttons;

namespace CharacterSheeet.F7;

internal class CharacterSheeetF7FeatherHardware : ICharacterSheeetHardware
{
    public RotationType DisplayRotation => RotationType.Default;
    public IButton? RightButton => null;
    public IButton? LeftButton => null;
    public IButton? UpButton => null;
    public IButton? DownButton => null;
    public IPixelDisplay? Display => null;
    public INetworkController NetworkController { get; }

    public CharacterSheeetF7FeatherHardware(F7FeatherBase device)
    {
        NetworkController = new NetworkController(device);
    }
}