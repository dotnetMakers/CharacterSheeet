using CharacterSheeet.Core;
using CharacterSheeet.Core.Contracts;
using Meadow.Devices;
using Meadow.Foundation.Displays;
using Meadow.Peripherals.Displays;
using Meadow.Peripherals.Sensors.Buttons;

namespace CharacterSheeet.F7;

internal class CharacterSheeetF7FeatherHardware : ICharacterSheeetHardware
{
    public RotationType DisplayRotation => RotationType._90Degrees;
    public IButton? RightButton => null;
    public IButton? LeftButton => null;
    public IButton? UpButton => null;
    public IButton? DownButton => null;
    public IPixelDisplay? Display { get; }
    public INetworkController NetworkController { get; }

    public CharacterSheeetF7FeatherHardware(F7FeatherBase device)
    {
        NetworkController = new NetworkController(device);

        Display = new Epd7in5V2(
            device.CreateSpiBus(),
            device.Pins.D00,
            device.Pins.D01,
            device.Pins.D02,
            device.Pins.D04
            );
    }
}